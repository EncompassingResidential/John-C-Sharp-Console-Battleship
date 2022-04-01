using System;

public class BattleShipGrid {
	private int _numberRows;
	private int _numberCols;

	private char[,] _shipLocations;

	private int _battleShipRowStart;
	private int _battleShipColStart;

	public BattleShipGrid(int numberColums, int numberRows)
	{
		_numberCols = numberColums;
		_numberRows = numberRows;

		_shipLocations = new char[_numberCols, _numberCols];

		Random rand = new Random();
		_battleShipRowStart = rand.Next(0, _numberRows);
		_battleShipColStart = rand.Next(0, _numberCols);
	}

	public int BattleShipRowStart { get { return _battleShipRowStart; } }
	public int BattleShipColStart { get { return _battleShipColStart; } }

}
