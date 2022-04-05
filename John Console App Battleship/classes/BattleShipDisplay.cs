using System;

public class BattleShipDisplay
{
	private string _ActorInputString = "";
	private char _ActorInputChar = ' ';

	private int _BattleShipLocationLeft = 0;
	private int _BattleShipLocationTop  = 0;

	private int _BattleShipGridWidth  = 0;
	private int _BattleShipGridHeight = 0;

	private int _ErrorLocationLeft = 0;
	private int _ErrorLocationTop  = 0;

	private int _InfoLocationLeft = 0;
	private int _InfoLocationTop  = 0;

	private int _HeaderLocationLeft = 0;
	private int _HeaderLocationTop  = 0;

	public BattleShipDisplay()
	{
		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;

		_BattleShipLocationLeft = 1;
		_BattleShipLocationTop  = 1;

		_BattleShipGridWidth  = 10 * 2;
		_BattleShipGridHeight = 10;

		_HeaderLocationLeft = 5;
		_HeaderLocationTop  = 2;

		_ErrorLocationLeft = 51;
		_ErrorLocationTop = 23;

		_InfoLocationLeft = 9;
		_InfoLocationTop = 35;

		updateDisplaySettings();
	}

	private void updateDisplaySettings() {
		WriteLineToPoint($"updateDisplaySettings B4 _HeaderLocationLeft {_HeaderLocationLeft} _HeaderLocationTop {_HeaderLocationTop}", 28, 20);
		WriteLineToPoint($"updateDisplaySettings B4 _ErrorLocationLeft {_ErrorLocationLeft} _ErrorLocationTop {_ErrorLocationTop}", 29, 21);

		WriteLineToPoint($"updateDisplaySettings B4 _BattleShipLocationLeft {_BattleShipLocationLeft} _BattleShipLocationTop {_BattleShipLocationTop}", 30, 22);
		WriteLineToPoint($"updateDisplaySettings B4 _InfoLocationLeft {_InfoLocationLeft} _InfoLocationTop {_InfoLocationTop}", 31, 23);

		_ErrorLocationLeft = _BattleShipLocationLeft + _BattleShipGridWidth + 5;
		_ErrorLocationTop = _BattleShipLocationTop + _HeaderLocationTop;

		_InfoLocationLeft = _BattleShipLocationLeft + 3;
		_InfoLocationTop = _BattleShipLocationTop + _BattleShipGridHeight + 5;

		WriteLineToPoint($"updateDisplaySettings C5 _HeaderLocationLeft {_HeaderLocationLeft} _HeaderLocationTop {_HeaderLocationTop}", 33, 25);
		WriteLineToPoint($"updateDisplaySettings C5 _ErrorLocationLeft {_ErrorLocationLeft} _ErrorLocationTop {_ErrorLocationTop}", 34, 26);

		WriteLineToPoint($"updateDisplaySettings C5 _BattleShipLocationLeft {_BattleShipLocationLeft} _BattleShipLocationTop {_BattleShipLocationTop}", 35, 27);
		WriteLineToPoint($"updateDisplaySettings C5 _InfoLocationLeft {_InfoLocationLeft} _InfoLocationTop {_InfoLocationTop}", 36, 28);

	}

	public void setGridLocation(int battleshiplocationleft, int battleshiplocationtop) {
		_BattleShipLocationLeft = battleshiplocationleft;
		_BattleShipLocationTop = battleshiplocationtop;

		updateDisplaySettings();
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
		if (inputLine != null && inputLine != "") {
			string printThis = $"ReadLineFromActor if (inputLine != null) Actor typed <{inputLine}>";
			WriteLineToPoint(printThis, _ErrorLocationLeft, _ErrorLocationTop);
			_ActorInputString = inputLine;
		}
		else {
			WriteLineToPoint("ReadLineFromActor is null", _ErrorLocationLeft, _ErrorLocationTop);

			_ActorInputString = "Player 1";
		}
	}

	public void WriteInformationLine(string stringToPrint) {
		/*
		 * 		_InfoLocationLeft = _BattleShipLocationLeft + 3;
		 * 		_InfoLocationTop  = _BattleShipLocationTop + _BattleShipGridHeight + 5;
		 */
		Console.SetCursorPosition(_InfoLocationLeft + 30, _InfoLocationTop);
		Console.Write(stringToPrint);
	}

	public void WriteHeaderLine(string stringToPrint, int leftOffSet = 1, int topOffSet = 1) {
		/*
		 * 		_HeaderLocationLeft && _HeaderLocationTop
		 */
		Console.SetCursorPosition(_HeaderLocationLeft + leftOffSet, _HeaderLocationTop + topOffSet);
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
