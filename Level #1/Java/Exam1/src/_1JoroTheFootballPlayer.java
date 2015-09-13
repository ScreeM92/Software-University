import java.util.*;
public class _1JoroTheFootballPlayer {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String leapS = input.next();
		double p = input.nextDouble();
		double h = input.nextDouble();
		input.close();
		if ("t".equals(leapS)) {
			double result = h + (52 - h)*(double)2 / 3 + p*(double)1/2 + 3;
			System.out.println((int)result);
		}
		else if ("f".equals(leapS)) {
			double result = h + (52 - h)*(double)2 / 3 + p*(double)1/2;
			System.out.println((int)result);
		}
	}

}
