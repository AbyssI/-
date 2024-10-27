namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Image : Base
    {
        public int ImageId { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }

        public virtual Product? Products { get; set; }
    }
}