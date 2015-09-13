var models = models || {};

(function(scope) {
    var Item = function () {
        var id = 0;
        function Item(content) {
            this._id = ++id;
            this._content = content ? content : '';
            this._isCompleted = false;
        }

        Item.prototype.getId = function () {
            return this._id;
        }

        Item.prototype.getContent = function () {
            return this._content;
        };

        Item.prototype.changeContent = function (content) {
            this._content = content ? content : '';
        };

        Item.prototype.getStatus = function () {
            return this._isCompleted;
        };

        Item.prototype.changeStatus = function (status) {
            this._isCompleted = status;
        }

        return Item;
    }();

    scope.Item = Item;
}(models));