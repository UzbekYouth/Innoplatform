using Innoplatform.Domain.Entities;
using System.Transactions;

namespace Innoplatform.Service.DTOs.Transactions;

public class TransactionForCreationDto
{
    public long FromUserId { get; set; }
    public long ToUserId { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
}
