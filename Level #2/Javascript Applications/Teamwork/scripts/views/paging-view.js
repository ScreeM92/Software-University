var app = app || {};

app.pagingView = (function(){
    function PagingView(selector, data, activePage) {
        var deffer = Q.defer();

        $.get('templates/paging.html', function(template) {
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
        load: function (selector, data, activePage) {
            return PagingView(selector, data, activePage);
        }
    }
}());