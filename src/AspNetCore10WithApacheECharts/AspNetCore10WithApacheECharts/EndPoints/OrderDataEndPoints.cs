using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore10WithApacheECharts.Repositories.EndPoints
{
    public static class OrderDataEndPoints
    {
        public static void MapOrderDataEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("/api")
                         .WithTags("OrderData");

            group.MapGet("/orderdatas/{top}", async (int top) =>
            {
                var orderDatas = await Commons.GetOrderDatasAsync(top);
                return Results.Ok(orderDatas);
            })
            .WithTags("OrderData")
            .WithSummary("Get Top 10 Order Sales by Country")
            .WithDescription("Retrieves the top 10 order sales data entries grouped by country.");
        }
    }
}