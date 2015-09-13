var app = app || {};
app._model = app._model || {};

app._model.tag = (function(){
    function Tag(ajaxRequester){
        this._requester = ajaxRequester;
        this._postsByTag = {
            posts: []
        };
    }

    Tag.prototype.getPostsByTag = function(tag){
        var defer = Q.defer();
        var _this = this;
        this._postsByTag['posts'].length = 0;
        var where = {
            'tags_lower': tag.toLowerCase()
        };

        this._requester.get('classes/Post?where=' + JSON.stringify(where) + '&include=author,headerImage')
            .then(function (data) {
                data['results'].forEach(function (dataPost) {
                    var post = {
                        'objectId': dataPost.objectId,
                        'title': dataPost.title,
                        'headerImage': dataPost.headerImage,
                        'content': dataPost.content,
                        'contentSummary': dataPost.contentSummary,
                        'tags': dataPost.tags,
                        'author': dataPost.author.username,
                        'authorId': dataPost.author.objectId,
                        'createdAt': formatDate(dataPost.createdAt),
                        'visitsCount': dataPost.visitsCount
                    };
                    _this._postsByTag['posts'].push(post);
                });

                defer.resolve(_this._postsByTag);
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
            return new Tag(ajaxRequester);
        }
    }
}());