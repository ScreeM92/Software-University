import java.util.*;
public class _1InsideTheBuilding {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int h = Integer.parseInt(input.next());
		int x1 = Integer.parseInt(input.next());
		int y1 = Integer.parseInt(input.next());
		int x2 = Integer.parseInt(input.next());
		int y2 = Integer.parseInt(input.next());
		int x3 = Integer.parseInt(input.next());
		int y3 = Integer.parseInt(input.next());
		int x4 = Integer.parseInt(input.next());
		int y4 = Integer.parseInt(input.next());
		int x5 = Integer.parseInt(input.next());
		int y5 = Integer.parseInt(input.next());
		input.close();
		
		isInside(x1, y1, h);
		isInside(x2, y2, h);
		isInside(x3, y3, h);
		isInside(x4, y4, h);
		isInside(x5, y5, h);
		
		
	}
	public static void isInside(int x, int y, int h){
		Boolean isInSideRectangle = ((h <= x && x <= 2*h) && (0 <= y && y <= 4*h)) 
				|| ((0 <= x && x <= 3*h) && (0 <= y && y <= h));
		if (isInSideRectangle) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
	}

}
