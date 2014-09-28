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

        $scope.refresh = function () {
            console.log("Todo Wire up refresh here");
            //Todo Wire up refresh here
            var chat = $.connection.refreshHub;
            chat.server.refreshJob('1');
            $http.get("/api/refresh/1").then(function (response) {
                console.log('refreshed!');
                console.log(response.data);
            });

        }
    });
})();