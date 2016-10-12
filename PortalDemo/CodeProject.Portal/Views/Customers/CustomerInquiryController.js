
console.log("customer inquiry");

angular.module("codeProject").register.controller('customerInquiryController', ['$routeParams', '$location', 'ajaxService', 'dataGridService', 'alertService',
    function ($routeParams, $location, ajaxService, dataGridService, alertService) {

    "use strict";

    var vm = this;

    this.initializeController = function () {

        vm.title = "Customer Inquiry";

        vm.alerts = [];
        vm.closeAlert = alertService.closeAlert;

        dataGridService.initializeTableHeaders();

        dataGridService.addHeader("Customer Code", "CustomerCode");
        dataGridService.addHeader("Company Name", "CompanyName");
        dataGridService.addHeader("Contact Name", "ContactName");
        dataGridService.addHeader("City", "City");
        dataGridService.addHeader("Region", "Region");

        vm.tableHeaders = dataGridService.setTableHeaders();
        vm.defaultSort = dataGridService.setDefaultSort("Company Name");

        vm.currentPageNumber = 1;
        vm.sortExpression = "CompanyName";
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
        ajaxService.ajaxPost(inquiry, "api/CustomerService/GetCustomers", this.getCustomersOnSuccess, this.getCustomersOnError);
    }

    this.prepareSearch = function () {

        var inquiry = new Object();
      
        inquiry.currentPageNumber = vm.currentPageNumber;
        inquiry.sortExpression = vm.sortExpression;
        inquiry.sortDirection = vm.sortDirection;
        inquiry.pageSize = vm.pageSize;
        
        return inquiry;

    }

    this.getCustomersOnSuccess = function (response) {
        vm.customers = response.customers;
        vm.totalCustomers = response.totalRows;
        vm.totalPages = response.totalPages;
    }

    this.getCustomersOnError = function (response) {
        alertService.RenderErrorMessage(response.ReturnMessage);
    }


}]);
