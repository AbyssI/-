namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Category : Base
    {
        public string? Name { get; set; }

        public int? ParidId { get; set; }
        public virtual Category? Parid { get; set; }

        public int? PrevidId { get; set; }
        public virtual Category? Previd { get; set; }
    }
}