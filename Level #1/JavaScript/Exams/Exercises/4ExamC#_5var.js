function solve(input){

    var start = input[0];
    var end = input[1];
    var weight = input[2];
    var date = "";
    var zeroJ = "";
    var zeroK = "";
    var magicDate = false;

    function getLastDay(year, month) {

        return new Date(year, month, 0).getDate();
    }

    for (var year = start; year <= end; year++) {

        for (var month = 1; month <= 12; month++) {
            for (var day = 1; day <= getLastDay(year, month); day++) {
                if(day < 10){
                    zeroJ = "0";
                } else{
                    zeroJ = "";
                }
                if(month < 10){
                    zeroK = "0";
                } else{
                    zeroK = "";
                }

                date = zeroK + month + zeroJ + day + year;

                var sum = 0;

                for (var l = 0; l < date.length; l++) {
                    for (var m = l + 1; m < date.length; m++) {

                         sum += Number(date[l]*date[m]);
                    }
                }

                if(sum == weight){
                    magicDate = true;
                    console.log(zeroJ+day + "-" + zeroK+month + "-" + year);
                }
            }
        }
    }
    if(!magicDate){
        console.log("No")
    }
}
solve(['2007','2007','144']);
//solve(['2003','2004','1500']);
