﻿using PortfolioWebsite.EntityLayer.Concrete;
using FluentValidation;
using System.Text.RegularExpressions;

namespace PortfolioWebsite.BusinessLayer.ValidationRules.FluentValidation
{
    public  class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola Boş Geçilemez");
            RuleFor(x => x.WriterCity).NotEmpty().WithMessage("Sehir Boş Geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bio Boş Geçilemez");
           
           
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parola en az 6 karakter olmalıdır, en az bir küçük harf bir büyük harf ve rakam olmalıdır");

        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]{6,}$");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
