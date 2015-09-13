import java.util.*;
public class _6FormattingNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter a:(0 ≤ a ≤ 500)");
		int a = input.nextInt();
		String hex = Integer.toHexString(a);
		String str = String.format("%8s", Integer.toBinaryString(a & 0xFF)).replace(' ', '0');
		System.out.println("Enter b:");
		float b = input.nextFloat();
		System.out.println("Enter c:");
		float c = input.nextFloat();
		input.close();

		System.out.printf("|%-10s|%s|%10.2f|%-10.3f|",hex.toUpperCase(),str,b,c);
	}

}
