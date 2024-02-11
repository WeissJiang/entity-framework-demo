using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Domains.Tickets
{
    public class TicketHour : CreationDateRecord
    {
        public int Id { get; set; }
        public int Time { get; set; } = 0;
        public string Log { get; set; } = string.Empty;
        [Column(TypeName = "datetime")] public DateTime WorkingDateUTC { get; set; } = DateTime.UtcNow;
        [Required] public int TicketId { get; set; }
        [ForeignKey("TicketId")] public virtual Ticket Ticket { get; set; }
    }
}
