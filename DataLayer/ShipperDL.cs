using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ShipperDL
    {
        private readonly DatabaseContext _context;

        public ShipperDL()
        {
            _context = new DatabaseContext();
        }

        public List<ShipperDTO> GetShippers()
        {
            {
                var shippers = _context.GetContext().Shippers.ToList();
                return Mapper.convertToList(shippers);
            }
        }
    }
}
