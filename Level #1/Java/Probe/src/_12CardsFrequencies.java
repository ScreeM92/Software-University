import java.util.*;
public class _12CardsFrequencies {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine().toLowerCase();
		String[] words = text.split("\\W+");
		int N = words.length;
		int maxCount = Integer.MIN_VALUE;
		
		Map<String, Integer> map = new LinkedHashMap();
		for (String word : words) {
			if (map.containsKey(word)) {
				map.put(word, map.get(word) + 1);
			}
			else {
				map.put(word, 1);
			}
		}
		
		for (Map.Entry<String, Integer> entry : map.entrySet()) {
			System.out.printf("%s -> %.2f%%", entry.getKey(), (double)entry.getValue() * 100 / N).println();
		}
	}

}
