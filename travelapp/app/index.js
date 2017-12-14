(function () {
    "use strict";

    var app = angular.module("Myapp", []);
    app.controller("testController", TestController);

    TestController.inject = ["$scope"];
    function TestController($scope) {

    }

})();