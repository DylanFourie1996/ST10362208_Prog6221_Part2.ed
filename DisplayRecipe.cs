using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10362208_Prog6221_Part2.ed
{
    public class DisplayRecipes
    {
        public void Display(
            List<string> names,
            List<List<string>> instructions,
            List<int> steps,
            List<List<string>> ingredients,
            List<List<float>> units,
            List<List<int>> ingredientCalories,
            List<List<string>> ingredientFoodGroups,
            List<int> totalCalories,
            List<string> recipeFoodGroups)
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Display Recipes");
                Console.ResetColor();

                // Sort names list alphabetically and track original indices
                var sortedNameIndices = names
                    .Select((name, index) => new { name, index })
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
                int recipeIndex = sortedNameIndices[displayIndex].index;

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
                        Console.WriteLine("No total calories available.");//(see C# programming • C# intermediate level • C# course • C# tutorials • C# basics • learn C# • (pt. 2). 2022).
                    }
                }
                else
                {
                    Console.WriteLine("Invalid recipe index.");
                    continue; // Skip the rest of the loop iteration
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Enter 'home' to return to the home page or any other key to continue viewing recipes:");
                input = Console.ReadLine();
            } while (input.ToLower() != "home");
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

