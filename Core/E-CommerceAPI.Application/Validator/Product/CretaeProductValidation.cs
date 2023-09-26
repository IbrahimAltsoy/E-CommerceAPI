using E_CommerceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace E_CommerceAPI.Application.Validator.Product
{
    public class CretaeProductValidation: AbstractValidator<VM_Product_Create>
    {
        public CretaeProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lutfen urun ismi giriniz")
                .MaximumLength(25)
                    .WithMessage("Ürunu en fazla {MaxLength} karakter olmalidir.")
                .MinimumLength(2)
                    .WithMessage("Ürunu en az {MinLength} karakter olmalidir.");
            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lutfen urun ismi giriniz")
                .MaximumLength(25)
                    .WithMessage("Açıklama en fazla {MaxLength} karakter olmalidir.")
                .MinimumLength(2)
                    .WithMessage("Açıklama en az {MinLength} karakter olmalidir.");




            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lutfen urun stogunu giriniz")
                .Must(p => p >= 0)
                    .WithMessage("Urun stogunu en az 0 olmalidir.");



            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lutfen fiyat bilgisini giriniz")
                .Must(p => p >= 0)
                    .WithMessage("Fiyat bilgisi en az 0 olmalidir.");
        }

        
    }
}
