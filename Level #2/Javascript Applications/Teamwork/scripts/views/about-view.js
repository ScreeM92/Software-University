var app = app || {};

app.aboutView = (function(){
    function AboutView(selector, data) {
        var deffer = Q.defer();

        $.get('templates/about.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).done(function(data) {
            deffer.resolve(data);
        }).fail(function(error) {
            deffer.reject(error);
        });

        return deffer.promise;
    }

    return {
        load: function (selector, data) {
            return AboutView(selector, data);
        }
    }
})();