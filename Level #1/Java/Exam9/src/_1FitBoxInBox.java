import java.util.*;
public class _1FitBoxInBox {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int w1 = input.nextInt();
		int h1 = input.nextInt();
		int d1 = input.nextInt();
		
		int w2 = input.nextInt();
		int h2 = input.nextInt();
		int d2 = input.nextInt();
		
		input.close();
		
		BoxFit(w1, h1, d1, w2, h2, d2);
		BoxFit(w1, h1, d1, w2, d2, h2);
		BoxFit(w1, h1, d1, h2, w2, h2);
		BoxFit(w1, h1, d1, h2, d2, w2);
		BoxFit(w1, h1, d1, d2, w2, d2);
		BoxFit(w1, h1, d1, d2, h2, w2);
		
		BoxFit(w2, h2, d2, w1, h1, d1);
		BoxFit(w2, h2, d2, w1, d1, h1);
		BoxFit(w2, h2, d2, h1, w1, d1);
		BoxFit(w2, h2, d2, h1, d1, w1);
		BoxFit(w2, h2, d2, d1, w1, h1);
		BoxFit(w2, h2, d2, d1, h1, w1);
	
	}
	private static void BoxFit(int firstBoxWidth, int firstBoxHeight, int firstBoxDepth,
			int secondBoxWidth, int secondBoxHeight, int secondBoxDepth){
		
		if (firstBoxWidth < secondBoxWidth && firstBoxHeight < secondBoxHeight && firstBoxDepth < secondBoxDepth) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)", firstBoxWidth, firstBoxHeight, firstBoxDepth, secondBoxWidth, secondBoxHeight, secondBoxDepth).println();;
		}
	}
}
