namespace Quest;
// An instance of the Adventurer class is an object that will undergo some challenges
public class Adventurer
{
    // This is an "immutable" property. It only has a "get".
    // The only place the Name can be set is in the Adventurer constructor
    // Note: the constructor is defined below.
    public string Name { get; }

    // This is a mutable property it has a "get" and a "set"
    //  So it can be read and changed by any code in the application
    public int Awesomeness { get; set; }

    // Add a new immutable property to the Adventurer class called ColorfulRobe. The type of this property should be Robe.
    public Robe ColorfulRobe { get; }

    // Add a Hat property and constructor parameter to the Adventurer class.
    public Hat Hat { get; }

    public int Successes { get; set; }

    // A constructor to make a new Adventurer object with a given name
    // Add a new constructor parameter to the Adventurer class to accept a Robe and to set the ColorfulRobe property.
    public Adventurer(string name, Robe robe, Hat hat)
    {
        Name = name;
        Awesomeness = 50;
        ColorfulRobe = robe;
        Hat = hat;
        Successes = 0;
    }


    // This method returns a string that describes the Adventurer's status
    // Note one way to describe what this method does is:
    //   it transforms the Awesomeness integer into a status string
    public string GetAdventurerStatus()
    {
        string status = "okay";
        if (Awesomeness >= 75)
        {
            status = "great";
        }
        else if (Awesomeness < 25 && Awesomeness >= 10)
        {
            status = "not so good";
        }
        else if (Awesomeness < 10 && Awesomeness > 0)
        {
            status = "barely hanging on";
        }
        else if (Awesomeness <= 0)
        {
            status = "not gonna make it";
        }

        return $"Adventurer, {Name}, is {status}";
    }

    // Add a new method to the Adventurer class called GetDescription. This method should return a string that contains the adventurer's name and a description of their robe.
    // Update the Adventurer's GetDescription method to include the description of the hat.
    public string GetDescription()
    {
        string response = $"The adventurer, {Name}, wears a {Hat.ShininessDescription} hat and a robe of {ColorfulRobe.Length} inches in length with the colors of";

        var colors = String.Join(", ", ColorfulRobe.Colors.Take(ColorfulRobe.Colors.Count - 1));
        var lastColor = ColorfulRobe.Colors[ColorfulRobe.Colors.Count - 1];

        return $"{response} {colors} and {lastColor}.";
    }
}