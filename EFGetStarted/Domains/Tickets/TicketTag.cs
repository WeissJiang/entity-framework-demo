using System.Text.Json.Serialization;

namespace EFGetStarted.Domains.Tickets
{
    public class TicketTag : CreationDateRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#000000";
        [JsonIgnore] public virtual List<Ticket> Tickets { get; }
    }
}
