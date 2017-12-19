(function () {
    "use strict";
    angular.module("Myapp")
        .controller("registerController", RegisterController);

    RegisterController.$inject = ["$scope", "registerService"];
    function RegisterController($scope, RegisterService) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.registerService = RegisterService;

        vm.post = _post;
        vm.postSuccess = _postSuccess;
        vm.postError = _postError;

        vm.login = _login;
        vm.loginSuccess = _loginSuccess;
        vm.loginError = _loginError;
        vm.item = {};
        vm.loginItem = {};

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

        function _login() {
            console.log("post button was clicked");
            vm.registerService.loging(vm.loginItem.email)
                .then(vm.loginSuccess).catch(vm.loginError);
        }
        function _loginSuccess(res) {
            console.log(res);
            vm.loginItem = {};
        }

        function _loginError(err) {
            console.log(err);
        }
    }
})();