import java.util.*;
public class _6CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String strr = input.nextLine().toLowerCase();
		String[] words = strr.split("\\W+");
		String word = input.nextLine();
		int count = 0;
		
		for (int i = 0; i < words.length; i++) {
			if (word.equals(words[i])) {
				count++;
			}
		}
		System.out.println(count);
	}

}
