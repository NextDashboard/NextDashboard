(function () {
    var app = angular.module('nextDashboard', []);

    var jobsFake = [
        { name: 'Test CI Build', status: "Passed" },
        { name: 'Integration Tests', status: "Failing" },
        { name: 'System Tests', status: "Passing" },
        { name: 'QA TestAutomation', status: "Passing" },
        { name: 'Web App Deployment', status: "Failing" },
        { name: 'TP Sprint 3', status: "3 of 7 Stories Completed" },
        { name: 'Code Reviews', status: "25 Completed this week, 9 Pending" },
    ];

    app.controller('GroupController', function ($scope) {
        this.jobs = jobsFake;
    });
})();