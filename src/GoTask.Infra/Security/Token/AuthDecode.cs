using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;
using GoTask.Domain.Security.Token;
using GoTask.Infra.DataAcess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.Security.Token;

internal class AuthDecode : IAuthDecode
{
    
    private readonly GoTaskDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string SiD = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid";

    public AuthDecode(GoTaskDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User?> DecodeTokenToUser()
    {
        var userId = _httpContextAccessor
            .HttpContext?
            .User?
            .FindFirst(SiD)?
            .Value;

        if (userId is null)
            throw new Exception("Erro");
        
        var user = await _dbContext
            .User
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserIdentify == Guid.Parse(userId));

        return user;
    }
}