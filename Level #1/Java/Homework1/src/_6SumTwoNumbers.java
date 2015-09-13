import java.io.*;
//import java.util.Scanner;
public class _6SumTwoNumbers {

	public static void main(String[] args) {
		int numOne;
		int numTwo;
		try {
			InputStreamReader in = new InputStreamReader(System.in);
			BufferedReader br = new BufferedReader(in);
			System.out.println("Enter first number:");
			String a1 = br.readLine();
			numOne = Integer.valueOf(a1);
			System.out.println("Enter second number:");
			String b2 = br.readLine();
			numTwo = Integer.valueOf(b2);
			int sum = numOne + numTwo;
			System.out.println(sum);
		} catch (Exception e) {
		}
		
		// 2ri nachin
		//		Scanner input = new Scanner(System.in);
		//		int first = input.nextInt();
		//		int second = input.nextInt();
		//		int sum = first + second;
		//		System.out.println(sum);
		//		input.close();

	}

}
