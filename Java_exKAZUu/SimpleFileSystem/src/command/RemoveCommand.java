package command;

import java.io.PrintStream;
import java.util.List;

import filesystem.FileSystem;

public class RemoveCommand extends Command {

	private FileSystem fileSystem;
	
	public RemoveCommand(FileSystem fileSystem) {
		this.fileSystem = fileSystem;
	}

	@Override
	public boolean execute(PrintStream out, List<String> args) {
		if (args.size() < 1)
			return false;
		String path = args.get(0);
		String[] folderAndFile = path.split("/");
		if (folderAndFile.length == 1) {
			return fileSystem.removeFolder(folderAndFile[0]);
		}
		else if (folderAndFile.length == 2) {
			return fileSystem.removeFile(folderAndFile[0], folderAndFile[1]);
		}
		return false;
	}
}
