(function () {
    "use strict";
    angular.module("Myapp")
        .factory("registerService", RegisterService);

    RegisterService.$inject = ["$http", "$q"];
    function RegisterService($http, $q) {
        return {
            registering: _registering,
            loging: _loging
        };

        function _registering(data) {
            return $http.post("http://localhost:50709/api/register", data)
                .then(Success).catch(Error);
        }

        function _loging(email) {
            return $http.get("http://localhost:50709/api/register/login/"+ email)
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