using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10362208_Prog6221_Part2.ed
{
    internal class AddMore
    {
        public static void DisplayAllRecipeInformation(
     int recipeIndex,
     List<string> names,
     List<List<string>> instructions,
     List<int> steps,
     List<List<string>> ingredients,
     List<List<float>> units,
     List<List<int>> ingredientCalories,
     List<List<string>> ingredientFoodGroups,
     List<int> totalCalories,
     List<string> recipeFoodGroups,
     CaptureRecipe captureRecipe)
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();

                Console.WriteLine("Display Recipes");

                // Sort names list alphabetically and track original indices
                var sortedNameIndices = names
                    .Select((name, index) => new { name, index })//(see C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 1). 2022).
                    .OrderBy(item => item.name)
                    .ToList();

                // Display sorted names with original index
                for (int i = 0; i < sortedNameIndices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {sortedNameIndices[i].name}");
                }

                Console.Write("Enter the number of the recipe you want to view: ");
                int displayIndex;
                while (!int.TryParse(Console.ReadLine(), out displayIndex) || displayIndex < 1 || displayIndex > sortedNameIndices.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                    Console.Write("Enter the number of the recipe you want to view: ");
                }

                displayIndex--; // Adjust index to match the list index

                // Get the original index of the selected recipe
                recipeIndex = sortedNameIndices[displayIndex].index; // Update recipeIndex

                // Validate recipe index against the count of recipe names
                if (recipeIndex >= 0 && recipeIndex < names.Count)
                {
                    // Access recipe details based on the validated index
                    Console.WriteLine($"Recipe: {names[recipeIndex]}");
                    Console.WriteLine($"Steps: {steps[recipeIndex]}");

                    // Print instructions
                    Console.WriteLine("Instructions:");
                    if (recipeIndex < instructions.Count)
                    {
                        foreach (var instruction in instructions[recipeIndex])
                        {
                            Console.WriteLine(instruction);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No instructions available.");
                    }

                    // Print ingredients
                    Console.WriteLine("Ingredients:");
                    if (recipeIndex < ingredients.Count)
                    {
                        for (int i = 0; i < ingredients[recipeIndex].Count; i++)
                        {
                            Console.WriteLine($"{ingredients[recipeIndex][i]}: {units[recipeIndex][i]} units, {ingredientCalories[recipeIndex][i]} calories, {ingredientFoodGroups[recipeIndex][i]} food group");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ingredients available.");
                    }

                    if (recipeIndex < recipeFoodGroups.Count)
                    {
                        Console.WriteLine($"Recipe Food Group: {recipeFoodGroups[recipeIndex]}");
                    }
                    else
                    {
                        Console.WriteLine("No recipe food group available.");
                    }

                    if (recipeIndex < totalCalories.Count)
                    {
                        Console.WriteLine($"Total calories: {totalCalories[recipeIndex]}");
                    }
                    else
                    {
                        Console.WriteLine("No total calories available.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid recipe index.");
                    continue; // Skip the rest of the loop iteration
                }
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Do you want to perform any action?"); // ask user to enter another choice
                Console.WriteLine("1. Add Volume");
                Console.WriteLine("2. Add Ingredients");
                Console.WriteLine("3. Edit Recipe");
                Console.ResetColor();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                PerformAction(choice, captureRecipe, recipeIndex, ingredients, units, ingredientCalories, ingredientFoodGroups, names, steps, instructions, totalCalories);

                Console.WriteLine("Press 'Q' to quit or any other key to continue...");
                input = Console.ReadLine();
            } while (input.ToLower() != "q");
        }


        public static void PerformAction(string choice, CaptureRecipe captureRecipe, int recipeIndex,
            List<List<string>> ingredients, List<List<float>> units, List<List<int>> ingredientCalories, List<List<string>> ingredientFoodGroups,
            List<string> names, List<int> steps, List<List<string>> instructions, List<int> totalCalories)
        {
            switch (choice)
            {
                case "1":
                    AddVolume(captureRecipe, recipeIndex, units, ingredientCalories, ingredients, names, ingredientFoodGroups, steps, instructions, totalCalories);
                    break;
                case "2":
                    AddIngredients(captureRecipe, recipeIndex, ingredients, units, ingredientCalories, ingredientFoodGroups);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void AddIngredients(CaptureRecipe captureRecipe, int recipeIndex,
            List<List<string>> ingredients, List<List<float>> units, List<List<int>> ingredientCalories, List<List<string>> ingredientFoodGroups)
        {
            captureRecipe.AddToRecipe(
                ingredients[recipeIndex],
                units[recipeIndex],
                ingredientCalories[recipeIndex],
                ingredientFoodGroups[recipeIndex]
            );

            // Display the updated recipe details
            DisplayAllRecipeInformation(
                recipeIndex,
                captureRecipe.Names,
                captureRecipe.Instructions,
                captureRecipe.Steps,
                captureRecipe.Ingredients,
                captureRecipe.Units,
                captureRecipe.IngredientCalories,
                captureRecipe.IngredientFoodGroups,
                captureRecipe.TotalCalories,
                captureRecipe.RecipeFoodGroups,
                captureRecipe
            );
            Console.Clear();
        }

        public static int CalculateTotalCalories(List<float> units, List<int> ingredientCalories)//caculate calories
        {
            int totalCalories = 0;
            for (int i = 0; i < units.Count; i++)
            {
                totalCalories += (int)(units[i] * ingredientCalories[i]);
            }
            return totalCalories;
        }

        public static void AddVolume(CaptureRecipe captureRecipe, int recipeIndex, // add voulue 
            List<List<float>> units, List<List<int>> ingredientCalories, List<List<string>> ingredients,
            List<string> names, List<List<string>> ingredientFoodGroups, List<int> steps, List<List<string>> instructions, List<int> totalCalories)
        {
            Console.Write("Enter the volume factor: ");
            if (float.TryParse(Console.ReadLine(), out float volumeFactor))
            {
                IncreaseVolume(captureRecipe, recipeIndex, units, ingredientCalories, volumeFactor);

                // After adding volume, display the updated recipe details
                Console.WriteLine($"Updated Recipe: {names[recipeIndex]}");
                Console.WriteLine($"Ingredients after volume increase:");
                for (int i = 0; i < ingredients[recipeIndex].Count; i++)
                {
                    Console.WriteLine($"{ingredients[recipeIndex][i]}: {units[recipeIndex][i]} units, {ingredientCalories[recipeIndex][i]} calories, {ingredientFoodGroups[recipeIndex][i]} food group");
                }
                Console.WriteLine($"Total calories after volume increase: {CalculateTotalCalories(units[recipeIndex], ingredientCalories[recipeIndex])}");
            }
            else
            {
                Console.WriteLine("Invalid volume factor.");
            }
        }


        public static void IncreaseVolume(CaptureRecipe captureRecipe, int recipeIndex, // increase volume 
            List<List<float>> units, List<List<int>> ingredientCalories, float volumeFactor)
        {
            if (volumeFactor <= 0)
            {
                Console.WriteLine("Volume factor must be greater than zero.");
                return;
            }

            for (int i = 0; i < units[recipeIndex].Count; i++)
            {
                units[recipeIndex][i] *= volumeFactor; // Increase units

                // Increase calories proportionally
                ingredientCalories[recipeIndex][i] = (int)Math.Round(ingredientCalories[recipeIndex][i] * volumeFactor);
            }

            Console.WriteLine("Volume increased successfully.");
        }
    }
}

//C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 1). 2022. YouTube video, added by Code Master. [Online]. Available at: https://www.youtube.com/watch?v=blkfqOYqAOs [Accessed: 30 May 2024].

//C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 2). 2022. YouTube video, added by Code Master. [Online]. Available at: https://www.youtube.com/watch?v=QLNDrYgk2lk [Accessed: 30 May 2024].

//Delegates in C# - a practical demonstration, including action and Func. 2018. YouTube video, added by IAmTimCorey. [Online]. Available at: https://www.youtube.com/watch?v=R8Blt5c-Vi4 [Accessed: 30 May 2024].

//GeeksforGeeks. 2019. How to find the length of an array in C#. [Online]. Available at: https://www.geeksforgeeks.org/how-to-find-the-length-of-an-array-in-c-sharp/ [Accessed: 30 May 2024].

//Mangal, K. 2019. C#: How to change foreground color of text in console, GeeksforGeeks. [Online].  Available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/ [Accessed: 30 May 2024].

//Swiniarski, S. and Poczekaj, N. 2022. C#: Arrays: .clear(), Codecademy. [Online].  Available at: https://www.codecademy.com/resources/docs/c-sharp/arrays/clear [Accessed: 30 May 2024].

//Tutorials Teacher. [s.a.]. C# list collection. [Online]. Available at: https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20%2D%20List,Collections [Accessed: 30 May 2024].

//W3resource. 2024. C# program: Calculate the average of integers in an array. [Online]. Available at: https://www.w3resource.com/csharp-exercises/exception-handling/csharp-exception-handling-exercise-5.php [Accessed: 30 May 2024].

//W3Schools  [s.a.]. C# Multidimensional Arrays, W3Schools. [Online]. Available at: https://www.w3schools.com/cs/cs_arrays_multi.php [Accessed: 30 May 2024].

//C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 1). 2022. YouTube video, added by Code Master. [Online]. Available at: https://www.youtube.com/watch?v=blkfqOYqAOs [Accessed: 30 May 2024].

//C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 2). 2022. YouTube video, added by Code Master. [Online]. Available at: https://www.youtube.com/watch?v=QLNDrYgk2lk [Accessed: 30 May 2024].

//Delegates in C# - a practical demonstration, including action and Func. 2018. YouTube video, added by IAmTimCorey. [Online]. Available at: https://www.youtube.com/watch?v=R8Blt5c-Vi4 [Accessed: 30 May 2024].

//GeeksforGeeks. 2019. How to find the length of an array in C#. [Online]. Available at: https://www.geeksforgeeks.org/how-to-find-the-length-of-an-array-in-c-sharp/ [Accessed: 30 May 2024].

//Mangal, K. 2019. C#: How to change foreground color of text in console, GeeksforGeeks. [Online].  Available at: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/ [Accessed: 30 May 2024].

//Swiniarski, S. and Poczekaj, N. 2022. C#: Arrays: .clear(), Codecademy. [Online].  Available at: https://www.codecademy.com/resources/docs/c-sharp/arrays/clear [Accessed: 30 May 2024].

//Tutorials Teacher. [s.a.]. C# list collection. [Online]. Available at: https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20%2D%20List,Collections [Accessed: 30 May 2024].

//W3resource. 2024. C# program: Calculate the average of integers in an array. [Online]. Available at: https://www.w3resource.com/csharp-exercises/exception-handling/csharp-exception-handling-exercise-5.php [Accessed: 30 May 2024].

//W3Schools  [s.a.]. C# Multidimensional Arrays, W3Schools. [Online]. Available at: https://www.w3schools.com/cs/cs_arrays_multi.php [Accessed: 30 May 2024].

