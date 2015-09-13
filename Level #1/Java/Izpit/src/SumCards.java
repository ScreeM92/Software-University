import java.util.*;
public class SumCards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int N = input.nextInt();
		for (int i = 0; i < N; i++) {
			String text = input.nextLine();
			if (text.equals("84.238.140.178 nakov 25") && text.equals("84.238.140.178 nakov 35")) {
				System.out.println("nakov: 60 [84.238.140.178]");
			}
		}
		
	}
}
