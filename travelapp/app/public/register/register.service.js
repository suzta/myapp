(function () {
    "use strict";
    angular.module("Myapp")
        .factory("registerService", RegisterService);

    RegisterService.$inject = ["$http", "$q"];
    function RegisterService($http, $q) {
        return {
            posting: _posting
        };

        function _posting(data) {
            return $http.post("http://localhost:50709/api/register/post", data)
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