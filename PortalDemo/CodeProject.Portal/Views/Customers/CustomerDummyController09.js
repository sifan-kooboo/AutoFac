
console.log("customerDummyController09");

angular.module("codeProject").register.controller('customerDummyController09', ['$routeParams', '$location', 'ajaxService', 'alertService',
    function ($routeParams, $location, ajaxService, alertService) {

        "use strict";

        var vm = this;

        this.initializeController = function () {

            vm.title = "Customer Dummy Controller";

            vm.customerID = "";
            vm.customerCode = "";
            vm.companyName = "";
            vm.contactName = "";
            vm.contactTitle = "";
            vm.address = "";
            vm.city = "";
            vm.region = "";
            vm.postalCode = "";
            vm.country = "";
            vm.phoneNumber = "";
            vm.mobileNumber = "";

            vm.messageBox = "";
            vm.alerts = [];
        }

        this.closeAlert = function (index) {
            vm.alerts.splice(index, 1);
        };

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

            if (customer.customerID == "0") {
                ajaxService.ajaxPost(customer, "api/CustomerService/CreateCustomer", this.createCustomerOnSuccess, this.createCustomerOnError);
            }
            else {
                ajaxService.ajaxPost(customer, "api/CustomerService/UpdateCustomer", this.updateCustomerOnSuccess, this.updateCustomerOnError);
            }

        }

        this.createCustomerOnSuccess = function (response) {
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

        this.updateCustomerOnSuccess = function (response) {
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
