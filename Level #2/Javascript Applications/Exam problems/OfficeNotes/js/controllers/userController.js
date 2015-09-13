var app = app || {};

app.userController = (function() {
    function UserController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this.viewBag.loginView.loadLoginView(selector);
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        this.viewBag.registerView.loadRegisterView(selector);
    };

    UserController.prototype.login = function(username, password) {
        return this.model.login(username, password)
            .then(function(loginData) {
                setUserToStorage(loginData);
                Noty.success('Successfully logged in.');
                window.location.replace('#/home/');
            }, function(error) {
                Noty.error('Your login has encountered an error. Please try again.');
            })
    };

    UserController.prototype.register = function(username, pass, fullName) {
        return this.model.register(username, pass, fullName)
            .then(function(registerData) {
                var data = {
                    username: username,
                    fullName: fullName,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                Noty.success('Your registration was successful.');
                window.location.replace('#/home/');
            }, function(error) {
                Noty.error('Your registration has encountered an error. Please try again.');
            })
    };

    UserController.prototype.logout = function() {
        return this.model.logout()
            .then(function() {
                clearUserFromStorage();
                Noty.success('Successfully logged out.');
                window.location.replace('#/');
            }, function(error) {
                Noty.error('Your logout has encountered an error. Please try again.');
            });
    };

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['fullName'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load : function(model, views) {
            return new UserController(model, views);
        }
    }
}());