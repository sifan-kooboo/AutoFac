
console.log("product maintenance");

angular.module("codeProject").register.controller('productMaintenanceController',
    ['$routeParams', '$location', 'ajaxService', 'alertService',
    function ($routeParams, $location, ajaxService, alertService) {

        "use strict";

        var vm = this;

        this.initializeController = function () {

            vm.title = "Product Maintenance";

            vm.messageBox = "";
            vm.alerts = [];

            var productID = ($routeParams.id || "");

            if (productID == "") {
                vm.productID = "0";
                vm.productName = "";
                vm.quantityPerUnit = "";
                vm.unitPrice = "";             
            }
            else {
                vm.productID = productID;
                var product = new Object();
                product.productID = productID
                ajaxService.ajaxPost(product, "api/productService/GetProduct", this.getProductOnSuccess, this.getProductOnError);
            }

        }

        this.closeAlert = function (index) {
            vm.alerts.splice(index, 1);
        };

        this.getProductOnSuccess = function (response) {

            vm.productName = response.productName;
            vm.quantityPerUnit = response.quantityPerUnit;
            vm.unitPrice = response.unitPrice;
          
        }

        this.getProductOnError = function (response) {

        }


        this.saveProduct = function () {

            var product = new Object();

            product.productID = vm.productID
            product.productName = vm.productName;
            product.quantityPerUnit = vm.quantityPerUnit;
            product.unitPrice = vm.unitPrice;         

            if (product.productID == "0") {
                ajaxService.ajaxPost(product, "api/productService/CreateProduct", this.createProductOnSuccess, this.createProductOnError);
            }
            else {
                ajaxService.ajaxPost(product, "api/productService/UpdateProduct", this.updateProductOnSuccess, this.updateProductOnError);
            }

        }

        this.createProductOnSuccess = function (response) {
            vm.clearValidationErrors();
            alertService.renderSuccessMessage(response.returnMessage);
            vm.messageBox = alertService.returnFormattedMessage();
            vm.alerts = alertService.returnAlerts();
            vm.productID = response.productID;
        }

        this.createProductOnError = function (response) {
            vm.clearValidationErrors();
            alertService.renderErrorMessage(response.returnMessage);
            vm.messageBox = alertService.returnFormattedMessage();
            vm.alerts = alertService.returnAlerts();
            alertService.setValidationErrors(vm, response.validationErrors);
        }

        this.updateProductOnSuccess = function (response) {
            vm.clearValidationErrors();
            alertService.renderSuccessMessage(response.returnMessage);
            vm.messageBox = alertService.returnFormattedMessage();
            vm.alerts = alertService.returnAlerts();
        }

        this.updateProductOnError = function (response) {
            vm.clearValidationErrors();
            alertService.renderErrorMessage(response.returnMessage);
            vm.messageBox = alertService.returnFormattedMessage();
            vm.alerts = alertService.returnAlerts();
            alertService.setValidationErrors(vm, response.validationErrors);
        }

        this.clearValidationErrors = function () {
            vm.productNameInputError = false;
        }

    }]);
