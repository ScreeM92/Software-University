var imdb = imdb || {};

(function (scope) {
    var Actor = function() {
        function Actor(name, bio, born) {
            this._id = Actor.id++;
            this.name = name;
            this.bio = bio;
            this.born = born;
        }

        Actor.id = 1;

        return Actor;
    }();

    scope.getActor = function(name, bio, born) {
        return new Actor(name, bio, born);
    }

}(imdb));
