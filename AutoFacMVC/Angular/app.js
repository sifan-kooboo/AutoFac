var sharedModuleName = "GoBear";

angular.module(sharedModuleName, []);

angular.module(sharedModuleName)
.controller('sharedModuleCtrl', function ($scope) {
    $scope.info = 'sharedModuleCtrl';
})