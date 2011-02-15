package utils;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.PrintStream;
import java.io.StringReader;

import org.junit.Before;
import org.junit.Test;

public class ConsoleUtilTest {
	
	private ByteArrayOutputStream os;
	private PrintStream out;

	@Before
	public void before() {
		this.os = new ByteArrayOutputStream();
		this.out = new PrintStream(os);
	}

	private BufferedReader createBufferedReader(String string) {
		StringReader stringReader = new StringReader(string);
		return new BufferedReader(stringReader);
	}

	@Test
	public void select_first_command() throws IOException {
		BufferedReader in = createBufferedReader("1");
		int actual = ConsoleUtil.selectCommand(this.out, in, new String[] { "abc" }, "");
		assertThat(actual, is(0));
	}

	@Test
	public void select_second_command() throws IOException {
		BufferedReader in = createBufferedReader("2");
		int actual = ConsoleUtil.selectCommand(this.out, in, new String[] { "ab-c", "def", "333/\\" }, "a");
		assertThat(actual, is(1));
	}
	
	@Test
	public void select_third_command_with_invalid_number() throws IOException {
		BufferedReader in = createBufferedReader("5\n3\n");
		int actual = ConsoleUtil.selectCommand(this.out, in, new String[] { "ac", "d^ef", "333/\\" }, "^^^^^^^^");
		assertThat(actual, is(2));
	}
	
	@Test
	public void select_third_command_with_invalid_string() throws IOException {
		BufferedReader in = createBufferedReader("aaa\n\n3\n");
		int actual = ConsoleUtil.selectCommand(this.out, in, new String[] { "ac", "d^ef", "333/\\" }, "124");
		assertThat(actual, is(2));
	}
}
