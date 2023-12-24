using Innoplatform.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Innoplatform.Service.DTOs.Transactions;

public class TransactionForCreationDto
{
    [Required]
    public long FromUserId { get; set; }
    [Required]
    public long ToUserId { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
}
