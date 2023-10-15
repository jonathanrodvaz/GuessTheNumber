string? player;
Random random = new Random();
int attempts = 0;
int highestScoreAttempts = 0;


Console.WriteLine("Guess The Number");

StartGame();

void StartGame()
{
    

    Console.WriteLine("Hello! Welcome to the game...");
    Console.WriteLine("What is your name?");


   
    var randomNumber = random.Next(1, 10);

    player = Console.ReadLine();
    WantToPlay(randomNumber);
}

void WantToPlay(int randomNumber, bool playAgain = false)
{
    if(!playAgain)
    Console.WriteLine($"Hi {player}, are you ready to play? (Enter Y/N)");
    else
        Console.WriteLine($"{player}, are you ready to play again? (Enter Y/N)");

    var wantToPlay = Console.ReadLine();

    //Ademas de pasar el input del usuario a lowerCase, también con Trim nos encargaremos de quitar cualquier espacio que ponga por delante o por detras de la respuesta en caso de que esto se diera.
switch (wantToPlay?.ToLower().Trim())
{
    case "y":
        Play(randomNumber);
        break;

    case "no":
        DontPlay();
        break;
    default:
        Console.WriteLine("That is not a valid option, please enter Y or N");
        WantToPlay(randomNumber);
        break;
}
}


void Play(int randomNumber) {
    

    try
    {
        Console.WriteLine("Pick a number between 1 and 10");
        var pickedNumber = Console.ReadLine();

        if (pickedNumber is null)
            throw new Exception("You need to a value!");

        if (int.Parse(pickedNumber) < 1 || int.Parse(pickedNumber) > 10)
            throw new Exception("Please pick a number between 1 and 10");

        if(int.Parse(pickedNumber) == randomNumber)
        {
            YouGuessed();
            
            
        }
        else if(int.Parse(pickedNumber) < randomNumber ) {

            Console.WriteLine("Try again! The number is higher");
            attempts++;
            Play(randomNumber);
        }
        else if(int.Parse(pickedNumber) > randomNumber)
                {
            Console.WriteLine("Try again! The number is lower");
            attempts++;
            Play(randomNumber);
        }

    }
    catch (Exception e)
    {
        Console.WriteLine($"An error has occurred: {e.Message}");
        Play(randomNumber);
        
    }
}

void DontPlay() {
    Console.WriteLine("No worries! Have a good day!");
}

void YouGuessed() {
    Console.WriteLine("Nice! You guessed the number!");
    attempts++;

    if (highestScoreAttempts == 0 || attempts < highestScoreAttempts)
        highestScoreAttempts = attempts;

    Console.WriteLine($"It took you this many attempts to guess the number: {attempts} attempts");
    ShowScore();
    //Despues de mostrar score, y para asegurarnos de que en el proximo juego no se empiece con los attempts acumulados, reseteamos attempts a 0
    attempts = 0;
    var randomNumber = random.Next(1, 10);
    WantToPlay(randomNumber, true);

}

void ShowScore()
{
    if (highestScoreAttempts == 0)
        Console.WriteLine("There is currently no high score, it's your for the taking!");
    else
        Console.WriteLine($"The current high score is {highestScoreAttempts} attempts!");
}