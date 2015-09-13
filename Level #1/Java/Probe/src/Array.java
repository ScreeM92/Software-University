import java.util.*;
public class Array {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputLine = input.nextLine();
		String[] elements = inputLine.split(" ");
		int[] nums = new int[elements.length];
		
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(elements[i]);
		}
		
		int max = Integer.MIN_VALUE;
		int min = Integer.MAX_VALUE;
		long sum = 0;
		
		for (int i = 0; i < nums.length; i++) {
			int num = nums[i];
			
			if (num > max) {
				max = num;
			}
			if (num < min) {
				min = num;
			}
			sum += num;
		}
		double avg = (double)sum / nums.length;
		System.out.println("min =" + min);
		System.out.println("max =" + max);
		System.out.println("sum =" + sum);
		System.out.println("avg =" + avg);

	}

}
