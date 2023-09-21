using Quest;

// Update the code to prompt the user for their name and pass that name to the Adventurer constructor when creating the new Adventurer object.
Console.WriteLine("What is thine name, adventurer?");
string response = Console.ReadLine();
while (string.IsNullOrWhiteSpace(response))
{
    Console.WriteLine("Enter thine own name...");
    response = Console.ReadLine();
}

// In Program.cs create a new instance of the Robe class and set its properties.
Robe robe = new Robe
{
    Length = 40,
    Colors = new List<string>
    {
        "green",
        "purple",
        "blue",
        "red"
    }
};
// Update the Program.cs file to create a Hat and pass it to the Adventurer's constructor.
Hat hat = new Hat
{
    ShininessLevel = 10
};
// In Program.cs create an instance of the Prize.
Prize prize = new("Rubber Ducky!");
// Make a new "Adventurer" object using the "Adventurer" class
// Pass the new Robe into the constructor of the Adventurer.
// Update the Program.cs file to create a Hat and pass it to the Adventurer's constructor.
Adventurer theAdventurer = new Adventurer(response, robe, hat);
// Before the adventurer starts their challenge, call the GetDescription method and print the results to the console.
Console.WriteLine(theAdventurer.GetDescription());

bool gaming = true;

while (gaming)
{
    // Create a few challenges for our Adventurer's quest
    // The "Challenge" Constructor takes three arguments
    //   the text of the challenge
    //   a correct answer
    //   a number of awesome points to gain or lose depending on the success of the challenge
    Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
    Challenge theAnswer = new Challenge(
        "What's the answer to life, the universe and everything?", 42, 25);
    Challenge whatSecond = new Challenge(
        "What is the current second?", DateTime.Now.Second, 50);

    int randomNumber = new Random().Next() % 10;
    Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

    Challenge favoriteBeatle = new Challenge(
        @"Who's your favorite Beatle?
1) John
2) Paul
3) George
4) Ringo
",
        4, 20
    );

    // Let's make the challenges a little more interesting. Add 2 to 5 more challenges to the program and then add code to randomly select 5 challenges for our adventurer to face. If the user chooses to repeat the quest another random selection of challenges should happen.
    Challenge favoriteColor = new Challenge(
                        @"What's Courtney's favorite color?
                1) Red
                2) Green
                3) Blue
                4) Purple
                ",
                        4, 25
                    );
    Challenge phobia = new Challenge(
        @"What is cynophobia?
                1) Fear of sin
                2) Fear of blue
                3) Fear of dogs
                4) Fear of clothes
                ",
        3, 25
    );
    Challenge languages = new Challenge("How many languages are written from right to left?", 12, 50);
    Challenge factOrCrap1 = new Challenge(
        @"Twins can have different fathers.
                1) Fact
                2) Crap
                ",
        1, 10
    );
    Challenge factOrCrap2 = new Challenge(
        @"A cup of tea has more caffeine than a cup of coffee.
                1) Fact
                2) Crap
                ",
        2, 10
    );



    // "Awesomeness" is like our Adventurer's current "score"
    // A higher Awesomeness is better

    // Here we set some reasonable min and max values.
    //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
    //  If an Adventurer has an Awesomeness less than the min, they are terrible
    int minAwesomeness = 0;
    int maxAwesomeness = 100;



    // A list of challenges for the Adventurer to complete
    // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
    List<Challenge> challenges = new List<Challenge>()
{
    twoPlusTwo,
    theAnswer,
    whatSecond,
    guessRandom,
    favoriteBeatle,
    favoriteColor,
    phobia,
    languages,
    factOrCrap1,
    factOrCrap2
};
    List<Challenge> selectedChallenges = new List<Challenge>();

    // Loop through all the challenges and subject the Adventurer to them
    // foreach (Challenge challenge in challenges)
    // {
    //     challenge.RunChallenge(theAdventurer);
    // }
    for (int i = 0; i < 5; i++)
    {
        int randomIndex = new Random().Next(challenges.Count);
        selectedChallenges.Add(challenges[randomIndex]);
        challenges.Remove(challenges[randomIndex]);
    }
    foreach (Challenge challenge in selectedChallenges)
    {
        challenge.RunChallenge(theAdventurer);
    }

    //At the end of the quest (before you ask if the user wants to repeat the quest) call the ShowPrize method.
    prize.ShowPrize(theAdventurer);

    // This code examines how Awesome the Adventurer is after completing the challenges
    // And praises or humiliates them accordingly
    if (theAdventurer.Awesomeness >= maxAwesomeness)
    {
        Console.WriteLine("YOU DID IT! You are truly awesome!");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");

    }
    else if (theAdventurer.Awesomeness <= minAwesomeness)
    {
        Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");

    }
    else
    {
        Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
        Console.WriteLine($"You had {theAdventurer.Successes} successes.");

    }
    // PHASE 3 Play again?
    string newGame = "";
    while (newGame == "")
    {
        Console.WriteLine("Shall we adventure still? Y/N");
        string newGameResponse = Console.ReadLine().ToUpper();
        switch (newGameResponse)
        {
            case "Y":
                theAdventurer.Awesomeness = 50 + (10 * theAdventurer.Successes);
                theAdventurer.Successes = 0;
                newGame = "YES";
                break;
            case "N":
                newGame = "NO";
                gaming = false;
                break;
            default:
                Console.WriteLine("Answer with only 'Y' or 'N'");
                break;
        }
    }
}