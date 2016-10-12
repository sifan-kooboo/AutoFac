
console.log("about");

angular.module("codeProject").register.controller('initializeDataController', ['$routeParams', '$location','ajaxService',
    function ($routeParams, $location, ajaxService) {

    "use strict";

    var vm = this;

    this.initializeController = function () {
        vm.title = "Initialize Data";
    }

    this.initializeData = function () {
        var inquiry = new Object();
        ajaxService.ajaxPost(inquiry, "api/CustomerService/InitializeData", this.initializeDataOnSuccess, this.initializeDataOnError);
    }

    this.initializeDataOnSuccess = function () {

    }
    
    this.initializeDataOnError = function () {

    }

}]);
