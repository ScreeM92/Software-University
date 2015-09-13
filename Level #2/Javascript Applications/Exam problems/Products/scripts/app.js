var app = app || {};

(function () {
    var baseURL = 'https://api.parse.com/1/';
    var ajaxRequester = app.requester.get(baseURL);
    var models = app.model.get(ajaxRequester);
    var controller = app.controller.get(models);
    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var mainSelector = '#main',
            menuSelector = '#menu';

        this.get('#/', function () {
            loadHeader();
            controller.loadHome(mainSelector);
        });

        this.get('#/login', function () {
            loadHeader();
            controller.loadLogin(mainSelector);
        });

        this.get('#/register', function () {
            loadHeader();
            controller.loadRegister(mainSelector);
        });

        this.get('#/products', function () {
            loadHeader();
            controller.loadProducts(mainSelector);
        });

        this.get('#/product/add', function () {
            loadHeader();
            controller.loadProductAdd(mainSelector);
        });

        this.get('#/product/edit/:id', function () {
            loadHeader();
            controller.loadProductEdit(mainSelector, this.params['id']);
        });

        this.get('#/product/delete/:id', function () {
            loadHeader();
            controller.loadProductDelete(mainSelector, this.params['id']);
        });

        this.get('#/logout', function () {
            controller.logout();
        });

        function loadHeader(){
            return controller.loadHeader(menuSelector);
        }
    });

    app.router.run('#/');
})();