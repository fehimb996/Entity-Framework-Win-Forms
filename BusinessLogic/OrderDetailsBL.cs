using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderDetailsBL
    {
        private readonly OrderDetailsDL _orderDetailsDL;

        public OrderDetailsBL()
        {
            _orderDetailsDL = new OrderDetailsDL();
        }

        public void Insert(OrderDetailsDTO odDTO)
        {
            _orderDetailsDL.Insert(odDTO);
        }

        public void Save(OrderDetailsDTO orderDetailsDTO)
        {
            _orderDetailsDL.Save(orderDetailsDTO);
        }

        public void UpdateProduct(int orderID, int oldProductID, int newProductID)
        {
            _orderDetailsDL.UpdateProduct(orderID, oldProductID, newProductID);
        }

        public void Delete(int orderID)
        {
            _orderDetailsDL.Delete(orderID);
        }

        public OrderDetailsDTO GetOrderDetail(int empId)
        {
            return _orderDetailsDL.GetSingleOrderDetail(empId);
        }

        public List<OrderDetailsDTO> GetAllByOrder(int OrderId)
        {
            return _orderDetailsDL.GetAllByOrder(OrderId);
        }
    }
}
