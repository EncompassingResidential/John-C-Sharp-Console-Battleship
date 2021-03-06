using System;

public class BattleShipGrid {
    private int _numberRows;
    private int _numberCols;

    private char[,] _shipLocations;

    // Worked private int[] _shipPositions = { 1, 2, 3, 4 };

    // Did Work
    // _shipPositions[0, #] Battleship can go to the North
    // _shipPositions[1, #] Battleship can go to the North East
    // _shipPositions[2, #] Battleship can go to the East
    // _shipPositions[3, #] Battleship can go to the South East
    // etc.
    private int[,] _shipPositions = { { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 },
                                    { 0, 0 } };

    private int _battleShipRowStart;
    private int _battleShipColStart;
    private int _battleShipLength;

    public BattleShipGrid(int numberColums, int numberRows) {
        _numberCols = numberColums;
        _numberRows = numberRows;
        _battleShipLength = 5;
        TypeBattleShip = 1;

        _shipLocations = new char[getNumberRows(), getNumberColumns()];

        resetShipLocation();
    }

    public int TypeBattleShip {
        private set; get;
    }

    public void startGameOver() {
        resetShipLocation();
    }

    private void resetShipLocation() {

        for (int rowL = 0; rowL < getNumberRows(); rowL++) {
            for (int colL = 0; colL < getNumberColumns(); colL++) {
                _shipLocations[rowL, colL] = '_';
            }
        }

        Random rand = new Random();
        _battleShipRowStart = rand.Next(0, getNumberRows());
        _battleShipColStart = rand.Next(0, getNumberColumns());

        _shipLocations[getBattleShipRowStart, getBattleShipColStart] = 'B';

        // Figure out how many directions the ship can go
        _shipPositions = whichDirectionsCanShipGo(getBattleShipRowStart, getBattleShipColStart);

        // Then pick one of them

        int directionsCanUseCount = 0;

        for (int row = 0; row < 8; row++) {
            if (   ( _shipPositions[row, 0] >= 0 && _shipPositions[row, 0] < getNumberRows() ) 
                && ( _shipPositions[row, 1] >= 0 && _shipPositions[row, 1] < getNumberColumns() ) ) {
                directionsCanUseCount++;
            }
        }

        int directionRow = -1;
        int directionCol = -1;
        int DirectionOn = 1;

        // 1 to 8
        int matrixDirection = rand.Next(1, directionsCanUseCount + 1);

        if (directionsCanUseCount > 0) {


            for (int row = 0; row < getNumberRows(); row++) {

                if (   (_shipPositions[row, 0] >= 0 && _shipPositions[row, 0] < getNumberRows())
                    && (_shipPositions[row, 1] >= 0 && _shipPositions[row, 1] < getNumberColumns())) {
                    if (DirectionOn == matrixDirection) {
                        directionRow = _shipPositions[row, 0];
                        directionCol = _shipPositions[row, 1];
                        break;
                    }
                    else {
                        DirectionOn++;
                    }
                }
                /* else {
                    DirectionOn++;
                } */
            } // for

        }
        else {
            Console.SetCursorPosition(26, 26);
            Console.Write(" Could not find a random direction to initialize the Ship Position on the board.");
        }

        // Then fill in ship grid

        int rowChangeNumber = 0;
        if (directionRow < getBattleShipRowStart) {
            rowChangeNumber = -1;
        }
        else if (directionRow > getBattleShipRowStart) {
            rowChangeNumber = 1;
        }
        else {
            rowChangeNumber = 0;
        }

        int columnChangeNumber = 0;
        if (directionCol < getBattleShipColStart) {
            columnChangeNumber = -1;
        }
        else if (directionCol > getBattleShipColStart) {
            columnChangeNumber = 1;
        }
        else {
            columnChangeNumber = 0;
        }

        // 5 + 0 = 5 -> 5 + 0 = 5
        // 5 + 1 = 6 -> 6 + 1 = 7
        // 5 - 1 = 4 -> 4 - 1 = 3
        int rowLocation = getBattleShipRowStart + rowChangeNumber;
        int colLocation = getBattleShipColStart + columnChangeNumber;
        _shipLocations[rowLocation, colLocation] = 'B';
        
        /* rowLocation ;
        colLocation ; */
        _shipLocations[rowLocation += rowChangeNumber, colLocation += columnChangeNumber] = 'B';
        
        _shipLocations[rowLocation += rowChangeNumber, colLocation += columnChangeNumber] = 'B';

        _shipLocations[rowLocation += rowChangeNumber, colLocation += columnChangeNumber] = 'B';

    } // resetShipLocation()

