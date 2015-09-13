app.controller('mainController', function ($scope, $interval, userService, $location, $routeParams, profileService, authentication, DEFAULT_PROFILE_IMAGE, notifyService, usSpinnerService) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    };

    $scope.username = authentication.getUsername();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;
    $scope.showPendingRequest = false;
    $scope.isOwnWall = authentication.getUsername() === $routeParams['username'];
    $scope.isOwnFeed = $location.path() === '/';

    function getFriendRequests(){
        if (authentication.isLogged()){
            profileService(authentication.getAccessToken()).getPendingRequests().$promise.then(
                function(data){
                    $scope.pendingRequests = data;
                }, function(error){
                    notifyService.showError("Failed to load friend requests!", error);
                }
            );
        }
    }

    $scope.acceptFriendRequest = function(request){
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).acceptRequest(request.id).$promise.then(
                function(){
                    var index =  $scope.pendingRequests.indexOf(request);
                    $scope.pendingRequests.splice(index,1);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Friend request successfully accepted.");
                }, function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Failed to accept friend request!", error);
                }
            );
        }
    };

    $scope.rejectFriendRequest = function(request){
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).rejectRequest(request.id).$promise.then(
                function(){
                    var index =  $scope.pendingRequests.indexOf(request);
                    $scope.pendingRequests.splice(index,1);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Friend request successfully rejected.");
                }, function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Failed to reject friend request!", error);
                }
            );
        }
    };

    $scope.toLocalTimeZone = function(item){
        item.date = new Date(item.date);
    };

    getFriendRequests();
    var interval = $interval(getFriendRequests, 60000);

    $scope.$on('$destroy', function () { $interval.cancel(interval); });
});