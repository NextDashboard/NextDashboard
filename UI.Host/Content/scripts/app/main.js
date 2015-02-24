(function () {
    var app = angular.module('nextDashboard', []);

    var jobsLoading = [
        { Name: 'Jobs', Status: "...Loading.." }
      
    ];

   
   


    app.controller('GroupController', function ($scope, $http, $interval) {
        $scope.jobs = jobsLoading;
        $http.get("/api/job").then(function (response) {
            console.log(response.data);
            $scope.jobs = response.data;
        });
        
        $interval(function () {
            console.log("looping!!");
            var chat = $.connection.refreshHub;
            console.log($scope.jobs);
            angular.forEach($scope.jobs, function(value) {
                console.log(">>" + value.Id);
                chat.server.refreshJob(value.Id);
            });

            

        }, 1000);

        $scope.refresh = function (value) {
            var chat = $.connection.refreshHub;
            console.log(value);
            chat.server.refreshJob(value);
         
        }
    });
})();