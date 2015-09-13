import java.util.Scanner;


public class _2Generate3LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String str = input.next();
		input.close();
		
		for (int i = 0; i < str.length(); i++) {
				for (int j = 0; j < str.length(); j++) {
					for (int j2 = 0; j2 < str.length(); j2++) {
						String currentResult = "";
						StringBuilder currentResult1 = new StringBuilder();
						currentResult1.append(str.charAt(i));
					    currentResult1.append(str.charAt(j));
						currentResult1.append(str.charAt(j2));
						System.out.println(currentResult1);
					}
				}
			
		}

	}

}
