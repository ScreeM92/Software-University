import java.util.*;
public class _4FiveSpecialLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int startNum = input.nextInt();
		int endNum = input.nextInt();
		input.close();

		for (char first = 'a'; first <= 'e'; first++) {
			for (char second = 'a'; second <= 'e'; second ++) {
				for (char third = 'a'; third <= 'e'; third++) {
					for (char fourth = 'a'; fourth <= 'e'; fourth++) {
						for (char fifth = 'a'; fifth <= 'e'; fifth++) {
							String wholeWord = "" + first + second + third + fourth + fifth;
							
						}
					}
				}
			}
		}
	}
	public static int calcWeight(Character letter){
		int letterWeight = 0;
		switch (letter) {
		case 'a':
			letterWeight = 5;
			break;
		case 'b':
			letterWeight = -12;
			break;
		case 'c':
			letterWeight = 47;
			break;
		case 'd':
			letterWeight = 7;
			break;
		case 'e':
			letterWeight = -32;
			break;

		default:
			break;
			return letterWeight;
		}
	}
}
