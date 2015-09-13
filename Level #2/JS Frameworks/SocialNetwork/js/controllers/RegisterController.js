'use strict';

app.controller('RegisterController',
    function ($scope, $rootScope, $location, townsService, authService, notifyService) {
        $rootScope.showRightSidebar = false;
        $rootScope.ngViewSize = 'col-md-10';
        $rootScope.pageTitle = "Register";

        $scope.userData = {townId: null};
        $scope.towns = townsService.getTowns();

        $scope.register = function(userData) {
            authService.register(userData,
                function success() {
                    notifyService.showInfo("User registered successfully");
                    $location.path("/home");
                },
                function error(err) {
                    notifyService.showError("User registration failed", err);
                }
            );
        };
    }
);
