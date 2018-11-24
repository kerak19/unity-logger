using System;
using System.Globalization;

// FileLogger is an class which writes logs to file
public class FileLogger : ILineWriter {
	// forbid usage of default constructor
	private FileLogger() { }

	// file where logs will be written
	private System.IO.StreamWriter logFile;

	public FileLogger(string logFilePath) {
		logFile = new System.IO.StreamWriter(logFilePath, true);
	}

	// whether logs should have date and time
	private bool logTime;
	public FileLogger(string logFilePath, bool withTime) {
		logFile = new System.IO.StreamWriter(logFilePath, true);
		logTime = withTime;
	}
 
	private readonly string timeFormat = ("yyyy-MM-dd HH:mm:ss");

	// WriteLine writes log into file.
	// Add JSON serialization
	public void WriteLine(LogEntry le) {
		// {{LogLevel}}: {{message}}
		le.msg = le.level.String() + ": " + le.msg;

		if(logTime) {
			// {{CurrentDate}} {{LogLevel}}: {{message}}
			string currTime = DateTime.UtcNow.ToString(timeFormat, CultureInfo.InvariantCulture);
			le.msg = currTime + " " + le.msg;
		}

		logFile.WriteLine(le.msg);
		logFile.Flush();
	}
} 