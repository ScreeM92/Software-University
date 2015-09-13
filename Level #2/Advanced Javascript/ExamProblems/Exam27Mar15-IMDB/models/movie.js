var imdb = imdb || {};

(function(scope) {
    var Movie = function() {
        function Movie(title, length, rating, country) {
            this._id = Movie.id++;
            this.title = title;
            this.length = length;
            this.rating = rating;
            this.country = country;
            this._actors = [];
            this._reviews = [];
        }

        Movie.id = 1;

        Movie.prototype.addActor = function(actor) {
            this._actors.push(actor);
        }

        Movie.prototype.getActors = function() {
            return this._actors;
        }

        Movie.prototype.addReview = function(review) {
            this._reviews.push(review);
        }

        Movie.prototype.deleteReview = function(review) {
            this._reviews = this._reviews.filter(function(rev) { return rev !== review });
        }

        Movie.prototype.deleteReviewById = function(id) {
            this._reviews = this._reviews.filter(function(review) { return review._id !== id });
        }

        Movie.prototype.getReviews = function() {
            return this._reviews;
        }

        return Movie;
    }();

    scope.movie = Movie;
    scope.getMovie = function (title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }
}(imdb));