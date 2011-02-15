package command;

import java.io.PrintStream;
import java.util.List;

import filesystem.FileSystem;

public class MoveCommand extends Command {

	private FileSystem fileSystem;
	
	public MoveCommand(FileSystem fileSystem) {
		this.fileSystem = fileSystem;
	}

	@Override
	public boolean execute(PrintStream out, List<String> args) {
		if (args.size() < 1)
			return false;
		String fromPath = args.get(0);
		String toPath = args.get(1);
		String[] fromFolderAndFile = fromPath.split("/");
		String[] toFolderAndFile = toPath.split("/");
		if (fromFolderAndFile.length != toFolderAndFile.length)
			return false;
		if (fromFolderAndFile.length == 1) {
			return fileSystem.moveFolder(fromFolderAndFile[0], toFolderAndFile[0]);
		}
		else if (fromFolderAndFile.length == 2) {
			return fileSystem.moveFile(fromFolderAndFile[0], fromFolderAndFile[1],
					toFolderAndFile[0], toFolderAndFile[1]);
		}
		return false;
	}
}
