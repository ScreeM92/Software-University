import java.util.*;
public class _7CountOfBitsOne {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int num = input.nextInt();
		input.close();
		Integer count = 0;
		String str = String.format("%16s", Integer.toBinaryString(num & 0xFF)).replace(' ', '0');
		System.out.println(str);
		
		for (int i = 0; i < str.length(); i++) {
			if (str.charAt(i) == '1') {
				count++;
			}
		}
		System.out.println(count);
		//2ri nachin
		
		//int bit = 0;
		//bit = Integer.bitCount(num);
		//System.out.println(bit);
		
	}

}
