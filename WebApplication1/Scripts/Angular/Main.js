var moduleName = 'MobHotel';
var MobHotel = angular.module(moduleName, ['ngRoute']);

MobHotel.config(['$routeProvider', '$locationProvider', function (routeProvider, locationProvider) {
    routeProvider
        .when('/about', {
            templateUrl: 'Templates/about.html',
            controller: 'aboutCtr'
        })
        .when('/contact', {
            templateUrl: 'Templates/contact.html',
            controller: 'contactCtr'
        })
        .otherwise({
            redirectTo: '/home'
        });
}]);