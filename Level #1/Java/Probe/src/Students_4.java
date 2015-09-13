import java.util.*;

public class Students_4 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int count = input.nextInt();
        input.nextLine();
        LinkedHashMap<String, ArrayList<Integer>> marks = new LinkedHashMap<>();
        for (int i = 0; i < count; i++) {
            String[] currentNameAndMarks = input.nextLine().split("\\W+");
            String name = currentNameAndMarks[0];
            ArrayList<Integer> currentMarks = new ArrayList<>();
            for (int j = 1; j < currentNameAndMarks.length; j++) {
                currentMarks.add(Integer.parseInt(currentNameAndMarks[j]));
            }

            if (marks.containsKey(name)) {
                ArrayList<Integer> oldMarks = marks.get(name);
                oldMarks.addAll(currentMarks);
                marks.put(name, oldMarks);
            } else {
                marks.put(name, currentMarks);
            }
        }

        double maxAverage = Double.MIN_VALUE;
        LinkedHashMap<String, Double> averageMarks = new LinkedHashMap<>();
        for (Map.Entry<String, ArrayList<Integer>> entry : marks.entrySet()) {
            double sum = 0;
            ArrayList<Integer> currentMarks = entry.getValue();
            for (Integer currentMark : currentMarks) {
                sum += currentMark;
            }

            double average = sum / currentMarks.size();
            averageMarks.put(entry.getKey(), average);
            if (average > maxAverage) {
                maxAverage = average;
            }
        }

        for (Map.Entry<String, Double> entry : averageMarks.entrySet()) {
            if (entry.getValue() == maxAverage) {
                Integer[] entryMarks = marks.get(entry.getKey()).toArray(new Integer[]{});
                Arrays.sort(entryMarks);
                System.out.print(entry.getKey() + " ->");
                for (Integer entryMark : entryMarks) {
                    System.out.print(" " + entryMark);
                }

                System.out.println();
            }
        }
    }
}