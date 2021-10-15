﻿using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebsite.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\Karaman; database=PortfolioWebsiteDb; integrated security=true;") ;
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}