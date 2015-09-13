function solve(input) {
    var rows = [];
    for (var i = 2; i < input.length - 1; i++) {
        var rowData = input[i];
        var regex = /<td>.*?<\/td><td>(.*?)<\/td>/g;
        var match = regex.exec(rowData);
        var price = Number(match[1]);
        var row = { price: price, data: rowData };
        rows.push(row);
    }
    rows.sort(function (a, b) {
        if (a.price != b.price) {
            return a.price - b.price;
        } else {
            return a.data == b.data ? 0 : a.data < b.data ? -1 : 1;
        }
    });
    console.log(input[0]);
    console.log(input[1]);
    for (var i = 0; i < rows.length; i++) {
        console.log(rows[i].data);
    }
    console.log(input[input.length - 1]);
}

solve(['<table>',
    '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
    '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
    '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
    '<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
    '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
    '<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
    '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
    '</table>'
])