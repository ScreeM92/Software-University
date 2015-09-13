function solve(input) {
    var nums = [];
    var result = [];
    var fibonacciNums = [];
    for (var i in input) {
        nums.push(Number(input[i]));
    }

    result.push("<table>");
    result.push("<tr><th>Num</th><th>Square</th><th>Fib</th></tr>");

    var a = 0;
    var b = 1;
    fibonacciNums.push(0);
    fibonacciNums.push(1);

    for (var i = 0; i < 100; i++) {
        if(fibonacci > 1000000){
            break;
        }
        var fibonacci = a + b;
        fibonacciNums.push(fibonacci);
        a = b;
        b = fibonacci;
    }
    var isFibonacci = false;

    for (var i = nums[0]; i <= nums[1]; i++) {
      for (var j = 0; j <= fibonacciNums.length; j++) {
        if(i == fibonacciNums[j]){
            isFibonacci = true;
            break;
        } else{
            isFibonacci = false;
        }
      }
       if(isFibonacci == true){
           result.push("<tr><td>" + i + "</td><td>" + i*i + "</td><td>yes</td></tr>")
           isFibonacci = false;
       } else{
           result.push("<tr><td>" + i + "</td><td>" + i*i + "</td><td>no</td></tr>")
       }

    }
    result.push("</table>")
    console.log(result.join("\n"))
}
solve(['2','6']);
//solve(['28657','28659']);
//solve(['55','56']);
//solve(['514220','514230']);