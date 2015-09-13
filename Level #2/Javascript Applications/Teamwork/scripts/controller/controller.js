var app = app || {};

app.controller = (function () {
    function Controller(model) {
        this.model = model;
    }

    Controller.prototype.loadMenu = function (selector) {
        //$(selector).empty();
        var _this = this;
        if (sessionStorage['logged-in']) {
            this.model.user.isAdmin(sessionStorage['id'])
                .then(function (data) {
                    app.userMenuView.load(selector, data)
                        .then(function () {
                            _this.attachLogoutEvents('#logout a');
                            _this.attachSearchEvents('#search');
                        });
                }, function (error) {
                    console.log(error.responseText);
                });
        } else {
            app.menuView.load(selector)
                .then(function () {
                    _this.attachSearchEvents('#search');
                });
        }

        this.attachUpToTopEvents();
    };

    Controller.prototype.attachUpToTopEvents = function(){
        //Show up-to-top button
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#up-to-top').fadeIn();
            } else {
                $('#up-to-top').fadeOut();
            }

            return false;
        });

        $("html, body").bind("scroll mousedown DOMMouseScroll mousewheel keyup", function(){
            $('html, body').stop();
        });

        //Animate move to top
        $(document).on('click', '#up-to-top a', function (e) {
            $('html, body').animate({ scrollTop: 0 }, 800);

            return false;
        });
    }

    Controller.prototype.attachSearchEvents = function (selector) {
        $(selector).click(function () {
            var tag = $('#search-input').val().trim();
            if (tag) {
                window.location.replace('#/tag/' + tag);
            }
        });

        $(document).on('keyup', '#search-form', function (event) {
            event.preventDefault();
            if (event.keyCode === 13) {
                $(selector).trigger('click');
            }
        });

        $(document).on('keypress', '#search-form', function (event) {
            return event.keyCode !== 13;
        });
    };

    Controller.prototype.getLoginPage = function (selector) {
        var _this = this;
        $(selector).empty();
        app.loginView.load(selector)
            .then(function () {
                _this.attachLoginEvents('#login-btn');
                $('#register-btn').click(function () {
                    window.location.replace('#/register');
                })
            })
    };

    Controller.prototype.attachLoginEvents = function (selector) {
        var _this = this;
        $(selector).click(function () {
            var username = ($("input[id=login-username]").val());
            var password = ($("input[id=login-password]").val());

            _this.model.user.logIn(username, password)
                .then(function (data) {
                    sessionStorage['username'] = data.username;
                    sessionStorage['logged-in'] = data.sessionToken;
                    sessionStorage['id'] = data.objectId;
                    window.location.replace('#/blog/page/1');
                    Noty.success('Successfully logged in!');
                },
                function (errorData) {
                    Noty.error(JSON.parse(errorData.responseText).error);
                });
        });
    };

    Controller.prototype.attachLogoutEvents = function (selector) {
        var _this = this;
        $(selector).click(function () {
            _this.model.user.logOut()
                .then(function () {
                    sessionStorage.clear();
                    window.location.replace('#/about');
                    _this.loadMenu('nav');
                    Noty.success('Goodbye!');
                },
                function (errorData) {
                    Noty.error(JSON.parse(errorData.responseText).error);
                });
        });
    };

    Controller.prototype.getProfilePage = function (selector) {
        var _this = this;
        app.profileView.load(selector)
            .then(function () {
                _this.attachProfilePageEvents('#save-btn');
                var userId = sessionStorage['id'];
                _this.model.user.getUserById(userId)
                    .then(function (data) {
                        $('#username').val(data.username);
                        $('#email').val(data.email);
                        $('#firstName').val(data.firstName);
                        $('#middleName').val(data.middleName);
                        $('#lastName').val(data.lastName);
                        $("#gender").val(data.gender);
                        _this.model.user.getProfilePicture(userId)
                            .then(function(picture){
                                if(picture.profilePicture.results.length > 0){
                                    $('.picture-preview').attr('src', picture.profilePicture.results[0].imageUrl);
                                } else {
                                    $('.picture-preview').attr('src', 'resources/default-avatar.png');
                                }

                            }, function(err){
                                Noty.error(JSON.parse(err.responseText).error);
                            });

                    }, function (error) {
                        Noty.error(JSON.parse(error.responseText).error);
                    });
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            })
    };

    Controller.prototype.attachProfilePageEvents = function (selector) {
        var _this = this;

        $(selector).click(function () {
            var userData = {
                username: $("input[id=username]").val(),
                email: $("input[id=email]").val(),
                firstName: $("input[id=firstName]").val(),
                middleName: $("input[id=middleName]").val(),
                lastName: $("input[id=lastName]").val(),
                gender: $("#gender").val()
            };
            if ($('#password').val()) {
                userData['password'] = $("input[id=password]").val();
            }

            _this.model.user.updateUser(sessionStorage['id'], userData)
                .then(function () {
                    window.location.replace('#/blog/page/1');
                    Noty.success('Profile edited successfully.');
                }, function () {
                    Noty.error('Error saving changes. Please try again.');
                });
        });

        _this.attachPictureUploadEvents('#upload-file-button');

        $('#cancel-btn').click(function () {
            window.location.replace('#/blog/page/1');
        });
    };

    Controller.prototype.attachPictureUploadEvents = function (selector) {
        var file;
        var _this = this;

        $('#picture').bind("change", function (e) {
            var files = e.target.files || e.dataTransfer.files;
            file = files[0];
        });

        $(selector).click(function () {
            if (file) {
                var serverUrl = 'https://api.parse.com/1/files/' + file.name;

                $.ajax({
                    method: "POST",
                    headers: {
                        'X-Parse-Application-Id': 'gBxtJ8j1z5sRZhOgtAstvprePygEIvYTxY4VNQOY',
                        'X-Parse-REST-API-Key': 'CLU5dIerpE1k9zX06HiR3RxJQA3Vob2NgJarCl4z',
                        'Content-Type': file.type
                    },
                    url: serverUrl,
                    data: file,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        var pictureData = {
                            "imageUrl": data.url,
                            "profilePicture": {
                                "name": data.name,
                                "__type": "File"
                            },
                            "username": sessionStorage['username'],
                            "user": {
                                "__type": "Pointer",
                                "className": "_User",
                                "objectId": sessionStorage['id']
                            }
                        };

                        _this.model.user.uploadProfilePicture(pictureData)
                            .then(function(pictureData){
                                _this.model.user.getProfilePicture(sessionStorage['id'])
                                    .then(function(picture){
                                        Noty.success('Upload Successful');
                                        var userData = {
                                            profilePicture : {
                                                __type: "Pointer",
                                                className: "Picture",
                                                objectId: picture.profilePicture.results[0].objectId
                                            }
                                        };
                                        _this.model.user.updateUser(sessionStorage['id'],userData)
                                            .then(function(user){
                                            }, function(error){
                                                console.log(error.responseText);
                                            });
                                        $('.picture-preview').attr('src', picture.profilePicture.results[0].imageUrl);
                                    }, function(response){
                                        Noty.error(JSON.parse(response.responseText).error);
                                    });
                            }, function(error){
                                Noty.error(JSON.parse(error.responseText).error);
                            });
                    },
                    error: function (err) {
                        Noty.error(JSON.parse(err.responseText).error);
                    }
                });
            }
        });
    };

    Controller.prototype.getRegisterPage = function (selector) {
        var _this = this;
        app.registerView.load(selector)
            .then(function () {
                _this.attachRegisterEvents('#reg-btn');
                $('#login-btn').click(function () {
                    window.location.replace('#/login');
                })
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            })
    };

    Controller.prototype.attachRegisterEvents = function (selector) {
        var _this = this;
        _this.attachPictureUploadEvents('#upload-file-button');

        $("input[id=reg-username]").keyup(function () {
            var $input =  $("input[id=reg-username]").val();
            var isUnique = true;
            if(validation.checkUsernameForLength($input)) {
                $('#usernameCheck').empty();
                _this.model.user.getUsers()
                    .then(function (data) {
                        data.users.forEach(function(key) {
                           if(key.username.toLowerCase() == $input.toLowerCase()) {
                                isUnique = false;
                           }
                        });
                        if(!isUnique) {
                            validation.hideRegistrationButton();
                            $('#usernameCheck').html('Username is already taken.').css({
                                "background-color": "red",
                                "font-weight": "bold",
                                "color": "white"
                            });
                        } else {
                            validation.showRegistrationButton();
                            $('#usernameCheck').html('Username is available.').css({
                                "background-color": "green",
                                "font-weight": "bold",
                                "color": "white"
                            })
                        }
                    });

            } else if ($input.length == 0) {
                $('#usernameCheck').empty();
            } else if($input) {
                $('#usernameCheck').html('Username is too short.').css({
                    "background-color": "red",
                    "font-weight": "bold",
                    "color": "white"
                })
            }
        });

        $("input[id=reg-password], input[id=repeat-password]").keyup(function () {
            var $input = $("input[id=reg-password]").val();
            var $resultLabel = $('#resultLabel');
            var $result = $('#result');
            if ($input.length >= 6) {
                var passwordStrength = validation.checkPasswordStrength($input);
                switch (passwordStrength) {
                    case 'weak':
                        $resultLabel.show();
                        $result.show();
                        $result.html(passwordStrength).css({"background-color": "red"});
                        break;

                    case 'medium':
                        $resultLabel.show();
                        $result.show();
                        $result.html(passwordStrength).css({"background-color": "deepskyblue"});
                        break;

                    case 'good':
                        $resultLabel.show();
                        $result.show();
                        $result.html(passwordStrength).css({"background-color": "blue"});
                        break;

                    case 'strong':
                        $resultLabel.show();
                        $result.show();
                        $result.html(passwordStrength).css({"background-color": "green"});
                        break;

                    case 'excellent':
                        $resultLabel.show();
                        $result.show();
                        $result.html(passwordStrength).css({"background-color": "greenyellow"});
                        break;
                }
            } else if($input.length == 0 ) {
                $resultLabel.hide();
                $result.hide();
            } else {
                $result.html('Password is too short').css({
                    "background-color": "red",
                    "font-weight": "bold",
                    "color": "white"
                });
                validation.hideRegistrationButton();
            }
        });

        $("input[id=repeat-password], input[id=reg-password]").keyup(function () {
            if (!validation.checkIfPasswordsMatch($("input[id=repeat-password]").val(), $("input[id=reg-password]").val())) {
                $('#passwordMatch').html('Both passwords do not match.').css({
                    "background-color": "red",
                    "font-weight": "bold",
                    "color": "white"
                });
                validation.hideRegistrationButton();
            } else {
                $('#passwordMatch').empty();
            }
        });

        $("input[id=reg-email]").keyup(function () {
            var $input = $("input[id=reg-email]").val();
            var isValid = validation.checkEmail($input);
            if($input.length == 0) {
                $('#checkEmail').empty();
            } else if(isValid === null) {
                validation.hideRegistrationButton();
                $('#checkEmail').html('This email is NOT valid').css({
                    "background-color": "red",
                    "font-weight": "bold",
                    "color": "white"
                });
            } else {
                var isUnique = true;
                _this.model.user.getUsers()
                    .then(function (data) {
                        data.users.forEach(function(key) {
                            if(key.email && key.email.toLowerCase() == $input.toLowerCase()) {
                                isUnique = false;
                            }
                        });

                        if(!isUnique) {
                            validation.hideRegistrationButton();
                            $('#checkEmail').html('This email is already taken!').css({
                                "background-color": "red",
                                "font-weight": "bold",
                                "color": "white"
                            });
                        } else {
                            validation.showRegistrationButton();
                            $('#checkEmail').html('This email is available!').css({
                                "background-color": "green",
                                "font-weight": "bold",
                                "color": "white"
                            });
                        }
                    });
            }
        });

        $(selector).click(function () {
            var userRegData = {
                username: $("input[id=reg-username]").val(),
                password: $("input[id=reg-password]").val(),
                passwordRepeat: $("input[id=repeat-password]").val(),
                email: $("input[id=reg-email]").val()
            };
            _this.model.user.register(userRegData)
                .then(function (data) {
                    Noty.success('Registration Successful');
                    sessionStorage['logged-in'] = data.sessionToken;
                    sessionStorage['id'] = data.objectId;
                    window.location.replace('#/blog/page/1');
                }, function (error) {
                    Noty.error(JSON.parse(error.responseText).error);
                })
        });
    };

    Controller.prototype.getAddPostPage = function (selector) {
        var _this = this;

        if(sessionStorage['logged-in']) {
            this.model.user.isAdmin(sessionStorage['id'])
                .then(function (data) {
                    if (data.result) {
                        app.postArticle.load(selector)
                            .then(function () {
                                _this.attachAddPostEvents('#postArticle');
                            });
                    }
                }, function (error) {
                    console.log(error.responseText);
                });
        }
    };

    Controller.prototype.loadPosts = function(selector, page, pagePosts){
        var _this = this;

        this.model.post.getPosts('classes/Post?count=1&limit=' + pagePosts + '&skip=' + ((page - 1) * pagePosts)  + '&include=author,headerImage&order=-createdAt')
            .then(function (data) {
                app.blogView.load(selector, data, page, pagePosts)
                    .then(function(){
                        _.each(data.posts, function (p) {
                            _this.model.comment.getPostCommentsCount(p.objectId)
                                .then(function (c) {
                                    $('article#' + p.objectId + ' .comments-count').text(c.count);
                                }, function (error) {
                                    Noty.error(JSON.parse(error.responseText).error);
                                });
                        });
                    });
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            });
    };

    Controller.prototype.attachCommentEvents = function (selector, commentsSelector) {
        var _this = this;

        $(selector).click(function(event){
            var id = event.target['id'];
            var data = {
                author: {
                    "__type": "Pointer",
                    "className": "_User",
                    "objectId": sessionStorage['id']
                },
                content: $('#content').val(),
                'post': {
                    __type: "Pointer",
                    className: "Post",
                    objectId: id
                }
            };

            $('#comment-form-toggle').trigger('click');

            // bad words censorship
            $.ajaxSetup({
                async: false
            });
            var badWords = [];
            var currentWords = data.content.split(' ');
            $.getJSON('scripts/helpers/lang.json', function (data) {
                $.each(data['words'], function (key, value) {
                    badWords.push(value);
                });
            });
            for (var i = 0; i < badWords.length; i++) {
                for (var j = 0; j < currentWords.length; j++) {
                    if (currentWords[j].toLowerCase() == badWords[i].toLowerCase()) {
                        currentWords[j] =  '****';
                    }
                }
            }
            $.ajaxSetup({
                async: true
            });
            data.content = currentWords.join(' ');
            // end of bad words censorship
            if(data.content.length >= 10) {
                _this.model.comment.createComment(data)
                    .then(function () {
                        Noty.success('Comment posted successfully.');
                        _this.model.comment.getPostComments(id)
                            .then(function (commentsData) {
                                $(commentsSelector).empty();
                                $('#comment-form')[0].reset();
                                app.commentView.load(commentsSelector, commentsData);
                            }, function (error) {
                                Noty.error(JSON.parse(error.responseText).error);
                            });
                    }, function (error) {
                        var errorCode = JSON.parse(error.responseText).code;
                        if (errorCode === 119) {
                            Noty.error("Only users can leave a comment.");
                        } else {
                            console.log(error);
                            Noty.error(JSON.parse(error.responseText).error);
                        }
                    });
            } else {
                Noty.error('Your comment is not long enough.');
            }

            return false;
        });
    };

    Controller.prototype.attachAddPostEvents = function (selector) {
        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

        $(document).ready(function () {
            $('.btn-file :file').on('fileselect', function (event, numFiles, label) {

                var input = $(this).parents('.input-group').find(':text'),
                    log = numFiles > 1 ? numFiles + ' files selected' : label;

                if (input.length) {
                    input.val(log);
                } else {
                    if (log) alert(log);
                }
            });
        });

        var _this = this,
            file;

        $('#upload-file-button').bind("change", function (e) {
            var files = e.target.files || e.dataTransfer.files;
            file = files[0];
        });

        $(selector).click(function () {
            var uniqueTags = [];

            $.each($('.tag span'), function(s, value){
                if($(value).text().trim() !== ""){
                    uniqueTags.push($(value).text().trim());
                }
            });

            var content = $("textarea[id=content]").val();

            var _data = {
                title: $("input[id=title]").val(),
                content: content,
                contentSummary: content.length > 300 ? content.substring(0, 300) + '...'  : content,
                visitsCount: 0,
                tags: uniqueTags,
                tags_lower: _.map(uniqueTags, function (tag) {
                    return _.isString(tag) ? tag.toLowerCase() : tag;
                })
            };

            $('#post-form')[0].reset();

			if(file){
                _this.model.post.uploadHeader(file, _data)
                    .then(function(headerPicture){
                        _data.headerImage = {
                            "__type": "Pointer",
                            "className": "HeaderPicture",
                            "objectId": headerPicture.objectId
                        };
                        createPost();
                    })
            } else{
                createPost();
            }

            file = undefined;

            function createPost(){
                _this.model.post.createPost(_data)
                    .then(function () {
                        $('#posts').empty();
                        _this.model.post.getPosts('classes/Post?include=author,headerImage&order=-createdAt&limit=5&skip=0')
                            .then(function (data) {
                                Noty.success('Article posted successfully');
                                window.location.replace('#/blog/page/1');
                            }, function (error) {
                                Noty.error(JSON.parse(error.responseText).error);
                            })
                    }, function (error) {
                        Noty.error(JSON.parse(error.responseText).error);
                    })
            }
        });
    };

    Controller.prototype.getAboutPage = function (selector) {
        $(selector).empty();
        app.aboutView.load(selector);
    };

    Controller.prototype.getSidebar = function (selector, tagsFunction, tagsClassName, tagsLimit) {
        //$(selector).empty();

        this.model.sidebar.getLatestPosts()
            .then(function (data) {
                app.sidebarView.load('#latestPosts', data);
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            });

        var data = {
            'className': tagsClassName,
            'limit': tagsLimit
        };

        this.model.sidebar.getMostPopularTags(tagsFunction, data)
            .then(function (data) {
                app.sidebarView.load('#mostPopularTags', data);
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            });
    };

    Controller.prototype.getPostPage = function (id, selector) {
        var _this = this;

        this.model.post.getPost(id)
            .then(function (data) {
                _this.model.comment.getPostComments(id)
                    .then(function (comment) {
                        data.posts[0]['commentsCount'] = comment.comments.length;
                        data.comments = comment.comments;
                        data.logged = !!sessionStorage['logged-in'];
                        app.postView.load(selector, data)
                            .then(function(){
                                _this.attachPostEvents('#comment-form-toggle', '#comment-form')
                                app.commentView.load('.comments', data).
                                then(function(){
                                    _this.attachCommentEvents('.postCommentButton', '.comments');
                                    _this.model.post.visitsIncrement(id)
                                        .then(function () {

                                        }, function (error) {
                                            Noty.error(JSON.parse(error.responseText).error);
                                        });
                                });
                            });

                    }, function (error) {
                        Noty.error(JSON.parse(error.responseText).error);
                    });

            }, function () {
                var error = $('<div class="alert alert-danger" role="alert">...</div>');
                error.text("Error showing this post or post does not exist.");
                $(selector).html(error);
            });
    };

    Controller.prototype.attachPostEvents = function(selector, child){
        $(selector).on('click', function(e){
            e.stopPropagation();
            $(child).slideToggle(400);
            $('#content').val("");

            if ($(child).not(":hidden")) {
                $('#content').focus();
            }
        });
    };

    Controller.prototype.getUserPage = function (id, selector) {
        var _this = this;
        this.model.user.getUserById(id)
            .then(function (data) {
                app.userView.load(selector, data);
            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            });
    };

    Controller.prototype.getTagPage = function (tag, selector) {
        //$(selector).empty();
        var _this = this;

        this.model.tag.getPostsByTag(tag)
            .then(function (data) {
                app.blogView.load(selector, data)
                    .then(function(){
                        if(data.posts.length > 0){
                            _.each(data.posts, function (p) {
                                _this.model.comment.getPostCommentsCount(p.objectId)
                                    .then(function (c) {
                                        $('article#' + p.objectId + ' .comments-count').text(c.count);
                                    }, function (error) {
                                        Noty.error(JSON.parse(error.responseText).error);
                                    });
                            });
                        } else {
                            var error = $('<div class="alert alert-warning" role="alert">...</div>');
                            error.text("There is no posts with this tag.");
                            $(selector).html(error);
                        }
                    });

            }, function (error) {
                Noty.error(JSON.parse(error.responseText).error);
            });
    };

    return {
        get: function (model) {
            return new Controller(model);
        }
    }
})();