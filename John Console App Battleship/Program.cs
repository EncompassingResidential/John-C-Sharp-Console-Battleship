﻿namespace BattleShip
{
 
    class Program
    {
        static void Main(string[] args)
        {
            BattleShipDisplay battleShipDisplay = new BattleShipDisplay();

            int left = 5;
            int top = 11;


            // See https://aka.ms/new-console-template for more information
            battleShipDisplay.WriteStringLine("Battleship has been hidden by CPU!");

            battleShipDisplay.WriteString("Type your name in: ");

            battleShipDisplay.ReadLineFromActor();
            var name = battleShipDisplay.GetLineFromActor();

            /*
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
            */

            char PlayerRow = 'z';
            int PlayerColumn = 0;
            bool runGame = true;
            char actorChar = 'y';


            BattleShipGrid battleShipGrid = new BattleShipGrid(10, 10);
            Console.SetCursorPosition(left + 3, top + 17);
            Console.Write("  Battleship Start Row {0}  --> Start Column {1}  ", battleShipGrid.BattleShipRowStart, battleShipGrid.BattleShipColStart);

            // here it asks to press "E" to exit
            // and the key "E" is not shown in
            // the console output window
            while (runGame)
            {
                var currentDate = DateTime.Now;

                Console.SetCursorPosition(1, 1);

                Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
                Console.WriteLine("      Battleship        ");
                Console.WriteLine("........................");
                Console.WriteLine(".......The Ocean........");
                Console.WriteLine("........................");

                Console.WriteLine("\nPress 'q' or 'Q' to exit the process...");

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