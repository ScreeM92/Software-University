app.factory('postService', function($http, $q, $resource, BASE_URL){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var post = {},
            resource = $resource(
                BASE_URL + 'Posts/:option1/:option2/:option3',
                {
                    option1: '@option1',
                    option2: '@option2',
                    option3: '@option3'
                },
                {
                    edit: {
                        method: 'PUT'
                    }
                }
            );

        post.addPost = function(postData){
            return resource.save(postData);
        };

        post.like = function(postId){
            return resource.save({option1: postId, option2: "likes"})
        };

        post.unlike = function(postId){
            return resource.remove({option1: postId, option2: "likes"})
        };

        post.removePost = function(postId){
            return resource.remove({option1: postId});
        };

        post.editPost = function(postId, postContent){
            var postData = { 'postContent': postContent};
            return resource.edit({option1: postId}, postData);
        };

        return post;
    }
});