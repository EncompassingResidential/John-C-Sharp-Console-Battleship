namespace BattleShip
{
 
    class Program
    {
        static void Main(string[] args)
        {
     
            BattleShipDisplay battleShipDisplay = new BattleShipDisplay();

            // battleShipDisplay.WriteLineToPoint("Calling battleShipDisplay.setGridLocation(15, 21)", 30, 3);
            battleShipDisplay.setGridLocation(15, 21);
            // battleShipDisplay.WriteLineToPoint("Done with battleShipDisplay.setGridLocation(15, 21)", 30, 4);

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

                battleShipDisplay.WriteHeaderLine("1 2 3 4 5 6 7 8 9 10", battleShipDisplay.GetHeaderLeft(), battleShipDisplay.GetHeaderTop());

                // battleShipDisplay.GetGridLeft() 5, battleShipDisplay.GetGridTop() 10
                // y is 10; 10 < 10 + 10; 10++
                // y is 11; 10 < 20; 10++
                for (int y = battleShipDisplay.GetGridTop(); y < 10 + battleShipDisplay.GetGridTop(); y++)
                {
                    // 7 + 8 + 20 = 35 0
                    // 8 + 9 + 20 = 36 1
                    // 9 + 10 + 20 = 37 2
                    // 48 starts 1st row at 0
                    char rowCharacter = Convert.ToChar(y - battleShipDisplay.GetGridTop() + 65);

                    // 3, 10
                    // 3, 11
                    // 3, 12
                    battleShipDisplay.WriteCharToPoint(rowCharacter, battleShipDisplay.GetGridLeft() - 3, y);

                    // 5; 5 < 5 + (10 * 2); 5 += 2
                    // 7; 7 < 5 + (20); 7 += 2
                    // 9; 7 < 25; 9 += 2
                    // 11; 11 < 25; 11 += 2
                    for (int x = battleShipDisplay.GetGridLeft(); x < battleShipDisplay.GetGridLeft() + (10 * 2); x += 2)
                    {
                        battleShipDisplay.WriteCharToPoint('.', x, y);
                    }
                }

                battleShipDisplay.WriteInformationLine($"  You Pressed --> Row {PlayerRow}  --> Column {PlayerColumn}  ");


                // Thread.Sleep(1000);
                battleShipDisplay.ReadCharFromActor();
                actorChar = battleShipDisplay.GetCharFromActor();

                battleShipDisplay.WriteCharToPoint(actorChar, battleShipDisplay.GetGridLeft() + 25, battleShipDisplay.GetGridTop() + 1);

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
                        case 'Q' or 'q':
                            runGame = false;
                            break;

                        case 'A' or 'a':
                            PlayerRow = 'A';
                            break;

                        case 'B' or 'b':
                            PlayerRow = 'B';
                            break;

                        case 'C' or 'c':
                            PlayerRow = 'C';
                            break;

                        case 'D' or 'c':
                            PlayerRow = 'D';
                            break;

                        case 'E' or 'e':
                            PlayerRow = 'E';
                            break;

                        case 'F' or 'f':
                            PlayerRow = 'F';
                            break;

                        case 'G' or 'g':
                            PlayerRow = 'G';
                            break;

                        case 'H' or 'h':
                            PlayerRow = 'H';
                            break;

                        case 'I' or 'i':
                            PlayerRow = 'I';
                            break;

                        case 'J' or 'j':
                            PlayerRow = 'J';
                            break;

                    } // switch

                }


            } // while

        } // Main
    }
}
