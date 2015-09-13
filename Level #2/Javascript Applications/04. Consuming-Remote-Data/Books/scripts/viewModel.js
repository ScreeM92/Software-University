var books = books || {};

(function(scope) {
    var ViewModel = (function() {
        function ViewModel(model) {
            this.model = model;
            this.attachEventListeners(this);
        }

        ViewModel.prototype.showAllBooks = function () {
            var _this = this;

            this.model.books.getAllBooks(
            function (books) {
                books.results.forEach(function (book) {
                    _this.addBookToDom(book.title, book.author, book.isbn, book.objectId);
                });
            },
            function (err) {
                viewModel.notification(err.responseText, 'error', 'bottom', 3000);
            });
        }

        ViewModel.prototype.addBook = function (viewModel, title, author, isbn) {
            var book = {
                title: title,
                author: author,
                isbn: isbn
            }
            viewModel.model.books.createBook(
                book,
                function(data) {
                    viewModel.addBookToDom(title, author, isbn, data.objectId);
                    viewModel.notification('Book successfully added.', 'success', 'bottom', 3000);
                },
                function(err) {
                    viewModel.notification(err.responseText, 'error', 'bottom', 3000);
                }
            );
        }

        ViewModel.prototype.editBook = function (bookId, title, author, isbn) {
            var _this = this;
            var bookData = {
                title: title,
                author: author,
                isbn: isbn
            }

            this.model.books.editBook(
                bookId,
                bookData,
                function (data) {
                    _this.editBookInDom(bookId, bookData);
                    $('#book-edit-section').remove();
                    _this.notification('Book successfully edited.', 'success', 'bottom', 3000);
                },
                function (err) {
                    _this.notification(err.responseText, 'error', 'bottom', 3000);
                }
            );
        }
        
        ViewModel.prototype.deleteBook = function (bookId) {
            var _this = this;

            this.model.books.deleteBook(
                bookId,
                function () {
                    $('#books')
                    .find('[book-id=' + bookId + ']')
                    .remove();
                    _this.notification('Book successfully deleted,', 'success', 'bottom', 3000);
                },
                function(err) {
                    viewModel.notification(err.responseText, 'error', 'bottom', 3000);
                }
            );
        }

        ViewModel.prototype.attachEventListeners = function (viewModel) {
            $(document).on('mouseenter', 'li', function () {
                $(this).find(".book-buttons").hide().fadeIn(100);
            }).on('mouseleave', 'li', function () {
                $(this).find(".book-buttons").hide();
            });

            $(document).on('click', '#add-book-toggle', function () {
                $('#add-details').slideToggle();
                $('#book-title').focus();
            });

            $(document).on('click', '.title', function() {
                $(this).parent().find('.details').slideToggle();
            });

            $('.title').click(function () {
                $(this).parent().find('.details').slideToggle();
            });

            $(document).on('mouseleave', 'li', function (e) {
                var editSection = $(this).find('#book-edit-section');

                if (editSection.length) {
                    if ($(editSection).is(':visible')) {
                        editSection.slideToggle();
                        setTimeout(function() {
                            editSection.remove();
                        }, 400);
                    } else {
                        editSection.remove();
                    }
                }
            });

            $('#add-book').click(function () {
                var title = $('#book-title');
                var author = $('#book-author');
                var isbn = $('#book-isbn');

                if (title.val()) {
                    viewModel.addBook(viewModel, title.val(), author.val(), isbn.val());
                    title.val('');
                    author.val('');
                    isbn.val('');
                    $('#add-book-toggle').trigger('click');
                } else {
                    viewModel.notification('Title cannot be empty.', 'warning', 'bottom', 3000);
                }
                
            });
        }

        ViewModel.prototype.addBookToDom = function (title, author, isbn, id) {
            var _this = this;
            var bookWrapper = $('<li>').addClass('book').attr('book-id', id);
            var bootTitle = $('<h3>').addClass('title').text(title);
            var bookDetails = $('<div>').addClass('details');
            var bookAuthor = $('<p>').addClass('author')
                .append('<span>Author: ')
                .append('<span>' + author);
            var bookIsbn = $('<p>').addClass('isbn')
                .append('<span>Isbn: ')
                .append('<span>' + (isbn ? isbn : 'none'));
            var buttons = $('<span>').addClass('book-buttons');
            var removeButton = $('<button>').addClass('remove').text('x');
            var editButton = $('<button>').addClass('edit').text('e');
            removeButton.click(function() {
                _this.deleteBook(id);
            });
            editButton.click(function () {
                var editSection = $('#books').find($('#book-edit-section'));
                if ($(this).parent().parent().children('#book-edit-section').length) {
                    $(editSection).slideToggle();
                    $('#book-edit-section input:eq(0)').focus();
                } else  {
                    if (editSection.length) {
                        editSection.slideToggle();
                        setTimeout(function () {
                            editSection.remove();
                        }, 400);
                    }
                    _this.createEditForm(id).hide().appendTo(bookWrapper).slideToggle();
                    $('#book-edit-section input:eq(0)').focus();
                }

                $(this).parent().next().slideDown();
            });
            buttons.append(editButton).append(removeButton);
            bookDetails.append(bookAuthor).append(bookIsbn);
            bookWrapper.append(bootTitle).append(buttons).append(bookDetails);
            bookWrapper.hide().appendTo($('#books')).fadeIn(800);
        }

        ViewModel.prototype.editBookInDom = function(bookId, bookData) {
            var bookNode = $('#books').find('[book-id=' + bookId + ']');
            bookNode.find('.title').text(bookData.title);
            bookNode.find('.author span:eq(1)').text(bookData.author);
            bookNode.find('.isbn span:eq(1)').text(bookData.isbn);
        }

        ViewModel.prototype.notification = function (text, type, layout, timeout) {
            noty({
                text: text,
                type: type,
                layout: layout,
                timeout: timeout
            });
        }

        ViewModel.prototype.createEditForm = function(bookId) {
            var _this = this;
            var bookData = getBookData(bookId);
            var editNode = $('<div>').attr('id', 'book-edit-section');
            var titleLabel = $('<label>').text('Title: ');
            var title = $('<input>').attr('type', 'text').val(bookData.title);
            var authorLabel = $('<label>').text('Author: ');
            var author = $('<input>').attr('type', 'text').val(bookData.author);
            var isbneLabel = $('<label>').text('Isbn: ');
            var isbn = $('<input>').attr('type', 'text').val(bookData.isbn);
            var editButton = $('<button>').attr('id', 'book-edit-button').text('Edit');

            editButton.click(function () {
                _this.editBook(bookId, title.val(), author.val(), isbn.val());
            });

            editNode
                .append(titleLabel)
                .append(title)
                .append(authorLabel)
                .append(author)
                .append(isbneLabel)
                .append(isbn)
                .append(editButton);

            return editNode;
        }

        function getBookData(bookId) {
            var bookData = {};
            var bookNode = $('#books').find('[book-id=' + bookId + ']');
            bookData.title = bookNode.find('.title').text();
            bookData.author= bookNode.find('.author span:eq(1)').text();
            bookData.isbn = bookNode.find('.isbn span:eq(1)').text();

            return bookData;
        }

        return ViewModel;
    }());

    scope.viewModel = {
        loadViewModel: function (model) {
            return new ViewModel(model);
        }
    }
}(books));