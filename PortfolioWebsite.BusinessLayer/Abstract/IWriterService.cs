using PortfolioWebsite.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PortfolioWebsite.BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterById(int id);
    }
}
