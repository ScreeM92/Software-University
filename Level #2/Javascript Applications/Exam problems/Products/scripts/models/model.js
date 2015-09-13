var app = app || {};

app.model = (function(){
    function Model(ajaxRequester){
        this.users = new app._model.users.get(ajaxRequester);
        this.products = new app._model.products.get(ajaxRequester);
    }

    return {
        get: function (ajaxRequester) {
            return new Model(ajaxRequester);
        }
    }
}());