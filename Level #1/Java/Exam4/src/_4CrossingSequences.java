import java.util.*;

import javax.xml.stream.events.StartDocument;

import com.sun.org.apache.bcel.internal.generic.GOTO;
public class _4CrossingSequences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int a = 1;
		int b = 2;
		int c = 3;
		int sum = 0;
		
		int first = 5;
		int second = 2;
		int sum1 = 0;
		int nextNum = 0;
		//System.out.print(a + " " + b + " " + c + " ");
		for (int i = 0; i < 21; i++) {
			nextNum = a + b + c;
			a = b;
			b = c;
			c = nextNum;
			}
		for (int j = 0; j < 100; j++) {
			int firstAndSecond = first + second;
			int firstAndSecond2 = firstAndSecond + second;
			second += 2;
			//System.out.print(firstAndSecond + " " + firstAndSecond2 + " ");
			first = firstAndSecond2;
			
		}
	}

}
