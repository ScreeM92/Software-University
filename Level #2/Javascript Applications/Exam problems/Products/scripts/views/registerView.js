var app = app || {};
app.views = app.views || {};

app.views.registerView = (function(){
    function registerView(selector) {
        var defer = Q.defer();

        $.get('templates/register.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp();
            $(selector).html(html);
        }).success(function(_data) {
            defer.resolve(_data);
        }).error(function(error) {
            defer.reject(error);
        });

        return defer.promise;
    }

    return {
        load: function (selector) {
            return registerView(selector);
        }
    }
}());