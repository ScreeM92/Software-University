var imdb = imdb || {};

(function (scope) {
    var Review = function () {
        function Review(author, content, date) {
            this._id = Review.id++;
            this.author = author;
            this.content = content;
            this.date = date;
        }

        Review.id = 1;

        return Review;
    }();


    scope.getReview = function (author, content, date) {
        return new Review(author, content, date);
    }

}(imdb));
