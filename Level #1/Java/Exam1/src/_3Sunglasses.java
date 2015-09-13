import java.util.*;
public class _3Sunglasses {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.close();
		String empty = new String(new char[n]);
		String asterix = new String(new char[2*n]).replace("\0", "*");
		String dash = new String(new char[2*n - 2]).replace("\0", "/");
		String bridge = empty.replace("\0", "|");
		
		System.out.println(asterix+empty+asterix);
		
		for (int i = 0; i < (n - 3) / 2; i++) {
			System.out.println("*" + dash + "*" + empty + "*" + dash + "*");
		}
		
		System.out.println("*" + dash + "*" + bridge + "*" + dash + "*");
		
		for (int i = 0; i < (n - 3) / 2; i++) {
			System.out.println("*" + dash + "*" + empty + "*" + dash + "*");
		}
		
		System.out.println(asterix+empty+asterix);
	}

}
