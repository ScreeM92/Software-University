import java.util.Date;
import java.time.LocalDateTime;
public class _5CurrentDateTime {

	public static void main(String[] args) {
		Date date = new Date();
		System.out.printf("The date and time is: %1$tA %1$tI:%1$tM%1$tp %1$tB/%1$tY. \n", date);
		LocalDateTime dt = LocalDateTime.now();
        System.out.println(dt);
	}

}
