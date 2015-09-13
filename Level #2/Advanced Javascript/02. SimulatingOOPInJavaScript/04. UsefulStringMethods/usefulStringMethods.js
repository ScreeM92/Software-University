String.prototype.startsWith = function(substring) {
    return this.indexOf(substring) === 0;
}

String.prototype.endsWith = function (substring) {
    var str = this.substring(this.length - substring.length, this.length);

    return str === substring;
}

String.prototype.left = function (count) {
    return this.substring(0, count);
}

String.prototype.right = function (count) {
    return this.substring(this.length - count, this.length);
}

String.prototype.padLeft = function (count, character) {
    var newStr = this;
    character = character ? character : " ";

    while (newStr.length < count) {
        newStr = character + newStr;
    }

    return newStr;
}

String.prototype.padRight = function (count, character) {
    var newStr = this;
    character = character ? character : " ";

    while (newStr.length < count) {
        newStr += character;
    }

    return newStr;
}

String.prototype.repeat = function (count) {
    var newStr = "";
    var c = count;

    while (c > 0) {
        newStr += this;
        c -= 1;
    }

    return newStr;
}

console.log("*********************** Test startsWith ***********************");
var example = "This is an example string used only for demonstration purposes.";
console.log("----- \"" + example + "\" -----");
console.log("startsWith(\"This\"): " + example.startsWith("This"));
console.log("startsWith(\"this\"): " + example.startsWith("this"));
console.log("startsWith(\"other\"): " + example.startsWith("other"));
console.log();

console.log("*********************** Test endsWith ***********************");
console.log("----- \"" + example + "\" -----");
console.log("endsWith(\"poses.\"): " + example.endsWith("poses."));
console.log("endsWith(\"example\"): " + example.endsWith("example"));
console.log("endsWith(\"something else\"): " + example.endsWith("something else"));
console.log();

console.log("*********************** Test left ***********************");
console.log("----- \"" + example + "\" -----");
console.log("left(9): " + example.left(9));
console.log("left(90): " + example.left(90));
console.log();

console.log("*********************** Test right ***********************");
console.log("----- \"" + example + "\" -----");
console.log("right(9): " + example.right(9));
console.log("right(90): " + example.right(90));
console.log();

console.log("*********************** Test combination between: left and right ***********************");
var example = "abcdefgh";
console.log("----- \"" + example + "\" -----");
// Combinations must also work
console.log("left(5).right(2): " + example.left(5).right(2));
console.log();

console.log("*********************** Test padLeft ***********************");
var hello = "hello";
console.log("----- \"" + hello + "\" -----");
console.log("padleft(5): |" + hello.padLeft(5));
console.log("padleft(10): |" + hello.padLeft(10));
console.log("padLeft(5, \".\"): |" + hello.padLeft(5, "."));
console.log("padLeft(10, \".\"): |" + hello.padLeft(10, "."));
console.log("padLeft(2, \".\"): |" + hello.padLeft(2, "."));
console.log();

console.log("*********************** Test padRight ***********************");
console.log("----- \"" + hello + "\" -----");
console.log("padRight(5): " + hello.padRight(5) + "|");
console.log("padRight(10): " + hello.padRight(10) + "|");
console.log("padRight(5, \".\"): " + hello.padRight(5, ".") + "|");
console.log("padRight(10, \".\"): " + hello.padRight(10, ".") + "|");
console.log("padRight(2, \".\"): " + hello.padRight(2, ".") + "|");
console.log();

console.log("*********************** Test repeat ***********************");
var character = "*";
console.log("----- \"" + character + "\" -----");

console.log("repat(5): " + character.repeat(5));
// Alternative syntax
console.log("\"~\".repat(3): " + "~".repeat(3));
console.log();

console.log("*********************** Test combination between: repeat, padLeft and padRight ***********************");
console.log("----- \"" + character + "\" -----");
// Another combination
console.log("\"*\".repeat(5).padLeft(10, \"-\").padRight(15, \"+\"):   " + "*".repeat(5).padLeft(10, "-").padRight(15, "+"));