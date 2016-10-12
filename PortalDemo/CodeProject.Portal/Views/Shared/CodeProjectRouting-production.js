
console.log("code project routing - production");

angular.module("codeProject").config(['$routeProvider', '$locationProvider', 'applicationConfigurationProvider',
    function ($routeProvider, $locationProvider, applicationConfigurationProvider) {

        var baseSiteUrlPath = $("base").first().attr("href");

        var _bundles = JSON.parse(applicationConfigurationProvider.getBundles());

        this.getApplicationVersion = function () {
            var applicationVersion = applicationConfigurationProvider.getVersion();
            return applicationVersion;
        }

        this.getBundle = function (bundleName) {

            for (var i = 0; i < _bundles.Bundles.length; i++) {
                if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName) {
                    return _bundles.Bundles[i].Path;
                }
            }
        }

        this.isLoaded = function (bundleName) {
            for (var i = 0; i < _bundles.Bundles.length; i++) {
                if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName) {
                    return _bundles.Bundles[i].IsLoaded;
                }
            }
        }

        this.setIsLoaded = function (bundleName) {
            for (var i = 0; i < _bundles.length; i++) {
                if (bundleName.toLowerCase() == _bundles.Bundles[i].BundleName) {
                    _bundles.Bundles[i].IsLoaded = true;
                    break;
                }
            }
        }

        $routeProvider.when('/:section/:tree',
        {
            templateUrl: function (rp) { return baseSiteUrlPath + 'views/' + rp.section + '/' + rp.tree + '.html?v=' + this.getApplicationVersion(); },

            resolve: {

                load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {

                    var path = $location.path().split("/");
                    var parentPath = path[1];

                    var bundle = this.getBundle(parentPath);
                    var isBundleLoaded = this.isLoaded(parentPath);
                    if (isBundleLoaded == false) {
                        this.setIsLoaded(parentPath);
                        var deferred = $q.defer();
                        require([bundle], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });

                        return deferred.promise;

                    }


                }]
            }


        });

        $routeProvider.when('/:section/:tree/:id',
        {
            templateUrl: function (rp) { return baseSiteUrlPath + 'views/' + rp.section + '/' + rp.tree + '.html?v=' + this.getApplicationVersion(); },

            resolve: {

                load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {

                    var path = $location.path().split("/");
                    var parentPath = path[1];

                    var bundle = this.getBundle(parentPath);
                    var isBundleLoaded = this.isLoaded(parentPath);
                    if (isBundleLoaded == false) {
                        this.setIsLoaded(parentPath);
                        var deferred = $q.defer();
                        require([bundle], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });

                        return deferred.promise;

                    }

                }]
            }

        });

        $routeProvider.when('/',
        {

            templateUrl: function (rp) { return baseSiteUrlPath + 'views/Home/Index.html?v=' + this.getApplicationVersion(); },

            resolve: {

                load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {

                    var bundle = this.getBundle("home");
                    var isBundleLoaded = this.isLoaded("home");

                    if (isBundleLoaded == false) {
                        this.setIsLoaded("home");
                        var deferred = $q.defer();
                        require([bundle], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });

                        return deferred.promise;
                    }

                }]
            }

        });

        $locationProvider.html5Mode(true);

    }]);



