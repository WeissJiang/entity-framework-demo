using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Domains
{
    public abstract class CreationDateRecord
    {
        [Column(TypeName = "datetime")] public DateTime CreationDateUTC { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime")] public DateTime LastModifiedDateUTC { get; set; } = DateTime.UtcNow;
    }
}
