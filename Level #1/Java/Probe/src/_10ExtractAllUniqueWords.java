import java.util.*;
public class _10ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String strr = input.nextLine().toLowerCase();
		String[] arr = strr.split("\\W+");
		TreeSet<String> words = new TreeSet<String>();

		for (int i = 0; i < arr.length; i++) {
			words.add(arr[i]);
		}
		for (String string : words) {
			System.out.print(string + " ");
		}
	}

}
