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

        public void Delete(int orderID)
        {
            _orderDetailsDL.Delete(orderID);
        }
    }
}
