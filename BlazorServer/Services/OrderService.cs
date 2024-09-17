using BlazorServer.Models.DBContext;
using BlazorServer.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services
{
    public class OrderService
    {
        /// <summary>
        /// DB
        /// </summary>
        private readonly DemoDBContext _demoDBContext;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="demoDBContext"></param>
        public OrderService(DemoDBContext demoDBContext)
        {
            _demoDBContext = demoDBContext;
        }


        /// <summary>
        /// |新增訂單
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<OrderInfo>> GetOrderListAsync()
        {
            List<OrderInfo> data = new();
            var query = await _demoDBContext.OrderInfos
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            if(query != null)
            {
                data = query;
            }
            return await Task.Run(() => data);
        }

        /// <summary>
        /// 新增訂單 (List razor page 呼叫)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddOrderAsync(OrderInfo entity)
        {
            bool success = false;
            int count = await _demoDBContext.OrderInfos.CountAsync();
            entity.OrderId = count + 1;
            await _demoDBContext.OrderInfos.AddAsync(entity);
            await _demoDBContext.SaveChangesAsync();
            success = true;
            return await Task.Run(() => success);
        }

        /// <summary>
        /// 新增訂單 (List razor page 呼叫)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            bool success = false;
            try
            {
                OrderInfo entity = new() { OrderId = orderId };
                _demoDBContext.OrderInfos.Remove(entity);
                await _demoDBContext.SaveChangesAsync();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            return await Task.Run(() => success);
        }


    }
}
