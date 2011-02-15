package command;

import java.io.PrintStream;
import java.util.List;

import filesystem.FileSystem;

public class MakeFileCommand extends Command {

	private FileSystem fileSystem;
	
	public MakeFileCommand(FileSystem fileSystem) {
		this.fileSystem = fileSystem;
	}

	@Override
	public boolean execute(PrintStream out, List<String> args) {
		if (args.size() < 1)
			return false;
		String path = args.get(0);
		String[] folderAndFile = path.split("/");
		if (folderAndFile.length != 2)
			return false;
		String folderName = folderAndFile[0];
		String fileName = folderAndFile[1];
		return fileSystem.createFile(folderName, fileName);
	}
}
