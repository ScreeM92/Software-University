import java.util.*;
public class _7CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String strr = input.nextLine().toLowerCase();
		String word = input.nextLine().toLowerCase();
		int count = 0;
		
		for (int i = 0; i <= strr.length() - word.length(); i++) {
			if (strr.substring(i, word.length() + i).contains(word)) {
				count++;
			}
		}
		
		System.out.println(count);

	}

}
