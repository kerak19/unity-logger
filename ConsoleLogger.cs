using System.Collections.Generic;
using System.Text;
using UnityEngine;

// ConsoleLogger is an class which writes logs to default Unity console
public class ConsoleLogger : Debug, ILineWriter {

	// levelColors assignes colors to corresponding log levels
	private readonly Dictionary<LogLevel, string> levelColors = new Dictionary<LogLevel, string>() {
		{LogLevel.TRACE, "#e094ef"},
		{LogLevel.DEBUG, "#4f8cef"},
		{LogLevel.INFO, "#008000ff"},
		{LogLevel.WARN, "#edb040"},
		{LogLevel.ERROR, "#ea4141"},
		{LogLevel.FATAL, "#ff0000"},
	};

	public void WriteLine(LogEntry le) {
		StringBuilder msgBuilder = new StringBuilder("<color=").Append(levelColors[le.level]).Append(">").Append(le.level.String()).Append(":</color> ").Append(le.msg);
		Log(msgBuilder);
	}
}