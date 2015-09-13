var app = app || {};

(function () {
    var baseURL = 'https://api.parse.com/1/';
    var ajaxRequester = app.requester.get(baseURL);
    var models = app.data.get(ajaxRequester);
    var controller = app.controller.get(models);
    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var mainSelector = '#main',
            headerSelector = '#header';

        this.get('#/', function () {
            controller.loadHeader(headerSelector)
                .then(function(){
                    controller.loadHome(mainSelector);
                });
        });

        this.get('#/login', function () {
            controller.loadLogin(mainSelector);
        });

        this.get('#/register', function () {
            controller.loadRegister(mainSelector);
        });

        this.get('#/profile/edit', function () {
            controller.loadHeader(headerSelector);
            controller.loadProfile(mainSelector);
        });

        this.get('#/logout', function () {
            controller.logout();
        });
    });

    app.router.run('#/');
})();