function solve(input){
    var numRotate = input[0].split(/[^0-9]+/g);
    numRotate.shift();
    numRotate.pop();
    numRotate = numRotate.join('');

    var text = [];
    var maxLength = 0;
    for (var i = 1; i < input.length; i++) {

        var length = input[i].length;
        if(length > maxLength){
            maxLength = length;
        }
        text.push(input[i].split(''));
    }
    if(numRotate == 0 || numRotate % 360 == 0){
        console.log(text.join("\n").replace(/,/g,''));
    }
    else{
    for (var i = 0; i < text.length; i++) {
        for (var j = 0; j < text[i].length; j++) {

            if(text[i].length < maxLength){
                text[i].push(" ");
            }
            else{
                break;
            }
        }
    }

        var rotate = numRotate / 90;
        var rightRotate = [];
        var last = [];
        var string = '';

        if(rotate % 2 != 0){
            for (var i = 0; i < rotate; i++) {
                for (var j = 0; j < maxLength; j++) {
                    for (var k = 0; k < text.length; k++) {

                        string += text[text.length - 1 - k][j];
                    }
                    if(j != maxLength - 1) {
                        string += '\n';
                    }
                }
            }
        } else{
            for (var i = 0; i < rotate; i++) {
                for (var j = 0; j < text.length; j++) {
                    for (var k = 0; k < text[j.length - 1]; k++) {


                    }
                }
             }
        }
        console.log(string);
    }
}
solve(['Rotate(90)','hello','softuni','exam' ]);
