(function () {
    'use strict';
    var app = angular.module("Myapp.routes", []);

    app.config(_configureStates);

    _configureStates.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];

    function _configureStates($stateProvider, $locationProvider, $urlRouterProvider) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false,
        });
        $urlRouterProvider.otherwise('/home');
        $stateProvider
            .state({
                name: 'home',
                url: '/home',
                templateUrl: '/app/public/home.html',
                title: 'home'
                //controller: 'testController as testCtrl'
            })
                .state({
                name: 'about',
                url: '/about',
                templateUrl: '/app/public/about.html',
                title: 'about'
            })
            .state({
                name: 'people',
                url: '/people',
                templateUrl: '/app/public/people/people.html',
                title: 'people',
                controller: 'peopleController as peopleCtrl'
            })
            //.state({
            //    name: 'listpeople',
            //    url: '/listpeople',
            //    templateUrl: '/app/public/people/listOfPeople.html',
            //    title: 'listpeople',
            //    controller: 'peopleController as peopleCtrl'
            //})
            .state({
                name: 'webscraping',
                url: '/webscraping',
                templateUrl: '/app/public/web/web.html',
                title: 'webscraping',
                controller: 'webscrapingController as webCtrl'
            })
            .state({
                name: 'upload',
                url: '/uplaod',
                templateUrl: '/app/public/upload/uploadpic.html',
                title: 'upload',
                controller: 'imageUploadController as uploadCtrl'
            })
            .state({
                name: 'register',
                url: '/register',
                templateUrl: '/app/public/register/register.html',
                title: 'register',
                controller: 'registerController as registerCtrl'
            });
    }
    })();