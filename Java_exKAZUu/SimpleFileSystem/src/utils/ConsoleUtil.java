package utils;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.PrintStream;

public class ConsoleUtil {
	public static int selectCommand(PrintStream out, BufferedReader in, String[] commands, String message) throws IOException {
		int index = 0;
		for (String cmd : commands) {
			out.println(++index + ". " + cmd);
		}
		
		while(true) {
			out.println(message + ": 1 - " + index);
			String line = in.readLine();
			try {
				int result = Integer.parseInt(line);
				if (1 <= result && result <= index)
					return result;
			} catch(Exception e) {
			}
		}
	}
}
