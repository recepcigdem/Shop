using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;

namespace Business.Concrete
{
    public class SalesManager : ISalesService
    {
        private ISalesDal _salesDal;
        private IProductService _productService;

        public SalesManager(ISalesDal salesDal, IProductService productService)
        {
            _salesDal = salesDal;
            _productService = productService;
        }

        public IResult Add(Sales sales)
        {
            if (sales.Quantity > 0)
            {
                var product = _productService.GetById(sales.ProductId);
                if (product.Success)
                {
                    if (product.Data.UnitsInStock > 0 && product.Data.UnitsInStock > sales.Quantity)
                    {
                        _salesDal.Add(sales);

                        product.Data.UnitsInStock = product.Data.UnitsInStock - sales.Quantity;
                        _productService.Update(product.Data);
                    }
                }
            }

            return new SuccessResult(Messages.SalesAdded);
        }
    }
}
