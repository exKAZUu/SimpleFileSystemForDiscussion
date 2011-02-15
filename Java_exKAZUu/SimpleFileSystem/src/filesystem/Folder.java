package filesystem;

import java.util.Collection;
import java.util.Collections;
import java.util.TreeMap;

public class Folder {
	private TreeMap<String, File> files;
	private String name;
	
	public Folder(String name) {
		this.name = name;
		this.files = new TreeMap<String, File>();
	}

	public void addFile(File file) {
		this.files.put(file.getName(), file);
	}

	public Collection<File> getFiles() {
		return Collections.unmodifiableCollection(this.files.values());
	}
	
	public boolean containsFile(String name) {
		return files.containsKey(name);
	}

	public void changeName(String name) {
		this.name = name;
	}

	public String getName() {
		return name;
	}

	public File removeFile(String fileName) {
		return this.files.remove(fileName);
	}
}
