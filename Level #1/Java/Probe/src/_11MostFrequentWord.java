import java.util.*;
import java.util.Map.Entry;
public class _11MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine().toLowerCase();
		String[] words = text.split("\\W+");
		
		TreeMap<String, Integer> map = new TreeMap<>();
		
		int maxCount = Integer.MIN_VALUE;
		
		for (String word : words) {
			if (map.containsKey(word)) {
				map.put(word, map.get(word) + 1);
			}
			else {
				map.put(word, 1);
			}
			int count = map.get(word);
			if (count > maxCount) {
				maxCount = count;
			}
		}
		
		for (Map.Entry<String, Integer> entry : map.entrySet()) {
			if (entry.getValue() == maxCount) {
				System.out.printf("%s -> %d times", entry.getKey(), entry.getValue()).println();;
			}
		}

	}

}
