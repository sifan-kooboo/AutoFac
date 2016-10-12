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
    [RoutePrefix("api/CustomerService")]
    public class CustomerServiceController : ApiController
    {

        [Inject]
        public ICustomerDataService _customerDataService { get; set; }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCustomer")]      
        public HttpResponseMessage CreateCustomer(HttpRequestMessage request, [FromBody] CustomerViewModel customerViewModel)
        {
            TransactionalInformation transaction;

            Customer customer = new Customer();
            customer.CompanyName = customerViewModel.CompanyName;
            customer.ContactName = customerViewModel.ContactName;
            customer.ContactTitle = customerViewModel.ContactTitle;
            customer.CustomerCode = customerViewModel.CustomerCode;
            customer.Address = customerViewModel.Address;
            customer.City = customerViewModel.City;
            customer.Region = customerViewModel.Region;
            customer.PostalCode = customerViewModel.PostalCode;
            customer.Country = customerViewModel.Country;
            customer.PhoneNumber = customerViewModel.PhoneNumber;
            customer.MobileNumber = customerViewModel.MobileNumber;

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerBusinessService.CreateCustomer(customer, out transaction);
            if (transaction.ReturnStatus == false)
            {                
                customerViewModel.ReturnStatus = false;
                customerViewModel.ReturnMessage = transaction.ReturnMessage;
                customerViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.BadRequest, customerViewModel);
                return responseError;
              
            }

            customerViewModel.CustomerID = customer.CustomerID;
            customerViewModel.ReturnStatus = true;
            customerViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.OK, customerViewModel);
            return response;

        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(HttpRequestMessage request, [FromBody] CustomerViewModel customerViewModel)
        {
            TransactionalInformation transaction;

            Customer customer = new Customer();
            customer.CustomerID = customerViewModel.CustomerID;
            customer.CompanyName = customerViewModel.CompanyName;
            customer.ContactName = customerViewModel.ContactName;
            customer.ContactTitle = customerViewModel.ContactTitle;
            customer.CustomerCode = customerViewModel.CustomerCode;
            customer.Address = customerViewModel.Address;
            customer.City = customerViewModel.City;
            customer.Region = customerViewModel.Region;
            customer.PostalCode = customerViewModel.PostalCode;
            customer.Country = customerViewModel.Country;
            customer.PhoneNumber = customerViewModel.PhoneNumber;
            customer.MobileNumber = customerViewModel.MobileNumber;

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerBusinessService.UpdateCustomer(customer, out transaction);
            if (transaction.ReturnStatus == false)
            {
                customerViewModel.ReturnStatus = false;
                customerViewModel.ReturnMessage = transaction.ReturnMessage;
                customerViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.BadRequest, customerViewModel);
                return responseError;

            }

            customerViewModel.ReturnStatus = true;
            customerViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.OK, customerViewModel);
            return response;

        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [Route("GetCustomers")]
        [HttpPost]
        public HttpResponseMessage GetCustomers(HttpRequestMessage request, [FromBody] CustomerViewModel customerViewModel)
        {

            TransactionalInformation transaction;

            int currentPageNumber = customerViewModel.CurrentPageNumber;
            int pageSize = customerViewModel.PageSize;
            string sortExpression = customerViewModel.SortExpression;
            string sortDirection = customerViewModel.SortDirection;

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            List<Customer> customers = customerBusinessService.GetCustomers(currentPageNumber, pageSize, sortExpression, sortDirection, out transaction);
            if (transaction.ReturnStatus == false)
            {                
                customerViewModel.ReturnStatus = false;
                customerViewModel.ReturnMessage = transaction.ReturnMessage;
                customerViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.BadRequest, customerViewModel);
                return responseError;

            }

            customerViewModel.TotalPages = transaction.TotalPages;
            customerViewModel.TotalRows = transaction.TotalRows;
            customerViewModel.Customers = customers;
            customerViewModel.ReturnStatus = true;
            customerViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.OK, customerViewModel);
            return response;

        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [Route("GetCustomer")]
        [HttpPost]
        public HttpResponseMessage GetCustomer(HttpRequestMessage request, [FromBody] CustomerViewModel customerViewModel)
        {

            TransactionalInformation transaction;

            int customerID = customerViewModel.CustomerID;
          
            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            Customer customer = customerBusinessService.GetCustomer(customerID, out transaction);
            if (transaction.ReturnStatus == false)
            {
                customerViewModel.ReturnStatus = false;
                customerViewModel.ReturnMessage = transaction.ReturnMessage;
                customerViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.BadRequest, customerViewModel);
                return responseError;

            }

            customerViewModel.CustomerID = customer.CustomerID;
            customerViewModel.CompanyName = customer.CompanyName;
            customerViewModel.ContactName = customer.ContactName;
            customerViewModel.ContactTitle = customer.ContactTitle;
            customerViewModel.CustomerCode = customer.CustomerCode;
            customerViewModel.Address = customer.Address;
            customerViewModel.City = customer.City;
            customerViewModel.Region = customer.Region;
            customerViewModel.PostalCode = customer.PostalCode;
            customerViewModel.Country = customer.Country;
            customerViewModel.PhoneNumber = customer.PhoneNumber;
            customerViewModel.MobileNumber = customer.MobileNumber;

            customerViewModel.ReturnStatus = true;
            customerViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CustomerViewModel>(HttpStatusCode.OK, customerViewModel);
            return response;

        }

        /// <summary>
        /// Initialize Data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("InitializeData")]
        [HttpPost]
        public HttpResponseMessage InitializeData(HttpRequestMessage request)
        {

            TransactionalInformation transaction;
      
            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerBusinessService.InitializeData(out transaction);
            if (transaction.ReturnStatus == false)
            {               
                var responseError = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return responseError;

            }

            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);
            return response;

        }
    }
}