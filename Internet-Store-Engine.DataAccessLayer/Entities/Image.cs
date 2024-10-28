namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Image : Base
    {
        public string? Name { get; set; }
        public string? Picture { get; set; }

        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}