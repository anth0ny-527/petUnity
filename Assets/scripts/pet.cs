using UnityEngine;

public class Pet
{
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Boredom { get; set; }
    public int Tiredness { get; set; }
//gets the values then sets them
    public Pet(string name)
    {
        Name = name;
        Hunger = 0;
        Boredom = 0;
        Tiredness = 0;
    }

    public void Eat()
    {
        Hunger -= 10;
        if (Hunger < 0) Hunger = 0;
    }

    public void Play()
    {
        Boredom -= 10;
        if (Boredom < 0) Boredom = 0;

        Hunger += 3;
    }

    public void Rest()
    {
        Tiredness -= 10;
        if (Tiredness < 0) Tiredness = 0;
Boredom += 2;
    }
}