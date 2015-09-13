import java.util.*;
public class _6CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String sentence = in.nextLine().toLowerCase();
		String word = in.nextLine().toLowerCase();
		String[] str = sentence.split("\\W+");
		int counter = 0;

		for (int i = 0; i < str.length; i++) {
		if (word.equals(str[i])) {
		counter++;
		}
		}
		System.out.println(counter);
	}

}
