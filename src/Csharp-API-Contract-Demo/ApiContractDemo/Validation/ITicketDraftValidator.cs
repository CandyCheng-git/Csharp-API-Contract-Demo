using ApiContractDemo.Dtos;

namespace ApiContractDemo.Validation;

public interface ITicketDraftValidator
{
    TicketValidationResponse Validate(ValidateTicketRequest request);
}
