using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ShipperBL
    {
        private readonly ShipperDL _shipperDL;

        public ShipperBL()
        {
            _shipperDL = new ShipperDL();
        }

        public List<ShipperDTO> GetShippers()
        {
            return _shipperDL.GetShippers();
        }

        public ShipperDTO GetShipper(int shipperId)
        {
            return _shipperDL.GetShipper(shipperId);
        }
    }
}
