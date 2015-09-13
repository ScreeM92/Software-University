
import java.util.Arrays;
import java.util.Scanner;
public class _8SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String[] cities = new String[n];
		
		for (int i = 0; i < n; i++) {
			cities[i] = input.next();
			
		}
		Arrays.sort(cities);
		for (int i = 0; i < cities.length; i++) {
			System.out.println(cities[i]);
		}
		input.close();
	}

}
		