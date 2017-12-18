(function () {
    "use strict";
    angular.module("Myapp")
        .controller("peopleController", PeopleController);

    PeopleController.$inject = ["$scope", "peopleService"];
    function PeopleController($scope, PeopleService) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.peopleService = PeopleService;

        vm.postPerson = _postPerson;
        vm.postSuccess = _postSuccess;
        vm.postError = _postError;

        vm.item = {};
        vm.allItems = {};
        vm.itemCopy = {};

        vm.showAll = _showAll;
        vm.showSuccess = _showSuccess;
        vm.showError = _showError;

        vm.remove = _remove;
        vm.removeSuccess = _removeSuccess;
        vm.removeError = _removeError;

        vm.change = _change;
        vm.editing = _editing;
        vm.editSuccess = _editSuccess;
        vm.editError = _editError;
        vm.activeEdit = false;

        function _onInit() {
            console.log("onInit: PeopleController");
        }

        function _postPerson() {
                console.log("post button was clicked");
                vm.peopleService.posting(vm.item)
                    .then(vm.postSuccess).catch(vm.postError);
        }
        function _postSuccess(res) {
            console.log(res);
            _showAll();
            $scope.people.$setPristine();
            $scope.newAddress.$setUntouched();
        }

        function _postError(err) {
            console.log(err);
        }

        function _editing(editItem) {
            vm.editItem = editItem;
            vm.itemCopy = angular.copy(vm.editItem);
            vm.activeEdit = true;
        }

        function _change(id) {
            vm.peopleService.updating(vm.itemCopy)
                .then(vm.editSuccess).catch(vm.editError);
        }

        function _editSuccess(res) {
            console.log(res);
            _showAll();
        }

        function _editError(err) {
            console.log(err);
        }

        function _showAll() {
            vm.peopleService.getting()
                .then(vm.showSuccess).catch(vm.showError);
        }

        function _showSuccess(res) {
            console.log(res);
            vm.allItems = res.data.items;
        }

        function _showError(err) {
            console.log(err);
        }

        function _remove(id) {
            vm.peopleService.deleting(id)
                .then(vm.removeSuccess).catch(vm.removeError);
        }

        function _removeSuccess(res) {
            console.log(res);
            _showAll();
        }

        function _removeError(err) {
            console.log(err);
        }
        
    }
})();