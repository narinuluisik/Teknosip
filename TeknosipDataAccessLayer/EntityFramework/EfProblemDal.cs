using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknosipDataAccessLayer.Abstract;
using TeknosipDataAccessLayer.Concrete;
using TeknosipDataAccessLayer.Repositories;
using TeknosipEntityLayer.Concrete;

namespace TeknosipDataAccessLayer.EntityFramework
{
    public class EfProblemDal : GenericRepository<Problem>, IProblemDal
    {
       private readonly Context _context;
        public EfProblemDal(Context context) : base(context)
        {

        }
        public List<Problem> GetProblemsBySector(int sectorId)
        {
            return _context.Problems
                .Include(p => p.Sector)
                .Where(p => p.SectorId == sectorId)
                .OrderByDescending(p => p.OlusturmaTarihi)
                .ToList();
        }
    }
}
