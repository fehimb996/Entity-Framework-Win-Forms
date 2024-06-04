using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderBL
    {
        private readonly OrderDL _orderDL;

        public OrderBL()
        {
            _orderDL = new OrderDL();
        }

        public OrderDTO GetOrder(int ordId)
        {
            return _orderDL.GetSingle(ordId);
        }

        public List<OrderDTO> GetAllOrders()
        {
            return _orderDL.GetAll();
        }

        public int Insert(OrderDTO oDTO)
        {
            return _orderDL.Insert(oDTO);
        }

        public void Save(OrderDTO oDTO)
        {
            _orderDL.Save(oDTO);
        }

        public void Delete(int orderID)
        {
            _orderDL.Delete(orderID);
        }
    }
}
