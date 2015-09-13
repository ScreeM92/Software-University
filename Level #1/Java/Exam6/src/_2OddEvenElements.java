import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.*;
public class _2OddEvenElements {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		BigDecimal oddSum = new BigDecimal("" + 0);
		BigDecimal oddMin = new BigDecimal("" + Integer.MAX_VALUE);
		BigDecimal oddMax = new BigDecimal("" + Integer.MIN_VALUE);
		
		BigDecimal evenSum = new BigDecimal("" + 0);
		BigDecimal evenMin = new BigDecimal("" + Integer.MAX_VALUE);
		BigDecimal evenMax = new BigDecimal("" + Integer.MIN_VALUE);
		
		String inputNumbers = input.nextLine();
		String[] numbersArray = inputNumbers.split(" ");
		
		input.close();
		
		if (inputNumbers.equals("")) {
			numbersArray = new String[0];
		}
		
		for (int i = 0; i < numbersArray.length; i++) {
			BigDecimal currentNumber = 
					new BigDecimal("" + Double.parseDouble(numbersArray[i]));
			if (i % 2 == 0) {
			oddSum = oddSum.add(currentNumber);
				if (currentNumber.compareTo(oddMin) == -1) {
					oddMin = currentNumber;
				}
				if (currentNumber.compareTo(oddMax) == 1) {
					oddMax = currentNumber;
				}
			} else {
				evenSum = evenSum.add(currentNumber);
				
				if (currentNumber.compareTo(evenMin) == - 1) {
					evenMin = currentNumber;
				}
				if (currentNumber.compareTo(evenMax) == 1) {
					evenMax = currentNumber;
				}
			}
		}
		DecimalFormat df = new DecimalFormat("##########.##");
		
		if (numbersArray.length > 1) {
			System.out.printf("OddSum=%1$s, OddMin=%2$s, OddMax=%3$s"
					+ " EvenSum=%4$s, EvenMin=%5$s, EvenMax=%6$s",
					df.format(oddSum), df.format(oddMin), df.format(oddMax),
					df.format(evenSum), df.format(evenMin), df.format(evenMax));
		}else if (numbersArray.length == 1) {
			System.out.printf("OddSum=%1$.1s, OddMin=%2$.1s, OddMax=%3$.1s"
					+ " EvenSum=No, EvenMin=No, EvenMax=No", oddSum, oddMin, oddMax);
		}else if (numbersArray.length == 0) {
			System.out.println("No");
		}
	}

}
