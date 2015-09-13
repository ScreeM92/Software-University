function solve(input) {

    var start = input[0];
    var end = input[1];

    var fivSpecLett = [];

    for (var i = 0; i < 5; i++) {
        var a = String.fromCharCode(97 + i);
        for (var j = 0; j < 5; j++) {
            var b = String.fromCharCode(97 + j);
            for (var k = 0; k < 5; k++) {
                var c = String.fromCharCode(97 + k);
                for (var l = 0; l < 5; l++) {
                    var d = String.fromCharCode(97 + l);
                    for (var m = 0; m < 5; m++) {
                        var e = String.fromCharCode(97 + m);

                        var letters = a + b + c + d + e;
                        var specLet = "";


                        for (var n = 0; n < letters.length; n++) {

                                if(specLet.indexOf(letters.charAt(n)) < 0){
                                    specLet += letters.charAt(n);
                                }
                        }

                        var sum = 0;

                        for (var n = 1; n <= specLet.length; n++) {

                            if(specLet.charAt(n - 1) == 'a'){
                                sum += 5*n;
                            }
                            else if(specLet.charAt(n - 1) == 'b'){
                                sum += -12*n;
                            }
                            else if(specLet.charAt(n - 1) == 'c'){
                                sum += 47*n;
                            }
                            else if(specLet.charAt(n - 1) == 'd'){
                                sum += 7*n;
                            }
                            else if(specLet.charAt(n - 1) == 'e'){
                                sum += -32*n;
                            }
                        }

                        if(Number(start) <= sum && sum <= Number(end)){

                            fivSpecLett.push(letters);
                        }
                    }
                }
            }
        }
    }

    var positions = "";
    var count = 3;

    for (var i = 0; i < fivSpecLett.length; i++) {

            positions += fivSpecLett[i] + " ";
        if(i == count){
            positions += " ";
            positions += "\n";
            count += 4;
        }

    }

    if(positions == ""){
        console.log("No")
    } else {
        //console.log(positions);
        console.log(fivSpecLett.join(" "))
    }
}
//solve(['-1','1'])
//solve(['200','300'])
//solve(['300','400'])
solve(['100','120'])