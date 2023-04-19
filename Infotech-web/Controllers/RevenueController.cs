using Infotech_web.Models;
using Infotech_web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infotech_web.Controllers
{
    [ApiController]
    [Route("revenue")]
    public class RevenueController : ControllerBase
    {
     
        private readonly ILogger<RevenueController> _logger;
        private readonly EntityDbContext _dbContext;

        public RevenueController(ILogger<RevenueController> logger, EntityDbContextFactory dbContextFactory)
        {
            _logger = logger;
        
            _dbContext = dbContextFactory.CreateDbContext();
        }

        [HttpGet]
        public IEnumerable<MonthlyRevenue> Index()
        {
            var year = 2022;
            try
            {
                return _dbContext.MonthlyRevenues.Where(r => r.MonthYear.Year == year)
                            .GroupBy(r => new { r.Country, YearMonth = new DateTime(r.MonthYear.Year, r.MonthYear.Month, 1) })
                            .Select(g => new MonthlyRevenue
                            {
                                Country = g.Key.Country,
                                MonthYear = g.Key.YearMonth,
                                Revenue = g.Sum(r => r.Revenue)
                            })
                            .ToList();
            }
            catch
            {
                throw;
            }
            
        }
        [HttpGet("detail/{country}")]
        public IEnumerable<MonthlyRevenue> Detail(string country)
        {
            try
            {
                return _dbContext.MonthlyRevenues.Where(x => x.Country == country).ToList();
            }
            catch
            {
                throw;
            }

        }
    }
}
