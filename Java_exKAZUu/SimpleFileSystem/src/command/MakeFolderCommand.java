package command;

import java.io.PrintStream;
import java.util.List;

import filesystem.FileSystem;

public class MakeFolderCommand extends Command {

	private FileSystem fileSystem;
	
	public MakeFolderCommand(FileSystem fileSystem) {
		this.fileSystem = fileSystem;
	}

	@Override
	public boolean execute(PrintStream out, List<String> args) {
		if (args.size() < 1)
			return false;
		String name = args.get(0);
		if (fileSystem.containsFolder(name))
			return false;
		return fileSystem.createFolder(name);
	}
}
