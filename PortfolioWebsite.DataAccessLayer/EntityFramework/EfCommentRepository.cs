using PortfolioWebsite.DataAccessLayer.Abstract;
using PortfolioWebsite.DataAccessLayer.Repositories;
using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebsite.DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDAL
    {
    
    }
}
