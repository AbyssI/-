using InternetStoreEngine.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Linq.Expressions;


namespace InternetStoreEngine.DataAccessLayer.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ILogger _logger;
        protected readonly DbContext Context;
        private readonly DbSet<T> _entities;

        public Repository(DbContext context, ILogger logger)
        {
            _logger = logger;
            Context = context;
            _entities = context.Set<T>();
            _logger.Info($"Створено репозиторій для сутності {typeof(T).Name}.");
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _entities.FindAsync(id);
                _logger.Info($"Отримано сутність {typeof(T).Name} з ID = {id}.");
                return entity;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при отриманні сутності {typeof(T).Name} з ID = {id}.");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var entities = await _entities.ToListAsync();
                _logger.Info($"Отримано всі сутності типу {typeof(T).Name}.");
                return entities;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при отриманні всіх сутностей типу {typeof(T).Name}.");
                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entities = await _entities.Where(predicate).ToListAsync();
                _logger.Info($"Виконано пошук сутностей типу {typeof(T).Name} за предикатом.");
                return entities;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при пошуку сутностей типу {typeof(T).Name}.");
                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                _logger.Info($"Додано нову сутність типу {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при додаванні сутності типу {typeof(T).Name}.");
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _entities.Update(entity);
                _logger.Info($"Оновлено сутність типу {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при оновленні сутності типу {typeof(T).Name}.");
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _entities.Remove(entity);
                _logger.Info($"Видалено сутність типу {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Помилка при видаленні сутності типу {typeof(T).Name}.");
                throw;
            }
        }
    }
}