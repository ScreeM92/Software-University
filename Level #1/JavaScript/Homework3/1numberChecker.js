function printNumbers(){
    var arrayNumbers = new Array();
    var n = document.getElementById("input").value;
    for(var i = 1; i <= n; i+=1){
        if(i % 4 == 0 || i % 5 == 0){
            continue;
        }
        else{
           arrayNumbers.push(i);
        }
    }
        if(arrayNumbers.length > 0){
           console.log(arrayNumbers);
    }
        else{
            console.log("no");
        }
}
