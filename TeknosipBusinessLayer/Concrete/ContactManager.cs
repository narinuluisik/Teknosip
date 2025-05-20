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
    public class ContactManager : IContactMessageService
    {
        private readonly IContactMessageDal _contactMessageDal;

        public ContactManager(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }

        public void TDelete(ContactMessage t)
        {
            _contactMessageDal.Delete(t);
        }

        public ContactMessage TGetByID(int id)
        {
           return _contactMessageDal.GetByID(id);
        }

        public List<ContactMessage> TGetList()
        {
            return _contactMessageDal.GetList();
        }

        public void TInsert(ContactMessage t)
        {
            _contactMessageDal.Insert(t);
        }

        public void TUpdate(ContactMessage t)
        {
        _contactMessageDal.Update(t);
        }
    }
}
