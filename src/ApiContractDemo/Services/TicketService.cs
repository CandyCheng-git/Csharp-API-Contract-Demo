using ApiContractDemo.Dtos;
using ApiContractDemo.Models;

namespace ApiContractDemo.Services;

public class TicketService
{
    private readonly List<Ticket> _tickets = new();

    public IReadOnlyList<Ticket> GetAll() => _tickets;

    public Ticket? GetById(Guid id) => _tickets.FirstOrDefault(t => t.Id == id);

    public Ticket Create(CreateTicketRequest request)
    {
        var ticket = new Ticket
        {
            Title = request.Title,
            Description = request.Description,
            RequesterEmail = request.RequesterEmail,
            Priority = request.Priority,
            Status = "open",
            CreatedAt = DateTime.UtcNow
        };

        _tickets.Add(ticket);
        return ticket;
    }

    public Ticket? UpdateStatus(Guid id, string status)
    {
        var ticket = _tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return null;
        }

        ticket.Status = status;
        return ticket;
    }
}
