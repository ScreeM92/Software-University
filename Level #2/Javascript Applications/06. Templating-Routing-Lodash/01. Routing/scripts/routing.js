$(document).ready(function() {
    var app = app || {};

    (function() {
        app.router = Sammy(function() {
            var selector = $('#main');

            this.get('#/', function() {
                $(selector).load('templates/home.html');
            });

            this.get('#/Sam', function () {
                $(selector).load('templates/sam.html');
            });

            this.get('#/Bob', function () {
                $(selector).load('templates/bob.html');
            });
        });

        app.router.run('#/');
    }());

    
});