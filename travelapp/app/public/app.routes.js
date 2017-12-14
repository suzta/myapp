﻿(function () {
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
            //controller: 'testController as testCtrl'
        });
    }
    })();