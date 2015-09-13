


public class _3FullHouse {

	public static void printCard(int number) {
		if (number <= 10)
			System.out.print(number);
		else {
			switch (number) {
			case 11:
				System.out.print("J");
				break;
			case 12:
				System.out.print("Q");
				break;
			case 13:
				System.out.print("K");
				break;
			case 14:
				System.out.print("A");
				break;
			}
		}
	}

	public static void printSuit(int suitNumber) {
		char clubs = '♣';
		char diamonds = '♦';
		char hearts = '♥';
		char spades = '♠';
		switch (suitNumber) {
		case 1:
			System.out.print(clubs + " ");
			break;
		case 2:
			System.out.print(diamonds + " ");
			break;
		case 3:
			System.out.print(hearts + " ");
			break;
		case 4:
			System.out.print(spades + " ");
			break;
		}
	}

	public static void main(String[] args) {
		int counter = 0;
		for (int firstCard = 2; firstCard <= 14; firstCard++) {
			for (int secondCard = 2; secondCard <= 14; secondCard++) {
				if (secondCard == firstCard)
					continue;
				for (int firstSuit = 1; firstSuit <= 4; firstSuit++) {
					for (int secondSuit = firstSuit + 1; secondSuit <= 4; secondSuit++) {
						for (int thirdSuit = secondSuit + 1; thirdSuit <= 4; thirdSuit++) {
							for (int forthSuit = 1; forthSuit <= 4; forthSuit++) {
								for (int fifthSuit = forthSuit + 1; fifthSuit <= 4; fifthSuit++) {
									printCard(firstCard);
									printSuit(firstSuit);
									printCard(firstCard);
									printSuit(secondSuit);
									printCard(firstCard);
									printSuit(thirdSuit);
									printCard(secondCard);
									printSuit(forthSuit);
									printCard(secondCard);
									printSuit(fifthSuit);
									System.out.println();
									counter++;

								}
							}
						}
					}
				}

			}
		}
		   System.out.println(counter);
	}
 
}

