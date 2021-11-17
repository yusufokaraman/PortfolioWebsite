using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.TGetAll();
            return View(values);
        }
    }
}
