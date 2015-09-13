var shapes = shapes || {};

(function (scope) {
    function validateSides(width, height) {
        if (isNaN(width) || isNaN(height) || width <= 0 || height <= 0) {
            throw new Error('Rectangle sides should be numbers greater than 0.');
        }
    }

    var rectangle = scope.shape.extends({
        init: function init(leftCorner, width, height, color) {
            this._super.init.call(this, leftCorner, color);
            validateSides(width, height);
            this._width = width;
            this._height = height;
            this._POINT_TYPE = 'Top left corner';
            this._type = 'Rectangle';
            return this;
        },

        toString: function toString() {
            var rectangle = this._super.toString.call(this) +
                            'Width: ' + this._width + '\n' +
                            'Height: ' + this._height + '\n';

            return rectangle;
        }
    });

    scope.rectangle = rectangle;
}(shapes))