import java.util.*;

public class _11MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
        String[] words = input.nextLine().split("\\W+");
        TreeMap<String, Integer> frequencies = new TreeMap<>();
        int maxCount = 0;
        for (String word : words) {
            String wordToLowerCase = word.toLowerCase();
            if (!frequencies.containsKey(wordToLowerCase)) {
                frequencies.put(wordToLowerCase, 1);
            } else {
                frequencies.put(wordToLowerCase, frequencies.get(wordToLowerCase) + 1);
            }

            int currentCount = frequencies.get(wordToLowerCase);
            if (currentCount > maxCount) {
                maxCount = currentCount;
            }
        }
        
        for (Map.Entry<String, Integer> entry : frequencies.entrySet()) {
            if (entry.getValue() == maxCount) {
                System.out.printf("%s -> %.2f times", entry.getKey(), entry.getValue()).println();
            }
        }
//		try (Scanner scanner = new Scanner(System.in)) {
//            String[] words =  scanner.nextLine().split("\\W+");
//            TreeMap<String, Integer> wordOccurrences = new TreeMap<>();
//           
//            int maxWordCount = 0;
//            for (String word : words) {
//                    word = word.toLowerCase();
//                    Integer wordCount = wordOccurrences.get(word);
//                    if (wordCount == null) {
//                            wordCount = 0;
//                    }
//                    if (wordCount + 1 > maxWordCount) maxWordCount = wordCount + 1;
//                    wordOccurrences.put(word, wordCount + 1);
//            }
//           
//            for (Map.Entry<String, Integer> entry : wordOccurrences.entrySet()) {
//                    if (entry.getValue() == maxWordCount) {
//                            System.out.println(entry.getKey() + " -> "
//                                            + maxWordCount + " times");
//                    }
//            }
//    } catch (Exception e) {
//            e.printStackTrace();
//    }

	}

}
