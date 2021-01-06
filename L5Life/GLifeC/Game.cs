//Nhu Truong
//2020-01-16
//TINFO 200 Game of Life simulation
//Change HIstory 
//Date          Developer       Descroiption
//1/16/2020        Chuck            Game counting life cell

using System;
using System.IO;

namespace GLifeC
{
    public class Game
    {
        private StreamWriter outfile;
        //size the game boards
        public const int ROW_SIZE = 60;
        public const int COL_SIZE = 100;


        //
        public const char DEAD = '-';
        public const char LIVE = 'o';
        //game boards
        private char[,] gameBoard;
        private char[,] tempBoard;


        //ctor should do 2 things
        //1 - create the object - chunnk out storage on the heap for the actual storage
        //2 - innitialize all relevant variables to resaonable defaults


        public Game ()
        {
            gameBoard = new char[ROW_SIZE, COL_SIZE];
            tempBoard = new char[ROW_SIZE, COL_SIZE];

            InitializeBoards();

            //superimpose some start patterns over the initial board
            //step 1 - initializing the gameboard to some start pattern 
            //superimposed over the field 
            //the initial field will be all DEAD
            InsertStartPatterns();
        }

        public void PlayGame()
        {
            outfile = new StreamWriter("OUTPUT.txt");
            //get the number of generations to display from the user
            Console.Write("Enter the number of generation: ");
            int numberOfGenerations = int.Parse(Console.ReadLine());
            for (int generation = 0; generation <= numberOfGenerations; generation++)
            {
                //1-displays the results of the current generation
                DisplayBoard(generation);

                //2- processes the next gen to the results boarf(tempBoard)
                ProcessGameBoard();


                //3-swaps the 2 boards- or makes the ref to 
                char[,] temp = gameBoard;
                gameBoard = tempBoard;
                tempBoard = temp;

            }
            outfile.Close();
        }


