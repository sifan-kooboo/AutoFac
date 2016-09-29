var moduleName = 'MobHotel';
var MobHotel = angular.module(moduleName, ['ngRoute']);

MobHotel.config(['$routeProvider', '$locationProvider', function (routeProvider, locationProvider) {
    routeProvider
        .when('/home', {
            templateUrl: 'Templates/Views/home.html'
        })
        .when('/about', {
            templateUrl: 'Templates/Views/about.html',
            controller: 'aboutCtr'
        })
        .when('/contact', {
            templateUrl: 'Templates/Views/contact.html',
            controller: 'contactCtr'
        })
        .when('/Account/Login',
        {
            redirectTo: '/about'
        })
        .otherwise({
            redirectTo: '/home'
        });

    locationProvider.html5Mode(true);
}]);