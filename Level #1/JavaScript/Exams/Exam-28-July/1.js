function solve(input) {
    var result = [];
    result.push('<ul>');

    for (var i = input[0]; i <= input[1]; i++) {

        if(i < 1009){
            result.push("<li><span class='num'>"+ i + "</span></li>")
        }
        else{
            var numString = i.toString();
            var isCorrent = true;
            for (var j = 0; j < numString.length - 1; j++) {
                if(isCorrent == false){
                    break;
                }
                for (var k = j + 2; k < numString.length - 1; k++) {

                    if(numString.charAt(j) == numString.charAt(k) && numString.charAt(j+1) == numString.charAt(k+ 1)){
                        result.push("<li><span class='rakiya'>" + i + "</span><a href=\"view.php?id=" + i + "\>View</a></li>")
                        isCorrent = false;
                        break;
                    } else{
                        var str = "<li><span class='num'>"+ i + "</span></li>";

                        if(result.indexOf(str) < 0 && k == numString.length - 2 && j == numString.length - 4){
                            result.push("<li><span class='num'>"+ i + "</span></li>")
                        }
                    }
                }
            }
        }
    }
    result.push('</ul>');
    console.log(result.join("\n"));
}
//solve(['5','8']);
//solve(['11210','11215']);
//solve(['30000','30030']);
solve(['141240','141250']);