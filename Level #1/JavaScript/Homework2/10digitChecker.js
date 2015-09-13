function checkDigit(){
    var num = document.getElementById("input").value;

    if(num < 1000){
        document.getElementById("result").innerHTML = "Try again: \"num > 1000\" "
    }
    else{
        var newNum = Math.floor(num / 100);
        var numString = newNum.toString();
        var numLength = numString.length;

        if(numString.charAt(numLength - 1) == "3"){
            document.getElementById("result").innerHTML = "true";
        }
        else{
            document.getElementById("result").innerHTML = "false";
        }
    }
    // 2-ri nachin
//    else{
//        if(Math.floor(num / 100) % 10){
//            document.getElementById("result").innerHTML = "true";
//        }
//        else{
//            document.getElementById("result").innerHTML = "false";
//        }
//    }
}
