(function () {
    "use strict";
    angular.module("Myapp")
        .controller("webscrapingController", WebscrapingController);

    WebscrapingController.$inject = ["$scope", "webscrapingService"];
    function WebscrapingController($scope, WebscrapingService) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.webscrapingService = WebscrapingService;

        vm.post = _post;
        vm.postSuccess = _postSuccess;
        vm.postError = _postError;

        vm.item = {};
        vm.allItems = {};
        vm.addItem = {};
        vm.alert = _alert;

        vm.showAll = _showAll;
        vm.showSuccess = _showSuccess;
        vm.showError = _showError;

        function _onInit() {
            console.log("onInit: WebScrapingController");
            _showAll();
        }

        function _post(data) {
            console.log("post button was clicked");
            vm.webscrapingService.posting(data)
                .then(vm.postSuccess).catch(vm.postError);
        }
        function _postSuccess(res) {
            console.log(res);
            alert("data was saved");
        }

        function _postError(err) {
            console.log(err);
        }

        function _showAll() {
            vm.webscrapingService.getting()
                .then(vm.showSuccess).catch(vm.showError);
        }

        function _showSuccess(res) {
            console.log(res);
            vm.allItems = res.data;
        }

        function _showError(err) {
            console.log(err);
        }

        function _alert(addItem) {
            vm.addItem = addItem;
        }
    }
})();