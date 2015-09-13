var app = app || {};

app.loginView = (function(){
    function LoginView(selector) {
        var deffer = Q.defer();

        $.get('templates/login.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp();
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
            return LoginView(selector, data);
        }
    }
}());