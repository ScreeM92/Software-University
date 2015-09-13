var app = app || {};

app.userView = (function(){
    function UserView(selector, data) {
        var deffer = Q.defer();

        $.get('templates/user.html', function(template) {
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
            return UserView(selector, data);
        }
    }
}());