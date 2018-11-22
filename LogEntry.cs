public struct LogEntry {
	public string msg;
	public LogLevel level;

	public LogEntry(string p1, LogLevel p2) {
		msg = p1;
		level = p2;
	}
}