using System;

public class BattleShipDisplay
{
	private string _ActorInputString = "";
	private char _ActorInputChar = ' ';

	public BattleShipDisplay()
	{
		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;
	}

	public char GetCharFromActor() {
		return _ActorInputChar;
	}

	public void ReadCharFromActor() {
		ConsoleKeyInfo cKeyInfo;

        cKeyInfo = Console.ReadKey(true);

		_ActorInputChar = cKeyInfo.KeyChar;
    }

	public string GetLineFromActor() {
		return _ActorInputString;
	}

	public void ReadLineFromActor() {
		string inputLine = Console.ReadLine();
		if (inputLine != null) {
			_ActorInputString = inputLine;
		}
		else {
			_ActorInputString = "";
		}
	}

	public void WriteStringLine(string stringToWrite) {
		Console.WriteLine(stringToWrite);
	}

	public void WriteString(string stringToWrite) {
		Console.Write(stringToWrite);
	}

	public void WriteCharToPoint(char charToWrite, int locationLeft, int locationRight) {
		Console.SetCursorPosition(locationLeft, locationRight);
		Console.Write(charToWrite);
	}


}
