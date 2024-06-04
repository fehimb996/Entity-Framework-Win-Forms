using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProductBL
    {
        private readonly ProductDL _productDL;

        public ProductBL()
        {
            _productDL = new ProductDL();
        }

        public List<ProductDTO> GetProducts()
        {
            return _productDL.GetProducts();
        }
    }
}
