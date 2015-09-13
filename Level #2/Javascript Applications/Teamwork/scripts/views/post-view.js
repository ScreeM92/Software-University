var app = app || {};

app.postView = (function(){
    function PostView(selector, data){
        var deffer = Q.defer();

        $.get('templates/post.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).done(function(_data) {
            deffer.resolve(_data);
        }).fail(function(error) {
            deffer.reject(error);
        });

        return deffer.promise;
    }

    return {
        load: function (selector, data) {
            return PostView(selector, data);
        }
    }
}());