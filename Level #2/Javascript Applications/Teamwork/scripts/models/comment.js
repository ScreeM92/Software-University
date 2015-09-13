var app = app || {};
app._model = app._model || {};

app._model.comment = (function () {
    function Comment(ajaxRequster) {
        this._requester = ajaxRequster;
        this._comments = {
            comments: []
        };
    }

    Comment.prototype.createComment = function (data) {
        var defer = Q.defer();

        this._requester.post('classes/Comment', data)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };


    Comment.prototype.getComment = function () {
        var defer = Q.defer();
        var _this = this;
        this._comments['comments'].length = 0;

        this._requester.get('classes/Comment?include=post&order=createdAt')
            .then( function(data) {
                data['results'].forEach(function (comment) {
                    var comment = {
                        'objectId': comment.objectId,
                        'content': comment.content,
                        'author': comment.author,
                        'email': comment.email,
                        'likes': comment.likes,
                        'dislikes': comment.dislikes,
                        'post': {
                            __type: "Pointer",
                            className: "Post",
                            objectId: comment.postId
                        }
                    };
                    _this._comments['comments'].push(comment);
                });

                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Comment.prototype.getPostComments = function(postId){
        var defer = Q.defer();
        var _this = this;
        this._comments['comments'].length = 0;
        var where = {
            "post": {
                "__type": "Pointer",
                "className": "Post",
                "objectId": postId
            }
        };

        this._requester.get('classes/Comment?order=-createdAt&include=post,author&where=' + JSON.stringify(where))
            .then( function(data) {
                _.each(data['results'], function(dataComment){
                    dataComment['createdAt'] = formatDate(dataComment['createdAt']);
                    _this._comments['comments'].push(dataComment);
                });
                defer.resolve(_this._comments);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Comment.prototype.getPostCommentsCount = function (postId){
        var defer = Q.defer();
        var _this = this;
        var where = {
            "post": {
                "__type": "Pointer",
                "className": "Post",
                "objectId": postId
            }
        };

        this._requester.get('classes/Comment?count=1&limit=0&where=' + JSON.stringify(where))
            .then( function(data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    function formatDate(isoString) {
        var timestamp = new Date(Date.parse(isoString)),
            months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            hours = timestamp.getHours() > 9 ? timestamp.getHours() : '0' + timestamp.getHours(),
            minutes = timestamp.getMinutes() > 9 ? timestamp.getMinutes() : '0' + timestamp.getMinutes();

        return timestamp.getDate() + '-' + months[timestamp.getMonth()] + '-' + timestamp.getFullYear()
            + ' ' + hours  + ':' + minutes;
    }

    return {
        get: function (ajaxRequester) {
            return new Comment(ajaxRequester);
        }
    }
})();