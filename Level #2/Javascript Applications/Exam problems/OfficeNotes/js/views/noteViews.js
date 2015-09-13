var app = app || {};

app.noteViews = (function() {
    function NoteViews() {
        this.listNotes = {
            loadNotesView: loadNotesView
        };
        this.listUserNotes = {
            loadUserNotesView: loadUserNotesView
        };
        this.addNote = {
            addNoteView: addNoteView
        };
        this.editNote = {
            editNoteView: editNoteView
        };
        this.deleteNote = {
            deleteNoteView: deleteNoteView
        }
    }

    function loadNotesView (selector, page, data, notesPerPage) {
        $.get('templates/officeNoteTemplate.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).then(function(){
            $('#pagination').pagination({
                items: data['count'],
                itemsOnPage: notesPerPage,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/office/'
             }).pagination('selectPage', page);
        });
    }

    function loadUserNotesView (selector, page, data, notesPerPage) {
        $.get('templates/myNoteTemplate.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).then(function(){
            $('#pagination').pagination({
                items: data['count'],
                itemsOnPage: notesPerPage,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/myNotes/'
            }).pagination('selectPage', page);

            $('.edit').click(function(){
                var urlParams = getUrlData(this);
                window.location.replace('#/notes/edit/' + encodeURI(urlParams));

                return false;
            });

            $('.delete').click(function(){
                var urlParams = getUrlData(this);
                window.location.replace('#/notes/delete/' + encodeURI(urlParams));

                return false;
            });
        });
    }

    function addNoteView (selector) {
        $.get('templates/addNote.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp();
            $(selector).html(html);
        }).then(function() {
            $('#addNoteButton').click(function() {
                var title = $('#title').val();
                var text = $('#text').val();
                var deadline = $('#deadline').val();

                $.sammy(function() {
                    this.trigger('addNote', {title: title, text: text, deadline: deadline});
                });

                return false;
            })
        }).done();
    }

    function editNoteView (selector, data) {
        $.get('templates/editNote.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).then(function() {
            $('#editNoteButton').click(function() {
                var title = $('#title').val();
                var text = $('#text').val();
                var deadline = $('#deadline').val();

                $.sammy(function() {

                    this.trigger('editNote', {id: data.id, title: title, text: text, deadline: deadline});
                });

                return false;
            })
        }).done();
    }

    function deleteNoteView (selector, data) {
        $.get('templates/deleteNote.html', function (template) {
            var temp = Handlebars.compile(template);
            var html = temp(data);
            $(selector).html(html);
        }).then(function() {
            $('#deleteNoteButton').click(function() {
                $.sammy(function() {
                    this.trigger('deleteNote', {id: data.id});
                });

                return false;
            })
        }).done();
    }

    function getUrlData(element){
        var data = {
            id: $(element).parent().attr('data-id'),
            title: $(element).parent().find('#title').text(),
            text: $(element).parent().find('#text').text(),
            deadline: $(element).parent().find('.deadline').text()
        };

        var urlParams = 'id=' + data.id +
            '&title=' + data.title +
            '&text=' + data.text +
            '&deadline=' + data.deadline;

        return urlParams;
    }

    return {
        load: function() {
            return new NoteViews();
        }
    }
}());