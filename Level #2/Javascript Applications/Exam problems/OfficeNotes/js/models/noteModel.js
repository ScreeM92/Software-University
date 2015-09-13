var app = app || {};

app.noteModel = (function() {
    function NoteModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Note';
        this.requester = requester;
        this.headers = headers;
    }

    NoteModel.prototype.listOfficeNotes = function(page, notesPerPage) {
        var where = {
            "deadline": getTodayDate()
        };
        var url = this.serviceUrl +
            '?count=1&limit=' + notesPerPage +
            '&skip=' + ((page - 1 ) * notesPerPage) +
            '&include=author&where=' + JSON.stringify(where);

        return this.requester.get(url, this.headers.getHeaders(true));
    };

    NoteModel.prototype.listUserNotes = function(page, notesPerPage) {
        var where = {
            "author":{
                "__type":"Pointer",
                "className":"_User",
                "objectId": sessionStorage['userId']
            }
        };
        var url = this.serviceUrl +
            '?count=1&limit=' + notesPerPage +
            '&skip=' + ((page - 1 ) * notesPerPage) +
            '&include=author&where=' + JSON.stringify(where);

        return this.requester.get(url, this.headers.getHeaders(true));
    };

    NoteModel.prototype.addNote = function(title, text, deadline) {
        var userId = sessionStorage['userId'];
        var data = {
            title: title,
            text: text,
            deadline: deadline,
            author: {
                "__type": "Pointer",
                "className": "_User",
                "objectId": userId
            },
            ACL : {
                "*":{"read":true }
            }
        };

        data.ACL[userId] = {"write":true,"read":true};

        return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.editNote = function(noteId, title, text, deadline) {
        var data = {
            title: title,
            text: text,
            deadline: deadline
        };

        return this.requester.put(this.serviceUrl + '/' +  noteId, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.deleteNote = function(noteId) {
        return this.requester.remove(this.serviceUrl + '/' +  noteId, this.headers.getHeaders(true));
    };

    var getTodayDate = function(){
        var now = new Date();
        var month = (now.getMonth() + 1) >= 10 ? now.getMonth() + 1 : '0' + (now.getMonth() + 1);
        var day = now.getDate() >= 10 ? now.getDate(): '0' + now.getDate();
        var today = '' + now.getFullYear() + '-' + month + '-' + day;

        return today;
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new NoteModel(baseUrl, requester, headers);
        }
    }
}());