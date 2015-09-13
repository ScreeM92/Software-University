import java.util.Scanner;


public class _1SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		 String[] var = input.nextLine().split(" ");
	        int start = Integer.parseInt(var[0]);
	        int end = Integer.parseInt(var[1]);
		input.close();
		
		for (int i = start; i <= end; i++) {
			
			String num = "" + i;
			if (num.length() == 1) {
				System.out.println(i);
			}
			else if (num.length() == 2) {
				if (num.charAt(0) == num.charAt(1)) {
					System.out.println(i);
				}
			}
			else if (num.length() == 3) {
				
				if (num.charAt(0) == num.charAt(2)) {
					System.out.println(i);
				}
			}
		}
	}

}
