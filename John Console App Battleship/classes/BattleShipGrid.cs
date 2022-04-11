using System;

public class BattleShipGrid {
    private int _numberRows;
    private int _numberCols;

    private char[,] _shipLocations;

    private int _battleShipRowStart;
    private int _battleShipColStart;

    public BattleShipGrid(int numberColums, int numberRows) {
        _numberCols = numberColums;
        _numberRows = numberRows;

        _shipLocations = new char[_numberCols, _numberCols];

        for (int row = 0; row < _numberRows; row++) {
            for (int col = 0; col < _numberCols; col++) {
                _shipLocations[row, col] = '_';
            }
        }

        Random rand = new Random();
        _battleShipRowStart = rand.Next(0, _numberRows);
        _battleShipColStart = rand.Next(0, _numberCols);

        _shipLocations[_battleShipRowStart, _battleShipColStart] = 'B';
    }

    public int getNumColumns() {
        return _numberCols;
    }

    public int getNumRows() {
        return _numberRows;
    }

    public int getBattleShipRowStart {
        get {
            return _battleShipRowStart;
        }
    }
    public int getBattleShipColStart {
        get {
            return _battleShipColStart;
        }
    }

    public bool isShipLocatedHere(int col, int row) {
        if (_shipLocations[row, col] == 'B') {
            return true;
        }
        else {
            return false;
        }
    }

}
