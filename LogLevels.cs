public enum LogLevel {
	DEBUG = 0,
	INFO = 1,
	WARN = 2,
	ERROR = 3,
}

// Extension methods for LogLevel enum
public static class LogLevelMethods {
	// Return string value of provided LogLevel
	public static string String(this LogLevel ll) {
		switch(ll) {
			case LogLevel.DEBUG:
				return "DEBUG";
			case LogLevel.INFO:
				return "INFO";
			case LogLevel.WARN:
				return "WARN";
			case LogLevel.ERROR:
				return "ERROR"; 
			default:
				return "UNKNOWN";
		}
	}
}