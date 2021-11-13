using ArcraftAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.DataAccess.Repositories
{
    public class AircraftRepository : GenericRepository<Aircraft>, IAircraftRepository
    {
        public AircraftRepository(AppDbContext context) : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return context as AppDbContext; }
        }
    }
}