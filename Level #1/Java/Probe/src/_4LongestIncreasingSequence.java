import java.util.*;
public class _4LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String str = input.nextLine();
		String[] arr = str.split(" ");
		int[] numbers = new int[arr.length];
		
		int counter = 1;
		int counterTemp = 1;
		int position = 0;
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(arr[i]);
		}
		System.out.print(arr[0]);

		for (int i = 1; i < numbers.length; i++) {
			if (numbers[i] > numbers[i - 1]) {
				System.out.print(" " + numbers[i]);
				counterTemp++;
			}
			else {
				System.out.println();
				System.out.print(numbers[i]);
				counterTemp = 1;
			}
			if (counterTemp > counter) {
				counter = counterTemp;
				position = i;
			}
		}
		System.out.println();
		System.out.print("Longest: ");
		for (int i = 0; i < counter; i++) {
			System.out.print(numbers[position - counter + 1 + i] + " ");
		}
	}

}
