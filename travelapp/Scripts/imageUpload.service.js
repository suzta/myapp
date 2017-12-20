(function () {
    "use strict";
    angular.module("Myapp")
        .factory("imageService", ImageService);

    ImageService.$inject = ["$http", "$q"];
    function ImageService($http, $q) {
        return {
            uploading: _uploading
        };

        function _uploading(data) {
            return $http.post("http://localhost:50709/api/image", data)
                .then(Success).catch(Error);
        }

        function Success(res) {
            return res;
        }
        function Error(err) {
            return $q.reject(err);
        }
    };

})();