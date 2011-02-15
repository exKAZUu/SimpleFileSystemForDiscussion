package command;

import java.io.PrintStream;
import java.util.Collection;
import java.util.List;

import filesystem.File;
import filesystem.FileSystem;
import filesystem.Folder;

public class ListCommand extends Command {

	private FileSystem fileSystem;
	
	public ListCommand(FileSystem fileSystem) {
		this.fileSystem = fileSystem;
	}

	@Override
	public boolean execute(PrintStream out, List<String> args) {
		Collection<Folder> folders = fileSystem.getFolders();
		for (Folder folder : folders) {
			String folderName = folder.getName();
			out.println(folderName + "/");
			for (File file : folder.getFiles()) {
				out.println(folderName + "/" + file.getName());
			}
		}
		return true;
	}
}
