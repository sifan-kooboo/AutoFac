angular.module(sharedModuleName)
.controller('MainCtr',function ($scope) {
    $scope.info = "MainCtr";

    $scope.$on("ctrTestNameChangebrodcastFromParrent", function (event,msg) {
        console.log("mainCtr:", msg);
        $scope.ctrMsg = msg;
    })
})