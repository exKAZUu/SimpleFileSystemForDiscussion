package filesystem;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import command.Command;
import command.ListCommand;
import command.MakeFileCommand;
import command.MakeFolderCommand;
import command.MoveCommand;
import command.RemoveCommand;

public class Main {
	
	/**
	 * @param args
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
		InputStreamReader streamReader = new InputStreamReader(System.in);
		BufferedReader reader = new BufferedReader(streamReader);
		
		FileSystem fileSystem = new FileSystem();
		
		HashMap<String, Command> commands = new HashMap<String, Command>();
		commands.put("mkfile", new MakeFileCommand(fileSystem));
		commands.put("mkdir", new MakeFolderCommand(fileSystem));
		commands.put("ls", new ListCommand(fileSystem));
		commands.put("mv", new MoveCommand(fileSystem));
		commands.put("rm", new RemoveCommand(fileSystem));
		
		String prefix = ">";
		while(true) {
			System.out.print(prefix);
			prefix = "\n>";
			String line = reader.readLine();
			String[] words = line.split(" ");
			if (words.length == 0)
				continue;
			List<String> cmdArgs = Arrays.asList(words).subList(1, words.length);
			Command command = commands.get(words[0]);
			if (command == null)
				continue;
			if (!command.execute(System.out, cmdArgs))
				System.out.println("failed.");
		}
	}
}
