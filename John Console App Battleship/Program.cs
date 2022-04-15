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

            // battleShipDisplay.WriteStringToPoint("Calling battleShipDisplay.setGridLocation(15, 21)", 30, 3);
            
            battleShipDisplay.setGridLocation(battleShipDisplay.GetHeaderLeft(), battleShipDisplay.GetHeaderTop() + 11);

            // battleShipDisplay.WriteStringToPoint("Done with battleShipDisplay.setGridLocation(15, 21)", 30, 4);

            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine("The Battleship has been hidden behind an invisible cloak by Master CPU!");
            battleShipDisplay.WriteStringLine(" ");
            battleShipDisplay.WriteStringLine("     You must find it and sink it...");
            battleShipDisplay.WriteStringLine(" ");

            battleShipDisplay.WriteString("Type Your Name In : ");

            battleShipInput.ReadLineFromActor();

            var name = battleShipInput.GetLineFromActor();

            battleShipDisplay.ResetScreen();

            bool runGame = true;
            char actorChar = 'y';
            
            string displayString = $"Battleship Start Row {battleShipGrid.getBattleShipRowStart}  --> Start Column {battleShipGrid.getBattleShipColStart}  ";
            battleShipDisplay.WriteInformationLine(displayString);

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

                battleShipDisplay.WriteHeaderLine("Press 'q' or 'Q' to exit the process...", 0, 7);

                battleShipDisplay.WriteStringToPoint("1 2 3 4 5 6 7 8 9 10", battleShipDisplay.GetGridLeft(), battleShipDisplay.GetGridTop() - 2);

                // battleShipDisplay.GetGridLeft() 5, battleShipDisplay.GetGridTop() 10
                // y is 10; 10 < 10 + 10; 10++
                // y is 11; 10 < 20; 10++
                for (int row = 0; row < battleShipGrid.getNumberRows(); row++) {
                    // 7 + 8 + 20 = 35 0
                    // 8 + 9 + 20 = 36 1
                    // 9 + 10 + 20 = 37 2
                    // 48 starts 1st row at 0
                    char rowCharacter = Convert.ToChar(battleShipDisplay.GetGridTop() + 52 + row);

                    // 3, 10
                    // 3, 11
                    // 3, 12
                    battleShipDisplay.WriteCharToGridPoint(rowCharacter, -3, row);

                    // 5; 5 < 5 + (10 * 2); 5 += 2
                    // 7; 7 < 5 + (20); 7 += 2
                    // 9; 7 < 25; 9 += 2
                    // 11; 11 < 25; 11 += 2
                    for (int column = 0; column < battleShipGrid.getNumberColumns(); column++ ) {
                        if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getMissChar() && battleShipGrid.isShipLocatedHere(column, row)) {
                            battleShipDisplay.WriteCharToGrid('X', column, row);
                            userBattleShipGrid.updatePlayerFires(false);
                        }
                        else if (userBattleShipGrid.getTargetLocation(column, row) == userBattleShipGrid.getMissChar()) {
                            battleShipDisplay.WriteCharToGrid(userBattleShipGrid.getMissChar(), column, row);
                            userBattleShipGrid.updatePlayerFires(false);
                        }
                        else {
                            battleShipDisplay.WriteCharToGrid('.', column, row);
                        }

                        // TESTING
                        if (battleShipGrid.isShipLocatedHere(column, row)) {
                            battleShipDisplay.WriteCharToPoint('B', battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                        }
                        else {
                            battleShipDisplay.WriteCharToPoint('_', battleShipDisplay.GetErrorLeft() + (column * 2) + 10, battleShipDisplay.GetErrorTop() + row);
                        }

                    }  // for column
                }  // for row

                battleShipDisplay.WriteStringToPoint($"  You Pressed --> Row    {userBattleShipGrid.PlayerRow}",
                                                        battleShipDisplay.GetInformationLeft(), battleShipDisplay.GetInformationTop() - 2 );
                battleShipDisplay.WriteStringToPoint($"              --> Column {userBattleShipGrid.PlayerColumn}",
                                                        battleShipDisplay.GetInformationLeft(), battleShipDisplay.GetInformationTop() - 1);
                battleShipDisplay.WriteStringToPoint("  ", battleShipDisplay.GetInformationLeft() + 1, battleShipDisplay.GetInformationTop() + 1);
                battleShipDisplay.WriteStringToPoint("          Press the Enter / Return key to fire a shot at the MCU's Battleship.", battleShipDisplay.GetInformationLeft() - 5, battleShipDisplay.GetInformationTop() + 1);

                battleShipDisplay.WriteStringToPoint("Press Row Letter on Keyboard to choose which row to target", 
                                                        battleShipDisplay.GetErrorLeft() + 24, battleShipDisplay.GetErrorTop() - 8);
                battleShipDisplay.WriteStringToPoint("Press Column number on Keyboard to choose which column to target",
                                                        battleShipDisplay.GetErrorLeft() + 24, battleShipDisplay.GetErrorTop() - 7);
                battleShipDisplay.WriteStringToPoint("Where the Row and Column cross on the grid", 
                                                        battleShipDisplay.GetErrorLeft() + 30, battleShipDisplay.GetErrorTop() - 5);
                battleShipDisplay.WriteStringToPoint("is where you are targeting your Dove of Love.",
                                                        battleShipDisplay.GetErrorLeft() + 30, battleShipDisplay.GetErrorTop() - 4);

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
                    battleShipDisplay.WriteStringToPoint($"    userBattleShipGrid.PlayerFires with {userBattleShipGrid.PlayerRow}", battleShipDisplay.GetErrorLeft(), battleShipDisplay.GetErrorTop() + 6);
                }


            } // while

        } // Main
    }
}
