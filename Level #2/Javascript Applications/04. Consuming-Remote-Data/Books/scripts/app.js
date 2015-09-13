var books = books || {};

(function (scope) {
    var BASE_URL = 'https://api.parse.com/1/classes/';
    var model = scope.models.loadModels(BASE_URL);
    var viewModel = new scope.viewModel.loadViewModel(model);
    viewModel.showAllBooks();
}(books));