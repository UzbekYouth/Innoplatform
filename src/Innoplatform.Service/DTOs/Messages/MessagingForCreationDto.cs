using Innoplatform.Domain.Entities;

namespace Innoplatform.Service.DTOs.Messages;

public class MessagingForCreationDto
{
    public long SenderId { get; set; }
    public long RecipientId { get; set; }
    public string Message { get; set; }
}
