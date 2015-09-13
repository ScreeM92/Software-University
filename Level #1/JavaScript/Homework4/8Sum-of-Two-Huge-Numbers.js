//                                     without BigInteger
//function sumTwoHugeNumbers(input){
//    var sum = 0;
//
//    for(var i = 0; i < input.length; i += 1){
//        var num = parseInt(input[i]);
//        sum += num;
//    }
//
//    return sum;
//}
//console.log(sumTwoHugeNumbers(['155', '65']));
//console.log(sumTwoHugeNumbers(['123456789', '123456789']));
//console.log(sumTwoHugeNumbers(['887987345974539','4582796427862587']));
//console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
//        '817651358763158761358796358971685973163314321']));

//                                     with BigInteger

var BigNumber = require('./bignumber.js');
function sumTwoHugeNumbers(arr) {

    var digOne = new BigNumber(arr[0]);
    var digTwo = new BigNumber(arr[1]);
    var sum = new BigNumber(digOne + digTwo);
    return sum;
}
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
        '817651358763158761358796358971685973163314321']
));