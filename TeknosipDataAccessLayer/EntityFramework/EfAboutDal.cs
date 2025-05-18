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
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {

        }
    }
}
