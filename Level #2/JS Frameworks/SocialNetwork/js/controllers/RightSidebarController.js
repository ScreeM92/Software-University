'use strict';

app.controller('RightSidebarController', function ($scope, $rootScope,authService, notifyService, userService) {

    $scope.getUsersFriends = function () {
            userService.getUsersFriends(
                null,
                function success (data) {
                    $scope.friends = data;
                }, function error (error) {
                    notifyService.showError('Error: ' + error);
                }
            );
        };

    if (authService.isLoggedIn()) {
        $scope.getUsersFriends();
    }    
});