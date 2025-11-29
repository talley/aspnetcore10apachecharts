using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore10WithApacheECharts.Repositories
{
    public static class Commons
    {
        public static async  Task<List<OrderData>> GetOrderDatasAsync(int top=10)
        {
            IEnumerable<OrderData> orderDatas=new List<OrderData>();
            var proc="proc_get_top_countries_sales";
            using(IDbConnection conn=new SqlConnection(DB.CS))
            {
                var param=new DynamicParameters();
                param.Add("@top",top,DbType.Int32,ParameterDirection.Input);
                orderDatas=await conn.QueryAsync<OrderData>(proc,param,commandType:CommandType.StoredProcedure);
            }

            return orderDatas.ToList();
        }
    }

   public struct OrderData
    {
        public string Country { get; set; }
        public decimal Amount { get; set; }
    }
}