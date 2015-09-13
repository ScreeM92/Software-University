function solve(input) {
    var count = input[0];
    var numbers = [];

    for (var i = 1; i < input.length; i++) {
        numbers.push(input[i]);
    }

    numbers.sort(sortNumber);

    for (var i = 1; i <= 3; i++) {
        if(numbers.length == 2){
            console.log(numbers[numbers.length - i])
            console.log(numbers[numbers.length - i - 1]);
            break;
        }
        else if(numbers.length == 1){
            console.log(numbers[numbers.length - i])
            break;
        } else{
        console.log(numbers[numbers.length - i])
        }
    }

    function sortNumber(a,b) {
        return a - b;
    }
}
solve(['5','20','50','100','10','75']);
solve(['4','-5','2.77','1.33','-3']);
solve(['2','3','4']);
solve(['5','1.500000000000','25.55555555555','-0.00000000001','1.000000000001','3.333333333333']);
solve(['1','3']);