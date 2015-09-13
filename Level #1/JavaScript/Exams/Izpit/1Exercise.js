function solve(input) {
    var nums = [];
    var numbers = [];
    var result = [];
    for (var i in input) {
        nums.push(Number(input[i]));
    }

    for (var i in nums) {
        numbers.push(nums[i].toFixed(2))
    }

    result.push("<table>");
    result.push("<tr><th>Price</th><th>Trend</th></tr>")
    result.push("<tr><td>" + numbers[0] + "</td><td><img src=\"fixed.png\"/></td></td>")

    for (var i = 1; i <= numbers.length - 1; i++) {
        if(parseFloat(numbers[i]) > parseFloat(numbers[i - 1])){
            result.push("<tr><td>" + numbers[i] + "</td><td><img src=\"up.png\"/></td></td>")
        }
        else if(parseFloat(numbers[i]) == parseFloat(numbers[i - 1])){
            result.push("<tr><td>" + numbers[i] + "</td><td><img src=\"fixed.png\"/></td></td>")
        } else{
            result.push("<tr><td>" + numbers[i] + "</td><td><img src=\"down.png\"/></td></td>")
        }
    }

    result.push("</table>");
    console.log(result.join('\n'))
}

solve(['50','60']);
solve(['36.333','36.5','37.019','35.4','35','35.001','36.225']);
solve(['0']);
solve(['5','6','13']);
