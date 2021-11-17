﻿using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetAll(id);
            return View(values);
        }
    }
}
