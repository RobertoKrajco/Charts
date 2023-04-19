namespace Infotech_web.Services
{
    using Infotech_web.Models;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Threading;

    public class DataPointGenerator
    {
        private Timer _timer;
        private List<MonthlyRevenue> _revenues;
        private RealtimeChartHub _hub;
        private readonly IHubContext<RealtimeChartHub> _hubContext;
        private readonly IConfiguration _configuration;

        public DataPointGenerator(IHubContext<RealtimeChartHub> hubContext,IConfiguration configuration)
        {
            _hubContext = hubContext;
            _configuration = configuration;

            _timer = new Timer(state =>
            {
                var dbContext = new EntityDbContext(_configuration);

                if (this._revenues == null || dbContext.MonthlyRevenues.ToList()!=this._revenues)
                {
                    this._revenues = 
                    dbContext.MonthlyRevenues.Where(r => r.MonthYear.Year == 2022)
                        .GroupBy(r => new { r.Country, YearMonth = new DateTime(r.MonthYear.Year, r.MonthYear.Month, 1) })
                        .Select(g => new MonthlyRevenue
                        {
                            Country = g.Key.Country,
                            MonthYear = g.Key.YearMonth,
                            Revenue = g.Sum(r => r.Revenue)
                        })
                        .ToList();
                    _hubContext.Clients.All.SendAsync("SendDataPoint", _revenues);
                }

            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }
    }

}
