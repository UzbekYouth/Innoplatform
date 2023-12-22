
namespace Innoplatform.Service.DTOs.Messages;

public class MessgingForUpdateDto
{
    public long SenderId { get; set; }
    public long RecipientId { get; set; }
    public string Message { get; set; }
}
