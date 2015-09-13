app.factory('userService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var user = {},
            resource = $resource(
                BASE_URL + 'users/:option1/:option2/:option3',
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

        user.login = function(loginData){
            return resource.save({option1: 'login'}, loginData);
        };

        user.register = function(registerData){
            return resource.save({option1: 'register'}, registerData);
        };

        user.logout = function(){
            return resource.save({option1: 'logout'});
        };

        user.getUserWall = function(username, pageSize, startPostId){
            var option2 = 'wall?StartPostId' + (startPostId ? "=" + startPostId : "") + "&PageSize=" + pageSize;

            return resource.query({ option1: username, option2: option2});
        };

        user.searchUser = function(searchTerm){
            var option1 = "search?searchTerm=" + searchTerm;

            return resource.query({ option1: option1 });
        };

        user.getUserFullData = function(username){
            return resource.get({ option1: username });
        };

        user.getUserPreviewData = function(username){
            return resource.get({ option1: username, option2: 'preview' });
        };

        user.getUserFriendsPreview = function(username){
            return resource.get({ option1: username, option2: 'friends', option3: 'preview' });
        };

        user.getUserFriends = function(username){
            return resource.query({ option1: username, option2: 'friends' });
        };

        user.isLogged = function(){
            return authentication.isLogged();
        };

        return user;
    }
});