using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderHeaderRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        

        public void Update(OrderHeader orderHeaderObj)
        {
           _dbContext.OrderHeaders.Update(orderHeaderObj);
        }

        public void UpdateStatus(int orderId, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _dbContext.OrderHeaders.FirstOrDefault(u=>u.Id == orderId);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int orderId, string sessionId, string paymentIntendId)
        {
            var orderFromDb = _dbContext.OrderHeaders.FirstOrDefault(u => u.Id == orderId);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntendId))
            {
                orderFromDb.PaymentIntentId = paymentIntendId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
