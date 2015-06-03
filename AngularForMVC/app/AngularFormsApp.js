
var angularFormsApp = angular.module('angularFormsApp', ["ngRoute", "ui.bootstrap"]);

angularFormsApp.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "app/Home.html",
                controller: "HomeController"
            })
            .when("/newEmployeeForm", {
                templateUrl: "app/EmployeeForm/efTemplate.html",
                controller: "efController"
            })
            .when("/updateEmployeeForm/:id", {
                templateUrl: "app/EmployeeForm/efTemplate.html",
                controller: "efController"
            })
            .otherwise({
                redirectTo: "/home"
            });

        // gets rid of the #/home in the url (will block routeParams from passing through)
        // $locationProvider.html5Mode(true); 
    }]);

angularFormsApp.controller("HomeController",
    ["$scope", "$location", "DataService",
    function ($scope, $location, DataService) {

        DataService.getEmployees().then(
            function (results) {
                // on success
                var data = results.data;
            },
            function (results) {
                // on error
                var data = results.data;
            }
        );

        $scope.x = 5;

        $scope.showCreateEmployeeForm = function () {
            $location.path('/newEmployeeForm');
        };

        $scope.showUpdateEmployeeForm = function (id) {
            $location.path('/updateEmployeeForm/' + id)
        };

    }]);

