using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknosipBusinessLayer.Abstract;
using TeknosipDataAccessLayer.Abstract;
using TeknosipDataAccessLayer.Concrete;
using TeknosipEntityLayer.Concrete;

namespace TeknosipBusinessLayer.Concrete
{
    public class ProblemManager : IProblemService
    {
        private readonly IProblemDal _problemDal;
              private readonly Context _context;
        public ProblemManager(IProblemDal problemDal, Context context)
        {
            _problemDal = problemDal;
            _context = context;
        }

        public void TDelete(Problem t)
        {
            _problemDal.Delete(t);
        }

        public Problem TGetByID(int id)
        {
            return _problemDal.GetByID(id);
        }

        public List<Problem> TGetList()
        {
            return _context.Problems
        .Include(p => p.Sector)
        .ToList();
        }

        public void TInsert(Problem t)
        {
          _problemDal.Insert(t);
        }

        public void TUpdate(Problem t)
        {
          _problemDal.Update(t);
        }
        // Sektöre göre filtreleme metodu


        public List<Problem> GetProblemsBySector(int sektorId)
        {
            return _context.Problems
                .Include(p => p.Sector)
                .Where(p => p.SectorId == sektorId)
                .ToList();
        }
    }
}
