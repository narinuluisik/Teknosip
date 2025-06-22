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
    public class SectorManager : ISectorService
    {
        private readonly ISectorDal _sectorDal;

        public SectorManager(ISectorDal sectorDal)
        {
            _sectorDal = sectorDal;
        }

        public void TDelete(Sector t)
        {
            _sectorDal.Delete(t);
        }

        public Sector TGetByID(int id)
        {
            return _sectorDal.GetByID(id);
        }

        public List<Sector> TGetList()
        {
           return _sectorDal.GetList();
        }

        public void TInsert(Sector t)
        {
            _sectorDal.Insert(t);
        }

        public void TUpdate(Sector t)
        {
           _sectorDal.Update(t);
        }

    }
}
