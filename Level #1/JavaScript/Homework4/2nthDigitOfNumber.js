function findNthDigit(input){
     // second way
    //var n = input[0]-1;
    var n = input[0];
    var num = input[1].toString();
    var i;
    num = num.replace(".", "").replace("-", "");
    var numLength = num.toString().length;
    var result;

    //debugger;
    var k = 1;
    for(i = numLength - 1; i >= 0; i -= 1){
        if(k == n){
            result = num[i];
            break;
        }
        k++;
    }
    if(result == undefined){
        return "The number doesn’t have " + n + " digits"
    }
    else{
        return result;
    }



 //                                                second way
//    if(n > num.length - 1){
//        return "The number doesn’t have " + (n+1) + " digits";
//    }
//    else{
//        return num.split("").reverse().join("")[n];
//    }

}
console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));
console.log(findNthDigit([6, 8888.88]));
console.log(findNthDigit([11, 8888.88]));