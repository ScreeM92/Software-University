function solve(input) {
    var cards = input[0].split(/[ CHDS]+/)
    cards.pop();
    var count = 1;
    var sum = 0;

    var cardsAll = [];
    for (var i in cards) {
        if(cards[i] == 'J'){
            cardsAll.push(parseInt(12))
        }
        else if(cards[i] == 'Q'){
            cardsAll.push(parseInt(13))
        }
        else if(cards[i] == 'K'){
            cardsAll.push(parseInt(14))
        }
        else if(cards[i] == 'A'){
            cardsAll.push(parseInt(15))
        }
        else{
            cardsAll.push(parseInt(cards[i]))
        }
    }

    for (var i = 0; i < cardsAll.length; i++) {
        while(cardsAll[i] == cardsAll[i + 1]){
            count++;
            i++;
        }
        if(count > 1){
            sum += cardsAll[i] * count * 2;
            count = 1;
        }
        else{
            sum += cardsAll[i];
        }
    }
    console.log(sum)
}
solve(['2C 2H 2D AS 10H 10C 2S KD']);
solve(['AS KH 10C']);
solve(['AS 10C KS KH KD 9H JH QS 3H QD QH 8S 10D 10S 7C JD']);