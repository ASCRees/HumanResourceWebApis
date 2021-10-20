using HumanResourcesWebApis.DataLayer;
using System.Data.Entity;

namespace HumanResourcesWebApis.Services
{
    public class BuildModelServicesBase : DbContext
    {
        private HRDatabaseEntities _context;

        public HRDatabaseEntities Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new HRDatabaseEntities();
                }
                return _context;
            }
        }
    }
}