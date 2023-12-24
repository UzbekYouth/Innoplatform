using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Transactions;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Transactions;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.ITransactionServices;
using Microsoft.EntityFrameworkCore;
namespace Innoplatform.Service.Services.TransactionServices;

public class TransactionService : ITransactionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Transaction> _transactionRepository;

    public TransactionService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Transaction> transactionRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
    }
    public async Task<TransactionForResultDto> AddAsync(TransactionForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.FromUserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User is not found");

        var mapped = _mapper.Map<Transaction>(dto);

        var result = await _transactionRepository.CreateAsync(mapped);

        return _mapper.Map<TransactionForResultDto>(result);
    }

    public async Task<IEnumerable<TransactionForResultDto>> GetAllAsync()
    {
        var transactions = await _transactionRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .Include(r => r.FromUser)
            .Include(r => r.ToUser)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<TransactionForResultDto>>(transactions);
    }

    public async Task<TransactionForResultDto> GetByIdAsync(long id)
    {
        var transaction = await _transactionRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .Include(r => r.FromUser)
            .Include(r => r.ToUser)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (transaction is null)
            throw new InnoplatformException(404, "Transaction is not found");

        return _mapper.Map<TransactionForResultDto>(transaction);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var transaction = await _transactionRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .FirstOrDefaultAsync();

        if (transaction is null)
            throw new InnoplatformException(404, "Transaction is not found");

        return await _transactionRepository.DeleteAsync(id);
    }
}
