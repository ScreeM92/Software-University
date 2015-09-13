import java.util.*;
public class _9CombineListsLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Character> arrFL = new ArrayList<>();
		ArrayList<Character> arrSL = new ArrayList<>();
		ArrayList<Character> arrPrint = new ArrayList<>();
				
		for (char first : input.nextLine().toCharArray()) {
			arrFL.add(first);
		}
		for (char second : input.nextLine().toCharArray()) {
			arrSL.add(second);
		}
		arrPrint.addAll(arrFL);
		
		for (int i = 0; i < arrSL.size(); i++) {
			if (arrFL.contains(arrSL.get(i))) {
				continue;
			}
			else {
				arrPrint.add(' ');
				arrPrint.add(arrSL.get(i));
			}
		}
		for (char allWord : arrPrint) {
			System.out.print(allWord);
		}
	}

}
