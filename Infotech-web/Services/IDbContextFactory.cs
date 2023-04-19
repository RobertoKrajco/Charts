using Infotech_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Infotech_web.Services
{
    public interface IDbContextFactory
    {
        EntityDbContext CreateDbContext();
        
    }
}
