var imdb = imdb || {};

(function(scope) {
    var Genre = function() {
        function Genre(name) {
            this._id = Genre.id++;
            this.name = name;
            this._movies = [];
        }

        Genre.id = 1;

        Genre.prototype.addMovie = function(movie) {
            this._movies.push(movie);
        };

        Genre.prototype.getMovies = function() {
            return this._movies;
        }

        Genre.prototype.deleteMovie = function(movie) {
            this._movies = this._movies.filter(function(mov) {
                return mov !== movie;
            });
        };

        Genre.prototype.deleteMovieById = function(id) {
            this._movies = this._movies.filter(function(movie) {
                return movie.getId() !== id;
            });
        };

        return Genre;
    }();

    scope.getGenre = function(name) {
        return new Genre(name);
    }
}(imdb));
