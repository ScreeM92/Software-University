import java.security.Principal;
import java.util.*;
public class _3TheExplorer {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();

		printChar('-', (n - 1) / 2);
		printChar('*', 1);
		printChar('-', (n - 1) / 2);
		System.out.println();
		
		for (int i = 1; i <= n / 2 - 1; i++) {
		printChar('-', n / 2 - i);
		printChar('*', 1);
		printChar('-', 2*i - 1);
		printChar('*', 1);
		printChar('-', n / 2 - i);
		System.out.println();
		}
		
		printChar('*', 1);
		printChar('-', n - 2);
		printChar('*', 1);
		System.out.println();
		
		for (int i = 1; i <= n / 2 - 1; i++) {
			printChar('-', i);
			printChar('*', 1);
			printChar('-', (n - 2) - 2*i);
			printChar('*', 1);
			printChar('-', i);
			System.out.println();
		}
		printChar('-', (n - 1) / 2);
		printChar('*', 1);
		printChar('-', (n - 1) / 2);
	}
	public static void printChar(char c, int i) {
		for (int j = 0; j < i; j++) {
			System.out.print(c);
	}	
	}
}
