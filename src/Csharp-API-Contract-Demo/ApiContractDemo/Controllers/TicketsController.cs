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
    private readonly ITicketDraftValidator _ticketDraftValidator;

    public TicketsController(TicketService ticketService, ITicketDraftValidator ticketDraftValidator)
    {
        _ticketService = ticketService;
        _ticketDraftValidator = ticketDraftValidator;
    }

    /// <summary>
    /// Get all tickets.
    /// </summary>
    /// <returns>A list of all support tickets currently stored in the demo service.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TicketResponse>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<TicketResponse>> GetAll()
    {
        var result = _ticketService.GetAll().Select(MapToResponse).ToList();
        return Ok(result);
    }

    /// <summary>
    /// Get a single ticket by id.
    /// </summary>
    /// <param name="id">The ticket identifier.</param>
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
    /// Create a new support ticket.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/tickets
    ///     {
    ///         "title": "Unable to login to employee portal",
    ///         "description": "After resetting my password this morning, I still cannot log in to the employee portal. The page keeps showing an invalid credentials message.",
    ///         "requesterEmail": "user@example.com",
    ///         "priority": "high"
    ///     }
    ///
    /// </remarks>
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
    /// </summary>
    /// <remarks>
    /// This endpoint simulates a two-layer validation flow:
    /// 1. standard request validation
    /// 2. AI-style quality validation for support content clarity
    /// </remarks>
    [HttpPost("validate")]
    [ProducesResponseType(typeof(TicketValidationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TicketValidationResponse> ValidateDraft([FromBody] ValidateTicketRequest request)
    {
        var response = _ticketDraftValidator.Validate(request);
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
