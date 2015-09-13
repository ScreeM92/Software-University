var app = app || {};

(function() {
    var appId= 'u5iEfoMo5NmpIMWV3WCHhAMDpx5iLBk3pCEA0O7n';
    var restAPI = '9pbMmyBbFqKa8p2NUaSwIEQ7SYUSeGbPp5pGDRE1';
    var baseUrl = 'https://api.parse.com/1/';
    var notesPerPage = 10;

    var headers = app.headers.load(appId, restAPI);
    var requester = app.requester.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var noteModel = app.noteModel.load(baseUrl, requester, headers);

    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load();
    var noteViews = app.noteViews.load();

    var userController = app.userController.load(userModel, userViews);
    var noteController = app.noteController.load(noteModel, noteViews);
    var homeController = app.homeController.load(homeViews);

    app.router = Sammy(function () {
        var selector = '#container';

        this.before(function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['username']);
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before('#/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/login/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/register/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/office/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/myNotes/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/notes/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/addNote/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/logout/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function () {
            homeController.welcomeScreen(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/home/', function () {
            homeController.homeScreen(selector);
        });

        this.get('#/office/:page', function() {
            noteController.listOfficeNotes(selector, this.params['page'], notesPerPage);
        });

        this.get('#/office/', function() {
            this.redirect('#/office/1');
        });

        this.get('#/office', function() {
            this.redirect('#/office/1');
        });

        this.get('#/myNotes', function() {
            this.redirect('#/myNotes/1');
        });

        this.get('#/addNote/', function() {
            noteController.loadAddNoteView(selector);
        });

        this.get('#/myNotes/:page', function() {
            noteController.listUserNotes(selector, this.params['page'], notesPerPage);
        });

        this.get('#/myNotes/', function() {
            this.redirect('#/myNotes/1');
        });

        this.get('#/notes/edit/:params', function() {
            noteController.loadNoteView(selector, this.params['params'], 'edit');
        });

        this.get('#/notes/delete/:params', function() {
            noteController.loadNoteView(selector, this.params['params'], 'delete');
        });

        this.bind('login', function(e, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function(e, data) {
            userController.register(data.username, data.password, data.fullName);
        });

        this.bind('addNote', function(e, data) {
            noteController.addNote(data.title, data.text, data.deadline);
        });

        this.bind('editNote', function(e, data) {
            noteController.editNote(data.id, data.title, data.text, data.deadline);
        });

        this.bind('deleteNote', function(e, data) {
            noteController.deleteNote(data.id);
        });
    });

    app.router.run('#/');
}());