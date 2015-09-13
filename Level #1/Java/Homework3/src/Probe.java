


public class Probe {
	public static void printCard(int number){
		if (number <= 10) {
			switch (number) {
			case 2: System.out.print("2"); break;
			case 3: System.out.print("3"); break;
			case 4: System.out.print("4"); break;
			case 5: System.out.print("5"); break;
			case 6: System.out.print("6"); break;
			case 7: System.out.print("7"); break;
			case 8: System.out.print("8"); break;
			case 9: System.out.print("9"); break;
			case 10: System.out.print("10"); break;
			}
		}
			else if (number > 10) {
				switch (number) {
				case 11: System.out.print("J"); break;
				case 12: System.out.print("Q"); break;
				case 13: System.out.print("K"); break;
				case 14: System.out.print("A"); break;
				}
			
			}
		}
	
	public static void printSuit(int firstSuit){
		switch (firstSuit) {
		case 1: System.out.print("♣ "); break;
		case 2: System.out.print("♦ "); break;
		case 3: System.out.print("♥ "); break;
		case 4: System.out.print("♠ "); break;
			
		}
		
	}

	public static void main(String[] args) {
		 int count = 0;
		for (int firstCard = 2; firstCard <= 14; firstCard++) {
			for (int secondCard = 2; secondCard <= 14; secondCard++) {
				if (firstCard == secondCard) {
					continue;
				}
				for (int firstSuit = 1; firstSuit <= 4; firstSuit++) {
					for (int secondSuit = firstSuit + 1; secondSuit <= 4; secondSuit++) {
						for (int thirdSuit = secondSuit + 1; thirdSuit <= 4; thirdSuit++) {
							for (int fourthSuit = 1; fourthSuit <= 4; fourthSuit++) {
								for (int fifthSuit = fourthSuit + 1; fifthSuit <= 4; fifthSuit++) {
									
									printCard(firstCard);
									printSuit(firstSuit);
									printCard(firstCard);
									printSuit(secondSuit);
									printCard(firstCard);
									printSuit(thirdSuit);
									printCard(secondCard);
									printSuit(fourthSuit);
									printCard(secondCard);
									printSuit(fifthSuit);
									count++;
									System.out.println();
								}
							}
						}
					}
				}
			}
		}
		System.out.println(count);
	}
}
		
		

