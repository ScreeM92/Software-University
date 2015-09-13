function compareChars(){
    var charsArray1 = new Array();
    var charsArray2 = new Array();
    var chars1 = document.getElementById("input").value;
    var chars2 = document.getElementById("input1").value;

    chars1 = chars1.split(" ");
    chars2 = chars2.split(" ");
    var equal = true;

    for(var i = 0; i < chars1.length; i += 1){
        charsArray1[i] = chars1[i];
        charsArray2[i] = chars2[i];
    }
    if(chars1.length !== chars2.length){
        console.log("Not Equal");
    }
    else{
        for(var j = 0; j < charsArray1.length; j +=1){
            if(charsArray1[j] == charsArray2[j]){
                equal = true;
            }
            else{
                equal = false;
                break;
            }
        }
        if(equal){
            console.log("Equal");
        }
        else{
            console.log("Not Equal");
        }
    }
}