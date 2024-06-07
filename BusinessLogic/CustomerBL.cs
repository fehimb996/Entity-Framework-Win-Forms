using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private readonly CustomerDL _customerDL;

        public CustomerBL()
        {
            _customerDL = new CustomerDL();
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _customerDL.GetCustomers();
        }

        public CustomerDTO GetCustomer(string customerId)
        {
            return _customerDL.GetCustomer(customerId);
        }

        public List<CustomerDTO> SearchCustomers(string searchTerm)
        {
            return _customerDL.SearchCustomers(searchTerm);
        }
    }
}
