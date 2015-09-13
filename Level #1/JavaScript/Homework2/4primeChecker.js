function isPrime(){
    var num = document.getElementById("input").value;
    var maxDivider = Math.floor(Math.sqrt(num));
    for(var divider = 2; divider <= maxDivider; divider += 1){
        if(num % divider == 0){
            console.log("false");
            document.getElementById("result").innerHTML = "false";
            break;
        }
        else{
            console.log("true");
            document.getElementById("result").innerHTML = "true";
        }
    }
}