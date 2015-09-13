function findLargestBySumOfDigits(input){
    input = input.split(/[ ,]+/);
    var currentSum = 0;
    var maxSum = 1;
    var result;

    for(var i = 0; i < input.length; i += 1){
        if(parseInt(input[i]) == input[i]){
            var num = input[i];
            for(k = 0; k < num.length; k += 1){
                if(num[k] == "-"){
                    continue;
                }
                else{
                    currentSum += parseInt(num[k]);
                }
            }
            //left to right
            if(currentSum > maxSum){
                maxSum = currentSum;
                result = num;
            }
            //right to left
//            if(currentSum >= maxSum){
//                maxSum = currentSum;
//                result = num;
//            }
            currentSum = 0;
        }
        else{
            return "undefined";
            break;
        }
    }
    return result;
}
console.log(findLargestBySumOfDigits("5, 10, 15, 111"));
console.log(findLargestBySumOfDigits("33, 44, -99, 0, 20"));
console.log(findLargestBySumOfDigits("'hello'"));
console.log(findLargestBySumOfDigits("5, 3.3"));
console.log(findLargestBySumOfDigits("333, 44, -99, 0, 20"));
console.log(findLargestBySumOfDigits("33, 444, -99, 0, 20"));
console.log(findLargestBySumOfDigits("33, 44, -99, 0, 20.2"));
console.log(findLargestBySumOfDigits("3333333, 44, -9921, 0, 200000000"));