        //iterate throught the current gameboard and
        //determine if that cell will live or die ( in the next gen)
        //store the result nack into the results board(tempBoard)
        private void ProcessGameBoard()
        {

            // count the neighbors for a given cell(each cell)
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    //determine if [r,c] will live or die
                    // store the results back into the results board (tempBoard)
                    tempBoard[r, c] = DetermineDeadorAlive(r,c);
                   
                }

            }
        }
        //Determine if a specific cell is dead or alive in the next gen by doing the following
        // count the neighbors to get a total
        //apply the rules
        private char DetermineDeadorAlive(int r, int c)

        {
            // count the neighbors to get a total
            int count = CountNeighbors(r,c);

            //apply the rules
            if (count == 2) return gameBoard[r,c];
            else if (count == 3) return LIVE;
            else
            { 
                return DEAD;
            }
        }

        private int CountNeighbors(int r, int c)
        {//TODO: 

            int count = 0;
            if (r == 0 && c == 0)
            {
                //top left
                //if(gameBoard[r - 1, c - 1] == LIVE) count++;
                //if (gameBoard[r - 1, c] == LIVE) count++;
                //  if (gameBoard[r - 1, c + 1] == LIVE) count++;
                //if (gameBoard[r, c - 1] == LIVE) count++;
                if (gameBoard[r, c + 1] == LIVE) count++;
                // if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
                if (gameBoard[r + 1, c + 1] == LIVE) count++;

            }
            else if (r == 0 && c == COL_SIZE - 1)
            {      //top right
                //if(gameBoard[r - 1, c - 1] == LIVE) count++;
                //if (gameBoard[r - 1, c] == LIVE) count++;
                //if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
                //if (gameBoard[r, c + 1] == LIVE) count++;
                if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
                //if (gameBoard[r + 1, c + 1] == LIVE) count++;
            }
            else if (r == ROW_SIZE -1 && c == 0)
            {//bottom left
                //if(gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
                if (gameBoard[r - 1, c + 1] == LIVE) count++;
                //if (gameBoard[r, c - 1] == LIVE) count++;
                //if (gameBoard[r, c + 1] == LIVE) count++;
                //if (gameBoard[r + 1, c - 1] == LIVE) count++;
               // if (gameBoard[r + 1, c] == LIVE) count++;
                //if (gameBoard[r + 1, c + 1] == LIVE) count++;
            }
            else if (r == ROW_SIZE - 1 && c == COL_SIZE - 1)
            {//bottom right
                if(gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
                //if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
                //if (gameBoard[r, c + 1] == LIVE) count++;
               // if (gameBoard[r + 1, c - 1] == LIVE) count++;
               // if (gameBoard[r + 1, c] == LIVE) count++;
                //if (gameBoard[r + 1, c + 1] == LIVE) count++;
            }
            else if(r == 0)
            {
               // if (gameBoard[r - 1, c - 1] == LIVE) count++;
                //if (gameBoard[r - 1, c] == LIVE) count++;
                //if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
                if (gameBoard[r, c + 1] == LIVE) count++;
                if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
                if (gameBoard[r + 1, c + 1] == LIVE) count++;

            }
            else if(c == 0)
            {
                //if (gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
                if (gameBoard[r - 1, c + 1] == LIVE) count++;
                //if (gameBoard[r, c - 1] == LIVE) count++;
                if (gameBoard[r, c + 1] == LIVE) count++;
                //if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
                if (gameBoard[r + 1, c + 1] == LIVE) count++;

            }
            else if (r == ROW_SIZE - 1)
            {
                if (gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
                if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
                if (gameBoard[r, c + 1] == LIVE) count++;
               // if (gameBoard[r + 1, c - 1] == LIVE) count++;
                //if (gameBoard[r + 1, c] == LIVE) count++;
               // if (gameBoard[r + 1, c + 1] == LIVE) count++;

            }
            else if (c == COL_SIZE -1)
            {
                if (gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
               // if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
               // if (gameBoard[r, c + 1] == LIVE) count++;
                if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
               // if (gameBoard[r + 1, c + 1] == LIVE) count++;
            }

            else
            {
                if (gameBoard[r - 1, c - 1] == LIVE) count++;
                if (gameBoard[r - 1, c] == LIVE) count++;
                if (gameBoard[r - 1, c + 1] == LIVE) count++;
                if (gameBoard[r, c - 1] == LIVE) count++;
                if (gameBoard[r, c + 1] == LIVE) count++;
                if (gameBoard[r + 1, c - 1] == LIVE) count++;
                if (gameBoard[r + 1, c] == LIVE) count++;
                if (gameBoard[r + 1, c + 1] == LIVE) count++;
            }
            return count;
        }

        //main processing loop for the game
        //plays the game by setting a number of generations to display
        //and then looping for each generation
        //each generation 
    

  
        private void InsertStartPatterns()
        {
            InsertStartPatterns1(20, 25);
        }



        //Initializes the game boards to the start state of raw storage
        //Preconditions: not yet
        //Inputs: no args
        //Outputs: void return
        //Postconditions: not yet
        private void InsertStartPatterns1(int r, int c)
        {
            gameBoard[r, c + 1] = LIVE;
            gameBoard[r, c + 2] = LIVE;
            gameBoard[r, c + 3] = LIVE;
            gameBoard[r, c + 4] = LIVE;
            gameBoard[r, c + 5] = LIVE;
            gameBoard[r, c + 6] = LIVE;
            gameBoard[r, c + 7] = LIVE;
            gameBoard[r, c + 8] = LIVE;


            gameBoard[r, c + 10] = LIVE;
            gameBoard[r, c + 11] = LIVE;
            gameBoard[r, c + 12] = LIVE;
            gameBoard[r, c + 13] = LIVE;
            gameBoard[r, c + 14] = LIVE;

            gameBoard[r, c + 18] = LIVE;
            gameBoard[r, c + 19] = LIVE;
            gameBoard[r, c + 20] = LIVE;

            gameBoard[r, c + 27] = LIVE;
            gameBoard[r, c + 28] = LIVE;
            gameBoard[r, c + 29] = LIVE;
            gameBoard[r, c + 30] = LIVE;
            gameBoard[r, c + 31] = LIVE;
            gameBoard[r, c + 32] = LIVE;
            gameBoard[r, c + 33] = LIVE;


            gameBoard[r, c + 35] = LIVE;
            gameBoard[r, c + 36] = LIVE;
            gameBoard[r, c + 37] = LIVE;
            gameBoard[r, c + 38] = LIVE;
            gameBoard[r, c + 39] = LIVE;

        }
        private void InitializeBoards()
        {
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    //init all cells in both boards to the init start status DEAD
                    gameBoard[r, c] = DEAD;
                    tempBoard[r, c] = DEAD;
                }

            }
        }
        public void DisplayBoard(int generation)
        {
            Console.WriteLine($"GENERATION # {generation}");
            outfile.WriteLine ($"GENERATION# {generation}");
            for(int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    //init all cells in both boards to the init start status DEAD
                    Console.Write(gameBoard[r, c]);
                    outfile.Write(gameBoard[r, c]);

                }
                //insert CRLF at the end of every 
                Console.WriteLine();
                outfile.Write();
            }


        }
       
        
    }
}