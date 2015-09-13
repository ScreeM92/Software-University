import java.util.*;
public class _4NineDigitMagicNumbers {
  public static int sumOfDigits(int number){
	int first = number / 100;
	int second = number%100/10;
	int third = number % 10;
	return first + second + third;
}
  public static boolean isCorrect(int number){
		int first = number / 100;
		int second = number%100/10;
		int third = number % 10;
		return first > 0 && first < 8 && second > 0 && second < 8 && third > 0 && third < 8;
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		int sum = input.nextInt();
		int diff = input.nextInt();
		input.close();
		for (int n1 = 111; n1 < 777; n1++) {
			int n2 = n1 + diff;
			int n3 = n1 + 2 * diff;
			if (sumOfDigits(n1) + sumOfDigits(n2) + sumOfDigits(n3) == sum
					&& isCorrect(n1) && isCorrect(n2) && isCorrect(n3)) {
				System.out.println(n1 + "" + n2 + "" + n3);
			}
			else {
				System.out.println("No");
			}
		}
	}

}
