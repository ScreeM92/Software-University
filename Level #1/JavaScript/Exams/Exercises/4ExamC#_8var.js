//function solve(input){
//
//    var num = Number(input[0]);
//    var sum = 40;
//    var currentSum6 = 0;
//    var currentSum5 = 0;
//    var currentSum4 = 0;
//    var currentSum3 = 0;
//    var currentSum2 = 0;
//    var currentSum1 = 0;
//    var leftSum = 0;
//    var count = 0;
//    var newTry = true;
//    var beforeSum = 0;
//    var d1 = 1;
//    var d2 = 1;
//    var d3 = 1;
//    var d4 = 1;
//
//
//    for (var digit1 = 0; digit1 <= 9; digit1++) {
//        sum += digit1;
//
//        if(digit1 > 1){
//            sum -= d1;
//            d1++;
//        }
//        for (var digit2 = 0; digit2 <= 9; digit2++) {
//            sum += digit2;
//
//            if(digit2 > 1){
//                sum -= d2;
//                d2++;
//            }
//            for (var digit3 = 0; digit3 <= 9; digit3++) {
//                sum += digit3;
//
//                if(digit3 > 1){
//                    sum -= d3;
//                    d3++;
//                }
//                for (var digit4 = 0; digit4 <= 9; digit4++) {
//                    sum += digit4;
//
//                    if(digit4 > 1){
//                        sum -= d4;
//                        d4++;
//                    }
//                    for (var letter1 = 65; letter1 < 89; letter1++) {
//
//                        switch(String.fromCharCode(letter1)){
//                            case "A":
//                                sum += 10;
//                                break;
//                            case "B":{
//                                sum += 20;
//                                //sum -= 10;
//                                break;
//                            }
//                            case "C":{
//                                sum += 30;
//                                //sum -= 20;
//                                break;
//                            }
//                            case "E":{
//                                sum += 50;
//                                //sum -= 30;
//                                break;
//                            }
//                            case "H":{
//                                sum += 80;
//                                //sum -= 50;
//                                break;
//                            }
//                            case "K":{
//                                sum += 110;
//                                //sum -= 80;
//                                break;
//                            }
//                            case "M":{
//                                sum += 130;
//                                //sum -= 110;
//                                break;
//                            }
//                            case "P":{
//                                sum += 160;
//                                //sum -= 130;
//                                break;
//                            }
//                            case "T":{
//                                sum += 200;
//                                //sum -= 160;
//                                break;
//                            }
//                            case "X":{
//                                sum += 240;
//                                //sum -= 200;
//                                break;
//                            }
//                        }
////                        currentSum5 = sum;
////                        if(letter1 > 65){
////                            sum -= beforeSum;
////                        }
//                        for (var letter2 = 65; letter2 < 89; letter2++) {
//                            currentSum6 = sum;
//
//                            if(letter2 == 65){
//                                var cc = 40;
//                                var vv = sum;
//                                currentSum1 = vv - cc + digit1+ digit2+ digit3+ digit4;
//                            }
//
//                            beforeSum = currentSum6 - currentSum5;
//
//                            switch (String.fromCharCode(letter2 )) {
//                                case "A":
//                                {
//                                    sum += 10;
//                                    break;
//                                }
//                                case "B":
//                                {
//                                    sum += 20;
//                                    break;
//                                }
//                                case "C":
//                                {
//                                    sum += 30;
//                                    break;
//                                }
//                                case "E":
//                                {
//                                    sum += 50;
//                                    break;
//                                }
//                                case "H":
//                                {
//                                    sum += 80;
//                                    break;
//                                }
//                                case "K":
//                                {
//                                    sum += 110;
//                                    break;
//                                }
//                                case "M":
//                                {
//                                    sum += 130;
//                                    break;
//                                }
//                                case "P":
//                                {
//                                    sum += 160;
//                                    break;
//                                }
//                                case "T":
//                                {
//                                    sum += 200;
//                                    break;
//                                }
//                                case "X":
//                                {
//                                    sum += 240;
//                                    break;
//                                }
//                            }
//
//                            leftSum = sum - currentSum6;
//                            if(sum == num){
//                                count++;
//                                sum = sum - leftSum;
//                            }
//                            else{
//                               sum = sum - leftSum;
//                                newTry = false;
//                            }
//                            if(letter2 == 88){
//                                sum -= currentSum1;
//                            }
//                            console.log(sum)
//                        }
//                    }
//                }
//            }
//        }
//    }
//    console.log(count)
//}

function solve(input) {
    var number = parseInt(input);
    var letters = ["A", "B", "C", "E", "H", "K", "M", "P", "T", "X"];
    var count = 0;
    for(var firstLetterIndex = 0; firstLetterIndex < letters.length; firstLetterIndex++) {
        for(var secondLetterIndex = 0; secondLetterIndex < letters.length; secondLetterIndex++) {
            for(var a = 0; a <= 9; a++) {
                if(checkNumber("" + a + a + a + a + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                for(var b = 0; b <= 9; b++) {
                    if(a == b) {
                        continue;
                    }
                    if(checkNumber("" + a + b + b + b + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                    if(checkNumber("" + a + a + a + b + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                    if(checkNumber("" + a + a + b + b + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                    if(checkNumber("" + a + b + a + b + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                    if(checkNumber("" + a + b + b + a + letters[firstLetterIndex] + letters[secondLetterIndex], number)) count++;
                }
            }
        }
    }

    console.log(count);

    function checkNumber(numberAsString, magicNumber) {
        var weight = 40;
        for(var i = 0; i < 4; i++) {
            weight += parseInt(numberAsString[i]);
        }

        for(var i = 4; i <= 5; i++) {
            weight += (numberAsString.charCodeAt(i) - "A".charCodeAt(0) + 1) * 10;
        }

        return weight == magicNumber;
    }
}

solve(['555']);