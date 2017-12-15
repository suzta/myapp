(function () {
    "use strict";
    angular.module("publicApp")
        .controller("registerController", RegisterController);

    RegisterController.$inject = ["$scope", "registerService"];
    function RegisterController($scope, RegisterService) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.registerService = RegisterService;

        vm.postPerson = _PostPerson;
        vm.Success = _Success;
        vm.Error = _Error;
        vm.item = {};

        function _onInit() {
            console.log("onInit: RegisterController");
            _PostPerson();
        }

        function _PostPerson() {
            vm.registerService.posting(vm.item)
                .then(vm.Success).catch(vm.Error); 
        }
        function _Success(res) {
            console.log(res);
        }

        function _Error(err) {
            console.log(err);
        }
    }
})();