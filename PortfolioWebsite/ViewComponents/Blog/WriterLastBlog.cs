using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.DataAccessLayer.EntityFramework;

namespace PortfolioWebsite.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
       BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogsListWithWriter(19);
            return View(values);
        }
    }
}
