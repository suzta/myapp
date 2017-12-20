(function () {
    "use strict";
    angular.module("Myapp")
        .controller("imageUploadController", ImageUploadController);

    ImageUploadController.$inject = ["$scope", "imageService"];
    function ImageUploadController($scope, ImageService) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _onInit;
        vm.imageService = ImageService;

        vm.post = _post;
        vm.postSuccess = _postSuccess;
        vm.postError = _postError;

        vm.item = {};

        function _onInit() {
            console.log("onInit: imageUploadController");
        }

        function _post() {
            console.log("post button was clicked");
            vm.imageService.uploading(vm.item)
                .then(vm.postSuccess).catch(vm.postError);
        }
        function _postSuccess(res) {
            console.log(res);
            vm.item = [];
        }

        function _postError(err) {
            console.log(err);
        }

    }
})();