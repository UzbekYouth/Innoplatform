using System.Transactions;

namespace Innoplatform.Service.DTOs.Transactions;

public class TransactionForResultDto
{
    public long Id { get; set; }
    public long FromUserId { get; set; }
    public long ToUserId { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
