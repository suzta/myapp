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
        vm.cropper.sourceImage = null;
        vm.cropper.croppedImage = null;
        vm.item = {};

        //vm.bounds = {};
        //vm.bounds.top = 0;
        //vm.bounds.right = 0;
        //vm.bounds.bottom = 0;
        //vm.bounds.left = 0;

        function _onInit() {
            console.log("onInit: imageUploadController");
        }

        function _post() {
            console.log("post button was clicked");

            var image = vm.cropper.croppedImage;
            var imageInfo = image.split(",");
            var getExtension = imageInfo[0].split("/");
            var extension = getExtension[1].split(";");

            vm.item.encodedImagefile = imageInfo[1];
            vm.item.fileExtension = "." + extension[0];

            vm.imageService.uploading(vm.item)
                .then(vm.postSuccess).catch(vm.postError);
        }
        function _postSuccess(res) {
            console.log(res);
        }

        function _postError(err) {
            console.log(err);
        }

    }
})();