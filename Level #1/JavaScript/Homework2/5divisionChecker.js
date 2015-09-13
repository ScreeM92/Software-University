function divisionBy3(){
    var num = document.getElementById("input").value;
    if(num.length == 2){
        var firstDigit = Math.floor(num / 10);
        var secondDigit = num % 10;
        var sum = firstDigit + secondDigit;
        if(sum % 3 == 0){
            console.log("the number is divided by 3 without remainder");
            document.getElementById("result").innerHTML = "the number is divided by 3 without remainder";
        }
        else{
            console.log("the number is not divided by 3 without remainder");
            document.getElementById("result").innerHTML = "the number is not divided by 3 without remainder";
        }
    }
    else if(num.length == 3){
        var firstDigit = Math.floor(num / 100);
        var secondDigit = Math.floor((num / 10) % 10);
        var thirdDigit = num % 10;
        var sum = firstDigit + secondDigit + thirdDigit;
        if(sum % 3 == 0){
            console.log("the number is divided by 3 without remainder");
            document.getElementById("result").innerHTML = "the number is divided by 3 without remainder";
        }
        else{
            console.log("the number is not divided by 3 without remainder");
            document.getElementById("result").innerHTML = "the number is not divided by 3 without remainder";
        }
    }
}