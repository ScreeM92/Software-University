//function indCardFrequency(inputString) {
//    var cards = inputString.split(' ');
//    var cardsFaces = [];
//    var cardsAppearance = [];
//    var i;
//    for (i = 0; i < cards.length; i += 1) {
//        var currentCard = cards[i];
//        var cardFace = currentCard[0];
//        var cardCounter = 0;
//
//        //check if array contains cardFace
//        if (cardsFaces.indexOf(cardFace) > -1) {
//            continue;
//        }
//        cardsFaces.push(cardFace);
//
//        for (var j = i; j < cards.length; j++) {
//            var targetCard = cards[j];
//            var targetCardFace = targetCard[0];
//
//            if (targetCardFace === cardFace) {
//                cardCounter += 1;
//            }
//        }
//        cardsAppearance.push(cardCounter);
//    }
//
//    for (i = 0; i < cardsFaces.length; i += 1) {
//        var percentage = (cardsAppearance[i] / cards.length * 100).toFixed(2);
//
//        //if cardFace is '1' the card is 10 so print 10 :)
//        if (cardsFaces[i] === '1') {
//            console.log('10 -> ' + percentage + '%');
//
//        } else {
//            console.log(cardsFaces[i] + ' -> ' + percentage + '%');
//        }
//    }
//
//    console.log();
//}
//
//indCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
//indCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
//indCardFrequency('10♣ 10♥');


//                                                       second way

//function findCardFrequency(inputString) {
//
//    function getUniqueElements(arr) {
//        var uniqueElements = [];
//
//        for (var i in arr) {
//            if (uniqueElements.indexOf(arr[i]) === -1) { // if elements doesn't exist, add it to the array
//                uniqueElements.push(arr[i]);
//            }
//        }
//
//        return uniqueElements;
//    }
//
//    var cards = inputString.split(/[♣♦♥♠ ]+/);
//    var frequencies = [];
//
//    cards.pop(); //removing last element
//
//    //calculate frequence of cards
//    for (var i in cards) {
//        if (cards[i] in frequencies) {
//            frequencies[cards[i]]++; // if exist, frequencies is + 1
//        } else {
//            frequencies[cards[i]] = 1; // if not exist, create new instance equals to 1
//        }
//    }
//
//    var output = ''; //storing the output string
//    var cardsLength = cards.length;
//
//    cards = getUniqueElements(cards);
//    // now we have all unique cards and their frequency
//    for (i in cards) {
//        var percent = (frequencies[cards[i]] / cardsLength * 100).toFixed(2); // calculate percent for each element
//        output += cards[i] + ' -> ' + percent + '%<br>'; // in the browser console <br> should be /n !!
//    }
//
//    return output;
//}
//
//findCardFrequency("8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦");
//findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
//findCardFrequency('10♣ 10♥');

// third way

function findCardFrequency(input){

    var cards = input.split(/[♣♦♥♠ ]+/);
    cards.pop();

    var frequency = [];
    var unique = [];
    for(var key in cards){
        if(cards[key] in frequency){
            frequency[cards[key]]++;
        }
        else{
            frequency[cards[key]] = 1;
            unique.push(cards[key]);
        }
    }
    for(var key in unique){
        console.log(unique[key] + " -> " + (frequency[unique[key]] / cards.length * 100).toFixed(2) + "%");
    }

}
findCardFrequency("8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦");
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');

//fourth way
//function findCardFrequency (value) {
//
//    var newValue = value.split(/[♥♣♦♠ ]+/);
//    newValue.pop();
//    var arr = {"1" : 0, "2" : 0, "3" : 0, "4" : 0, "5" : 0, "6" : 0, "7" : 0, "8" : 0, "9" : 0, "10" : 0, "J" : 0, "Q" : 0, "K" : 0, "A" : 0};
//
//    var result = "";
//
//    for (var i = 0; i < newValue.length; i++) {
//        for (var key in arr) {
//            if (newValue[i] == key) {
//                arr[key]++;
//            }
//        }
//    }
//
//    for (var key in arr) {
//        var value = arr[key];
//        if (value != 0) {
//            result += key + " -> " + ( (value / newValue.length) * 100 ).toFixed(2) + "%\r\n";
//        }
//    }
//    return result;
//}
//
//console.log(findCardFrequency("8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦"));
//console.log(findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠'));
//console.log(findCardFrequency('10♣ 10♥'));