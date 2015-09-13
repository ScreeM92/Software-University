import java.util.*;
public class _2equencesEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String str = input.nextLine();
		String[] allStr = str.split(" ");
		
		System.out.print(allStr[0]);
		for (int i = 1; i < allStr.length; i++) {
			if (allStr[i].equals(allStr[i - 1])) {
				System.out.print(" " + allStr[i]);
			}
			else {
				System.out.println();
				System.out.print(allStr[i]);
			}
		}

	}

}
