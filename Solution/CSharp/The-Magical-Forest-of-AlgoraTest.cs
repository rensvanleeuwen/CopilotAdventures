using System;
using System.Collections.Generic;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void TestForestStateAfterDance()
    {
        // Arrange
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

        var expectedStates = new List<string>
        {
            "The forest is filled with a magical aura.",
            "The forest is filled with a magical aura.",
            "A rainbow appears in the sky.",
            "Fireflies light up the forest.",
            "Gentle rain starts falling."
        };

        var expectedFinalState = "The forest is filled with a magical aura.";

        var consoleOutput = new List<string>();

        // Redirect Console.WriteLine to capture the output
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);

            // Act
            Program.Main(null);

            // Read the captured output
            var output = writer.ToString();
            consoleOutput = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        // Assert
        Assert.Equal(expectedStates.Count, consoleOutput.Count);

        for (int i = 0; i < expectedStates.Count; i++)
        {
            Assert.Contains(expectedStates[i], consoleOutput[i]);
        }

        Assert.Contains(expectedFinalState, consoleOutput[consoleOutput.Count - 1]);
    }
}