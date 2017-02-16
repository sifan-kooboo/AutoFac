angular.module(sharedModuleName)
.controller('TestCtr', function ($scope) {
    $scope.info = "TestCtr";

    $scope.change = function (name) {
        console.log("testContrChangName:", name);
        $scope.$emit("ctrTestNameChange", name);
    };


})