namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Category : Base
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual Category ParidId { get; set; }
        public virtual Category PrevidId { get; set; }
    }
}
