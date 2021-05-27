using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }
        
        public IDataResult<Product> GetByProductName(string productName)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductName == productName));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNullControl(product), CheckIfProductDbControl(product));
            if (result != null)
                return result;

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNullControl(product), CheckIfProductDbControl(product));
            if (result != null)
                return result;

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductNullControl(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName))
                return new ErrorResult(Messages.ProductNameNull);

            if (string.IsNullOrEmpty(product.Category))
                return new ErrorResult(Messages.CategoryNull);

            if (product.Price < 1)
                return new ErrorResult(Messages.PriceNull);

            if (product.UnitsInStock < 1)
                return new ErrorResult(Messages.UnitsInStockNull);

            return new SuccessResult();
        }

        private IResult CheckIfProductDbControl(Product product)
        {
            var result = GetByProductName(product.ProductName);
            if (result.Success)
                return new ErrorResult(Messages.ProductNameAlreadyExists);
           
            return new SuccessResult();
        }
    }
}
