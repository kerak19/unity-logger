using UnityEngine;
using Generic = System.Collections.Generic;

// Log class is a Singleton class, used for logging 
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
		if(l < LogLevel.TRACE || l > LogLevel.FATAL) {
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

	// Trace writes log entry with TRACE LogLevel
	public static void Trace(string msg, params object[] args) {
		if(level > LogLevel.TRACE) {
			return;
		}
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.TRACE));
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

	// Fatal writes log entry with FATAL LogLevel. It'll also quit application(or stop playing when in unity editor).
	// Use with caution.
	public static void Fatal(string msg, params object[] args) {
		msg = string.Format(msg, args);
		WriteLog(new LogEntry(msg, LogLevel.FATAL));
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		Application.Quit();
	}
}
