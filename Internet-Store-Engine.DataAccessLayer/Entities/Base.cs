namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? User { get; set; }
    }
}