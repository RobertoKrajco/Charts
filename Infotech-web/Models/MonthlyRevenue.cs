using System;
using System.Collections.Generic;

namespace Infotech_web.Models;

public partial class MonthlyRevenue
{
    public int RevenueId { get; set; }

    public string Country { get; set; } = null!;

    public DateTime MonthYear { get; set; }

    public decimal Revenue { get; set; }
}
