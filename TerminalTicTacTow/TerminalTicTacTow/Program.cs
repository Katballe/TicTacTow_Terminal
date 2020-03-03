using System;

namespace TerminalTicTacTow
{
    class TIcTacTow
    {
        public static char[,] array = {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };

        private static int player = 1;
        private static char playerSign = ' ';
        private static int input = 0;

        private static int[] usedNumbers = new int[9];

        private static bool running = true; 
        static void Main(string[] args)
        {
            render();
            while (running)
            {
               
                
                getInput();
                playerTurn(player);
                checkForWin();
                player = player == 2 ? player = 1 : player = 2;

                

                render();
            }
        }

        

        public static void render()
        {
            Console.Clear();
            Console.WriteLine("       |       |        ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", array[0,0], array[0,1], array[0,2]);
            Console.WriteLine("       |       |        "); 
            Console.WriteLine("-------------------------");
            Console.WriteLine("       |       |        ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", array[1,0], array[1,1], array[1,2]);
            Console.WriteLine("       |       |        ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", array[2,0], array[2,1], array[2,2]);
            Console.WriteLine("       |       |       ");
        }

        public static void resetArray()
        {
            int counter = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int n = 0; n < 3; n++)
                {
                    String temp = Convert.ToString(counter);
                    array[i, n] = Convert.ToChar(temp);
                    counter++;
                }
            }
        }
     
        public static void getInput()
        {
            String rawInput;
            bool acceptedInput = false;
            while (!acceptedInput)
            {
                Console.Write("\nPlayer {0}'s turn. Choose your field!  ", player);
                rawInput = Console.ReadLine();
                try
                {
                    if (rawInput == "reset")
                    {
                        resetArray();
                        player = 1;
                        render();

                    }
                    else
                    {
                        input = Convert.ToInt32(rawInput);
                        acceptedInput = true;
                    }

                }
                catch
                {
                    input = -1;
                    Console.WriteLine("Invalid field. Try again");
                }
            }
        }

        
        
        public static bool checkField(int x, int y)
        {
            if(array[x,y] == 'X' || array[x,y] == 'O')
            {
                Console.WriteLine("Field taken");
                Console.ReadKey();
                player = player == 2 ? player = 1 : player = 2;
                return false;
            } else
            return true;
        }

        public static bool checkForWin()
        {
            if ((array[0, 0] == playerSign && array[1, 0] == playerSign && array[2, 0] == playerSign) ||
                (array[0, 1] == playerSign && array[1, 1] == playerSign && array[2, 1] == playerSign) ||
                (array[0, 2] == playerSign && array[1, 2] == playerSign && array[2, 2] == playerSign) ||

                (array[0, 0] == playerSign && array[0, 1] == playerSign && array[0, 2] == playerSign) ||
                (array[1, 0] == playerSign && array[1, 1] == playerSign && array[1, 2] == playerSign) ||
                (array[2, 0] == playerSign && array[2, 1] == playerSign && array[2, 2] == playerSign) ||

                (array[0, 0] == playerSign && array[1, 1] == playerSign && array[2, 2] == playerSign) ||
                (array[2, 0] == playerSign && array[1, 1] == playerSign && array[0, 2] == playerSign) 

                    )
            {
                render();
                Console.WriteLine("PLAYER {0} WINS! ", player);
                Console.ReadKey();
                resetArray();
            }
            return true;
        }




        public static void playerTurn(int player)
        {

            // Console.Write("\nPlayer {0}'s turn. Choose your field!  ", player);

            
          
            
            if(player == 1)
            {
                playerSign = 'X';
            } else if(player == 2) {
                playerSign = 'O';
            }


            switch (input)
            {
                case 1:
                    if (checkField(0, 0))
                    {
                        array[0, 0] = playerSign;
                    }
                    
                    break;
                case 2:
                    if (checkField(0, 1))
                        array[0, 1] = playerSign;
                    break;
                case 3:
                    array[0, 2] = playerSign;
                    break;
                case 4:
                    array[1, 0] = playerSign;
                    break;
                case 5:
                    array[1, 1] = playerSign;
                    break;
                case 6:
                    array[1, 2] = playerSign;
                    break;
                case 7:
                    array[2, 0] = playerSign;
                    break;
                case 8:
                    array[2, 1] = playerSign;
                    break;
                case 9:
                    array[2, 2] = playerSign;
                    break;
                case 0:
                    break;
                default:
                    break;

            }
        }

        public static void resetArr()
        {
            int counter = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int n = 0; n < 3; n++)
                {
                    array[i, n] = (char) counter;
                    Console.WriteLine(i + " " + n + " - " + counter);
                    counter++;
                }
            }

        }

        // Setters and getters

    }
}
