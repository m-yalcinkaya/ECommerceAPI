using ECommerceAPI.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş geçmeyiniz!")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz!");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok adedini boş geçmeyiniz!")
                .Must(s => s >= 0)
                .WithMessage("Stok adedi negatif olamaz!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün fiyatını boş geçmeyiniz!")
                .Must(s => s >= 0)
                .WithMessage("Ürün fiyatı negatif olamaz!");

        }
    }
}
