import java.text.DecimalFormat;
import java.util.*;
public class _2Exam6OddEvenElements {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String numString = input.nextLine();
		String[] nums = numString.split(" ");
		double OddSum = 0, OddMin = Integer.MAX_VALUE,
				OddMax = Integer.MIN_VALUE, EvenSum = 0,
				EvenMin = Integer.MAX_VALUE,
				EvenMax = Integer.MIN_VALUE;
		for (int i = 0; i < nums.length; i++) {
			if (i % 2 == 0) {
				double currentNum = Double.parseDouble(nums[i]);
				OddSum += Double.parseDouble(nums[i]);
				
				if (currentNum > OddMax) {
					OddMax = currentNum;
				}
				if (currentNum < OddMin) {
					OddMin = currentNum;
				}
			}
			else {
				double currentNum = Double.parseDouble(nums[i]);
				EvenSum += Double.parseDouble(nums[i]);
				
				if (currentNum > EvenMax) {
					EvenMax = currentNum;
				}
				if (currentNum < EvenMin) {
					EvenMin = currentNum;
				}
			}
		}
		DecimalFormat dF = new DecimalFormat("########.##");
		
		if (nums.length > 1) {
			System.out.printf("OddSum=%1$s, OddMin=%2$s, OddMax=%3$s, EvenSum=%4$s, EvenMin=%5$s, EvenMax=%6$s", dF.format(OddSum), dF.format(OddMin), dF.format(OddMax), dF.format(EvenSum), dF.format(EvenMin), dF.format(EvenMax));
		}
		if (nums.length == 1) {
			System.out.printf("OddSum=%1$s, OddMin=%2$s, OddMax=%3$s, EvenSum=No, EvenMin=No, EvenMax=No", dF.format(OddSum), dF.format(OddMin), dF.format(OddMax));
		}
		if (nums.length < 1) {
			System.out.println("No");
		}
	}

}
