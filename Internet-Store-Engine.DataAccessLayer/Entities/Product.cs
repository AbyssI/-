using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public sealed class Product : Base
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.Categories = new HashSet<Category>();
        }

        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }

        public int? ImageId { get; set; }
        public ICollection<Image> Images { get; set; }

        public int? CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}