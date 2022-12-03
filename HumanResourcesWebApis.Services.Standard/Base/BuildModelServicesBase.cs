using HumanResourcesWebApis.DataLayer;
using System.Data.Entity;

namespace HumanResourcesWebApis.Services.Standard
{
    public class BuildModelServicesBase : DbContext
    {
        private HRDatabaseEntities1 _context;

        public HRDatabaseEntities1 Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new HRDatabaseEntities1();
                }
                return _context;
            }
        }
    }
}