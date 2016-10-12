
console.log("product inquiry");

angular.module("codeProject").register.controller('productInquiryController', ['$routeParams', '$location', 'ajaxService', 'dataGridService', 'alertService',
    function ($routeParams, $location, ajaxService, dataGridService, alertService) {

        "use strict";

        var vm = this;

        this.initializeController = function () {

            vm.title = "Product Inquiry";

            vm.alerts = [];
            vm.closeAlert = alertService.closeAlert;

            dataGridService.initializeTableHeaders();

            dataGridService.addHeader("Product ID", "ProductID");
            dataGridService.addHeader("Product Name", "ProductName");
            dataGridService.addHeader("Quantity Per Unit", "QuantityPerUnit");
            dataGridService.addHeader("Unit Price", "UnitPrice");
        
            vm.tableHeaders = dataGridService.setTableHeaders();
            vm.defaultSort = dataGridService.setDefaultSort("Product Name");

            vm.currentPageNumber = 1;
            vm.sortExpression = "ProductName";
            vm.sortDirection = "ASC";
            vm.pageSize = 15;

            this.executeInquiry();

        }

        this.closeAlert = function (index) {
            vm.alerts.splice(index, 1);
        };

        this.changeSorting = function (column) {

            dataGridService.changeSorting(column, vm.defaultSort, vm.tableHeaders);

            vm.defaultSort = dataGridService.getSort();
            vm.sortDirection = dataGridService.getSortDirection();
            vm.sortExpression = dataGridService.getSortExpression();
            vm.currentPageNumber = 1;

            vm.executeInquiry();

        };

        this.setSortIndicator = function (column) {
            return dataGridService.setSortIndicator(column, vm.defaultSort);
        };

        this.pageChanged = function () {
            this.executeInquiry();
        }

        this.executeInquiry = function () {
            var inquiry = vm.prepareSearch();
            ajaxService.ajaxPost(inquiry, "api/ProductService/GetProducts", this.getProductsOnSuccess, this.getProductsOnError);
        }

        this.prepareSearch = function () {

            var inquiry = new Object();

            inquiry.currentPageNumber = vm.currentPageNumber;
            inquiry.sortExpression = vm.sortExpression;
            inquiry.sortDirection = vm.sortDirection;
            inquiry.pageSize = vm.pageSize;

            return inquiry;

        }

        this.getProductsOnSuccess = function (response) {
            vm.products = response.products;
            vm.totalProducts = response.totalRows;
            vm.totalPages = response.totalPages;
        }

        this.getProductsOnError = function (response) {
            alertService.RenderErrorMessage(response.ReturnMessage);
        }


    }]);
