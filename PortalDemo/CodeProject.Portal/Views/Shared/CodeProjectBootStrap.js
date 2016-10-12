//
//  angular bootup and routing table
//


console.log("Code Project Bootstrap");

(function () {

    var app = angular.module('codeProject', ['ngRoute', 'ui.bootstrap', 'ngSanitize', 'blockUI']);

    app.config(['$controllerProvider', '$provide', function ($controllerProvider, $provide) {
        app.register =
          {
              controller: $controllerProvider.register,
              service: $provide.service
          };
    }]);

})();

console.log("Code Project Bootstrap FINISHED 2");




