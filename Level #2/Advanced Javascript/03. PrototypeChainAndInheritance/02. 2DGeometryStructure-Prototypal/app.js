(function (scope) {
    var consoleOutput = document.getElementById('console');

    var pointA = Object.create(scope.point2D).init(1, 2);
    var pointB = Object.create(scope.point2D).init(3, 4);
    var pointC = Object.create(scope.point2D).init(5, 6);

    var circle = Object.create(scope.circle).init(pointA, 5, 'purple');
    var rectangle = Object.create(scope.rectangle).init(pointB, 5, 6, 'violet');
    var triangle = Object.create(scope.triangle).init(pointA, pointB, pointC, 'green');
    var line = Object.create(scope.line).init(pointA, pointB, 'red');
    var segment = Object.create(scope.segment).init(pointB, pointC, 'blue');

    var shapes = [circle, rectangle, triangle, line, segment];

    shapes.forEach(function(shape) {
        consoleOutput.innerHTML += shape.toString() + '<hr>';
        console.log(shape.toString());
    });
}(shapes));