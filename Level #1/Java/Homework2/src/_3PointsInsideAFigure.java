import java.util.Scanner;
public class _3PointsInsideAFigure {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter x:");
		double x = input.nextDouble();
		System.out.println("Enter y:");
		double y = input.nextDouble();
		input.close();
		
		boolean isInSideRectangle1 = (12.5 <= x && x <= 22.5) && (6 <= y && y <= 8.5);
		boolean isInSideRectangle2 = (12.5 <= x && x <= 17.5) && (8.5 <= y && y <= 13.5);
		boolean isInSideRectangle3 = (20 <= x && x <= 22.5) && (8.5 <= y && y <= 13.5);
		if (isInSideRectangle1 || isInSideRectangle2 || isInSideRectangle3) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}

}
