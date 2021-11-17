using PortfolioWebsite.BusinessLayer.Abstract;
using PortfolioWebsite.DataAccessLayer.Abstract;
using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebsite.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDal;

        public ContactManager(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Add(contact);
        }
    }
}
