using PortfolioWebsite.BusinessLayer.Abstract;
using PortfolioWebsite.DataAccessLayer.Abstract;
using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PortfolioWebsite.BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDal;
        public WriterManager(IWriterDAL writerDal)
        {
            _writerDal = writerDal;
        }
        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetAll(x => x.WriterId == id);
        }

        public void TAdd(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void TDelete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer entity)
        {
            throw new NotImplementedException();
        }
    }
}
