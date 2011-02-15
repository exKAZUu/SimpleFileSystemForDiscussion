package filesystem;

import java.util.Collection;
import java.util.Collections;
import java.util.TreeMap;

public class FileSystem {
	private TreeMap<String, Folder> folders;

	FileSystem() {
		this.folders = new TreeMap<String, Folder>();
	}
	
	public Collection<Folder> getFolders() {
		return Collections.unmodifiableCollection(this.folders.values());		
	}
	
	public boolean containsFolder(String name) {
		return this.folders.containsKey(name);
	}

	public boolean createFile(String folderName, String fileName) {
		Folder folder = this.folders.get(folderName);
		if (folder == null)
			return false;
		if (folder.containsFile(fileName))
			return false;
		folder.addFile(new File(fileName));
		return true;
	}

	public boolean createFolder(String name) {
		this.folders.put(name, new Folder(name));
		return true;
	}

	public boolean removeFile(String folderName, String fileName) {
		Folder folder = this.folders.get(folderName);
		if (folder == null)
			return false;
		return folder.removeFile(fileName) != null;
	}

	public boolean removeFolder(String folderName) {
		return this.folders.remove(folderName) != null;
	}

	public boolean moveFolder(String fromFolderName, String toFolderName) {
		if (containsFolder(toFolderName))
			return false;
		
		Folder fromFolder = this.folders.remove(fromFolderName);
		if (fromFolder == null)
			return false;
		
		fromFolder.changeName(toFolderName);
		this.folders.put(toFolderName, fromFolder);
		return true;
	}

	public boolean moveFile(String fromFolderName, String fromFileName, String toFolderName, String toFileName) {
		Folder fromFolder = this.folders.get(fromFolderName);
		if (fromFolder == null)
			return false;
		if (!fromFolder.containsFile(fromFileName))
			return false;
		
		Folder toFolder = this.folders.get(toFolderName);
		if (toFolder == null)
			return false;
		if (toFolder.containsFile(toFileName))
			return false;
		
		File file = fromFolder.removeFile(fromFileName);
		toFolder.addFile(file);
		return true;
	}
}
