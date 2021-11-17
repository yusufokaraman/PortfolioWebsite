using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDahsboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = wm.GetWriterById(20);
            return View(values);
        }


    }
}
