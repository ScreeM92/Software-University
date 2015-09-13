import java.util.*;
public class _2Exam5Pairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String numsAsString = input.nextLine();
		String[] numStrings = numsAsString.split(" ");
		int[] nums = new int[numStrings.length];
		
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(numStrings[i]);
		}
		
		int maxPair = 0;
		int minPair = 0;
		boolean equal = true; 
		
		for (int i = 0; i < nums.length; i+=2) {
			int sum = nums[i] + nums[i + 1];
			if (equal) {
				maxPair = sum;
				minPair = sum;
				equal = false;
			}
			else {
				if (sum > maxPair) {
					maxPair = sum;
				}
				else if (sum < minPair) {
					minPair = sum;
				}
			}
			
		}
		if (maxPair == minPair) {
			System.out.println("Yes, value=" + maxPair);
		}
		else {
			int diff = maxPair - minPair;
			System.out.println("No, maxdiff=" + diff);
		}
		
	}

}
