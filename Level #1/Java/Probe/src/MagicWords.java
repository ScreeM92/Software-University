import java.util.*;
public class MagicWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		ArrayList<Character> chars = new ArrayList<>();
		for (int i = 0; i < n; i++) {
			String words = input.nextLine();
			for (char c : words.toCharArray()) {
				  chars.add(c);
				}
		}
		for (int i = 0, k = 0; i < chars.size(); i++, k++) {
			chars.add(1 % (n + k), ' ');
			chars.set(1 % (n + k), chars.get(i));
			chars.remove(i);
			
		}
		for (Character ch : chars) {
			System.out.print(ch);
		}
	}

}
