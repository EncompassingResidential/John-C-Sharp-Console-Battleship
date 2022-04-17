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
                int curNumOfTurnsBeginingOfForLoop = currentNumberOfTurns;

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
                        if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getMissChar() 
                            && battleShipGrid.isShipLocatedHere(column, row)) {

                            battleShipDisplay.WriteCharToGrid('X', column, row);
                            userBattleShipGrid.updateNumberOfHits(++numberOfStrikes);
                            userBattleShipGrid.updatePlayerFires(false);
                            
                        }
                        else if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getMissChar()) {
                            battleShipDisplay.WriteCharToGrid(userBattleShipGrid.getMissChar(), column, row);
                            userBattleShipGrid.updatePlayerFires(false);
                        }
                        else {
                            battleShipDisplay.WriteCharToGrid('.', column, row);
                        }

                        /* TESTING */
                        if (battleShipGrid.isShipLocatedHere(column, row)) {
                            battleShipDisplay.WriteCharToPoint('B', battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                        }
                        else {
                            battleShipDisplay.WriteCharToPoint('_', battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                        } /* */

                    }  // for column
                }  // for row

                if (userBattleShipGrid.ShipStrikes > 0) {
                    battleShipDisplay.WriteStringToPoint($"You hit ship {userBattleShipGrid.ShipStrikes} times!", battleShipDisplay.GetErrorLeft() + 10, battleShipDisplay.GetErrorTop() + 5);

                    battleShipDisplay.WriteStringToPoint($"currentNumberOfTurns {currentNumberOfTurns}  out of {numberOfTurnsMax} turns.",
                                           battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop());

                    currentNumberOfTurns = battleShipGrid.getShipLength() - userBattleShipGrid.ShipStrikes + 2;
                }


                if (userBattleShipGrid.ShipStrikes > 4) {
                    battleShipDisplay.ReverseColors();
                    Task.Delay(200);
                    battleShipDisplay.WriteStringToPoint($"You sunk the Battleship!", battleShipDisplay.GetErrorLeft() + 10, battleShipDisplay.GetErrorTop() + 5);
                    battleShipDisplay.ForeColors();
                    Task.Delay(200);
                    battleShipDisplay.ReverseColors();
                }

                battleShipDisplay.WriteStringToPoint("Press Row Letter on Keyboard to choose which row to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 9);
                battleShipDisplay.WriteStringToPoint("Press Column number on Keyboard to choose which column to target",
                                                        battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() - 8);
                battleShipDisplay.WriteStringToPoint("Where the Row and Column cross on the grid",
                                                        battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 6);
                battleShipDisplay.WriteStringToPoint("is where you are targeting your Dove of Love.",
                                                       battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 5);

                battleShipDisplay.WriteStringToPoint($"Battleship fires on you in {currentNumberOfTurns} turns.",
                                                           battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop() - 2);


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
                    battleShipDisplay.WriteStringToPoint($"  if IsNumber then userBattleShipGrid.updatePlayerColumn with {userBattleShipGrid.PlayerColumn}", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 5);

                }
                else if (battleShipInput.GetKeyFromActor() == ConsoleKey.Enter) {
                    userBattleShipGrid.updatePlayerFires(true);

                    battleShipDisplay.WriteStringToPoint("   else if battleShipInput.GetKeyFromActor() == ConsoleKey.Enter", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 5);
                    // battleShipDisplay.WriteStringToPoint($"", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 6);
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

                    } // switch

                    battleShipDisplay.WriteStringToPoint($"    else userBattleShipGrid.updatePlayerRow with {userBattleShipGrid.PlayerRow}", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 5);

                } // else

                if (userBattleShipGrid.PlayerFires) {
                    userBattleShipGrid.markUserTarget();
                    // battleShipDisplay.WriteStringToPoint($"    userBattleShipGrid.PlayerFires with {userBattleShipGrid.PlayerRow}", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 6);
                    currentNumberOfTurns--;
                }

                battleShipDisplay.WriteStringToPoint($"End of while loop currentNumberOfTurns {currentNumberOfTurns}  out of {numberOfTurnsMax} turns.",
                       battleShipDisplay.GetErrorLeft() + 4, battleShipDisplay.GetErrorTop());

            } // while

        } // Main
    }
}
