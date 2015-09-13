function solve(value) {
    var result = [];
    for (var i = 2; i < value.length; i++) {
        result[i - 2] = value[i].split(/[^0-9.-]+/g)
    }

    for (var i = 0; i < result.length; i++) {
        result[i].pop();
        result[i].shift();
    }
    result.pop();
    var maxSum = 0;
    var sum = 0;
    var count = 0;
    var maxCount = 0;
    var position = [];
    var lastPosition = [];
    var last = [];
    var mer = 0;

    for (var i = 0; i < result.length; i++) {
        var floatResult = result[i];
        for (var j = 0; j < floatResult.length; j++) {
            if(floatResult[j] == "-"){
                continue;
            }
            else{
                sum += Number(floatResult[j]);
                position.push(floatResult[j]);
                mer++;
            }
            if(sum > maxSum){
                maxSum = sum;
                if(j == floatResult.length - 1 || mer == position.length){
                    for (var k = 0; k < position.length; k++) {
                        lastPosition.push(position[k]);
                        count = position.length;
                        maxCount = count;
                    }
                }
            }
        }
        position = [];
        count = 0;
        sum = 0;
        mer = 0;
    }

    for (var i = 0; i < maxCount; i++) {
        last.push(lastPosition[lastPosition.length - 1 - i]);
    }
    if(maxCount == 1){
        console.log(maxSum + " = " + last[0])
    }
    else if(maxCount == 3){
        console.log(maxSum + " = " + last[2] + " + " + last[1] + " + " + last[0])
    }
    else if(maxCount == 2){
        console.log(maxSum + " = " + last[0] + " + " + last[1])
    }

    else{
        console.log("no data")
    }
}
solve(['<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<td><td>Sofia</th><th>26.2</th><th>8.20</th><th>-</th></tr>',
    '<td><td>Varna</th><th>11.2</th><th>18.00</th><th>36.10</th></tr>',
    '<td><td>Plovdiv</th><th>17.2</th><th>12.3</th><th>6.4</th></tr>',
    '<td><td>Bourgas</th><th>-</th><th>24.3</th><th>-</th></tr>',
    '</table>']);
solve(['<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><th>Sofia</th><th>-</th><th>-</th><th>-</th></tr>',
    '</table>']);
solve(['<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><th>Sofia</th><th>12850</th><th>-560</th><th>20833</th></tr>',
    '<tr><th>Varna</th><th>-</th><th>50000.0</th><th>-</th></tr>',
    '<tr><th>Plovdiv</th><th>25000</th><th>25000</th><th>-</th></tr>',
    '</table>']);
solve(['<table>',
    '<tr><th>Ploddvdiv</th><th>-0.0000002</th><th>1</th><th>47.112</th></tr>',
    '<tr><th>Pldodvdiv</th><th>19</th><th>47.112</th><th>-0.2</th></tr>',
    '<tr><th>Pldodvdiv</th><th>47.112</th><th>-</th><th>19</th></tr>',
    '</table>']);
solve(['<table>',
    '<tr><th>Ploddvdiv</th><th>-0.0000002</th><th>1</th><th>47.112</th></tr>',
    '<tr><th>Pldodvdiv</th><th>55</th><th>47.112</th><th>-0.2</th></tr>',
    '<tr><th>Pldodvdiv</th><th>47.112</th><th>-</th><th>19</th></tr>',
    '<tr><th>Pldodvdiv</th><th>19</th><th>47.112</th><th>-0.2</th></tr>',
    '<tr><th>Pldodvdiv</th><th>47.112</th><th>-</th><th>19</th></tr>',
    '</table>']);
