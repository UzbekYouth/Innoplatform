using Innoplatform.Domain.Commons;
using System.Transactions;

namespace Innoplatform.Domain.Entities;

public class Transaction : Auditable
{
    public long FromUserId { get; set; }
    public User FromUser { get; set; }

    public long ToUserId { get; set; }
    public User ToUser { get; set; }

    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
}
