var app = app || {};
app._model = app._model || {};


app._model.products = (function(){
    var SERVICE_URL = 'classes/Post';

    function Products(ajaxRequester) {
        this._requester = ajaxRequester;
        this._products = {
            'products': []
        };
    }

    Products.prototype.getAllProducts = function(){
        var defer = Q.defer(),
            userId = app.credentials.getUserId(),
            _this = this;

        this._requester.get('classes/Product', app.credentials.getHeaders())
            .then(function(data){
                _this._products['products'].length = 0;

                $.each(data['results'], function(key, productData){
                    var product = {
                        objectId: productData.objectId,
                        name: productData.name,
                        category: productData.category,
                        price: productData.price,
                        owner: userId === productData.user.objectId,
                        createdAt: app.helpers.formatDate(productData['createdAt'])
                    };
                    _this._products['products'].push(product);
                });
                defer.resolve(_this._products);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    Products.prototype.getById = function(id){
        var defer = Q.defer();

        this._requester.get('classes/Product/' + id, app.credentials.getHeaders())
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Products.prototype.addProduct = function(data){
        var defer = Q.defer();

        this._requester.post('classes/Product', app.credentials.getHeaders(), data)
            .then(function(data){
                defer.resolve(data);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    Products.prototype.deleteProduct = function(id){
        var defer = Q.defer();

        this._requester.delete('classes/Product/' + id, app.credentials.getHeaders())
            .then(function(data){
                defer.resolve(data);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    Products.prototype.editProduct = function(id, data){
        var defer = Q.defer();

        this._requester.put('classes/Product/' + id, app.credentials.getHeaders(), data)
            .then(function(data){
                defer.resolve(data);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    Products.prototype.filterProducts = function(filters){
        var _this = this,
            defer = Q.defer(),
            userId = app.credentials.getUserId(),
            where = {
                category: {
                    '$in': [filters.category]
                },
                price: {
                    "$gte": filters.minPrice,
                    "$lte": filters.maxPrice
                }
            };

        this._requester.get('classes/Product?where=' + JSON.stringify(where), app.credentials.getHeaders())
            .then(function(data){
                _this._products['products'].length = 0;

                $.each(data['results'], function(key, productData){
                    if(productData.name.indexOf(filters.keyword) > -1){
                        var product = {
                            objectId: productData.objectId,
                            name: productData.name,
                            category: productData.category,
                            price: productData.price,
                            owner: userId === productData.user.objectId,
                            createdAt: app.helpers.formatDate(productData['createdAt'])
                        };

                        _this._products['products'].push(product);
                    }
                });

                defer.resolve(_this._products);
            }, function(error){
                defer.reject(error);
            });

        return defer.promise;
    };

    return {
        get: function (ajaxRequester) {
            return new Products(ajaxRequester);
        }
    }
}());