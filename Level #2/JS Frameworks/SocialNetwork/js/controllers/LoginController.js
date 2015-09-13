'use strict';

app.controller('LoginController',
    function ($scope, $rootScope, $location, authService, notifyService) {
        $rootScope.showRightSidebar = false;
        $rootScope.ngViewSize = 'col-md-10';

        $scope.login = function(userData) {
            authService.login(userData,
                function success() {
                    notifyService.showInfo("Login successful");
                    $location.path("/home");
                },
                function error(err) {
                    notifyService.showError("Login failed", err);
                }
            );
        };
    }
);
