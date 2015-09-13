import java.util.*;
public class _8CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter n:");
		int n = input.nextInt();
		String bit = Integer.toBinaryString(n);
		input.close();
		int count = 0;
		for (int i = 0; i < bit.length() - 1; i++) {
			if (bit.charAt(i) == bit.charAt(i+1)) {
				count++;
			}
		}
		System.out.println(bit);
		System.out.println(count);
	}

}
