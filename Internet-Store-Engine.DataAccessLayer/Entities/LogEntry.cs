namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class LogEntry : Base
    {
        public string? Message { get; set; }
        public string? Level { get; set; }
        public string? Logger { get; set; }
        public string? Callsite { get; set; }
        public DateTime? LogTime { get; set; }
    }
}