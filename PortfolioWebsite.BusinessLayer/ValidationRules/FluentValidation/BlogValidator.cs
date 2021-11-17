using FluentValidation;
using PortfolioWebsite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebsite.BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator :   AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Lütfen Blog Başlığını Boş Bırakmayınız!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Lütfen Blog İçeriğini Boş Bırakmayınız!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Lütfen Blog Dosya Yolunu Boş Bırakmayınız!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 Karakter'den daha az Veri Girişi Yapınız!");
            RuleFor(x => x.BlogContent).MinimumLength(80).WithMessage("Lütfen 80 Karakter'den daha fazla Veri Girişi Yapınız!");
        }
    }
}
