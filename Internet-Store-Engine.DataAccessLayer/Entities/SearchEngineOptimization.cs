using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreEngine.DataAccessLayer.Entities
{
    [Table("SearchEngineOptimization", Schema = "dbo")]
    public class SearchEngineOptimization : Base
    {
        [ForeignKey("TagId")]
        [Column("TagId")]
        public required IEnumerable<Tag> TagId { get; set; }

        [Column("TagContent")]
        public required string TagContent { get; set; }

        [Column("TagProperty")]
        public required string TagProperty { get; set; }
    }

    public class Tag : Base
    {
        [Column("TagId")]
        public required string TagName { get; set; }
    }
}