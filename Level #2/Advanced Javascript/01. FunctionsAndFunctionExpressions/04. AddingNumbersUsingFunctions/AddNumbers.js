function add(n) {
    var v = function (x) {
        return add(n + x);
    };

    v.valueOf = v.toString = function () {
        return n;
    };

    return v;
}


var addTwo = +add(2);
console.log(addTwo); //2

var addTwo = add(2);
console.log(+addTwo(3)(5)(1)(7)); //18