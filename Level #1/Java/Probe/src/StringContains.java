import java.io.Reader;
import java.util.Scanner;
public class StringContains {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String sentence = in.nextLine().toLowerCase();
		char word = in.next().charAt(0);
		boolean contain = true;
		
		for (int i = 0; i < sentence.length(); i++) {
			if (sentence.charAt(i) == word && contain) {
				System.out.print(word);
				contain = false;
			}
			else {
				if (sentence.charAt(i) == word) {
					contain = false;
				}
				else {
					System.out.print(sentence.charAt(i));
				}
				
			}
			
		}

	}

}
