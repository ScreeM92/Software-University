app.controller('FriendsController', function ($scope, $routeParams, userService, notifyService) {
	
    userService.getUsersFriends(null,
        function success (data) {
            $scope.friends = data;
            notifyService.showInfo('Success searching friend!');
        }, function error (err) {
            notifyService.showError('Error: ' + err);
        });
});