namespace Infotech_web.Services
{
    using Infotech_web.Models;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class RealtimeChartHub : Hub
    {
        [HubMethodName("SendDataPoint")]
        public async Task SendDataPoint(List<MonthlyRevenue> _revenues)
        {
           
            
            await Clients.All.SendAsync("SendDataPoint", _revenues);
        }
    }

}
