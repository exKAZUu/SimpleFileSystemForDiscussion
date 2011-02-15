package command;

import java.io.PrintStream;
import java.util.List;

public abstract class Command {
	public abstract boolean execute(PrintStream out, List<String> args);
}
