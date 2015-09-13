var app = app || {};
app._model = app._model || {};

app._model.users = (function(){
    function Users(ajaxRequester) {
        this._requester = ajaxRequester;
    }

    Users.prototype.login = function(username, password){
        var defer = Q.defer();
        this._requester.get('login?username=' + username + '&password=' + password, app.credentials.getHeaders())
            .then(function (data) {
                app.credentials.setSessionToken(data.sessionToken);
                app.credentials.setUserId(data.objectId);
                app.credentials.setUsername(data.username);

                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Users.prototype.register = function(userData){
        var defer = Q.defer();

        this._requester.post('users', app.credentials.getHeaders(), userData)
            .then(function(data){
                app.credentials.setSessionToken(data.sessionToken);
                app.credentials.setUserId(data.objectId);
                app.credentials.setUsername(userData.username);
                defer.resolve(data);
            },function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    Users.prototype.editProfile = function(userId, userData){
        var defer = Q.defer();
        this._requester.put('users/' + userId, app.credentials.getHeaders(), userData)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Users.prototype.getById = function(id){
        var defer = Q.defer();

        this._requester.get('users/' + id, app.credentials.getHeaders())
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Users.prototype.getCurrentUserData = function(){
        var defer = Q.defer(),
            userData = {
                userId: app.credentials.getUserId(),
                username: app.credentials.getUsername(),
                sessionToken: app.credentials.getSessionToken()
            };

        defer.resolve(userData);

        return defer.promise;
    };

    Users.prototype.logout = function(){
        var defer = Q.defer();
        this._requester.post('logout', app.credentials.getHeaders())
            .then(function (data) {
                app.credentials.clearStorage();
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Users.prototype.isLogged = function(){
        return app.credentials.getSessionToken();
    };

    Users.prototype.validateToken = function (sessionToken) {
        var defer = Q.defer();
        var _this = this;

        this._requester.get('users/me', app.credentials.getHeaders())
            .then(function(data){
                defer.resolve(data === sessionToken);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    return {
        get: function (ajaxRequester) {
            return new Users(ajaxRequester);
        }
    }
}());
