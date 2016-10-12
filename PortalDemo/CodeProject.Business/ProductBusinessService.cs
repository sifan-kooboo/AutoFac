using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeProject.Business.Entities;
using CodeProject.Interfaces;
using CodeProject.Business.Common;

using FluentValidation;
using FluentValidation.Results;
using System.Configuration;
using System.Web;
using System.IO;
using System.Net.Mail;

namespace CodeProject.Business
{
    public class ProductBusinessService
    {
        private IProductDataService _productDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductBusinessService(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Product CreateProduct(Product product, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {
                ProductBusinessRules productBusinessRules = new ProductBusinessRules();
                ValidationResult results = productBusinessRules.Validate(product);

                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return product;
                }

                _productDataService.CreateSession();
                _productDataService.BeginTransaction();
                _productDataService.CreateProduct(product);
                _productDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Product successfully created.");

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }

            return product;


        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="transaction"></param>
        public void UpdateProduct(Product product, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {

                ProductBusinessRules productBusinessRules = new ProductBusinessRules();
                ValidationResult results = productBusinessRules.Validate(product);

                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return;
                }

                _productDataService.CreateSession();
                _productDataService.BeginTransaction();

                Product existingProduct = _productDataService.GetProduct(product.ProductID);

                existingProduct.ProductName = product.ProductName;
                existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                existingProduct.UnitPrice = product.UnitPrice;
             
                _productDataService.UpdateProduct(product);
                _productDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Product was successfully updated.");

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }


        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            List<Product> products = new List<Product>();

            try
            {
                int totalRows;

                _productDataService.CreateSession();
                products = _productDataService.GetProducts(currentPageNumber, pageSize, sortExpression, sortDirection, out totalRows);
                _productDataService.CloseSession();

                transaction.TotalPages = CodeProject.Business.Common.Utilities.CalculateTotalPages(totalRows, pageSize);
                transaction.TotalRows = totalRows;

                transaction.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }

            return products;

        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Product GetProduct(int productID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            Product product = new Product();

            try
            {

                _productDataService.CreateSession();
                product = _productDataService.GetProduct(productID);
                _productDataService.CloseSession();      
                transaction.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }

            return product;

        }






    }
}

