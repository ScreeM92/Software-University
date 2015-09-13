var app = app || {};

app.controller = (function () {
    function Controller(model) {
        this._model = model;
    }

    Controller.prototype.loadHeader = function(headerSelector){
        var isLogged = {
                isLogged: false
            };

        if(this._model.users.isLogged()){
            isLogged.isLogged = true;
        }

        return  app.views.menuView.load(headerSelector, isLogged);
    };

    Controller.prototype.loadHome = function(selector){
        var _isLogged = {
            isLogged: false
        };

        if(this._model.users.isLogged()){
            _isLogged.isLogged = true;

        }

        return app.views.homeView.load(selector, _isLogged);
    };

    Controller.prototype.loadLogin = function(selector){
        if(!this._model.users.isLogged()){
            app.views.loginView.load(selector);
        } else {
            window.location.replace('#/');
            Noty.error('Already logged in!');
        }

    };

    Controller.prototype.loadRegister = function(selector){
        if(!this._model.users.isLogged()){
            app.views.registerView.load(selector);
        } else {
            this.redirectTo('#/');
            Noty.error('Can\'t register while logged in!');
        }
    };

    Controller.prototype.loadProductAdd = function(selector){
        if(this._model.users.isLogged()){
            app.views.productAddView.load(selector);
        } else {
            this.redirectTo('#/');
            Noty.error('You have to login to add a new product!');
        }
    };

    Controller.prototype.loadProductEdit = function(selector, productId){
        if(this._model.users.isLogged()){
            this._model.products.getById(productId)
                .then(function(data){
                    app.views.productEditView.load(selector, data);
                }, function(){
                    Noty.error('Error retrieving product data. Please try again.');
                });

        } else {
            this.redirectTo('#/');
            Noty.error('You have to login to view this page!');
        }
    };

    Controller.prototype.loadProductDelete = function(selector, productId){
        if(this._model.users.isLogged()){
            this._model.products.getById(productId)
                .then(function(data){
                    app.views.productDeleteView.load(selector, data);
                }, function(){
                    Noty.error('Error retrieving product data. Please try again.');
                });

        } else {
            this.redirectTo('#/');
            Noty.error('You have to login to view this page!');
        }
    };

    Controller.prototype.logout = function(){
        var _this = this;

        if(this._model.users.isLogged()){
            this._model.users.logout()
                .then(function(){
                    _this.redirectTo('#/');
                    Noty.success('Successfully logged out.');
                });
        } else {
            Noty.error('Already logged out.');
            this.redirectTo('#/')
        }
    };

    Controller.prototype.loadProducts = function(selector){
        var _this = this,
            categories = [];

        if(this._model.users.isLogged()){
            _this._model.products.getAllProducts()
                .then(function(data){
                    $.each(data.products, function(key, value){
                        categories.push(value.category);
                    });
                    data.categories =  $.unique(categories);
                    app.views.productsView.load(selector, data);
                }, function(){

                });

        } else {
            this.redirectTo('#/');
            Noty.error('You have to login to see this page!');
        }
    };

    Controller.prototype.redirectTo = function(url) {
        window.location = url;
    };


    Controller.prototype.attachEventHandlers = function() {
        var selector = '#main';
        attachRegisterHandler.call(this, selector);
        attachLoginHandler.call(this, selector);
        attachProductHandler.call(this, selector);
        attachAddProductHandler.call(this, selector);
        attachEditProductHandler.call(this, selector);
        attachDeleteProductHandler.call(this, selector);
    };

    var attachDeleteProductHandler = function(selector){
        var _this = this;

        $(selector).on('click', '#delete-product-button', function () {
            var id = $(this).attr('product-id');

            _this._model.products.deleteProduct(id)
                .then(function(){
                    Noty.success('Product successfully deleted.');
                    _this.redirectTo('#/products');
                }, function(){
                    Noty.error('Your product edit has encountered an error.');
                });


            return false;
        })
    };

    var attachProductHandler = function(selector){
        var _this = this;

        $(selector).on('click', '.edit-button', function () {
            _this.redirectTo('#/product/edit/' + $(this).attr('product-id'));

            return false;
        });

        $(selector).on('click', '.delete-button', function () {
            _this.redirectTo('#/product/delete/' + $(this).attr('product-id'));

            return false;
        });

        $(selector).on('click', '#clear-filters', function () {
            //$('.filters form')[0].reset();
            _this.loadProducts(selector);

            return false;
        });

        $(selector).on('click', '.filter-button', function () {
            var filters = {
                keyword: $('#search-bar').val(),
                minPrice: Number($('#min-price').val()),
                maxPrice: Number($('#max-price').val()),
                category: $('#category').val()
            };

            _this._model.products.filterProducts(filters)
                .then(function(data){
                    console.log(data);
                    app.views.productsView.load(selector, data);
                });



            return false;
        });

    };

    var attachEditProductHandler = function(selector){
        var _this = this;

        $(selector).on('click', '#edit-product-button', function () {
            var productData = {
                    name: $('#item-name').val(),
                    category: $('#category').val(),
                    price: Number($('#price').val())
                },
                id = $(this).attr('product-id');;

            if(!productData.name || !productData.category || !productData.price) {
                Noty.error('No empty fields allowed!');
            } else {
                _this._model.products.editProduct(id, productData)
                    .then(function(){
                        Noty.success('Product successfully edited.');
                        _this.redirectTo('#/products');
                    }, function(){
                        Noty.error('Your product edit has encountered an error.');
                    });
            }

            return false;
        })
    };

    var attachAddProductHandler = function(selector){
        var _this = this;

        $(selector).on('click', '#add-product-button', function () {
            var productData = {
                name: $('#name').val(),
                category: $('#category').val(),
                price: Number($('#price').val()),
                "ACL": {"*":{"read":true}}
            };

            if(!productData.name || !productData.category || !productData.price) {
                Noty.error('No empty fields allowed!');
            } else {
                _this._model.users.getCurrentUserData()
                    .then(function(user){
                        productData.user = {
                            "__type": "Pointer",
                            "className": "_User",
                            "objectId": user.userId
                        };
                        productData.ACL[user.userId] = {"write":true,"read":true};

                        _this._model.products.addProduct(productData)
                            .then(function(){
                                Noty.success('Product successfully created.');
                                _this.redirectTo('#/products');
                            }, function(){
                                Noty.error('Your product submit has encountered an error.');
                            });
                    });
            }

            return false;
        });
    };

    var attachRegisterHandler = function (selector) {
        var _this = this;

        $(selector).on('click', '#register-button', function () {
            var userData = {
                username: $('#username').val(),
                password: $('#password').val()
            };

            if(!userData.username || !userData.password){
                Noty.error('Username and password cannot be empty.');
            } else if(userData.password !== $('#confirm-password').val()){
                Noty.error('Passwords must be identical.');
            } else {
                _this._model.users.register(userData)
                    .then(function () {
                        Noty.success('Registration successful.');
                        _this.redirectTo('#/');
                    }, function (error) {
                        Noty.error('Your registration has encountered an error.');
                        _this.redirectTo('#/');
                    });
            }

            return false;
        });
    };

    var attachLoginHandler = function(selector){
        var _this = this;

        $(selector).on('click', '#login-button', function(){
            var userData = {
                username : $('#username').val(),
                password : $('#password').val()
            };

            _this._model.users.login(userData.username, userData.password)
                .then(function(){
                    Noty.success('Successfully logged in.');
                    _this.redirectTo('#/');
                }, function(){
                    Noty.error('Incorrect username/password.');
                    _this.redirectTo('#/');
                });

            return false;
        });
    };

    return {
        get: function (model) {
            return new Controller(model);
        }
    }
}());