using UnityEngine;
using Generic = System.Collections.Generic;

/// <summary> 
/// Log class is a Singleton class, used for logging 
/// </summary> 
public sealed class Log : Debug {
	#region Singleton
	// Prevent using default constructor
	private Log() { }

	// Unity special method, invoked with object creation
	void Awake() {
		level = LogLevel.INFO; 
	}
	#endregion

	private static LogLevel level;
	public static void SetLevel(LogLevel l) {
		if(l < LogLevel.DEBUG || l > LogLevel.ERROR) {
			return;
		}
		level = l;
	} 

	// Sources where logs will be written
	private static Generic.List<ILineWriter> logWriters = new Generic.List<ILineWriter>();
	public static void AddLogWriter(ILineWriter o) {
		logWriters.Add(o); 
	}
	// WriteLog writes log entry into every provided output
	private static void WriteLog(LogEntry le) {
		foreach(ILineWriter logWriter in logWriters) {
			logWriter.WriteLine(le);
		}
	} 

	// Debug writes log entry with DEBUG LogLevel
	public static void Debug(string msg, params object[] args) {
		if(level > LogLevel.DEBUG) {
			return;
		}
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.DEBUG));
	}

	// Info writes log entry with INFO LogLevel
	public static void Info(string msg, params object[] args) {
		if(level > LogLevel.INFO) {
			return;
		}
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.INFO));
	}

	// Warn writes log entry with WARN LogLevel
	public static void Warn(string msg, params object[] args) {
		if(level > LogLevel.WARN) {
			return;
		}
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.WARN));
	}

	// Error writes log entry with ERROR LogLevel
	public static void Error(string msg, params object[] args) {
		if(level > LogLevel.ERROR) {
			return;
		}
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.ERROR));
	}
}
