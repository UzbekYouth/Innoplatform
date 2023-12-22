using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class Messaging : Auditable
{
    public long SenderId { get; set; }
    public User Sender { get; set; }

    public long RecipientId { get; set; }
    public User Recipient { get; set; }

    public string Message { get; set; }
}
