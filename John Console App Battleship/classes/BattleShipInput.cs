using System;

public class BattleShipInput
{
	private string _ActorInputString = "";
	private char _ActorInputChar = ' ';
	private ConsoleKey _ActorKeyInfo;

	List<int> intList = new List<int>();

	public BattleShipInput()
	{
	}

	public char GetCharFromActor() {
		return _ActorInputChar;
	}

	public ConsoleKey GetKeyFromActor() {
		return _ActorKeyInfo;
	}


	public void ReadCharFromActor() {
		ConsoleKeyInfo cKeyInfo;

		cKeyInfo = Console.ReadKey(true);

		Console.SetCursorPosition(26, 15);
		Console.Write($"   ReadCharFromActor  --> cKeyInfo.Key <{cKeyInfo.Key}> and cKeyInfo.KeyChar <{cKeyInfo.KeyChar}>");

		_ActorInputChar = cKeyInfo.KeyChar;
		_ActorKeyInfo = cKeyInfo.Key;

	}

	public string GetLineFromActor() {
		return _ActorInputString;
	}

	public void ReadLineFromActor() {
		string? inputLine = Console.ReadLine();
		if (inputLine != null && inputLine != "") {

			string printThis = $"ReadLineFromActor if (inputLine != null) Actor typed <{inputLine}>";

			Console.SetCursorPosition(26, 16);
			Console.Write(printThis);

			_ActorInputString = inputLine;
		}
		else {
			Console.SetCursorPosition(26, 16);
			Console.Write("ReadLineFromActor is null");

			_ActorInputString = "Player 1";
		}
	}
}
