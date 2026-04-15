using ApiContractDemo.Dtos;
using ApiContractDemo.Models;
using ApiContractDemo.Services;
using ApiContractDemo.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ApiContractDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly TicketService _ticketService;

    public TicketsController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    /// <summary>
    /// Get all tickets.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TicketResponse>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<TicketResponse>> GetAll()
    {
        var result = _ticketService.GetAll()
            .Select(MapToResponse)
            .ToList();

        return Ok(result);
    }

    /// <summary>
    /// Get a single ticket by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TicketResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TicketResponse> GetById(Guid id)
    {
        var ticket = _ticketService.GetById(id);

        if (ticket == null)
        {
            return NotFound(new
            {
                error = "ticket_not_found",
                message = $"Ticket with id '{id}' was not found."
            });
        }

        return Ok(MapToResponse(ticket));
    }

    /// <summary>
    /// Create a new ticket.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(TicketResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TicketResponse> Create([FromBody] CreateTicketRequest request)
    {
        var ticket = _ticketService.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, MapToResponse(ticket));
    }

    /// <summary>
    /// Update ticket status.
    /// </summary>
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(typeof(TicketResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TicketResponse> UpdateStatus(Guid id, [FromBody] UpdateTicketStatusRequest request)
    {
        var ticket = _ticketService.UpdateStatus(id, request.Status);

        if (ticket == null)
        {
            return NotFound(new
            {
                error = "ticket_not_found",
                message = $"Ticket with id '{id}' was not found."
            });
        }

        return Ok(MapToResponse(ticket));
    }

    /// <summary>
    /// Validate draft ticket content before submission.
    /// Day 1 version returns a skeleton response for future rule-based and AI-style validation layers.
    /// </summary>
    [HttpPost("validate")]
    [ProducesResponseType(typeof(TicketValidationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TicketValidationResponse> ValidateDraft([FromBody] ValidateTicketRequest request)
    {
        var response = new TicketValidationResponse
        {
            IsValid = true,
            RuleValidationPassed = true,
            AiQualityPassed = true,
            Issues = new List<ValidationIssue>(),
            Suggestions = new List<string>()
        };

        return Ok(response);
    }

    private static TicketResponse MapToResponse(Ticket ticket)
    {
        return new TicketResponse
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            RequesterEmail = ticket.RequesterEmail,
            Priority = ticket.Priority,
            Status = ticket.Status,
            CreatedAt = ticket.CreatedAt
        };
    }
}
