using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public class CustomerDL
    {
        private readonly DatabaseContext _context;

        public CustomerDL()
        {
            _context = new DatabaseContext();
        }

        public List<CustomerDTO> GetCustomers()
        {
            {
                var customerEntities = _context.GetContext().Customers.ToList();
                var customerDTOs = Mapper.convertToList(customerEntities);
                return customerDTOs;
            }
        }

        public List<CustomerDTO> SearchCustomers(string searchTerm)
        {
            {
                var customerEntities = _context.GetContext().Customers.ToList();
                var customerDTOs = Mapper.convertToList(customerEntities);

                if (string.IsNullOrEmpty(searchTerm))
                {
                    return customerDTOs;
                }

                searchTerm = searchTerm.ToLower();
                return customerDTOs.Where(c =>
                    (c.CustomerID != null && c.CustomerID.ToLower().Contains(searchTerm)) ||
                    (c.CompanyName != null && c.CompanyName.ToLower().Contains(searchTerm)) ||
                    (c.ContactName != null && c.ContactName.ToLower().Contains(searchTerm)) ||
                    (c.ContactTitle != null && c.ContactTitle.ToLower().Contains(searchTerm)) ||
                    (c.Address != null && c.Address.ToLower().Contains(searchTerm)) ||
                    (c.City != null && c.City.ToLower().Contains(searchTerm)) ||
                    (c.Region != null && c.Region.ToLower().Contains(searchTerm)) ||
                    (c.PostalCode != null && c.PostalCode.ToLower().Contains(searchTerm)) ||
                    (c.Country != null && c.Country.ToLower().Contains(searchTerm)) ||
                    (c.Phone != null && c.Phone.ToLower().Contains(searchTerm)) ||
                    (c.Fax != null && c.Fax.ToLower().Contains(searchTerm))
                ).ToList();
            }
        }
    }
}
