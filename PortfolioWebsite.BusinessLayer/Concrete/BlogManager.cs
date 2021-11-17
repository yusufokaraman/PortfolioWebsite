using PortfolioWebsite.BusinessLayer.Abstract;
using PortfolioWebsite.DataAccessLayer.Abstract;
using PortfolioWebsite.EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDal;

        public BlogManager(IBlogDAL blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> TGetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().TakeLast(3).ToList();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetAll(x => x.BlogId == id);
        }

        public List<Blog> GetBlogsListWithCategory()
        {
            return _blogDal.GetListCategory();
        }

        public List<Blog> GetBlogsListWithWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void TAdd(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
