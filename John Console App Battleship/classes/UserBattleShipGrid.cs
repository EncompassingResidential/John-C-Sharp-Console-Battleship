using System;
using System.Collections.Generic;

public class UserBattleShipGrid {
    private int _numberRows;
    private int _numberCols;
    private char _UserTargetChar;

    private char[,] _targetLocations;

    private List<char> _RowNumbers = new List<char>();

    public UserBattleShipGrid(int numberColums, int numberRows) {
        _numberCols = numberColums;
        _numberRows = numberRows;

        ActorName = "Default Actor Name";

        _UserTargetChar = 'O';

        _RowNumbers.Add('A');
        _RowNumbers.Add('B');
        _RowNumbers.Add('C');
        _RowNumbers.Add('D');
        _RowNumbers.Add('E');
        _RowNumbers.Add('F');
        _RowNumbers.Add('G');
        _RowNumbers.Add('H');
        _RowNumbers.Add('I');
        _RowNumbers.Add('J');

        _targetLocations = new char[getNumberRows(), getNumberColumns()];

        resetUserShipStatus();

    }

    public char PlayerRow { get; private set; }

    public int PlayerColumn { get; private set; }

    public bool PlayerFires { get; private set; }

    public int ShipStrikes { get; private set; }

    public bool RunGame { get; set; }

    public bool UserTriedAndFailed { get; set; }

    public string ActorName { get; set; }

    public void resetUserShipStatus() {

        // updateRestartGameStatus(false);

        PlayerRow = '_';
        PlayerColumn = -99;

        updatePlayerFires(false);

        updateNumberOfHits(0);

        isTesting = false;

        for (int row = 0; row < getNumberRows(); row++) {
            for (int col = 0; col < getNumberColumns(); col++) {
                _targetLocations[row, col] = '~';
            }
        }
    }
     

    public char getUserTargetChar() {
        return _UserTargetChar;
    }

    public void updatePlayerColumn(int playerColumn) {
        if ( playerColumn > 0 && playerColumn <= getNumberColumns() ) {
            PlayerColumn = playerColumn;
        }
        else {
            PlayerColumn = -99;
        }
    }

    public void updatePlayerRow(char playerRow) {
        PlayerRow = playerRow;
    }

    private int getNumberRows() {
        return _numberRows;
    }

    private int getNumberColumns() {
        return _numberCols;
    }

    public void updatePlayerFires(bool playerFires) {
        PlayerFires = playerFires;
    }

    public char getTargetLocation(int column, int row) {
        return _targetLocations[row, column];
    }

    public bool didUserFireHere(int column, int row) {
        bool didFireHere = false;
        if ( _targetLocations[row, column] == getUserTargetChar() ) {
            didFireHere = true;
        }
        return didFireHere;
    }

    public bool areUserInputsValid() {
        bool returnBoolean = false;
        if (getRowIndex() >= 0 && getRowIndex() < _RowNumbers.Count) {
            if ( PlayerColumn > 0 && PlayerColumn <= _numberCols) {
                returnBoolean = true;
            }
        }
        return returnBoolean;
    }

    public int getRowIndex() {
        // why did creating this rowIndex variable fix this?
        int rowIndex = _RowNumbers.FindIndex(e => e == PlayerRow);

        // when I did a direct return of the _RowNumbers.FindIndex it broke the code.
        return rowIndex;
    }

    public char getRowChar(int index) {

        char charAtIndex = _RowNumbers.ElementAt(index);

        return charAtIndex;
    }

    public void markUserTarget() {

        if (PlayerRow != '_' && PlayerColumn != -99) {
            _targetLocations[getRowIndex(), PlayerColumn - 1] = getUserTargetChar();
        }
        else {
            updatePlayerFires(false);
        }

/*        for (int row = 0; row < getNumberRows(); row++) {
            for (int col = 0; col < getNumberColumns(); col++) {
            }
        } */

    }

    public void updateNumberOfHits(int numberOfShipStrikes) {
        ShipStrikes = numberOfShipStrikes;
    }

    public void updateRestartGameStatus(bool gameStatus) {
        StartGameOver = gameStatus;
    }

    public bool StartGameOver {
        get; private set;
    }

    public bool isTesting {
        get; private set;
    }

    public void toggleTesting() {
        isTesting = (isTesting) ? false : true;
    }
}
