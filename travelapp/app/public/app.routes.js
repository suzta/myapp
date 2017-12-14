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
        //$urlRouterProvider.otherwise('/home');
        $stateProvider
            .state({
                name: 'next',
                url: '/next',
                templateUrl: '/app/public/home.html',
                title: 'next'
                //controller: 'testController as testCtrl'
            });
    }
    })();