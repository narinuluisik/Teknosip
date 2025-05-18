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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetByID(int id)
        {
           return _aboutDal.GetByID(id);
        }

        public List<About> TGetList()
        {
          return _aboutDal.GetList();
        }

        public void TInsert(About t)
        {
           _aboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
           _aboutDal.Update(t);
        }
    }
}
