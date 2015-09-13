var app = app || {};

app.homeViews = (function() {
    function HomeViews() {
        this.welcomeView = {
            loadWelcomeView : loadWelcomeView
        };
        this.homeView = {
            loadHomeView : loadHomeView
        };
    }

    function loadWelcomeView (selector) {
        $.get('templates/welcome.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp();
            $(selector).html(html);
        })
    }

    function loadHomeView (selector, data) {
        $.get('templates/home.html', function(template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        })
    }

    return {
        load: function() {
            return new HomeViews();
        }
    }
}());