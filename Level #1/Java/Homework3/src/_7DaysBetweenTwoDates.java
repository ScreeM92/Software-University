import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Date;
import java.util.Scanner;
 
public class _7DaysBetweenTwoDates {
 
        public static void main(String args[]) throws ParseException  {
               
        	Scanner input = new Scanner(System.in);
             String firstDateAsString = input.nextLine();
             String secondDateAsString = input.nextLine();
             LocalDate firstDate = LocalDate.parse(firstDateAsString, DateTimeFormatter.ofPattern("d-MM-uuuu"));
             LocalDate secondDate = LocalDate.parse(secondDateAsString, DateTimeFormatter.ofPattern("d-MM-uuuu"));
             long difference = ChronoUnit.DAYS.between(firstDate, secondDate);
             System.out.println("The difference between the two dates is " + difference + " days");
             
//                Scanner in = new Scanner(System.in);
//                String input1 = in.nextLine();
//                String input2 = in.nextLine();
//               
//                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy");
//                Date date1 = simpleDateFormat.parse(input1);
//                Date date2 = simpleDateFormat.parse(input2);
//               
//                System.out.println((int)computeDaysBetweenDates(date1, date2));
// 
//        }
//       
//        public static double computeDaysBetweenDates(Date d1, Date d2) {
//            long diff;
//            diff = d2.getTime() - d1.getTime();
//            return ((double) diff) / (86400.0 * 1000.0);
//        }
        }
}