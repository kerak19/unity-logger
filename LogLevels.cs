public enum LogLevel {
	TRACE = 0,
	DEBUG = 1,
	INFO = 2,
	WARN = 3,
	ERROR = 4,
	FATAL = 5,
}

// Extension methods for LogLevel enum
public static class LogLevelMethods {
	// Return string value of provided LogLevel
	public static string String(this LogLevel ll) {
		switch(ll) {
			case LogLevel.TRACE:
				return "TRACE";
			case LogLevel.DEBUG:
				return "DEBUG";
			case LogLevel.INFO:
				return "INFO";
			case LogLevel.WARN:
				return "WARN";
			case LogLevel.ERROR:
				return "ERROR";
			case LogLevel.FATAL:
				return "FATAL";
			default:
				return "UNKNOWN";
		}
	}
}