var shapes = shapes || {};
(function (scope) {
    function validatePoint(point) {
        if (typeof point.getType !== 'function' || point.getType() !== 'Point2D') {
            throw new Error('Invalid point.');
        }
    }

    var triangle = scope.shape.extends({
        init: function init(pointA, pointB, pointC, color) {
            this._super.init.call(this, pointA, color);
            validatePoint(pointB);
            validatePoint(pointC);
            this._pointB = pointB;
            this._pointC = pointC;
            this._POINT_TYPE = 'PointA';
            this._type = 'Triangle';
            return this;
        },

        toString: function toString() {
            var triangle = this._super.toString.call(this) +
                'PointB: ' + this._pointB + '\n' +
                'PointC: ' + this._pointC + '\n';

            return triangle;
        }
    });
    
    scope.triangle = triangle;
}(shapes))