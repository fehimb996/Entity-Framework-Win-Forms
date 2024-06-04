using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class DatabaseContext : IDisposable
    {
        private readonly NorthwindEntities _context;

        public DatabaseContext()
        {
            _context = new NorthwindEntities();
        }

        public NorthwindEntities GetContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
