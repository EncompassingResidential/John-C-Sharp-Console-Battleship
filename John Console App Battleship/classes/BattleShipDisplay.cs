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
	private int _HeaderLocationWidth  = 0;
	private int _HeaderLocationHeight = 0;

	public BattleShipDisplay(int numberGridColumns, int numberGridRows)
	{
		Console.BackgroundColor = ConsoleColor.DarkBlue;
		Console.ForegroundColor = ConsoleColor.DarkGreen;

		_BattleShipLocationLeft = 1;
		_BattleShipLocationTop  = 1;

		_BattleShipGridWidth  = numberGridColumns * 2;
		_BattleShipGridHeight = numberGridRows;

		_HeaderLocationLeft = 5;
		_HeaderLocationTop  = 2;
		_HeaderLocationWidth  = 25;
		_HeaderLocationHeight =  2;

		_ErrorLocationLeft = 51;
		_ErrorLocationTop = 23;

		_InfoLocationLeft = 9;
		_InfoLocationTop = 35;

		updateDisplaySettings();
	}

	private void updateDisplaySettings() {
	/*	WriteLineToPoint($"updateDisplaySettings B4 _HeaderLocationLeft {GetHeaderLeft()} _HeaderLocationTop {GetHeaderTop()}", 28, 20);
		WriteLineToPoint($"updateDisplaySettings B4 _ErrorLocationLeft {GetErrorLeft()} _ErrorLocationTop {GetErrorTop()}", 29, 21);

		WriteLineToPoint($"updateDisplaySettings B4 _BattleShipLocationLeft {GetGridLeft()} _BattleShipLocationTop {GetGridTop()}", 30, 22);
		WriteLineToPoint($"updateDisplaySettings B4 _InfoLocationLeft {GetInformationLeft()} _InfoLocationTop {GetInformationTop()}", 31, 23);
	*/
		_ErrorLocationLeft = GetGridLeft()     + GetGridWidth() + 1;
		_ErrorLocationTop  = GetGridTop();

		_InfoLocationLeft = GetGridLeft() + 3;
		_InfoLocationTop  = GetGridTop()  + GetGridHeight() + 3;

		// _HeaderLocationLeft = GetGridLeft();
		//	_HeaderLocationTop  = GetGridTop() - 2;

		WriteLineToPoint($"updateDisplaySettings C5 _HeaderLocationLeft {GetHeaderLeft()} _HeaderLocationTop {GetHeaderTop()}", 30, 1);
		WriteLineToPoint($"updateDisplaySettings C5 _ErrorLocationLeft {GetErrorLeft()} _ErrorLocationTop {GetErrorTop()}", 30, 2);

		WriteLineToPoint($"updateDisplaySettings C5 _BattleShipLocationLeft {GetGridLeft()} _BattleShipLocationTop {GetGridTop()}", 30, 4);
		WriteLineToPoint($"updateDisplaySettings C5 _InfoLocationLeft {GetInformationLeft()} _InfoLocationTop {GetInformationTop()}", 30, 5);
	
	}

	// (15, 21)
	public void setGridLocation(int battleshiplocationleft, int battleshiplocationtop) {
		_BattleShipLocationLeft = battleshiplocationleft;
		_BattleShipLocationTop = battleshiplocationtop;

		updateDisplaySettings();
	}


	public char GetCharFromActor() {
		return _ActorInputChar;
	}

	public void ResetScreen() {
		Console.Clear();

		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;
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
			WriteLineToPoint(printThis, GetErrorLeft(), GetErrorTop());
			_ActorInputString = inputLine;
		}
		else {
			WriteLineToPoint("ReadLineFromActor is null", GetErrorLeft(), GetErrorTop());

			_ActorInputString = "Player 1";
		}
	}

	public int GetGridLeft() {
		return _BattleShipLocationLeft;
	}

	public int GetGridTop() {
		return _BattleShipLocationTop;
	}

	public int GetGridHeight() {
		return _BattleShipGridHeight;
	}

	public int GetGridWidth() {
		return _BattleShipGridWidth;
	}


	public int GetHeaderLeft() {
		return _HeaderLocationLeft;
	}

	public int GetHeaderTop() {
		return _HeaderLocationTop;
	}

	public int GetHeaderHeight() {
		return _HeaderLocationHeight;
	}

	public int GetHeaderWidth() {
		return _HeaderLocationWidth;
	}

	public int GetInformationLeft() {
		return _InfoLocationLeft;
	}

	public int GetInformationTop() {
		return _InfoLocationTop;
	}

	public int GetErrorLeft() {
		return _ErrorLocationLeft;
	}

	public int GetErrorTop() {
		return _ErrorLocationTop;
	}

	public void WriteHeaderLine(string stringToPrint, int leftOffSet = 1, int topOffSet = 1) {
		/*
		 * 		GetHeaderLeft() && GetHeaderTop()
		 */
		Console.SetCursorPosition(GetHeaderLeft() + leftOffSet, GetHeaderTop() + topOffSet);
		Console.Write(stringToPrint);
	}
	
	public void WriteInformationLine(string stringToPrint) {
		/*
		 * 		GetInformationLeft() = GetGridLeft() + 3;
		 * 		GetInformationTop()  = GetGridTop() + GetGridHeight() + 5;
		 */
		Console.SetCursorPosition(GetInformationLeft(), GetInformationTop());
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
