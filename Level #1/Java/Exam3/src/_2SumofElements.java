import java.time.chrono.MinguoChronology;
import java.util.*;
public class _2SumofElements {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int max = Integer.MIN_VALUE;
		int currentNumber = 0;
		int sum = 0;
		String[] nums = input.nextLine().split(" ");
		
		for (int i = 0; i < nums.length; i++) {
			int number = Integer.parseInt(nums[i]);
			if (number > max) {
				max = number;
				currentNumber = i;
			}
		}
		for (int i = 0; i < nums.length; i++) {
			if (nums[currentNumber] == nums[i] ) {
				continue;				
			}
			else {
				sum = sum + Integer.parseInt(nums[i]);
			}
		}
		int diff = Math.abs(max - sum);
		if (sum == max) {
			System.out.println("Yes, sum=" + max);
		}
		else {
			System.out.println("No, diff=" + diff);
		}
		
	}

}
