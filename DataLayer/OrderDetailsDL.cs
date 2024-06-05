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

        public void Save(OrderDetailsDTO oDTO)
        {
            var order = _context.GetContext().Order_Details.Find(oDTO.OrderID, oDTO.ProductID);
            if (order != null)
            {

                order.OrderID = oDTO.OrderID;
                order.ProductID = oDTO.ProductID;
                order.UnitPrice = oDTO.UnitPrice;
                order.Quantity = oDTO.Quantity;
                order.Discount = oDTO.Discount;

                _context.GetContext().SaveChanges();
            }
        }

        public void UpdateProduct(int orderID, int oldProductID, int newProductID)
        {
            var orderDetail = _context.GetContext().Order_Details.Find(orderID, oldProductID);
            if (orderDetail != null)
            {
                // First, remove the existing order detail with the old product ID
                _context.GetContext().Order_Details.Remove(orderDetail);
                _context.GetContext().SaveChanges();

                // Then, create a new order detail with the new product ID
                orderDetail.ProductID = newProductID;
                _context.GetContext().Order_Details.Add(orderDetail);
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

        public OrderDetailsDTO GetSingleOrderDetail(int OrderId)
        {
            var orderDetails = _context.GetContext().Order_Details.Where(od => od.OrderID == OrderId).ToList();

            return Mapper.MapToDTO(orderDetails[0]);

        }

        public List<OrderDetailsDTO> GetAllByOrder(int OrderId)
        {
            var details = _context.GetContext().Order_Details.Where(od => od.OrderID == OrderId).ToList();

            return Mapper.convertToList(details);
        }
    }
}
