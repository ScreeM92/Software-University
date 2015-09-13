function testContext() {
    console.log(this);
}

console.log("-==== Call from global scope: ====-");
testContext();

console.log("-==== Call inside another function: ====-");
callFromFunc();

function callFromFunc() {
    testContext();
}

console.log("-==== Call as an object: ====-");
var a = new testContext();