using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknosipBusinessLayer.Abstract;
using TeknosipDataAccessLayer.Abstract;
using TeknosipEntityLayer.Concrete;

namespace TeknosipBusinessLayer.Concrete
{
    public class ProblemManager : IProblemService
    {
        private readonly IProblemDal _problemDal;

        public ProblemManager(IProblemDal problemDal)
        {
            _problemDal = problemDal;
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
           return _problemDal.GetList();
        }

        public void TInsert(Problem t)
        {
          _problemDal.Insert(t);
        }

        public void TUpdate(Problem t)
        {
          _problemDal.Update(t);
        }
    }
}
