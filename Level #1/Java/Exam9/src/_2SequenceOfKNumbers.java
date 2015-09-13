import java.util.*;
public class _2SequenceOfKNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] inputNumberAsStrings = input.nextLine().split(" ");
		int k = input.nextInt();
		int[] inputNumber = new int[inputNumberAsStrings.length];
		for (int i = 0; i < inputNumber.length; i++) {
			inputNumber[i] = Integer.parseInt(inputNumberAsStrings[i]);
		}
		if (k == 1) {
			
		}
		else {
			int count = 1;
			for (int i = 1; i < inputNumber.length; i++) {
				if (inputNumber[i] == inputNumber[i - 1]) {
					count++;
					if (i == inputNumber.length-1) {
						for (int j = 0; j < count % k; j++) {
							System.out.print(inputNumber[i - 1] + " ");
						}
					}
				}
				else {
					for (int j = 0; j < count % k; j++) {
						System.out.print(inputNumber[i - 1] + " ");
					}
					count = 1;
				}
			}
		}
	}

}
