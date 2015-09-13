var imdb = imdb || {};

(function (scope) {
    var Theatre = function() {
        function Theatre(name, lenght, ratinrg, country, isPuppet) {
            scope.movie.call(this, name, lenght, ratinrg, country);
            this.isPuppet = isPuppet ? isPuppet : false;
        }

        Theatre.extends(scope.movie);

        return Theatre;
    }();

    scope.getTheatre = function (name, lenght, ratinrg, country, isPuppet) {
        return new Theatre(name, lenght, ratinrg, country, isPuppet);
    }
}(imdb));