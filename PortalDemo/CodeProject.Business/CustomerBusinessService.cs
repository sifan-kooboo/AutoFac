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
    public class CustomerBusinessService
    {
        private ICustomerDataService _customerDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerBusinessService(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Customer CreateCustomer(Customer customer, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {
                CustomerBusinessRules customerBusinessRules = new CustomerBusinessRules();
                ValidationResult results = customerBusinessRules.Validate(customer);

                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return customer;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.CreateCustomer(customer);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Customer successfully created.");

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }

            return customer;


        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="transaction"></param>
        public void UpdateCustomer(Customer customer, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {

                CustomerBusinessRules customerBusinessRules = new CustomerBusinessRules();
                ValidationResult results = customerBusinessRules.Validate(customer);

                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();

                Customer existingCustomer = _customerDataService.GetCustomer(customer.CustomerID);

                existingCustomer.CustomerCode = customer.CustomerCode;
                existingCustomer.CompanyName = customer.CompanyName;
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.Address = customer.Address;
                existingCustomer.City = customer.City;
                existingCustomer.Region = customer.Region;
                existingCustomer.PostalCode = customer.PostalCode;
                existingCustomer.Country = customer.Country;
                existingCustomer.MobileNumber = customer.MobileNumber;
                existingCustomer.PhoneNumber = customer.PhoneNumber;

                _customerDataService.UpdateCustomer(customer);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Customer was successfully updated.");

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }


        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<Customer> GetCustomers(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            List<Customer> customers = new List<Customer>();

            try
            {
                int totalRows;

                _customerDataService.CreateSession();
                customers = _customerDataService.GetCustomers(currentPageNumber, pageSize, sortExpression, sortDirection, out totalRows);
                _customerDataService.CloseSession();

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
                _customerDataService.CloseSession();
            }

            return customers;

        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Customer GetCustomer(int customerID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            Customer customer = new Customer();

            try
            {

                _customerDataService.CreateSession();
                customer = _customerDataService.GetCustomer(customerID);
                _customerDataService.CloseSession();      
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
                _customerDataService.CloseSession();
            }

            return customer;

        }

        /// <summary>
        /// Initialize Data
        /// </summary>
        /// <param name="transaction"></param>
        public void InitializeData(out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            Customer customer = new Customer();

            try
            {

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.InitializeData();
                _customerDataService.CommitTransaction(true);
                _customerDataService.CloseSession();

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.LoadData();
                _customerDataService.CommitTransaction(true);
                _customerDataService.CloseSession();

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
                _customerDataService.CloseSession();
            }           

        }




    }
}
