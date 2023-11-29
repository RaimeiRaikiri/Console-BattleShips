//Introduce the game
void Introduction()
{
    Console.WriteLine("Welcome to battleships console edition!");
    Console.WriteLine("This game requires two players,");
    Console.WriteLine("each player can pick the position of a battleship with a length of 3 spaces.");
    Console.WriteLine("Then you take it in turns trying to locate where the other player has put their ship,");
    Console.WriteLine("one space at a time!");
}
//Create 10x10 grid
void PrintInitialBoard()
{
    int[,] board = new int[11, 11];
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 11; j++)
        {
            if(i == 0 && j == 0)
            {
                Console.Write(" " + "\t");
            }
            else if (i == 0 && j > 0)
            {
                Console.Write( j + "\t");
            } 
            else if (j == 0 && i > 0)
            {
                Console.Write(i + "\t");
            }
            else
            {
                Console.Write(board[i, j] + "\t");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}
//Create 2 1 for each player
void ExplainCoordinates()
{
    Console.WriteLine();
    Console.WriteLine("Choose 3 sets of coordinates from the board");
    Console.WriteLine("starting with it's X coordinate 1-10 (horizonatl)");
    Console.WriteLine("then it's Y coordinate 1-10 (vertical)");
}
int[,] playerOneShipCoordinates = new int[3, 2];
int whoseTurnCounter = 1;
void PlayerShipCoordinates(int whoseTurnCounter)
{
    int whichPlayer = 0;
    int howManyCoordinatesCounter = 1;
    if (whoseTurnCounter % 2 == 0)
    {
        whichPlayer = 2;
    }
    else
    {
        whichPlayer = 1;
    }
    Console.WriteLine();
    Console.WriteLine($"Player {whichPlayer} choose X coordinate {howManyCoordinatesCounter}");
    int xCoordinate = GetCoordinateInput();
    CheckCorrectCoordinates(xCoordinate);
    LoopCoordinatesUntilCorrect(xCoordinate);
    playerOneShipCoordinates[howManyCoordinatesCounter, 1] = xCoordinate;
    Console.WriteLine();
}
int GetCoordinateInput()
{
    string? usersChoice = Console.ReadLine();
    if (int.TryParse(usersChoice, out int number))
    {
        return number;
    }
    else
    {
        Console.WriteLine("You have not entered an integer");
        return 11;
    }
}

bool CheckCorrectCoordinates(int coordinate)
{
    if (coordinate < 11 && coordinate > 0)
    {
        return true;
    }
    else
    {
        return false;
    }

}
void LoopCoordinatesUntilCorrect(int coordinate)
{
    // Constraints being checked
    bool inputBetween1and10 = CheckCorrectCoordinates(coordinate);
    if (inputBetween1and10 == false)
    {
        while (inputBetween1and10 == false)
        {
            Console.WriteLine("Your input was not from 1-10, try again.");
            coordinate = GetCoordinateInput();
            inputBetween1and10 = CheckCorrectCoordinates(coordinate);
            if (inputBetween1and10 == true)
            {
                break;
            }
            else
            {
                continue;
            }

        }
    }

}
Introduction();
PrintInitialBoard();
PlayerShipCoordinates(whoseTurnCounter);

//Create method for initialising a battle ship with a length of 3 for each player

//Method for selecting position
//method for comparing selected positiion and the position wiht ship