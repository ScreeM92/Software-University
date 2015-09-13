import java.util.Scanner;
public class _1RectangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter a:");
		int a = input.nextInt();
		System.out.println("Enter b:");
		int b = input.nextInt();
		input.close();
		int area = a * b;
		System.out.println(area);
	}
}
