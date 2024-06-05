using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDL
    {
        private readonly DatabaseContext _context;

        public OrderDL()
        {
            _context = new DatabaseContext();
        }

        public OrderDTO GetSingle(int orderId)
        {
            OrderDTO order;
            var orderDB = _context.GetContext().Orders.SingleOrDefault(od => od.OrderID == orderId);

            order = Mapper.MapToDTO(orderDB);

            return order;
        }

        public List<OrderDTO> GetAll()
        {
            var orders = _context.GetContext().Orders.ToList();

            return Mapper.convertToList(orders);
        }

        public List<OrderDTO> SearchOrders(int? employeeID, string customerID, int? productID)
        {
            var results = _context.GetContext().spSearchOrders(employeeID, customerID, productID).ToList();
            return Mapper.convertToList(results);
        }

        public int Insert(OrderDTO oDTO)
        {
            using (var context = new NorthwindEntities())
            {
                var order = Mapper.MapToEntity(oDTO);
                context.Orders.Add(order);
                context.SaveChanges();
                return order.OrderID;
            }
        }

        public void Save(OrderDTO oDTO)
        {
            var order = _context.GetContext().Orders.Find(oDTO.OrderID);
            if (order != null)
            {

                order.OrderID = oDTO.OrderID;
                order.CustomerID = oDTO.CustomerID;
                order.ShipAddress = oDTO.ShipAddress;
                order.ShipCity = oDTO.ShipCity;
                order.ShipRegion = oDTO.ShipRegion;
                order.ShipPostalCode = oDTO.ShipPostalCode;
                order.ShipCountry = oDTO.ShipCountry;
                order.ShipName = oDTO.ShipName;
                order.EmployeeID = oDTO.EmployeeID;
                order.OrderDate = oDTO.OrderDate;

                _context.GetContext().SaveChanges();
            }
        }

        public void Delete(int orderID)
        {
            using (var context = new NorthwindEntities())
            {
                var order = context.Orders
                                    .Include("Order_Details")
                                    .FirstOrDefault(o => o.OrderID == orderID);
                if (order != null)
                {
                    context.Order_Details.RemoveRange(order.Order_Details);
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }
    }
}
