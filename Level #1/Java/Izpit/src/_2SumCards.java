import java.util.*;
public class _2SumCards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String cards = input.nextLine();
		String[] card = cards.split("[SHDC] ");
		card[card.length - 1] = card[card.length - 1].substring(0, card[card.length - 1].length() - 1);
		int sum = 0;
		int mult = 1;
		int count = 1;
		
		for (int i = 0; i < card.length; i++) {
			if (card[i].equals(card[i+1])) {
				if (card[i].equals("2")) {
					sum += (2+2)*2;
				}
				 else if (card[i].equals("3")) {
					 sum += (3 + 3)*2;
				}
				 else if (card[i].equals("4")) {
					 sum += (4 + 4)*2;
					}
				 else if (card[i].equals("5")) {
					 sum += (5 + 5)*2;
					}
				 else if (card[i].equals("6")) {
					 sum += (6 + 6)*2;
					}
				 else if (card[i].equals("7")) {
					 sum += (7 + 7)*2;
					}
				 else if (card[i].equals("8")) {
					 sum += (8 + 8)*2;
					}
				 else if (card[i].equals("9")) {
					 sum += (9 + 9)*2;
					}
				 else if (card[i].equals("10")) {
					 sum += (10+ 10)*2;
					}
				 else if (card[i].equals("J")) {
					 sum += (12+12)*2;
					}
				 else if (card[i].equals("Q")) {
					 sum += (13+13)*2;
					}
				 else if (card[i].equals("K")) {
					 sum += (14+14)*2;
					}
				 else if (card[i].equals("A")) {
					 sum += (15+15)*2;
					}
			}
			else {
				if (card[i].equals("2")) {
					sum += 2;
				}
				 else if (card[i].equals("3")) {
					 sum += 3;
				}
				 else if (card[i].equals("4")) {
					 sum += 4;
					}
				 else if (card[i].equals("5")) {
					 sum += 5;
					}
				 else if (card[i].equals("6")) {
					 sum += 6;
					}
				 else if (card[i].equals("7")) {
					 sum += 7;
					}
				 else if (card[i].equals("8")) {
					 sum += 8;
					}
				 else if (card[i].equals("9")) {
					 sum += 9;
					}
				 else if (card[i].equals("10")) {
					 sum += 10;
					}
				 else if (card[i].equals("J")) {
					 sum += 12;
					}
				 else if (card[i].equals("Q")) {
					 sum += 13;
					}
				 else if (card[i].equals("K")) {
					 sum += 14;
					}
				 else if (card[i].equals("A")) {
					 sum += 15;
					}
			}
		}
		System.out.println(sum);
		
	}

}
