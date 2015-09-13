function solve(input) {
    input.pop();
    var sumStacks = 0;
    var sumBeers = 0;

    for (var i = 0; i < input.length; i++) {
        if(input[i].indexOf("stacks") > -1){
            var indexStacks = input[i].indexOf("stacks");
            var stacks = parseInt(input[i].slice(0, indexStacks));
            sumStacks += stacks;
        }
        else if(input[i].indexOf("beers") > -1){
            var indexBeers = input[i].indexOf("beers");
            var beers = parseInt(input[i].slice(0, indexBeers));
            sumBeers += beers;
                while(sumBeers > 19){
                    sumBeers -= 20;
                    sumStacks += 1;
                }
        }
    }
    console.log(sumStacks + " stacks " + "+ " + sumBeers + " beers")
}
solve(['4 stacks', '12 beers','10 beers','1 stacks','1 beers', 'End']);
solve(['41 beers', '1 stacks','19 beers','End']);
solve(['5 stacks', '12 beers','7 beers','1 stacks','1 beers', 'End']);