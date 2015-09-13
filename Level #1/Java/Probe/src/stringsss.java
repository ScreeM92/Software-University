import java.util.*;
public class stringsss {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String string = input.nextLine();
		String[] arr = string.split("\\W+");
		
		int maxTimes = 1;
		int times = 1;
		int position = 0;
		
		for (int i = 1; i < arr.length; i++) {
			if (arr[i].equals(arr[i - 1])) {
				times++;
			}
			else {
				times = 1;
			}
			if (times > maxTimes) {
				maxTimes = times;
				position = i;
			}
		}
		for (int i = 0; i < maxTimes; i++) {
			System.out.print(arr[position] + " ");
		}

	}

}
