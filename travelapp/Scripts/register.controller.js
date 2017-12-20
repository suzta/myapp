(function () {
    "use strict";
    angular.module("Myapp")
        .controller("registerController", RegisterController);

    RegisterController.$inject = ["$scope", "registerService", "$location"];
    function RegisterController($scope, RegisterService, $location) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.registerService = RegisterService;
        vm.$location = $location;

        vm.post = _post;
        vm.postSuccess = _postSuccess;
        vm.postError = _postError;

        vm.login = _login;
        vm.loginSuccess = _loginSuccess;
        vm.loginError = _loginError;
        vm.item = {};
        vm.loginItem = {};
        vm.showForm = _showForm;
        vm.loginshow = false;

        function _onInit() {
            console.log("onInit: WebScrapingController");
        }

        function _post() {
            console.log("post button was clicked");
            vm.registerService.registering(vm.item)
                .then(vm.postSuccess).catch(vm.postError);
        }
        function _postSuccess(res) {
            console.log(res);
            vm.item = [];
        }

        function _postError(err) {
            console.log(err);
        }

        function _showForm() {
            vm.loginshow = true;
        }

        function _login() {
            console.log("post button was clicked");
            vm.registerService.loging(vm.loginItem.email, vm.loginItem.password)
                .then(vm.loginSuccess).catch(vm.loginError);
        }
        function _loginSuccess(res) {
            console.log(res);
            vm.loginItem = {};
            vm.$location.path("/home");
        }

        function _loginError(err) {
            console.log(err);
        }
    }
})();