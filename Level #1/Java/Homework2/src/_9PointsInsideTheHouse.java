import java.util.*;
public class _9PointsInsideTheHouse {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		System.out.println("Enter x, y:");
        String[] var = input.nextLine().split(" ");
        double x = Double.parseDouble(var[0]);
        double y = Double.parseDouble(var[1]);                     
        double x1 = 12.5, y1 = 8.5;
        double x2 = 17.5, y2 = 3.5;
        double x3 = 22.5, y3 = 8.5;
        double ABC = Math.abs (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        double ABP = Math.abs (x1 * (y2 - y) + x2 * (y - y1) + x * (y1 - y2));
        double APC = Math.abs (x1 * (y - y3) + x * (y3 - y1) + x3 * (y1 - y));
        double PBC = Math.abs (x * (y2 - y3) + x2 * (y3 - y) + x3 * (y - y2));
        boolean isInTriangle = ABP + APC + PBC == ABC;
        if((x>=12.5 && x<=17.5) && (y<=13.5 && y>=8.5)) {
                System.out.println("Inside");
        }
        else if((x>=20 && x<=22.5) && (y<=13.5 && y>=8.5)) {
                System.out.println("Inside");
        }

    else if(isInTriangle){
                System.out.println("Inside");
        }
    else {
        System.out.println("Outside");
    }
		
		//2-ri nachin
//		Scanner input = new Scanner(System.in);
//		System.out.println("Enter x:");
//		float x = input.nextFloat();
//		System.out.println("Enter y:");
//		float y = input.nextFloat();
//		input.close();
//		
//		boolean isInSideRectangle1 = (12.5 <= x && x <= 17.5) && (8.5 <= y && y <= 13.5);
//		boolean isInSideRectangle2 = (20 <= x && x <= 22.5) && (8.5 <= y && y <= 13.5);
//		
//		
//		Point a = new Point(12.5 , 8.5);
//		Point b = new Point(22.5, 8.5);
//		Point c = new Point(17.5, 3.5);
//		
//		boolean isInSideRectangle3 = isLeft(a, b, c);
//		
//		if (isInSideRectangle3 || isInSideRectangle2 || isInSideRectangle1) {
//			System.out.println("Inside");
//		}
//		else {
//			System.out.println("Outside");
//		}
//	}
//	public static boolean isLeft(Point a, Point b, Point c){
//	     return ((b.x() - a.x())*(c.y() - a.y()) - (b.y() - a.y())*(c.x() - a.x())) > 0;
	}

}
