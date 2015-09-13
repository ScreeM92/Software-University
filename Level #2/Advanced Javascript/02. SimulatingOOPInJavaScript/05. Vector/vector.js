var Vector = function() {
    function Vector(arr) {
        if (!arr || !Array.isArray(arr) || arr.length === 0) {
            throw new Error("Invalid argument");
        }

        this._dimensions = arr;
    }

    Vector.prototype.toString = function() {
        return "(" + this._dimensions.join(", ") + ")";
    }

    Vector.prototype.validate = function(other) {
        if (!(other instanceof Vector)) {
            throw new Error("Second object is not a vector.");
        }

        if (this._dimensions.length !== other._dimensions.length) {
            throw new Error("The vectors have different dimensions.");
        }
    }
    
    Vector.prototype.add = function(other) {
        this.validate(other);
        var arr = [];

        for (var i = 0, len = this._dimensions.length; i < len; i += 1) {
            arr.push(this._dimensions[i] + other._dimensions[i]);
        }

        return new Vector(arr);
    };

    Vector.prototype.substract = function(other) {
        this.validate(other);
        var arr = [];

        for (var i = 0, len = this._dimensions.length; i < len; i += 1) {
            arr.push(this._dimensions[i] - other._dimensions[i]);
        }

        return new Vector(arr);
    };

    Vector.prototype.dot = function(other) {
        this.validate(other);
        var dotProduct = 0;

        for (var i = 0, len = this._dimensions.length; i < len; i += 1) {
            dotProduct += this._dimensions[i] * other._dimensions[i];
        }

        return dotProduct;
    };

    Vector.prototype.norm = function() {
        var norm = Math.sqrt(this.dot(this));

        return norm;
    };

    return Vector;
}();

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);

console.log("*********************** Create vectors ***********************");
console.log("Vector a: " + a.toString());
console.log("Vector b: " + b.toString());
console.log("Vector c: " + c.toString());
console.log();

console.log("*********************** Test add ***********************");
var result = a.add(b);
console.log("a.add(b) : " + result.toString());
console.log();

console.log("*********************** Test substract ***********************");
var result = a.substract(b);
console.log("a.substract(b) : " + result.toString());
console.log();

console.log("*********************** Test dot ***********************");
var result = a.dot(b);
console.log("a.dot(b) : " + result.toString());
console.log();

console.log("*********************** Test norm ***********************");
console.log("a.norm() : " + a.norm());
console.log("b.norm() : " + b.norm());
console.log("c.norm() : " + c.norm());
console.log();

console.log("*********************** Test combination between: add and norm ***********************");
console.log("a.add(b).norm() : " + a.add(b).norm());

// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);
//a.add(c);
//a.subtract(c);
//a.dot(c);