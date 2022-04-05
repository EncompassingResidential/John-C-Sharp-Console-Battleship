namespace BattleShip
{
 
    class Program
    {
        static void Main(string[] args)
        {
            // This creates class, but setGridLocations 
            BattleShipDisplay battleShipDisplay = new BattleShipDisplay();

            int left = 5;
            int top = 11;

            battleShipDisplay.WriteLineToPoint("Calling battleShipDisplay.setGridLocation(15, 21)", 30, 3);
            battleShipDisplay.setGridLocation(15, 21);
            battleShipDisplay.WriteLineToPoint("Done with battleShipDisplay.setGridLocation(15, 21)", 30, 4);

            battleShipDisplay.WriteStringLine("Battleship has been hidden by CPU!");

            battleShipDisplay.WriteString("Type Your Name In : ");

            battleShipDisplay.ReadLineFromActor();
            var name = battleShipDisplay.GetLineFromActor();

            char PlayerRow = 'z';
            int PlayerColumn = 0;
            bool runGame = true;
            char actorChar = 'y';
            

            BattleShipGrid battleShipGrid = new BattleShipGrid(10, 10);

            string displayString = $"Battleship Start Row {battleShipGrid.BattleShipRowStart}  --> Start Column {battleShipGrid.BattleShipColStart}  ";
            battleShipDisplay.WriteInformationLine(displayString);

            while (runGame)
            {
                var currentDate = DateTime.Now;

                battleShipDisplay.WriteHeaderLine($"Hello, {name}, on {currentDate:d} at {currentDate:t}!", 0, 0);
                battleShipDisplay.WriteHeaderLine("      Battleship        ", 0, 1);
                battleShipDisplay.WriteHeaderLine("........................", 0, 2);
                battleShipDisplay.WriteHeaderLine(".......The Ocean........", 0, 3);
                battleShipDisplay.WriteHeaderLine("........................", 0, 4);

                battleShipDisplay.WriteHeaderLine("Press 'q' or 'Q' to exit the process...", 0, 6);

                Console.SetCursorPosition(left, top - 1);
                Console.Write("1 2 3 4 5 6 7 8 9 10");

                // left 5, top 10
                // y is 10; 10 < 10 + 10; 10++
                // y is 11; 10 < 20; 10++
                for (int y = top; y < 10 + top; y++)
                {
                    // 3, 10
                    // 3, 11
                    // 3, 12
                    Console.SetCursorPosition(left - 3, y);

                    // 7 + 8 + 20 = 35 0
                    // 8 + 9 + 20 = 36 1
                    // 9 + 10 + 20 = 37 2
                    // 48 starts 1st row at 0
                    char rowCharacter = Convert.ToChar(y - top + 65);
                    Console.Write(rowCharacter);

                    // 5; 5 < 5 + (10 * 2); 5 += 2
                    // 7; 7 < 5 + (20); 7 += 2
                    // 9; 7 < 25; 9 += 2
                    // 11; 11 < 25; 11 += 2
                    for (int x = left; x < left + (10 * 2); x += 2)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(".");
                    }
                    // Console.Write(".");
                    // Console.SetCursorPosition(left, top);
                }

                Console.SetCursorPosition(left + 2, top + 15);
                Console.Write("  You Pressed --> Row {0}  --> Column {1}  ", PlayerRow, PlayerColumn);


                // Thread.Sleep(1000);
                battleShipDisplay.ReadCharFromActor();
                actorChar = battleShipDisplay.GetCharFromActor();

                battleShipDisplay.WriteCharToPoint(actorChar, left + 25, top + 1);

                if (Char.IsNumber(actorChar) == true) {
                    if (actorChar >= 49) {
                        PlayerColumn = actorChar - 48;
                    }
                    else {
                        PlayerColumn = 10;
                    }
                }
                else {
                    switch (actorChar) {
                        case 'Q':
                            runGame = false;
                            break;

                        case 'A':
                            PlayerRow = 'A';
                            break;

                        case 'B':
                            PlayerRow = 'B';
                            break;

                        case 'C':
                            PlayerRow = 'C';
                            break;

                        case 'D':
                            PlayerRow = 'D';
                            break;

                        case 'E':
                            PlayerRow = 'E';
                            break;

                        case 'F':
                            PlayerRow = 'F';
                            break;

                        case 'G':
                            PlayerRow = 'G';
                            break;

                        case 'H':
                            PlayerRow = 'H';
                            break;

                        case 'I':
                            PlayerRow = 'I';
                            break;

                        case 'J':
                            PlayerRow = 'J';
                            break;

                    } // switch

                }


            } // while

        } // Main
    }
}
