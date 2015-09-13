function solve(table) {
    var maxSum = Number.NEGATIVE_INFINITY;
    for (var lineIndex = 2; lineIndex < table.length - 1; lineIndex++) {
        var row = table[lineIndex];
        var cells = row.match(/<td>(.*?)<\/td>/g);
        var sum = 0, values = [];
        for (var c = 1; c < cells.length; c++) {
            var cellValue = cells[c];
            cellValue = cellValue.substring('<td>'.length);
            cellValue = cellValue.substring(0, cellValue.length - '</td>'.length);
            var num = Number(cellValue.trim());
            if (! isNaN(num)) {
                values.push(cellValue);
                sum += num;
            }
        }
        if (sum > maxSum && values.length > 0) {
            maxSum = sum;
            var maxSumDetails = values.join(' + ');
        }
    }
    if (maxSum != Number.NEGATIVE_INFINITY) {
        console.log(maxSum + ' = ' + maxSumDetails);
    } else {
        console.log("no data");
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