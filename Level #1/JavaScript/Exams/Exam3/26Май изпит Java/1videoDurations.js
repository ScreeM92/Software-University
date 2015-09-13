function solve(input) {
    input.pop();
    var sumHours = 0;
    var sumMinutes = 0;

    for (var i = 0; i < input.length; i++) {
            var index = input[i].indexOf(":");
            var hours = parseInt(input[i].slice(0, index));
            var minutes = parseInt(input[i].slice(index + 1, input[i].length));

            sumHours += hours;
            sumMinutes += minutes;

            while(sumMinutes > 59){
                sumMinutes -= 60;
                sumHours += 1;
            }
    }
    if(sumMinutes < 10){
        sumMinutes = '0' + sumMinutes;
    }

    console.log(sumHours + ":" + sumMinutes)
}
solve(['1:40', '2:25','17:35','0:01','2:57', 'End']);
solve(['0:02', '0:59','End']);
solve(['0:00', '0:59','0:01','End']);
solve(['5:55', '4:44','3:33', '1:11','End']);
solve(['0:45',
'1:14',
'0:01',
'2:57',
'0:59',
'1:59',
'2:59',
'3:59',
'1:40',
'2:25',
'17:35',
'4:59',
'End'
])
