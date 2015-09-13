app.controller('SearchController', function ($scope, $routeParams, userService, notifyService) {
	var searchTerm = $routeParams.searchTerm;
	
    userService.searchUsers(searchTerm,
        function success (data) {
            $scope.users = data;
            notifyService.showInfo('Success searching friend!');
        }, function error (err) {
            notifyService.showError('Error: ' + err);
        });
});