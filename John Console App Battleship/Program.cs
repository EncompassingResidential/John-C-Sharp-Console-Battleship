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
            
            string displayString = $"Battleship Start Row {battleShipGrid.getBattleShipRowStart}  --> Start Column {battleShipGrid.getBattleShipColStart}  ";
            battleShipDisplay.WriteInformationLine(displayString);

            const int numberOfTurnsMax = 8;
            int currentNumberOfTurns = numberOfTurnsMax;
            bool wasUserBattleShipGridPlayerFires = false;

            int previousRow = -1;
            int previousColumn = -1;

            while (runGame)
            {
                var currentDate = DateTime.Now;

                battleShipDisplay.ResetScreen();
                userBattleShipGrid.updateGameOverStatus(false);

                battleShipDisplay.WriteStringToPoint($"Begining of while loop currentNumberOfTurns {currentNumberOfTurns}  out of {numberOfTurnsMax} turns.",
                                                    battleShipDisplay.GetErrorLeft() + 10, battleShipDisplay.GetErrorTop() - 1);

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
                // int curNumOfTurnsBeginingOfForLoop = currentNumberOfTurns;

                // battleShipDisplay.GetGridLeft() 5, battleShipDisplay.GetGridTop() 10
                // y is 10; 10 < 10 + 10; 10++
                // y is 11; 10 < 20; 10++
                for (int row = 0; row < battleShipGrid.getNumberRows(); row++) {
                    // 7 + 8 + 20 = 35 0
                    // 8 + 9 + 20 = 36 1
                    // 9 + 10 + 20 = 37 2
                    // 48 starts 1st row at 0
                    rowCharacter = Convert.ToChar(battleShipDisplay.GetGridTop() + 52 + row);

                    // 3, 10
                    // 3, 11
                    // 3, 12
                    battleShipDisplay.WriteCharToGridPoint(rowCharacter, -3, row);

                    // 5; 5 < 5 + (10 * 2); 5 += 2
                    // 7; 7 < 5 + (20); 7 += 2
                    // 9; 7 < 25; 9 += 2
                    // 11; 11 < 25; 11 += 2
                    for (int column = 0; column < battleShipGrid.getNumberColumns(); column++ ) {
                        if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getUserTargetChar() 
                            && battleShipGrid.isShipLocatedHere(column, row)) {

                            battleShipDisplay.WriteCharToGrid('X', column, row);
                            userBattleShipGrid.updateNumberOfHits(++numberOfStrikes);
                            userBattleShipGrid.updatePlayerFires(false);
                            
                        }
                        else if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getUserTargetChar()) {
                            battleShipDisplay.WriteCharToGrid(userBattleShipGrid.getUserTargetChar(), column, row);
                            userBattleShipGrid.updatePlayerFires(false);
                        }
                        else {
                            battleShipDisplay.WriteCharToGrid('.', column, row);
                        }

                        /* TESTING */
                        if (userBattleShipGrid.isTesting) {
                            if (battleShipGrid.isShipLocatedHere(column, row)) {
                                battleShipDisplay.WriteCharToPoint('B', 
                                                battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                            }
                            else {
                                battleShipDisplay.WriteCharToPoint('_', 
                                                battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                            }
                        } /* */

                    }  // for column
                }  // for row

                int testingPresentWidth = (userBattleShipGrid.isTesting) ? 21 : 0;

                if (wasUserBattleShipGridPlayerFires) {
                    wasUserBattleShipGridPlayerFires = false;
                    battleShipDisplay.WriteStringToPoint($"update PlayerRow {userBattleShipGrid.PlayerRow}",
                                        battleShipDisplay.GetErrorLeft() + testingPresentWidth + 11, battleShipDisplay.GetErrorTop() + 10);
                    battleShipDisplay.WriteStringToPoint($"update PlayerCol {userBattleShipGrid.PlayerColumn}",
                                        battleShipDisplay.GetErrorLeft() + testingPresentWidth + 11, battleShipDisplay.GetErrorTop() + 11);
                }

                string extraS = (userBattleShipGrid.ShipStrikes == 1) ? "" : "s";

                if (userBattleShipGrid.ShipStrikes > 0 && userBattleShipGrid.areUserInputsValid()) {

                    battleShipDisplay.WriteStringToPoint($"You hit the ship {userBattleShipGrid.ShipStrikes} time{extraS}!",
                                         battleShipDisplay.GetErrorLeft() + testingPresentWidth + 11, battleShipDisplay.GetErrorTop() + 4);

                    battleShipDisplay.WriteStringToPoint($"Player shot [getRowIndex(), PlayerColumn]",
                                         battleShipDisplay.GetErrorLeft() + testingPresentWidth +  9, battleShipDisplay.GetErrorTop() + 6);
                    battleShipDisplay.WriteStringToPoint($"            [{userBattleShipGrid.getRowIndex()}, {userBattleShipGrid.PlayerColumn - 1}]",
                                         battleShipDisplay.GetErrorLeft() + testingPresentWidth +  9, battleShipDisplay.GetErrorTop() + 7);

                    if (userBattleShipGrid.getTargetLocation(userBattleShipGrid.PlayerColumn - 1, userBattleShipGrid.getRowIndex())
                                == userBattleShipGrid.getUserTargetChar()) {
                    // When Actor presses ENTER
                        // currentNumberOfTurns--;
                        battleShipDisplay.WriteStringToPoint($"WHAT getTargetLoction == getUserTargetChar  >>> currentNumberOfTurns is now {currentNumberOfTurns}",
                                                        battleShipDisplay.GetErrorLeft() - 6, battleShipDisplay.GetErrorTop() - 3);
                    }
                    else {
                        // When Actor presses non-Enter keys

                        if (userBattleShipGrid.ShipStrikes == 1) {
                            currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 2;
                            battleShipDisplay.WriteStringToPoint($"HEY getTargetLoction  !=  getUserTargetChar  >>> currentNumberOfTurns is now {currentNumberOfTurns}",
                                                            battleShipDisplay.GetErrorLeft() - 6, battleShipDisplay.GetErrorTop() - 3);
                        }
                        else {
                            // currentNumberOfTurns = ;
                        }
                    }

                    //battleShipDisplay.WriteStringToPoint($"ShipStrikes > 0 && areUserInputsValid then currentNumberOfTurns is now {currentNumberOfTurns}  out of {numberOfTurnsMax} turns.",
                    //                                  battleShipDisplay.GetErrorLeft() - 6, battleShipDisplay.GetErrorTop() - 3);

                }
                else if (userBattleShipGrid.ShipStrikes > 0) {
                    battleShipDisplay.WriteStringToPoint($"You hit the ship {userBattleShipGrid.ShipStrikes} time{extraS}!",
                                        battleShipDisplay.GetErrorLeft() + testingPresentWidth + 11, battleShipDisplay.GetErrorTop() + 4);

                    battleShipDisplay.WriteStringToPoint($"HOW           >>> currentNumberOfTurns is now {currentNumberOfTurns}",
                                                        battleShipDisplay.GetErrorLeft() - 6, battleShipDisplay.GetErrorTop() - 3);
                }


                if (userBattleShipGrid.ShipStrikes > 4) {
                    battleShipDisplay.ReverseColors();
                    Task.Delay(200);
                    battleShipDisplay.WriteStringToPoint($"You sunk the Battleship!", 
                                                battleShipDisplay.GetErrorLeft() + testingPresentWidth + 12, battleShipDisplay.GetErrorTop() + 7);
                    battleShipDisplay.ForeColors();
                    Task.Delay(200);
                    battleShipDisplay.ReverseColors();

                    battleShipDisplay.WriteStringToPoint($"Press R or r to ReStart the Game.",
                                                battleShipDisplay.GetErrorLeft() + testingPresentWidth + 10, battleShipDisplay.GetErrorTop() + 11);

                }

                battleShipDisplay.WriteStringToPoint("Press Row Letter on Keyboard to choose which row to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 9);
                battleShipDisplay.WriteStringToPoint("Press Column number on Keyboard to choose which column to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 8);
                battleShipDisplay.WriteStringToPoint("Where the Row and Column cross on the grid",
                                                        battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 6);
                battleShipDisplay.WriteStringToPoint("is where you are targeting your Dove of death.",
                                                       battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 5);

                battleShipDisplay.WriteStringToPoint($"Battleship fires on you in {currentNumberOfTurns} turns.",
                                                           battleShipDisplay.GetErrorLeft() + 10, battleShipDisplay.GetErrorTop() - 2);


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

                if (Char.IsNumber(actorChar) == true) {
                    if (actorChar >= 49) {
                        userBattleShipGrid.updatePlayerColumn(actorChar - 48);
                    }
                    else {
                        userBattleShipGrid.updatePlayerColumn(10);
                    }

                }
                else if (battleShipInput.GetKeyFromActor() == ConsoleKey.Enter) {
                    userBattleShipGrid.updatePlayerFires(true);
                    wasUserBattleShipGridPlayerFires = true;
                }
                else {
                    // Could use a List to replace this Switch Case
                    switch (actorChar) {
                        case 'Q' or 'q':
                            runGame = false;
                            break;

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

                        case 'R' or 'r':
                            userBattleShipGrid.updatePlayerRow('_');
                            userBattleShipGrid.updateGameOverStatus(true);
                            break;

                        case 'T' or 't':
                            userBattleShipGrid.updatePlayerRow('_');
                            userBattleShipGrid.toggleTesting();
                            break;
                    
                    } // switch

                } // else

                // When Actor presses ENTER
                if (userBattleShipGrid.PlayerFires &&
                        ( previousRow != userBattleShipGrid.getRowIndex() ||
                            previousColumn != userBattleShipGrid.PlayerColumn - 1 ) ) {

                    previousRow = userBattleShipGrid.getRowIndex();
                    previousColumn = userBattleShipGrid.PlayerColumn - 1;

                    userBattleShipGrid.markUserTarget();

                    // If a Hit
                    if (userBattleShipGrid.didUserFireHere(userBattleShipGrid.PlayerColumn - 1, userBattleShipGrid.getRowIndex())
                            == battleShipGrid.isShipLocatedHere(userBattleShipGrid.PlayerColumn - 1, userBattleShipGrid.getRowIndex())) {

                        // On 1st Player fire, the ShipStrikes will be 0 at this point
                        // On 2nd Player fire, the ShipStrikes will be 1 at this point
                        if (userBattleShipGrid.ShipStrikes == 0) {
                            // 5 - 0 + 2 = 7
                            // 5 - 1 + 2 = 6
                            // ..
                            // 5 - 4 + 2 = 3
                            currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 2;
                        } // if

                        // Example 1 - It's a hit and it's ShipStrikes >= 1
                        else {
                            // Example 2 - It was a hit previously but they missed and now hit again
                            // 2 < 1 = 2 turns left and only struck ship once
                            //              5 - 2 = 3
                            //              5 - 1 = 4
                            // 2 < 2 = 2 turns left and struck ship twice
                            // 2 < 3 = 2 turns left and struck ship 3 times
                            if ( currentNumberOfTurns < battleShipGrid.getShipLength() ) {
                                /*
                                 * 
                                 */
                                if (currentNumberOfTurns < battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes) {
                                    currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 0;
                                }
                                else {
                                    currentNumberOfTurns--;
                                }
                            }
                            else {
                                currentNumberOfTurns--;
                            } // else
                        } // else
                    } // if a hit

                    // If not a hit
                    // Example 1 - subtract 1
                    // Example 2 - On any Player fire after they hit the ship and this time they miss then subtract 1
                    else {
                        currentNumberOfTurns--;
                    } // else

                } // If Actor fires

                if (userBattleShipGrid.StartGameOver) {
                    battleShipGrid.startGameOver();
                    userBattleShipGrid.resetUserShipStatus();
                    currentNumberOfTurns = numberOfTurnsMax;
                }

            } // while

        } // Main
    }
}
