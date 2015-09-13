function convertDigitToWord(){
    var num = document.getElementById("input").value;
    switch(num){
        case "1":
            document.getElementById("result").innerHTML = "one";
            break;
        case "2":
            document.getElementById("result").innerHTML = "two";
            break;
        case "3":
            document.getElementById("result").innerHTML = "three";
            break;
        case "4":
            document.getElementById("result").innerHTML = "four";
            break;
        case "5":
            document.getElementById("result").innerHTML = "five";
            break;
        case "6":
            document.getElementById("result").innerHTML = "six";
            break;
        case "7":
            document.getElementById("result").innerHTML = "seven";
            break;
        case "8":
            document.getElementById("result").innerHTML = "eight";
            break;
        case "9":
            document.getElementById("result").innerHTML = "nine";
            break;
    }
}