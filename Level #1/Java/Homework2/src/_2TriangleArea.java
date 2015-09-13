import java.util.Scanner;
public class _2TriangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter aX:");
		int aX = input.nextInt();
		System.out.println("Enter aY:");
		int aY = input.nextInt();
		System.out.println("Enter bX:");
		int bX = input.nextInt();
		System.out.println("Enter bY:");
		int bY = input.nextInt();
		System.out.println("Enter cX:");
		int cX = input.nextInt();
		System.out.println("Enter cY:");
		int cY = input.nextInt();
		input.close();
		
		int area;
		area = Math.abs((aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);
		System.out.println(area);
	}

}
