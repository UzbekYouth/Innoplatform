namespace Innoplatform.Service.DTOs.Messages;

public class MessagingForResultDto
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long RecipientId { get; set; }
    public string Message { get; set; }
}
