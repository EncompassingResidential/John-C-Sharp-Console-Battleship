using System;

public class BattleShipGrid {
    private int _numberRows;
    private int _numberCols;

    private char[,] _shipLocations;

    private int _battleShipRowStart;
    private int _battleShipColStart;
    private int _battleShipLength;

    public BattleShipGrid(int numberColums, int numberRows) {
        _numberCols = numberColums;
        _numberRows = numberRows;
        _battleShipLength = 5;

        _shipLocations = new char[_numberCols, _numberCols];

        resetShipLocation();
    }

    private void resetShipLocation() {
        for (int row = 0; row < _numberRows; row++) {
            for (int col = 0; col < _numberCols; col++) {
                _shipLocations[row, col] = '_';
            }
        }

        Random rand = new Random();
        _battleShipRowStart = rand.Next(0, _numberRows);
        _battleShipColStart = rand.Next(0, _numberCols);

        _shipLocations[_battleShipRowStart, _battleShipColStart] = 'B';

        // 5 - 4 = 1
        int positionUpEnd      = _battleShipRowStart - (_battleShipLength - 1);
        // 5 + 4 = 9
        int positionRightEnd   = _battleShipColStart + (_battleShipLength - 1);

        // 5 + 4 = 9
        int positionDownEnd    = _battleShipRowStart + (_battleShipLength - 1);
        // 5 - 4 = 1
        int positionLeftEnd    = _battleShipColStart - (_battleShipLength - 1);

        // 1
        int positionUpRightRowEnd = positionUpEnd;
        // 9
        int positionUpRightColEnd = positionRightEnd;

        // 9
        int positionDownRightRowEnd = positionDownEnd;
        // 9
        int positionDownRightColEnd = positionRightEnd;

        // 1
        int positionUpLeftRowEnd = positionUpEnd;
        // 1
        int positionUpLeftColEnd = positionLeftEnd;

        // 9
        int positionDownLeftRowEnd = positionDownEnd;
        // 1
        int positionDownLeftColEnd = positionLeftEnd;


        // 0, 1, or 2
        int matrixRow = rand.Next(0, 3);
        int matrixCol = rand.Next(0, 3);

        /* D (3), 7 (6)
         D (3) + { 0, 1, 2 } - 1
            3 + 0 - 1 = 2 C
            3 + 1 - 1 = 3 D
            3 + 2 - 1 = 4 E
        */
        int nextRowToTry = _battleShipRowStart + matrixRow - 1;

        /* D (3), 7 (6)
         7 (6) + { 0, 1, 2 } - 1
            6 + 0 - 1 = 5
            6 + 1 - 1 = 6
            6 + 2 - 1 = 7
        */
        int nextColumnToTry = _battleShipColStart + matrixCol - 1;

        int row = 0;
        int col = 0;

        for (int shipGrid = 0; shipGrid < _numberCols; shipGrid++) {
            if (nextRowToTry < 0 || nextRowToTry >= _numberCols) {
                _shipLocations[row, col] = 'B';
            }
            nextRowToTry    = 0;
            nextColumnToTry = 0;

        }
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
