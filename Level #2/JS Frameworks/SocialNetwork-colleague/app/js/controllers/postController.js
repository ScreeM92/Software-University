app.controller('postController', function ($scope, $routeParams, userService, authentication, postService, notifyService, usSpinnerService) {

    $scope.addPost = function(){
        $scope.postData.username = $routeParams['username'];
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).addPost($scope.postData).$promise.then(
                function(data){
                    $scope.postData.postContent = "";
                    $scope.posts.unshift(data);
                    notifyService.showInfo("Post successfully added.");
                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    $scope.postData.postContent = "";
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Failed to add post!", error);
                }
            );
        }
    };

    $scope.editPost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).editPost(post.id, post.newPostContent).$promise.then(
                function(){
                    post.postContent = post.newPostContent;
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Post successfully edited.");
                },
                function(error){
                    notifyService.showError("Failed to edit post!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.deletePost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).removePost(post.id).$promise.then(
                function(){
                    var index =  $scope.posts.indexOf(post);
                    $scope.posts.splice(index, 1);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Post successfully deleted.");
                },
                function(error){
                    notifyService.showError("Failed to delete post!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.likePost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).like(post.id).$promise.then(
                function(){
                    notifyService.showInfo("Post successfully liked.");
                    usSpinnerService.stop('spinner-1');
                    post.liked = true;
                    post.likesCount++;
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Failed to like post!", error);
                }
            );
        }
    };

    $scope.unlikePost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).unlike(post.id).$promise.then(
                function(){
                    notifyService.showInfo("Post successfully unliked.");
                    usSpinnerService.stop('spinner-1');
                    post.liked = false;
                    post.likesCount--;
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Failed to unlike post!", error);
                }
            );
        }
    };
});


