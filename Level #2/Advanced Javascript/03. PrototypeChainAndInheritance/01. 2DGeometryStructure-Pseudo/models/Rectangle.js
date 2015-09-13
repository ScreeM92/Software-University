var models = models || {};

(function (scope) {
    function validateSides(width, height) {
        if (isNaN(width) || isNaN(height) || width <= 0 || height <= 0) {
            throw new Error('Rectangle sides should be numbers greater than 0.');
        }
    }

    var Rectangle = function() {
        function Rectangle(leftCorner, width, height, color) {
            scope._Shape.call(this, leftCorner, color);
            validateSides(width, height);
            this.setWidth(width);
            this.setHeight(height);
            this._POINT_TYPE = 'Top left corner';
        }

        Rectangle.extends(scope._Shape);

        Rectangle.prototype.setWidth = function(width) {
            this._width = width;
        }

        Rectangle.prototype.getWidth = function() {
            return this._width;
        }

        Rectangle.prototype.setHeight = function(height) {
            this._height = height;
        }

        Rectangle.prototype.getHeight = function() {
            return this._height;
        }

        Rectangle.prototype.toString = function() {
            var rectangle = scope._Shape.prototype.toString.call(this) + 
                            'Width: ' + this._width + '\n' + 
                            'Height: ' + this._height + '\n';

            return rectangle;
        }

        return Rectangle;
    }();

    scope.getRectangle = function (leftCorner, width, height, color) {
        return new Rectangle(leftCorner, width, height, color);
    }
}(models))