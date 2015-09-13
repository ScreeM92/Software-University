import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ss {

	public static void main(String[] args)
	{
		String text;
		ArrayList<String> emails = new ArrayList<String>();
		Scanner input = new Scanner(System.in);
		
		text = input.nextLine();
		input.close();
		
		Pattern p = Pattern.compile("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-]+");
		Matcher m = p.matcher(text);
		
		while(m.find())
		{
			emails.add(m.group());
		}
		
		for(String email : emails)
		{
			System.out.println(email);
		}
		
	}

}
