import java.util.Scanner;

public class _2BigestTriple {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] numbersAsStrings = input.nextLine().split(" ");
        int[] numbers = new int[numbersAsStrings.length];

        for (int i = 0; i < numbersAsStrings.length; i++) {
            numbers[i] = Integer.parseInt(numbersAsStrings[i]);
        }

        int currentSum = 0;
        int currentStartIndex = 0;
        int currentSubsequenceLength = 0;
        int bestStartIndex = 0;
        int bestSubsequenceLength = 0;
        int bestSum = Integer.MIN_VALUE;
        for (int i = 0; i < numbers.length; i += 3) {
            currentSum = numbers[i];
            currentSubsequenceLength = 1;

            if (i + 1 < numbers.length) {
                currentSum += numbers[i + 1];
                currentSubsequenceLength++;
            }

            if (i + 2 < numbers.length) {
                currentSum += numbers[i + 2];
                currentSubsequenceLength++;
            }

            if (currentSum > bestSum) {
                bestStartIndex = i;
                bestSubsequenceLength = currentSubsequenceLength;
                bestSum = currentSum;
            }
        }

        String output = "";
        for (int i = bestStartIndex; i <bestStartIndex + bestSubsequenceLength; i++) {
            output+= numbers[i] + " ";
        }

        System.out.println(output.trim());
    }
}