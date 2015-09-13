import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;
import java.util.*;

import com.sun.corba.se.spi.orbutil.fsm.Input;
public class probe {

	public static void main(String[] args) {
		BufferedReader reader;
		try {
			reader = new BufferedReader(new FileReader("src/Input.txt"));
			String str = null;
			int sum = 0;
			while ((str = reader.readLine()) != null) {
				int number = Integer.parseInt(str);
				sum += number;
			}
			System.out.println(sum);
		} catch (Exception e) {
			System.out.println("Error");
		}
	}

}
