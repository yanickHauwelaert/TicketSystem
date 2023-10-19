namespace TicketSystem.Core.Entities;

public class Ticket: BaseEntity
{
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Status  { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}