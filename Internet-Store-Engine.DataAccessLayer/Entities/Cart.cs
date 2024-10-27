using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Cart : Base
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines => _lineCollection;

        public void AddItem(Product product, int quantity)
        {
            var line = _lineCollection
                .FirstOrDefault(b => b.Product.Id == product.Id);

            if (line == null) _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else line.Quantity += quantity;
        }

        public void RemoveLine(Product book) => _lineCollection.RemoveAll(del => del.Product.Id == book.Id);

        public decimal ComputeTotalValue() => _lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => _lineCollection.Clear();
    }
}