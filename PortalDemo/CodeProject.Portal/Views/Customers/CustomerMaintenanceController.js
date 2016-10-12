
console.log("customer maintenance");

angular.module("codeProject").register.controller('customerMaintenanceController',
    ['$routeParams', '$location', 'ajaxService', 'alertService',
    function ($routeParams, $location, ajaxService, alertService) {

    "use strict";

    var vm = this;

    this.initializeController = function () {

        vm.title = "Customer Maintenance";

        vm.messageBox = "";
        vm.alerts = [];

        var customerID = ($routeParams.id || "");

        if (customerID == "")
        {
            vm.customerID = "0";
            vm.customerCode = "Micro";
            vm.companyName = "Microsoft Corporation";
            vm.contactName = "William Gates";
            vm.contactTitle = "Founder & CEO";
            vm.address = "One Microsoft Way";
            vm.city = "Redmond";
            vm.region = "WA";
            vm.postalCode = "98052-7329";
            vm.country = "USA";
            vm.phoneNumber = "(425) 882-8080";
            vm.mobileNumber = "(425) 706-7329";           
        }
        else
        {
            vm.customerID = customerID;
            var customer = new Object();
            customer.customerID = customerID                  
            ajaxService.ajaxPost(customer, "api/CustomerService/GetCustomer", this.getCustomerOnSuccess, this.getCustomerOnError);            
        }
              
    }

    this.closeAlert = function (index) {
        vm.alerts.splice(index, 1);
    };

    this.getCustomerOnSuccess = function (response) {

        vm.customerCode = response.customerCode;
        vm.companyName = response.companyName;
        vm.contactName = response.contactName;
        vm.contactTitle = response.contactTitle;
        vm.address = response.address;
        vm.city = response.city;
        vm.region = response.region;
        vm.postalCode = response.postalCode;
        vm.country = response.country;
        vm.phoneNumber = response.phoneNumber;
        vm.mobileNumber = response.mobileNumber;

    }
        
    this.getCustomerOnError = function (response) {

    }

    
    this.saveCustomer = function () {

        var customer = new Object();
        customer.customerID = vm.customerID
        customer.customerCode = vm.customerCode;
        customer.companyName = vm.companyName;
        customer.contactName = vm.contactName;
        customer.contactTitle = vm.contactTitle;
        customer.address = vm.address;
        customer.city = vm.city;
        customer.region = vm.region;
        customer.postalCode = vm.postalCode;
        customer.country = vm.country;
        customer.phoneNumber = vm.phoneNumber;
        customer.mobileNumber = vm.mobileNumber;
   
        if (customer.customerID=="0") {
            ajaxService.ajaxPost(customer, "api/CustomerService/CreateCustomer", this.createCustomerOnSuccess, this.createCustomerOnError);
        }
        else {
            ajaxService.ajaxPost(customer, "api/CustomerService/UpdateCustomer", this.updateCustomerOnSuccess, this.updateCustomerOnError);
        }

    }

    this.createCustomerOnSuccess = function (response)
    {
        vm.clearValidationErrors();
        alertService.renderSuccessMessage(response.returnMessage);
        vm.messageBox = alertService.returnFormattedMessage();
        vm.alerts = alertService.returnAlerts();
        vm.customerID = response.customerID;
    }

    this.createCustomerOnError = function (response) {
        vm.clearValidationErrors();
        alertService.renderErrorMessage(response.returnMessage);
        vm.messageBox = alertService.returnFormattedMessage();
        vm.alerts = alertService.returnAlerts();
        alertService.setValidationErrors(vm, response.validationErrors);
    }

    this.updateCustomerOnSuccess = function (response)
    {
        vm.clearValidationErrors();
        alertService.renderSuccessMessage(response.returnMessage);
        vm.messageBox = alertService.returnFormattedMessage();
        vm.alerts = alertService.returnAlerts();
    }

    this.updateCustomerOnError = function (response) {
        vm.clearValidationErrors();
        alertService.renderErrorMessage(response.returnMessage);
        vm.messageBox = alertService.returnFormattedMessage();
        vm.alerts = alertService.returnAlerts();
        alertService.setValidationErrors(vm, response.validationErrors);
    }

    this.clearValidationErrors = function () {
        vm.customerCodeInputError = false;
        vm.companyNameInputError = false;
    } 

}]);
