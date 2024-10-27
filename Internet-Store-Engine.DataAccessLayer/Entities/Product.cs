using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public sealed class Product : Base
    {
        public Product()
        {
            Images = new HashSet<Image>();
            Categories = new HashSet<Category>();
            Manufacturer = null;
        }

        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }

        public int? ImageId { get; set; }
        public ICollection<Image> Images { get; set; }

        public int? CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }

        public int? ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }
    }
}