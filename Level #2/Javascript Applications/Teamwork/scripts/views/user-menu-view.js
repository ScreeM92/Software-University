var app = app || {};

app.userMenuView = (function(){
    function UserMenuView(selector, data) {
        var deffer = Q.defer();

        $.get('templates/user-menu.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).done(function(data) {
            deffer.resolve(data);
        }).fail(function (error) {
            deffer.reject(error);
        });

        return deffer.promise;
    }

    return {
        load: function (selector, data) {
            return UserMenuView(selector, data);
        }
    }
}());