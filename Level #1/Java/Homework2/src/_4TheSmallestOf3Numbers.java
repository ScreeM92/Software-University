import java.util.*;
public class _4TheSmallestOf3Numbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double first = input.nextDouble();
		double second = input.nextDouble();
		double third = input.nextDouble();
		input.close();
		if (first < second && first < third) {
			System.out.println(first);
		}
		else if (second < first && second < third) {
			System.out.println(second);
		}
		else {
			System.out.printf("%s", third);
		}
	}

}
