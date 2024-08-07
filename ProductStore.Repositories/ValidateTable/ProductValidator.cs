using FluentValidation;
using ProductStore.Infrastrucre.Mediator.Request;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.ValidateTable
{
    public class ProductValidator : AbstractValidator<AddProductComand>
    {
        public ProductValidator() {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Không được bỏ trống tên");
            RuleFor(a => a.Price).GreaterThanOrEqualTo(1000).WithMessage("Giá phải lớn hơn 1000");
            RuleFor(a => a.Amount).GreaterThanOrEqualTo(1).WithMessage("Ít nhất có 1 sản phẩm");
            RuleFor(a => a.Description).NotEmpty().MinimumLength(10).WithMessage("Không được bỏ trống và ít nhất 10 kí tự");
        }
    }
}
