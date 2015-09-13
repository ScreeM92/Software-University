import java.util.*;
import java.util.Set;
import java.util.TreeSet;

public class _10ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String[] text = in.nextLine().toLowerCase().split("\\W+");
		Set<String> setWords = new TreeSet<>();
		
		for (String word : text) {
		setWords.add(word);
		}

		for (String word : setWords) {
		System.out.print(word + " ");
		}
	}

}
