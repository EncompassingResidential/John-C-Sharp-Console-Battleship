namespace BattleShip
{

class Program
    {
        static void Main(string[] args)
        {
            BattleShipGrid battleShipGrid = new BattleShipGrid(10, 10);

            BattleShipInput battleShipInput = new BattleShipInput();

            BattleShipDisplay battleShipDisplay = new BattleShipDisplay(battleShipGrid.getNumberColumns(),
                                                                        battleShipGrid.getNumberRows());

            UserBattleShipGrid userBattleShipGrid = new UserBattleShipGrid(battleShipGrid.getNumberColumns(), 
                                                                            battleShipGrid.getNumberRows());

            battleShipDisplay.setGridLocation(battleShipDisplay.GetHeaderLeft() + 20, battleShipDisplay.GetHeaderTop() + 11);

            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine("    TOP SECRET");
            battleShipDisplay.WriteStringLine("                     -  Our fate rests at your finger tips...");
            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine("The Battleship has been hidden behind an invisible cloak by Master CPU!");
            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine("     You must find it and sink it...");
            battleShipDisplay.WriteStringLine(" ");

            battleShipDisplay.WriteString("       Type In Your Code Name Call Sign In : ");

            battleShipInput.ReadLineFromActor();

            var name = battleShipInput.GetLineFromActor();

            battleShipDisplay.ResetScreen();

            bool runGame = true;
            char actorChar = 'y';
            
            const int numberOfTurnsMax = 8;
            int currentNumberOfTurns = numberOfTurnsMax;

            int previousRow = -1;
            int previousColumn = -1;
            bool userTriedAndFailed = false;
            int  userTriedAndFailedCount = 0;
            bool BattleShipSunk = false;

            while (runGame)
            {
                var currentDate = DateTime.Now;

                battleShipDisplay.ResetScreen();

                battleShipDisplay.WriteHeaderLine("........................", 0, 0);
                battleShipDisplay.WriteHeaderLine($"Hello, {name}, on {currentDate:d} at {currentDate:t}!", 0, 1);
                battleShipDisplay.WriteHeaderLine("      Battleship        ", 0, 2);
                battleShipDisplay.WriteHeaderLine("........................", 0, 3);
                battleShipDisplay.WriteHeaderLine(".......The Ocean........", 0, 4);
                battleShipDisplay.WriteHeaderLine("........................", 0, 5);

                battleShipDisplay.WriteHeaderLine("Press 'q' or 'Q' to blow up the entire Grid...", 0, 7);

                battleShipDisplay.WriteStringToPoint("1 2 3 4 5 6 7 8 9 10", battleShipDisplay.GetGridLeft(), battleShipDisplay.GetGridTop() - 2);

                int numberOfStrikes = 0;
                char rowCharacter = ' ';

                for (int row = 0; row < battleShipGrid.getNumberRows(); row++) {

                    rowCharacter = Convert.ToChar(battleShipDisplay.GetGridTop() + 52 + row);

                    battleShipDisplay.WriteCharToGridPoint(rowCharacter, -3, row);

                    for (int column = 0; column < battleShipGrid.getNumberColumns(); column++ ) {
                        if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getUserTargetChar() 
                            && battleShipGrid.isShipLocatedHere(column, row)) {

                            battleShipDisplay.WriteCharToGrid('X', column, row);
                            userBattleShipGrid.updateNumberOfHits(++numberOfStrikes);
                            // userBattleShipGrid.updatePlayerFires(false);
                            
                        }
                        else if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getUserTargetChar()) {
                            battleShipDisplay.WriteCharToGrid(userBattleShipGrid.getUserTargetChar(), column, row);
                            // userBattleShipGrid.updatePlayerFires(false);
                        }
                        else {
                            battleShipDisplay.WriteCharToGrid('.', column, row);
                        }

                        /* TESTING Easter Egg */
                        if (userBattleShipGrid.isTesting) {
                            if (battleShipGrid.isShipLocatedHere(column, row)) {
                                battleShipDisplay.WriteCharToPoint('B', 
                                                battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                            }
                            else {
                                battleShipDisplay.WriteCharToPoint('_', 
                                                battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                            }
                        }

                    }  // for column
                }  // for row

                int testingPresentWidth = (userBattleShipGrid.isTesting) ? 21 : 0;

                string extraS = (userBattleShipGrid.ShipStrikes == 1) ? "" : "s";

                if (userBattleShipGrid.ShipStrikes > 0) {

                    battleShipDisplay.WriteStringToPoint($"You hit the ship {userBattleShipGrid.ShipStrikes} time{extraS}!",
                                         battleShipDisplay.GetErrorLeft() + testingPresentWidth + 11, battleShipDisplay.GetErrorTop() + 4);

                }
                else if ( ! userBattleShipGrid.StartGameOver && userTriedAndFailed && ! BattleShipSunk ) {

                    userTriedAndFailedCount++;

                    battleShipDisplay.WriteStringToPoint("You Ran out of turns",
                                        battleShipDisplay.GetGridLeft() + testingPresentWidth + 1, battleShipDisplay.GetGridTop() + 2);
                    battleShipDisplay.WriteStringToPoint("The Battleship smashed you.",
                                        battleShipDisplay.GetGridLeft() + testingPresentWidth + 2, battleShipDisplay.GetGridTop() + 4);
                    battleShipDisplay.WriteStringToPoint("You reincarnated now try to find Battleship again to find and sink!",
                                        battleShipDisplay.GetGridLeft() + testingPresentWidth + 3, battleShipDisplay.GetGridTop() + 6);
                    
                    if (userTriedAndFailedCount > 1) {
                        BattleShipSunk = false;
                        userTriedAndFailed = false;
                        userTriedAndFailedCount = 0;
                    }
                }

                if (userBattleShipGrid.ShipStrikes > 4) {
                    BattleShipSunk = true;

                    battleShipDisplay.ReverseColors();
                    Task.Delay(200);
                    battleShipDisplay.WriteStringToPoint($"You sunk the Battleship!", 
                                    battleShipDisplay.GetErrorLeft() + testingPresentWidth + 12, battleShipDisplay.GetErrorTop() + 7);
                    battleShipDisplay.ForeColors();
                    Task.Delay(200);
                    battleShipDisplay.ReverseColors();

                    battleShipDisplay.WriteStringToPoint($"Press R or r to ReStart the Game.",
                                    battleShipDisplay.GetErrorLeft() + testingPresentWidth + 15, battleShipDisplay.GetErrorTop() + 10);

                }

                battleShipDisplay.WriteStringToPoint("Press Row Letter on Keyboard to choose which row to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 9);
                battleShipDisplay.WriteStringToPoint("Press Column number on Keyboard to choose which column to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 8);
                battleShipDisplay.WriteStringToPoint("Where the Row and Column cross on the grid",
                                                        battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 6);
                battleShipDisplay.WriteStringToPoint("is where you are targeting your Dove of death.",
                                                       battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 5);

                if (userBattleShipGrid.ShipStrikes < battleShipGrid.getShipLength()) {
                    battleShipDisplay.WriteStringToPoint($"Battleship fires on you in {currentNumberOfTurns} turns.",
                                                            battleShipDisplay.GetErrorLeft() + 10, battleShipDisplay.GetErrorTop() - 2);
                }


                string actorRowString    = (userBattleShipGrid.PlayerRow == '_') ? "Type in You Row Letter" : userBattleShipGrid.PlayerRow.ToString() ;
                string actorColumnString = (userBattleShipGrid.PlayerColumn == -99) ? "Type in Your Column number, for 10 type in a 0 (zero)" : userBattleShipGrid.PlayerColumn.ToString();

                battleShipDisplay.WriteStringToPoint($"  You Pressed --> Row    {actorRowString}",
                                                        battleShipDisplay.GetInformationLeft(), battleShipDisplay.GetInformationTop() - 2 );
                battleShipDisplay.WriteStringToPoint($"              --> Column {actorColumnString}",
                                                        battleShipDisplay.GetInformationLeft(), battleShipDisplay.GetInformationTop() - 1);
                battleShipDisplay.WriteStringToPoint("  ", battleShipDisplay.GetInformationLeft() + 1, battleShipDisplay.GetInformationTop() + 1);
                battleShipDisplay.WriteStringToPoint("          Press the Enter / Return key to fire a shot at the MCU's Battleship.", battleShipDisplay.GetInformationLeft() - 5, battleShipDisplay.GetInformationTop() + 1);

                battleShipDisplay.WriteStringToPoint("Grid Legend",
                        battleShipDisplay.GetGridLeft() - 16, battleShipDisplay.GetGridTop() + 1);
                battleShipDisplay.WriteStringToPoint(".  Unknown",
                        battleShipDisplay.GetGridLeft() - 15, battleShipDisplay.GetGridTop() + 3);
                battleShipDisplay.WriteStringToPoint("O  missed",
                        battleShipDisplay.GetGridLeft() - 15, battleShipDisplay.GetGridTop() + 5);
                battleShipDisplay.WriteStringToPoint("X  Strike",
                        battleShipDisplay.GetGridLeft() - 15, battleShipDisplay.GetGridTop() + 7);


                battleShipInput.ReadCharFromActor();
                
                actorChar = battleShipInput.GetCharFromActor();

                userBattleShipGrid.updateRestartGameStatus(false);

                if (Char.IsNumber(actorChar) == true) {
                    userBattleShipGrid.updatePlayerFires(false);

                    if (actorChar >= 49) {
                        userBattleShipGrid.updatePlayerColumn(actorChar - 48);
                    }
                    else {
                        userBattleShipGrid.updatePlayerColumn(10);
                    }

                }
                else if (battleShipInput.GetKeyFromActor() == ConsoleKey.Enter) {
                    userBattleShipGrid.updatePlayerFires(true);
                }
                else {
                    userBattleShipGrid.updatePlayerFires(false);

                    // Could use a List to replace this Switch Case
                    switch (actorChar) {
                        case 'A' or 'a':
                            userBattleShipGrid.updatePlayerRow('A');
                            break;

                        case 'B' or 'b':
                            userBattleShipGrid.updatePlayerRow('B');
                            break;

                        case 'C' or 'c':
                            userBattleShipGrid.updatePlayerRow('C');
                            break;

                        case 'D' or 'd':
                            userBattleShipGrid.updatePlayerRow('D');
                            break;

                        case 'E' or 'e':
                            userBattleShipGrid.updatePlayerRow('E');
                            break;

                        case 'F' or 'f':
                            userBattleShipGrid.updatePlayerRow('F');
                            break;

                        case 'G' or 'g':
                            userBattleShipGrid.updatePlayerRow('G');
                            break;

                        case 'H' or 'h':
                            userBattleShipGrid.updatePlayerRow('H');
                            break;

                        case 'I' or 'i':
                            userBattleShipGrid.updatePlayerRow('I');
                            break;

                        case 'J' or 'j':
                            userBattleShipGrid.updatePlayerRow('J');
                            break;

                        case 'Q' or 'q':
                            runGame = false;
                            break;

                        case 'R' or 'r':
                            userBattleShipGrid.updatePlayerRow('_');
                            userBattleShipGrid.updateRestartGameStatus(true);
                            userTriedAndFailed = false;
                            break;

                        case 'T' or 't':
                            userBattleShipGrid.toggleTesting();
                            break;

                    } // switch

                } // else

                // When Actor presses ENTER
                if (userBattleShipGrid.areUserInputsValid() &&
                    userBattleShipGrid.ShipStrikes < battleShipGrid.getShipLength() &&
                        userBattleShipGrid.PlayerFires &&
                            ( previousRow != userBattleShipGrid.getRowIndex() ||
                                previousColumn != userBattleShipGrid.PlayerColumn - 1 ) ) {

                    /*
                     * These previous### variables exist to prevent error
                     * after Actor types in Enter key
                     * but hasn't changed Row and Column keys.
                     * Preventing Actor from firing at the same target right
                     * after trying it on previous turn.
                     */
                    previousRow = userBattleShipGrid.getRowIndex();
                    previousColumn = userBattleShipGrid.PlayerColumn - 1;

                    userBattleShipGrid.markUserTarget();

                    // If a Hit
                    if (userBattleShipGrid.didUserFireHere(userBattleShipGrid.PlayerColumn - 1, userBattleShipGrid.getRowIndex())
                            == battleShipGrid.isShipLocatedHere(userBattleShipGrid.PlayerColumn - 1, userBattleShipGrid.getRowIndex())) {

                        if (userBattleShipGrid.ShipStrikes == 0) {
                            currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 2;
                        }

                        else {
                            if ( currentNumberOfTurns < battleShipGrid.getShipLength() ) {

                                if (currentNumberOfTurns < battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes) {
                                    currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 0;
                                }
                                else {
                                    currentNumberOfTurns--;
                                }
                            }
                            else {
                                currentNumberOfTurns--;
                            }
                        }
                    }

                    // If not a hit
                    else {
                        currentNumberOfTurns--;
                    }

                } // If Actor fires

                if ( userBattleShipGrid.StartGameOver || currentNumberOfTurns <= 0 ) {
                    battleShipGrid.startGameOver();
                    userBattleShipGrid.resetUserShipStatus();
                    currentNumberOfTurns = numberOfTurnsMax;
                    
                    previousRow = -1;
                    previousColumn = -1;

                    if ( ! userBattleShipGrid.StartGameOver ) {
                        userTriedAndFailed = true;
                    }
                }

            } // while

        } // Main
    }
}
