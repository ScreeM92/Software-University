var shapes = shapes || {};

(function (scope) {
    function validatePoint(point) {
        if (typeof point.getType !== 'function' || point.getType() !== 'Point2D') {
            throw new Error('Invalid point.');
        }
    }

    var line = scope.shape.extends({
        init: function init(pointA, pointB, color) {
            this._super.init.call(this, pointA, color);
            validatePoint(pointB);
            this._pointB = pointB;
            this._POINT_TYPE = 'PointA';
            this._type = 'Line';
            return this;
        },

        toString: function toString() {
            var line = this._super.toString.call(this) +
                'PointB: ' + this._pointB + '\n';

            return line;
        }
    });

    scope.line = line;
}(shapes));