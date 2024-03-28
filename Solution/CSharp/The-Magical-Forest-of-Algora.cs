using System;
using System.Collections.Generic;

enum DanceMove
{
    Twirl,
    Leap,
    Spin
}

class Creature
{
    public string Name { get; set; }
    public List<DanceMove> DanceMoves { get; set; }
}

class Program
{
    /// <summary>
    /// The entry point of the program that
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    static void Main(string[] args)
    {
        var lox = new Creature
        {
            Name = "Lox",
            DanceMoves = new List<DanceMove> { DanceMove.Twirl, DanceMove.Leap, DanceMove.Spin, DanceMove.Twirl, DanceMove.Leap }
        };

        var drako = new Creature
        {
            Name = "Drako",
            DanceMoves = new List<DanceMove> { DanceMove.Spin, DanceMove.Twirl, DanceMove.Leap, DanceMove.Leap, DanceMove.Spin }
        };

        var forestState = "The forest is calm and peaceful.";

        for (int i = 0; i < 5; i++)
        {
            var loxMove = lox.DanceMoves[i];
            var drakoMove = drako.DanceMoves[i];

            switch (loxMove)
            {
                case DanceMove.Twirl when drakoMove == DanceMove.Twirl:
                    forestState = "Fireflies light up the forest.";
                    break;
                case DanceMove.Leap when drakoMove == DanceMove.Spin || loxMove == DanceMove.Spin && drakoMove == DanceMove.Leap:
                    forestState = "Gentle rain starts falling.";
                    break;
                case DanceMove.Spin when drakoMove == DanceMove.Leap || loxMove == DanceMove.Leap && drakoMove == DanceMove.Spin:
                    forestState = "A rainbow appears in the sky.";
                    break;
                default:
                    forestState = "The forest is filled with a magical aura.";
                    break;
            }

            Console.WriteLine($"After sequence {i + 1}, {forestState}");
        }

        Console.WriteLine($"Final state of the forest after the dance is complete: {forestState}");
    }
}