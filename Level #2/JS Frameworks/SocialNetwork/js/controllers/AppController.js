'use strict';

// The AppController holds the presentation logic for the entire app (common all screens)
app.controller('AppController',
    function ($scope, $rootScope, $location, authService, notifyService) {
		// Put the authService in the $scope to make it accessible from all screens
        $scope.authService = authService;
        $scope.adminAdsMenuOption = null;
        $scope.adminAdmMenuOption = null;

        $scope.goHome = function () {
            $rootScope.selectedMenuItem = 'Home';
        };

        $scope.logout = function() {
            authService.logout();
            notifyService.showInfo("Logout successful");
            $location.path('/');
        };
    }
);
