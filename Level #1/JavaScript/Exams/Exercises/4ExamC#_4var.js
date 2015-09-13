function solve(input){
    var tribA = parseInt(input[0]);
    var tribB = parseInt(input[1]);
    var tribC = parseInt(input[2]);
    var tribonacci = 0;

    var tribo = [];
    tribo.push(tribA);
    tribo.push(tribB);
    tribo.push(tribC);

     for (var i = 1; i < 10000; i++) {
        tribonacci = tribA + tribB + tribC;

         if(tribonacci > 1000000){
             break;
         } else{

        tribo.push(tribonacci);
        tribA = tribB;
        tribB = tribC;
        tribC = tribonacci;
         }
     }
        //console.log(tribo);


    var num = parseInt(input[3]);
    var step = parseInt(input[4]);

    var temp = step;
    var spyral = [];
    var overMillion = false;
    var count = 2;
    spyral.push(num);

    for (var i = 0; i < Infinity; i++) {
        if(overMillion){
            break;
        }

        for (var j = 1; j <= 2; j++) {

            num += step;
            if(num > 1000000){
                overMillion = true;
                break;
            } else{
            spyral.push(num);
            }

        }
        step += temp;
        count++;
    }

    //console.log(spyral);

    var smallestNum = Number.MIN_VALUE;
    var isSmallest = false;

    for (var i = 0; i < tribo.length; i++) {
        if(isSmallest){
            break;
        }
        for (var j = 0; j < spyral.length; j++) {

            if(tribo[i] == spyral[j]){
                smallestNum = tribo[i];
                isSmallest = true;
                break
            }
        }
    }

    if(smallestNum == Number.MIN_VALUE){
        console.log("No")
    } else{
        console.log(smallestNum)
    }
}
solve(['1','1','999998','999996','4']);
//solve(['1','1','1','1','1']);
//solve(['13','25','99','5','2']);
//solve(['99','99','99','2','2']);
//solve(['4','1','7','23','3']);
//solve(['5','-1','2','3']);