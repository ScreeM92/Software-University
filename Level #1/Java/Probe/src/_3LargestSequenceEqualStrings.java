import java.util.*;
public class _3LargestSequenceEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String str = input.nextLine();
		String[] string = str.split(" ");
		
		int maxCount = 1;
		int count = 1;
		int wordPlace = 0;
		
		for (int i = 1; i < string.length; i++) {
			if (string[i].equals(string[i - 1])) {
				maxCount++;
			}
			else {
				maxCount = 1;
			}
			if (maxCount > count) {
				count = maxCount;
				wordPlace = i;
			}
			
		}
		for (int j = 0; j < count; j++) {
			System.out.print(string[wordPlace] + " ");
		}
	}

}
