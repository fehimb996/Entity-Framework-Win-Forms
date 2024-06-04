using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDetailsDL
    {
        private readonly DatabaseContext _context;

        public OrderDetailsDL()
        {
            _context = new DatabaseContext();
        }

        public void Insert(OrderDetailsDTO odDTO)
        {
            {
                var od = Mapper.MapToEntity(odDTO);
                _context.GetContext().Order_Details.Add(od);
                _context.GetContext().SaveChanges();
            }
        }

        public void Delete(int orderID)
        {
            {
                var orderDetails = _context.GetContext().Order_Details
                                           .Where(od => od.OrderID == orderID)
                                           .ToList();

                _context.GetContext().Order_Details.RemoveRange(orderDetails);
                _context.GetContext().SaveChanges();
            }
        }
    }
}
