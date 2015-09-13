import java.util.*;
public class _3Arrow {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int arrowWidth = input.nextInt();
		input.close();

		int wholeWidth = (2 * arrowWidth) - 1;
		int arrowHeight = wholeWidth;
		int numberOfDots = arrowWidth / 2;
		
		String dots = new String(new char[numberOfDots]).replace("\0", ".");
		String arrowTop = new String(new char[arrowWidth]).replace("\0", "#");
		
		System.out.print(dots);
		System.out.print(arrowTop);
		System.out.print(dots);
		System.out.println();
		
		for (int i = 0; i < arrowWidth - 2; i++) {
			System.out.print(dots);
			System.out.print("#");
			System.out.print(new String(new char[arrowWidth - 2]).replace("\0", "."));
			System.out.print("#");
			System.out.print(dots);
			System.out.println();
		}
		System.out.print(new String(new char[arrowWidth / 2 + 1]).replace("\0", "#"));
		System.out.print(new String(new char[arrowWidth - 2]).replace("\0", "."));
		System.out.println(new String(new char[arrowWidth / 2 + 1]).replace("\0", "#"));
		
		int outerDots = 1;
		int innerDots = wholeWidth - 4;
		
		for (int i = 0; i < arrowWidth - 2; i++) {
			System.out.print(new String(new char[outerDots]).replace("\0", "."));
			System.out.print("#");
			System.out.print(new String(new char[innerDots]).replace("\0", "."));
			System.out.print("#");
			System.out.println(new String(new char[outerDots]).replace("\0", "."));
			
			outerDots++;
			innerDots -= 2;
		}
		System.out.print(new String(new char[outerDots]).replace("\0", "."));
		System.out.print("#");
		System.out.println(new String(new char[outerDots]).replace("\0", "."));
	}

}
