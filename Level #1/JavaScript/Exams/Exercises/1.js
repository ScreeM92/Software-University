function dd(input) {
    sortArray(['<table>','<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
        '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
        '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
        '<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
        '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
        '<tr><td>Cofee Davidoff 250gr.</td><td>11.99</td><td>+11</td></tr>','</table>']);
}
var tempArr = [], n;
for (var i in arr) {
    tempArr[i] = arr[i].match(/([.^0-9]+)|([.0-9]+)|([^.0-9]+)|([.0-9]+)/g);
    for (var j in tempArr[i]) {
        if (!isNaN(n = parseFloat(tempArr[i][j]))) {
            tempArr[i][j] = n;
        }
    }
}
tempArr.sort(function (x , y) {
    for (var i in x) {
        if (y.length < i || x[i] < y[i]) {
            return x-y;
        }
        if (x[i] > y[i]) {
            return 1;
        }
    }
    return x-y;
});
function sortNum(x,y){
    return x-y;
}
tempArr = tempArr.sort(sortNum);
for (var i in tempArr) {
    arr[i] = tempArr[i].join('');
}