    private int[,] whichDirectionsCanShipGo(int shipRowStart, int shipColStart) {

        int[,] tdShipLocations = new int[8, 2];

        /* Example:  Actor Fires at end of ship [ H, 5 ]
            Ship had end of ship starting at    [ 7, 4 ]  
            Ship can go: Up, Up & Right, Right, Down and Left, Left, Up and Left
         {  {  3, 4 },
            {  3, 8 },
            {  7, 8 },
            { 11, 8 },
            { 11, 4 },
            { 11, 0 },
            {  7, 0 },
            {  3, 0 } }
        */

        // Starting at (row, column == 5, 5) [ Which in an array would be 4, 4 ]

        // 0 - 4 = -4
        // 9 - 4 = 5
        int positionUpEnd = getBattleShipRowStart - (_battleShipLength - 1);

        // 0 + 4 =  4
        // 9 + 4 = 13
        int positionRightEnd = getBattleShipColStart + (_battleShipLength - 1);

        // 0 + 4 =  4
        // 9 + 4 = 13
        int positionDownEnd = getBattleShipRowStart + (_battleShipLength - 1);

        // 0 - 4 = -4
        // 9 - 4 = 5
        int positionLeftEnd = getBattleShipColStart - (_battleShipLength - 1);


        // Range allowed -4 to 5
        int positionUpRightRowEnd = positionUpEnd;

        // Range allowed 4 to 13
        int positionUpRightColEnd = positionRightEnd;

        // Range allowed 4 to 13
        int positionDownRightRowEnd = positionDownEnd;

        // Range allowed 4 to 13
        int positionDownRightColEnd = positionRightEnd;

        // Range allowed -4 to 5
        int positionUpLeftRowEnd = positionUpEnd;

        // Range allowed -4 to 5
        int positionUpLeftColEnd = positionLeftEnd;

        // Range allowed 4 to 13
        int positionDownLeftRowEnd = positionDownEnd;

        // Range allowed -4 to 5
        int positionDownLeftColEnd = positionLeftEnd;

        // if getBattleShipRowStart = 0 && getBattleShipColStart = 0
        // then [-4, 0]
        // Ship going Up            = Row then Colmn
        tdShipLocations[0, 0] = positionUpEnd;
        tdShipLocations[0, 1] = getBattleShipColStart;

        // if getBattleShipRowStart = 0 && getBattleShipColStart = 9
        // then [-4, 13]
        // Ship going Up   && Right
        tdShipLocations[1, 0] = positionUpRightRowEnd;
        tdShipLocations[1, 1] = positionUpRightColEnd;

        // Ship going         Right = Row then Colmn
        tdShipLocations[2, 0] = getBattleShipRowStart;
        tdShipLocations[2, 1] = positionRightEnd;

        // Ship going Down && Right
        tdShipLocations[3, 0] = positionDownRightRowEnd;
        tdShipLocations[3, 1] = positionDownRightColEnd;

        // Ship going Down         = Row then Colmn
        tdShipLocations[4, 0] = positionDownEnd;
        tdShipLocations[4, 1] = getBattleShipColStart;

        // Ship going Down && Left
        tdShipLocations[5, 0] = positionDownLeftRowEnd;
        tdShipLocations[5, 1] = positionDownLeftColEnd;

        // Ship going         Left = Row then Colmn
        tdShipLocations[6, 0] = getBattleShipRowStart;
        tdShipLocations[6, 1] = positionLeftEnd;

        // Ship going Up   && Left
        tdShipLocations[7, 0] = positionUpLeftRowEnd;
        tdShipLocations[7, 1] = positionUpLeftColEnd;

        return tdShipLocations;
    }

    public int getNumberColumns() {
        return _numberCols;
    }

    public int getNumberRows() {
        return _numberRows;
    }

    public int getShipLength() {
        return _battleShipLength;
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