(function () {
    var app = angular.module('nextDashboard', []);

    var jobsLoading = [
        { Name: 'Jobs', Status: "...Loading.." }
      
    ];

   
   


    app.controller('GroupController', function ($scope, $http, $interval) {
        $scope.jobs = jobsLoading;
        $http.get("/api/job").then(function (response) {
            $scope.jobs = response.data;
        });
        
        $interval(function () {
            var chat = $.connection.refreshHub;
            angular.forEach($scope.jobs, function(value) {
                chat.server.refreshJob(value.Id);
            });

            

        }, 1000);

        $scope.refresh = function (value) {
            var chat = $.connection.refreshHub;
            chat.server.refreshJob(value);
         
        }
    });
})();