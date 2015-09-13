import java.util.*;

public class _2HalfSum {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		int sum1 = 0;
		int sum2 = 0;
		for (int i = 0; i < n; i++) {
			sum1= sum1 + input.nextInt();
		}
		for (int i = 0; i < n; i++) {
			sum2= sum2 + input.nextInt();
		}
		input.close();
		
		if (sum1 == sum2) {
			System.out.println("Yes, sum="+ sum1);
		}
		else {
			System.out.println("No, diff=" + Math.abs(sum1 - sum2));
		}
	}

}
