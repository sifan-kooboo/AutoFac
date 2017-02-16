angular.module(sharedModuleName)
.controller('RootCtr', function ($scope) {
    $scope.info = "rootCtr";

    /*Angularjs为在scope中为我们提供了冒泡和隧道机制

    $broadcast会把事件广播给所有子controller，
    $emit则会将事件冒泡传递给父controller，
    $on则是angularjs的事件注册函数(也可理解为监听)，
    
    有了这一些我们就能很快的以angularjs的方式去解决angularjs controller之间的通信
    */
    $scope.$on("ctrTestNameChange", function(event,msg){
        console.log("parent", msg);
        $scope.$broadcast("ctrTestNameChangebrodcastFromParrent", msg);
    });
})