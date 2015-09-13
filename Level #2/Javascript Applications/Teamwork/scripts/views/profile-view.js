var app = app || {};

app.profileView = (function(){
    function ProfileView(selector, data) {
        var deffer = Q.defer();

        $.get('templates/profile-page.html', function(template) {
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
            return ProfileView(selector, data);
        }
    }
}());