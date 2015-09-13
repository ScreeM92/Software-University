var app = app || {};

app.commentView = (function () {
    function CommentView(selector, data) {
        var defer = Q.defer();

        $.get('templates/comment-view.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).success(function (data) {
            defer.resolve(data);
        }).error(function (error) {
            defer.reject(error);
        });
        return defer.promise;
    }

    return {
        load: function (selectors, data) {
            return CommentView(selectors, data);
        }
    }
}());