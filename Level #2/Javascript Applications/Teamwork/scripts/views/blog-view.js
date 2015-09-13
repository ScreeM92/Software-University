var app = app || {};

app.blogView = function () {
    function BlogView(selector, data, page, pagePosts) {
        var deffer = Q.defer();

        $.get('templates/blog-view.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).then(function () {
            if (data['count'] > 0) {
                $('#pagination').pagination({
                    items: data['count'],
                    itemsOnPage: pagePosts,
                    cssStyle: 'light-theme',
                    hrefTextPrefix: '#/blog/page/'
                }).pagination('selectPage', page);
            }
        }).done(function(_data) {
            deffer.resolve(_data);
        }).fail(function (error) {
            deffer.reject(error);
        });

        return deffer.promise;
    }

    return {
        load: function (selector, data, page, pagePosts) {
            return BlogView(selector, data, page, pagePosts);
        }
    }
}();
