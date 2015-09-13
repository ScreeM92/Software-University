import java.util.*;
public class _5CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String strr = input.nextLine();
		String[] words = strr.split("\\W+");

		int count = 0;
		for (String word : words) {
			count++;
		}
		System.out.println(count);
	}

}
