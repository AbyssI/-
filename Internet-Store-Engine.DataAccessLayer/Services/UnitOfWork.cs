using System;
using System.Collections;
using System.Threading.Tasks;
using InternetStoreEngine.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NLog;

namespace InternetStoreEngine.DataAccessLayer.Services
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger _logger;

        private readonly StoreDbContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(ILogger logger)
        {
            _logger = logger;
            _context = new StoreDbContext();
            _logger.Info("Створено UnitOfWork.");

            _repositories = new Hashtable();
        }

        public IRepository<T>? Repository<T>() where T : class
        {
            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type)) return (IRepository<T>)_repositories[type]!;
            var repositoryInstance = new Repository<T>(_context, _logger);
            _repositories.Add(type, repositoryInstance);
            _logger.Info($"Створено репозиторій для типу {type}.");

            return (IRepository<T>)_repositories[type]!;
        }

        public async Task<int> CompleteAsync()
        {
            var result = 0;
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _logger.Info("Транзакція почата.");

                result = await _context.SaveChangesAsync();
                _logger.Info("Зміни збережено в базі даних.");

                await transaction.CommitAsync();
                _logger.Info("Транзакцію підтверджено.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger?.Error(ex, "Помилка при збереженні змін. Транзакцію відкотжено.");
                throw;
            }
            finally
            {
                await transaction.DisposeAsync();
            }

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _logger.Info("UnitOfWork утилізовано.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}