function bitChecker(){
    var num = document.getElementById("input").value;
    var numBinary = num.toString(8);
    var newBinary = numBinary >> 3;
    var mask = newBinary & 1;
    if(mask == 1){
        console.log("true");
        document.getElementById("result").innerHTML = "true";
    }
    else{
        console.log("false");
        document.getElementById("result").innerHTML = "false";
    }
}