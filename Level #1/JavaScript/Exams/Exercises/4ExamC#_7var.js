function solve(input){

    var text = input[0].split("");
    var n = input[1];
    var matrix = [];
    for(var i=0; i < n; i++) {
        matrix[i] = new Array(n);
    }
    var k = 0;
    for (var i = 0; i < n; i++) {
        for (var j = 0; j < n; j++) {
            if(k == text.length){
                k = 0;
            }
            matrix[i][j] = text[k];
            k++;
        }
    }

    var count = 0;
    var maxCount = 0;
    var longestWord = "";

    for (var row = 0; row < n; row++) {
        var k = 1;
        var currentUp = "";
        var currentDown = "";
        var currentLeft = "";
        var currentRight = "";
        var m = 0;

        for (var col = 0; col < n; col++) {
            currentUp = matrix[row][col];
            if(row != 0) {

                while (matrix[row - k][col] > matrix[row - m][col]) {

                    currentUp += matrix[row - k][col];
                    k++;
                    m++;
                    if(row - k < 0){
                        break;
                    }
                }
            }
            k = 1;
            m = 0;

            currentDown = matrix[row][col];
            if(row != n-1) {
                while (matrix[row + k][col] > matrix[row + m][col]) {

                    currentDown += matrix[row + k][col];
                    k++;
                    m++;
                    if(row + k > n-1){
                        break;
                    }
                }
            }
            k = 1;
            m = 0;
            currentLeft = matrix[row][col];
            if(col != 0) {
                while (matrix[row][col - k] > matrix[row][col - m]) {

                    currentLeft += matrix[row][col - k];
                    k++;
                    m++;
                    if(col - k < 0){
                        break;
                    }

                }
            }
            k = 1;
            m = 0;
            currentRight = matrix[row][col];
            if(col != n-1) {
                while (matrix[row][col + k] > matrix[row][col + m]) {

                    currentRight += matrix[row][col + k];
                    k++;
                    m++;
                    if(col + k > n-1){
                        break;
                    }
                }
            }
            k = 1;
            m = 0;
            count = Math.max(currentUp.length, currentDown.length, currentLeft.length, currentRight.length);


            if(count >= maxCount && count == currentUp.length){
                if(count == maxCount){
                    for (var i = 0; i < maxCount; i++) {

                        if(currentUp[i] < longestWord[i]){
                            longestWord = currentUp;
                            break;
                        }
                        else if(currentUp[i] == longestWord[i]){
                            continue
                        }
                        else{
                            break;
                        }
                    }
                } else{
                maxCount = count;
                longestWord = currentUp;
                }
            }
            if(count >= maxCount && count == currentDown.length){
                if(count == maxCount){
                    for (var i = 0; i < maxCount; i++) {

                        if(currentDown[i] < longestWord[i]){
                            longestWord = currentDown;
                            break;
                        }
                        else if(currentDown[i] == longestWord[i]){
                            continue
                        }
                        else{
                            break;
                        }
                    }
                } else {
                    maxCount = count;
                    longestWord = currentDown;
                }
            }
            if(count >= maxCount && count == currentLeft.length){
                if(count == maxCount){
                    for (var i = 0; i < maxCount; i++) {

                        if(currentLeft[i] < longestWord[i]){
                            longestWord = currentLeft;
                            break;
                        }
                        else if(currentLeft[i] == longestWord[i]){
                            continue
                        }
                        else{
                            break;
                        }
                    }
                } else {
                    maxCount = count;
                    longestWord = currentLeft;
                }
            }
            if(count >= maxCount && count == currentRight.length){
                if(count == maxCount){
                    for (var i = 0; i < maxCount; i++) {

                        if(currentRight[i] < longestWord[i]){
                            longestWord = currentRight;
                            break;
                        }
                        else if(currentRight[i] == longestWord[i]){
                            continue
                        }
                        else{
                            break;
                        }
                    }
                } else {
                    maxCount = count;
                    longestWord = currentRight;
                }
            }
        }
    }
    console.log(longestWord);
}
//solve(['softwareuniversity','7'])
//solve(['alpha','6'])
//solve(['java','3'])
solve(['aaaaaaaaazaaaaaaaaayaaaaaaaaawaaaaaaaaaqaaaaaaaaakaaaaaaaaajaaaaaaaaahaaaaaaaaaeaaaaaaaaabaaaaaaaaaa','10'])
//nak
//ovn
//ako