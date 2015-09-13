var models = models || {};

(function (scope) {
    function validatePoint(point) {
        if (!(point instanceof scope._Point2D)) {
            throw new Error('Invalid point.');
        }
    }
    
    var Shape = function () {
        function Shape(point2D, color) {
            if (this.constructor.name === 'Shape') {
                throw new Error("Cannot instantiate abstract class");
            }

            validatePoint(point2D);
            this.setPoint(point2D);
            this.setColor(color);
            this._POINT_TYPE = 'point';
        }

        Shape.prototype.setPoint = function(point) {
            this._point = point;
        }

        Shape.prototype.getPoint = function() {
            return this._point;
        }

        Shape.prototype.setColor = function(color) {
            this._color = color;
        }

        Shape.prototype.getColor = function() {
            return this._color;
        }

        Shape.prototype.toString = function() {
            var shape = this.constructor.name + ':\n' + 
                        'Color: <span style="color:' + this.getColor() + ';">' + this.getColor() + '</span>\n' + 
                        this._POINT_TYPE + ': ' + this.getPoint() + '\n';

            return shape;
        }

        return Shape;
    }();

    scope._Shape = Shape;
    scope.getShape = function (point2D, color) {
        return new Shape(point2D, color);
    }
}(models));