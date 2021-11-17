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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDAL _newsLetter;
        public NewsLetterManager(INewsLetterDAL newsLetter)
        {
            _newsLetter = newsLetter;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetter.Add(newsLetter);
        }
    }
}
