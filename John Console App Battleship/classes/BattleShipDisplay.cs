using System;

public class BattleShipDisplay
{
	private string _ActorInputString = "";
	private char _ActorInputChar = ' ';

	private int _BattleShipLocationLeft = 0;
	private int _BattleShipLocationTop  = 0;

	private int _BattleShipGridWidth  = 1;
	private int _BattleShipGridHeight = 1;

	private int _ErrorLocationLeft = 0;
	private int _ErrorLocationTop  = 0;

	private int _InfoLocationLeft = 0;
	private int _InfoLocationTop  = 0;

	public BattleShipDisplay()
	{
		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;

		_BattleShipLocationLeft = 1;
		_BattleShipLocationTop  = 1;

		_BattleShipGridWidth  = 10 * 2;
		_BattleShipGridHeight = 10;

		_ErrorLocationLeft = _BattleShipLocationLeft + _BattleShipGridWidth  + 5;
		_ErrorLocationTop  = _BattleShipLocationTop  + 0;

		_InfoLocationLeft = _BattleShipLocationLeft + 3;
		_InfoLocationTop  = _BattleShipLocationTop + _BattleShipGridHeight + 5;

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
		string? inputLine = Console.ReadLine();
		if (inputLine != null) {
			string printThis = $"ReadLineFromActor if (inputLine != null) Actor typed <{inputLine}>";
			WriteLineToPoint(printThis, _ErrorLocationLeft, _ErrorLocationTop);
			_ActorInputString = inputLine;
		}
		else {
			WriteLineToPoint("ReadLineFromActor is null", _ErrorLocationLeft, _ErrorLocationTop);

			_ActorInputString = "Player 1";
		}
	}

	public void setGridLocation(int battleshiplocationleft, int battleshiplocationtop) {
		_BattleShipLocationLeft = battleshiplocationleft;
		_BattleShipLocationTop  = battleshiplocationtop;
	}

	public void WriteInformationLine(string stringToPrint) {
		Console.SetCursorPosition(_InfoLocationLeft, _InfoLocationTop);
		Console.Write(stringToPrint);
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

	public void WriteLineToPoint(string stringToWrite, int locationLeft, int locationRight) {
		Console.SetCursorPosition(locationLeft, locationRight);
		Console.Write(stringToWrite);
	}


}
