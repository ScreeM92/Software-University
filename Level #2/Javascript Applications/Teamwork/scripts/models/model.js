var app = app || {};

app.model = function () {
    function Model(ajaxRequester) {
        this.user = app._model.user.get(ajaxRequester);
        this.post = app._model.post.get(ajaxRequester);
        this.comment = app._model.comment.get(ajaxRequester);
        this.sidebar = app._model.sidebar.get(ajaxRequester);
        this.tag = app._model.tag.get(ajaxRequester);
    }

    return {
        get: function (ajaxRequester) {
            return new Model(ajaxRequester);
        }
    }
}();