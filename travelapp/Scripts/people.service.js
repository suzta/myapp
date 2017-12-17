(function () {
    "use strict";
    angular.module("Myapp")
        .factory("peopleService", PeopleService);

    PeopleService.$inject = ["$http", "$q"];
    function PeopleService($http, $q) {
        return {
            posting: _posting,
            getting: _getting,
            updating: _updating,
            deleting: _deleting
        };

        function _posting(data) {
            return $http.post("http://localhost:50709/api/people", data)
                .then(Success).catch(Error);
        }

        function _getting() {
            return $http.get("http://localhost:50709/api/people/get")
                .then(Success).catch(Error);
        }

        function _updating(data) {
            return $http.put("http://localhost:50709/api/people/"+ data.id, data)
                .then(Success).catch(Error);
        }

        function _deleting(id) {
            return $http.delete("http://localhost:50709/api/people/"+ id)
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