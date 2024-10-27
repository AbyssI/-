namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class CartLine : Base
    {
        public required Product Product { get; set; }

        public required int Quantity { get; set; }
    }
}