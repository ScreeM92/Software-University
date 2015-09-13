import java.util.*;
public class _5DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int dec = input.nextInt();
		input.close();
		String hex = Integer.toHexString(dec);
		System.out.println(hex.toUpperCase());
	}

}
