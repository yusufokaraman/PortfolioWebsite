﻿using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebsite.BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void Add(Writer writer);
    }
}
