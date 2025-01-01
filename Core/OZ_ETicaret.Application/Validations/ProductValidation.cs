using FluentValidation;
using OZ_ETicaret.Application.Features.Commands.ProductCommands.AddProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Validations
{
    public class ProductValidation : AbstractValidator<AddProductCommandRequest>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ürün adı boş olamaz")
                .MinimumLength(4)
                .WithMessage("Ürün adı en az 4 karakter olmalıdır")
                .MaximumLength(50)
                .WithMessage("Ürün adı en fazla 50 karakter");
            RuleFor(p => p.Price)
                .NotNull()
                .WithMessage("Ürünün fiyat bilgisi boş olamaz")
                .GreaterThan(0)
                .WithMessage("Lütfen geçerli bir fiyat bilgisi giriniz");
            RuleFor(p => p.Category)
                .NotNull()
                .WithMessage("Ürünün kategori bilgisi boş olamaz");
        }
    }
}
