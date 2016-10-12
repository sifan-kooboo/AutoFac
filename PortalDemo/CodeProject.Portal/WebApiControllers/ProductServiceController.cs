using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeProject.Portal.Models;
using CodeProject.Business.Entities;
using CodeProject.Business;
using CodeProject.Interfaces;
using Ninject;

namespace CodeProject.Portal.WebApiControllers
{
    [RoutePrefix("api/ProductService")]
    public class ProductServiceController : ApiController
    {

        [Inject]
        public IProductDataService _productDataService { get; set; }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        [Route("CreateProduct")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(HttpRequestMessage request, [FromBody] ProductViewModel productViewModel)
        {
            TransactionalInformation transaction;

            Product product = new Product();
            product.ProductName = productViewModel.ProductName;
            product.QuantityPerUnit = productViewModel.QuantityPerUnit;
            product.UnitPrice = productViewModel.UnitPrice;
           

            ProductBusinessService productBusinessService = new ProductBusinessService(_productDataService);
            productBusinessService.CreateProduct(product, out transaction);
            if (transaction.ReturnStatus == false)
            {
                productViewModel.ReturnStatus = false;
                productViewModel.ReturnMessage = transaction.ReturnMessage;
                productViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<ProductViewModel>(HttpStatusCode.BadRequest, productViewModel);
                return responseError;

            }

            productViewModel.ProductID = product.ProductID;
            productViewModel.ReturnStatus = true;
            productViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<ProductViewModel>(HttpStatusCode.OK, productViewModel);
            return response;

        }

        [Route("UpdateProduct")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(HttpRequestMessage request, [FromBody] ProductViewModel productViewModel)
        {
            TransactionalInformation transaction;

            Product product = new Product();
            product.ProductID = productViewModel.ProductID;
            product.ProductName = productViewModel.ProductName;
            product.QuantityPerUnit = productViewModel.QuantityPerUnit;
            product.UnitPrice = productViewModel.UnitPrice;
          

            ProductBusinessService productBusinessService = new ProductBusinessService(_productDataService);
            productBusinessService.UpdateProduct(product, out transaction);
            if (transaction.ReturnStatus == false)
            {
                productViewModel.ReturnStatus = false;
                productViewModel.ReturnMessage = transaction.ReturnMessage;
                productViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<ProductViewModel>(HttpStatusCode.BadRequest, productViewModel);
                return responseError;

            }

            productViewModel.ReturnStatus = true;
            productViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<ProductViewModel>(HttpStatusCode.OK, productViewModel);
            return response;

        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="request"></param>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        [Route("GetProducts")]
        [HttpPost]
        public HttpResponseMessage GetProducts(HttpRequestMessage request, [FromBody] ProductViewModel productViewModel)
        {

            TransactionalInformation transaction;

            int currentPageNumber = productViewModel.CurrentPageNumber;
            int pageSize = productViewModel.PageSize;
            string sortExpression = productViewModel.SortExpression;
            string sortDirection = productViewModel.SortDirection;

            ProductBusinessService productBusinessService = new ProductBusinessService(_productDataService);
            List<Product> products = productBusinessService.GetProducts(currentPageNumber, pageSize, sortExpression, sortDirection, out transaction);
            if (transaction.ReturnStatus == false)
            {
                productViewModel.ReturnStatus = false;
                productViewModel.ReturnMessage = transaction.ReturnMessage;
                productViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<ProductViewModel>(HttpStatusCode.BadRequest, productViewModel);
                return responseError;

            }

            productViewModel.TotalPages = transaction.TotalPages;
            productViewModel.TotalRows = transaction.TotalRows;
            productViewModel.Products = products;
            productViewModel.ReturnStatus = true;
            productViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<ProductViewModel>(HttpStatusCode.OK, productViewModel);
            return response;

        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        [Route("GetProduct")]
        [HttpPost]
        public HttpResponseMessage GetProduct(HttpRequestMessage request, [FromBody] ProductViewModel productViewModel)
        {

            TransactionalInformation transaction;

            int productID = productViewModel.ProductID;

            ProductBusinessService productBusinessService = new ProductBusinessService(_productDataService);
            Product product = productBusinessService.GetProduct(productID, out transaction);
            if (transaction.ReturnStatus == false)
            {
                productViewModel.ReturnStatus = false;
                productViewModel.ReturnMessage = transaction.ReturnMessage;
                productViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<ProductViewModel>(HttpStatusCode.BadRequest, productViewModel);
                return responseError;

            }

            productViewModel.ProductID = product.ProductID;
            productViewModel.ProductName = product.ProductName;
            productViewModel.QuantityPerUnit = product.QuantityPerUnit;
            productViewModel.UnitPrice = product.UnitPrice;
          
            productViewModel.ReturnStatus = true;
            productViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<ProductViewModel>(HttpStatusCode.OK, productViewModel);
            return response;

        }



    }
}