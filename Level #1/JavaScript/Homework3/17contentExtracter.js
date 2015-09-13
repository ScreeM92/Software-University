//function extractContent(value){
//    var text = "";
//    for(var i = 0; i < value.length; i += 1){
//        if(value[i] == ">"){
//            var k = i + 1;
//            for(var j = i; j < value.length - 1; j++) {
//
//                if (value[k] == "<") {
//                    k = i + 1;
//                    break;
//                }
//                else {
//                    text += value[k];
//                    k++;
//                }
//            }
//        }
//        else{
//            continue;
//        }
//    }
//    return (text);
//}
//console.log(extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>"));

//                                                   second way

function extractContentTwo(value){
    var text = "";
    for(var i = 0; i < value.length; i += 1){
        if(value[i] == "<"){
            while(value[i] != ">"){
                i++;
            }
        }
        else{
            text += value[i];
        }
    }

    return (text);
}
console.log(extractContentTwo("'<p>Hello</p><a href='http://w3c.org'>W3C</a>'"));