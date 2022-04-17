using System;

public class BattleShipDisplay
{
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
	
		_ErrorLocationLeft = GetGridLeft()     + GetGridWidth() + 1;
		_ErrorLocationTop  = GetGridTop();

		_InfoLocationLeft = GetGridLeft() + 3;
		_InfoLocationTop  = GetGridTop()  + GetGridHeight() + 3;

		// _HeaderLocationLeft = GetGridLeft();
		//	_HeaderLocationTop  = GetGridTop() - 2;

		/*
		WriteStringToPoint($"updateDisplaySettings C5 _HeaderLocationLeft {GetHeaderLeft()} _HeaderLocationTop {GetHeaderTop()}", 30, 1);
		WriteStringToPoint($"updateDisplaySettings C5 _ErrorLocationLeft {GetErrorLeft()} _ErrorLocationTop {GetErrorTop()}", 30, 2);

		WriteStringToPoint($"updateDisplaySettings C5 _BattleShipLocationLeft {GetGridLeft()} _BattleShipLocationTop {GetGridTop()}", 30, 4);
		WriteStringToPoint($"updateDisplaySettings C5 _InfoLocationLeft {GetInformationLeft()} _InfoLocationTop {GetInformationTop()}", 30, 5);
		*/
	}

	// (15, 21)
	public void setGridLocation(int battleshiplocationleft, int battleshiplocationtop) {
		_BattleShipLocationLeft = battleshiplocationleft;
		_BattleShipLocationTop = battleshiplocationtop;

		updateDisplaySettings();
	}


	public void ResetScreen() {
		Console.Clear();

		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;
	}

	public void ForeColors() {
		Console.BackgroundColor = ConsoleColor.DarkGreen;
		Console.ForegroundColor = ConsoleColor.DarkBlue;
	}

	public void ReverseColors() {
		Console.ForegroundColor = ConsoleColor.DarkBlue;
		Console.BackgroundColor = ConsoleColor.DarkGreen;
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

	public void WriteCharToGrid(char charToWrite, int locationLeft, int locationTop) {
		Console.SetCursorPosition( GetGridLeft() + (locationLeft * 2), GetGridTop() + locationTop );
		Console.Write(charToWrite);
	}

	public void WriteCharToGridPoint(char charToWrite, int locationLeft, int locationTop) {
		Console.SetCursorPosition(GetGridLeft() + locationLeft, GetGridTop() + locationTop );
		Console.Write(charToWrite);
	}

	public void WriteCharToPoint(char charToWrite, int locationLeft, int locationTop) {
		Console.SetCursorPosition(locationLeft, locationTop);
		Console.Write(charToWrite);
	}

	public void WriteStringToPoint(string stringToWrite, int locationLeft, int locationTop) {
		Console.SetCursorPosition(locationLeft, locationTop);
		Console.Write(stringToWrite);
	}


}
