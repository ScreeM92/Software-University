import java.text.DecimalFormat;
import java.util.*;
public class _5AngleUnitConverter {

	public static void main(String[] args) {
//		Scanner input = new Scanner(System.in);
//		int n = input.nextInt();
//		
//		for (int i = 0; i < n; i++) {
//			double num = input.nextDouble();
//			String numNext = input.next();
//			if (numNext.equals("deg")) {
//				double num1 = Math.toRadians(num);
//				System.out.printf("%.6f", num1);
//				System.out.println();
//			}
//			else if (numNext.equals("rad")) {
//				double num2 = Math.toDegrees(num);
//				System.out.printf("%.6f", num2);
//				System.out.println();
//			}
//		}
//		input.close();
		
//            2ro reshenie
		
		 Locale.setDefault(Locale.ROOT);
         Scanner scan = new Scanner(System.in);
         System.out.println("How many numbers will you enter?");
         int n = scan.nextInt();
         //scan.nextLine();
         String[] strings = new String[n];
         double[] numbers = new double[n];
         for (int i = 0; i < numbers.length; i++) {
                 numbers[i] = scan.nextDouble();
                 strings[i] = scan.next();
                 
                 convertAngles(numbers[i], strings[i]);
         }              
 }

 private static void convertAngles(double number, String str) {
         DecimalFormat decPoints = new DecimalFormat("#.000000");
         if (str.equals("deg")) {
                 number *= 0.0174532925;
                 String convertedValue = decPoints.format(number);
                 System.out.println(convertedValue + " rad");
         }
         else if(str.equals("rad")){
                 number *= 57.2957795;
                String convertedValue = decPoints.format(number);
                 System.out.println(convertedValue + " deg");
         }
	}

}
