var app = app || {};

app.sidebarView = (function(){
    function SidebarView(selector, data){
        var deffer = Q.defer();
        
        $.get('templates/sidebar.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).done(function(_data) {
            deffer.resolve(_data);
        }).fail(function(error) {
            deffer.reject(error);
        });

        return deffer.resolve;
    }

    return {
        load: function (selector, data) {
            return SidebarView(selector, data);
        }
    }
}());