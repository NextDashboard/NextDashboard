(function () {
    var app = angular.module('nextDashboard', []);

    var jobsLoading = [
        { Name: 'Jobs', Status: "...Loading.." }
      
    ];

    app.controller('GroupController', function ($scope, $http) {
        $scope.jobs = jobsLoading;
        $http.get("/api/job").then(function (response) {
            console.log(response.data);
            $scope.jobs = response.data;
        });
    });
})();