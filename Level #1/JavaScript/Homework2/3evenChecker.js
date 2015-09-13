function evenNumber() {
    var num = document.getElementById("input").value;
    if(num % 2 == 0){
        console.log("true");
        document.getElementById("result").innerHTML = "true";
    }
    else{
        console.log("false");
        document.getElementById("result").innerHTML = "false";
    }
}