var app = app || {};
app._model = app._model || {};

app._model.user = (function () {
    function User(ajaxRequester) {
        this._requester = ajaxRequester;
        this._profilePicture = {
            profilePicture: []
        };
        this.users = {
            users: []
        };
    }

    User.prototype.logIn = function (username, password) {
        var defer = Q.defer();
        this._requester.get('login?username=' + username + '&password=' + password)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    User.prototype.logOut = function () {
        var defer = Q.defer();
        this._requester.post('logout')
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    User.prototype.register = function (data) {
        var defer = Q.defer();
        this._requester.post('users', data)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    User.prototype.updateUser = function (id, data) {
        var defer = Q.defer();
        this._requester.put('users/', id, data)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    //User.prototype.deleteUser = function (id) {
    //    var defer = Q.defer();
    //    this._requester.delete('users/', id)
    //        .then(function (data) {
    //            defer.resolve(data);
    //        }, function (error) {
    //            defer.reject(error);
    //        });
    //    return defer.promise;
    //};

    User.prototype.getUserById = function(id){
        var defer = Q.defer();
        this._requester.get('users/'+ id + '?include=profilePicture')
            .then(function (data) {
                data['createdAt'] = formatDate(data['createdAt']);
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    User.prototype.getUsers = function () {
        var defer = Q.defer();
        var _this = this;
        this.users['users'].length = 0;

        this._requester.get('users')
            .then(function (data) {
                data['results'].forEach(function (dataUser) {
                    var user = {
                        'objectId': dataUser.objectId,
                        'username': dataUser.username,
                        'password': dataUser.password,
                        'email': dataUser.email
                    };
                    _this.users['users'].push(user);
                });

                defer.resolve(_this.users);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    User.prototype.isAdmin = function(id){
        var defer = Q.defer();
        var data = {
            id: id
        };

        this._requester.post('functions/isAdmin', data)
            .then(function(role){
                defer.resolve(role);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    User.prototype.uploadProfilePicture = function(data){
        var defer = Q.defer();
        var _this = this;
        this._profilePicture['profilePicture'].length = 0;

        this._requester.post('classes/Picture', data)
            .then(function (picture) {
                defer.resolve(picture);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    User.prototype.getProfilePicture = function(userId){
        var defer = Q.defer();
        var _this = this;
        this._profilePicture['profilePicture'].length = 0;

        var where = {
            "user":{
                "__type":"Pointer",
                "className":"_User",
                "objectId":userId
            }
        };

        this._requester.get('classes/Picture?order=-createdAt&limit=1&where=' + JSON.stringify(where))
            .then(function (picture) {
                _this._profilePicture['profilePicture'] = picture;
                defer.resolve(_this._profilePicture);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    function formatDate(isoString) {
        var timestamp = new Date(Date.parse(isoString)),
            months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            hours = timestamp.getHours() > 9 ? timestamp.getHours() : '0' + timestamp.getHours(),
            minutes = timestamp.getMinutes() > 9 ? timestamp.getMinutes() : '0' + timestamp.getMinutes();

        return timestamp.getDate() + '-' + months[timestamp.getMonth()] + '-' + timestamp.getFullYear()
            + ' ' + hours  + ':' + minutes;
    }

    return {
        get: function (ajaxRequester) {
            return new User(ajaxRequester);
        }
    }
}());
