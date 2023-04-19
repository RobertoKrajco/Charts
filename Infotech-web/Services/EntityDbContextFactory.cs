using Infotech_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Infotech_web.Services
{
    public class EntityDbContextFactory :IDbContextFactory
    {
        private readonly DbContextOptions<EntityDbContext> _options;
        private readonly IConfiguration _configuration;
        public EntityDbContextFactory( IConfiguration configuration)
        {
          
            _configuration = configuration;
        }

        public EntityDbContext CreateDbContext()
        {
            return new EntityDbContext(_configuration);
        }
    }
}
