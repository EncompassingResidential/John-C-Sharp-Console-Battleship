using System;
using System.Collections.Generic;

public class UserBattleShipGrid {
    private int _numberRows;
    private int _numberCols;
    private char _MissChar;

    private char[,] _targetLocations;

    private List<char> _RowNumbers = new List<char>();

    public UserBattleShipGrid(int numberColums, int numberRows) {
        _numberCols = numberColums;
        _numberRows = numberRows;

        PlayerRow = '_';
        PlayerColumn = -99;

        _MissChar = 'O';

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

        for (int row = 0; row < getNumberRows(); row++) {
            for (int col = 0; col < getNumberColumns(); col++) {
                _targetLocations[row, col] = '~';
            }
        }

    }

    public char PlayerRow { get ;  private set ; }

    public int  PlayerColumn { get; private set; }

    public bool PlayerFires { get; private set; }

    public char getMissChar() {
        return _MissChar;
    }

    public void updatePlayerColumn(int playerColumn) {
        PlayerColumn = playerColumn;
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

    public void markUserTarget() {

        int indexFound = _RowNumbers.FindIndex(e => e == PlayerRow);
        _targetLocations[indexFound, PlayerColumn - 1] = getMissChar();

/*        for (int row = 0; row < getNumberRows(); row++) {
            for (int col = 0; col < getNumberColumns(); col++) {
            }
        } */

    }

}
