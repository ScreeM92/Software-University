var shapes = shapes || {};

(function (scope) {
    function validatePoint(point) {
        if (typeof point.getType !== 'function' || point.getType() !== 'Point2D') {
            throw new Error('Invalid point.');
        }
    }
    
    var shape = {
        init: function init(point2D, color) {
            validatePoint(point2D);
            this._point = point2D;
            this._color = color;
            this._POINT_TYPE = 'point';
            this._type = 'Shape';
            return this;
        },

        toString: function toString() {
            var shape = this._type + ':\n' + 
                        'Color: <span style="color:' + this._color + ';">' + this._color + '</span>\n' + 
                        this._POINT_TYPE + ': ' + this._point + '\n';

            return shape;
        }
    };

    scope.shape = shape;
}(shapes));

