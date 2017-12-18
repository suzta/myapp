(function () {
    "use strict";
    angular.module("Myapp")
        .factory("webscrapingService", WebscrapingService);

    WebscrapingService.$inject = ["$http", "$q"];
    function WebscrapingService($http, $q) {
        return {
            posting: _posting,
            getting: _getting
        };

        function _posting(data) {
            return $http.post("http://localhost:50709/api/scraping/save", data)
                .then(Success).catch(Error);
        }

        function _getting() {
            return $http.get("http://localhost:50709/api/scraping/getall")
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