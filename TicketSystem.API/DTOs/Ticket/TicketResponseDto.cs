namespace TicketSystem.API.DTOs.Ticket;

public class TicketResponseDto
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Status  { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
