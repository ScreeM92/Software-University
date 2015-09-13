var app = app || {};
app._model = app._model || {};

app._model.post = (function () {
    function Post(ajaxRequester) {
        this._requester = ajaxRequester;
        this._posts = {
            posts: []
        }
    }

    Post.prototype.getAuthor = function () {
        var defer = Q.defer();
        this._requester.get('sessions/me')
            .then(function (sessionData) {
                defer.resolve(sessionData.user);
            }, function (error) {
                defer.reject(error.responseText);
            });
        return defer.promise;
    };

    Post.prototype.createPost = function (data) {
        var defer = Q.defer();
        var _this = this;
        this.getAuthor()
            .then(function (author) {
                data.author = author;
               // var id = data.headerImage.objectId;
                //data.headerImage = {
                //    "__type": "Pointer",
                //    "className": "HeaderPicture",
                //    "objectId": id
                //};
                _this._requester.post('classes/Post', data)
                    .then(function(_data){
                        defer.resolve(_data);
                    }, function(error){
                        console.log(error.responseText);
                    });
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    Post.prototype.getPosts = function (url) {
        var defer = Q.defer();
        var _this = this;
        this._posts['posts'].length = 0;

        this._requester.get(url)
            .then(function (data) {
                data['results'].forEach(function (dataPost) {
                    var post = {
                        'objectId': dataPost.objectId,
                        'title': dataPost.title,
                        'content': dataPost.content,
                        'headerImage': dataPost.headerImage,
                        'contentSummary': dataPost.contentSummary,
                        'tags': dataPost.tags,
                        'visitsCount': dataPost.visitsCount,
                        'author': dataPost.author.username,
                        'authorId': dataPost.author.objectId,
                        'createdAt': formatDate(dataPost.createdAt)
                        //'createdAt': new Date(dataPost.createdAt).toLocaleString()
                    };

                    //if(dataPost.headerImage){
                    //    post.image = dataPost.headerImage.url;
                    //}
                    _this._posts['count'] = data['count'];
                    _this._posts['posts'].push(post);
                });

                defer.resolve(_this._posts);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Post.prototype.getPostsCount = function(url){
        var defer = Q.defer();
        var _this = this;

        this._requester.get(url)
            .then(function (data) {
                defer.resolve(data.count);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Post.prototype.getPost = function(id){
        var defer = Q.defer();
        var _this = this;
        this._posts['posts'].length = 0;

        this._requester.get('classes/Post/' + id + '?include=author,headerImage')
            .then(function (dataPost) {
                var post = {
                    'objectId': dataPost.objectId,
                    'title': dataPost.title,
                    'headerImage': dataPost.headerImage,
                    'content': dataPost.content,
                    'tags': dataPost.tags,
                    'author': dataPost.author,
                    'visitsCount': dataPost.visitsCount,
                    'createdAt': formatDate(dataPost.createdAt)
                };

                //if(dataPost.headerImage){
                //    post.image = dataPost.headerImage.url;
                //}
                _this._posts['posts'].push(post);

                defer.resolve(_this._posts);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    };

    Post.prototype.uploadHeader = function(file){
        var defer = Q.defer();
        var _this = this;

        this._requester.postFile('files/', file)
            .then(function (fileData) {
                var data = {
                    url: fileData.url,
                    name: fileData.name
                };
                _this._requester.post('classes/HeaderPicture', data)
                    .then(function(headerImage){
                        defer.resolve(headerImage);
                    }, function(error){
                        defer.reject(error);
                    });

            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    Post.prototype.visitsIncrement = function(postId){
        var defer = Q.defer();

        var data = {
              "postId": postId
        };

        this._requester.post('functions/incrementViewCount', data)
            .then(function () {
                defer.resolve('success');
            }, function (error) {
                defer.reject(error);
            });
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
            return new Post(ajaxRequester);
        }
    }
}());