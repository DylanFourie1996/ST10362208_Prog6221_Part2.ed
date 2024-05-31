using System;
using System.Collections.Generic;

namespace ST10362208_Prog6221_Part2.ed
{
    public class DeleteFunctions
    {
        public void Delete(
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
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("Delete Recipe");

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Delete an individual recipe");
                Console.WriteLine("2. Delete all recipes");
                Console.WriteLine("Type 'home' to return to the main menu");

                Console.Write("Enter your choice (1, 2, or 'home'): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DeleteIndividualRecipe(names, instructions, steps, ingredients, units, ingredientCalories, ingredientFoodGroups, totalCalories, recipeFoodGroups);
                        break;
                    case "2":
                        DeleteAllRecipes(names, instructions, steps, ingredients, units, ingredientCalories, ingredientFoodGroups, totalCalories, recipeFoodGroups);
                        break;
                    case "home":
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (true); // Loop indefinitely until user decides to return to main menu
        }


        private void DeleteIndividualRecipe(
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
            Console.Write("Enter the name of the recipe to delete: ");
            string nameToDelete = Console.ReadLine(); //Delete IndividualRecipe

            int index = names.IndexOf(nameToDelete);
            if (index >= 0)
            {
                names.RemoveAt(index);
                instructions.RemoveAt(index);
                steps.RemoveAt(index);
                ingredients.RemoveAt(index);
                units.RemoveAt(index);
                ingredientCalories.RemoveAt(index);
                ingredientFoodGroups.RemoveAt(index);
                totalCalories.RemoveAt(index);
                recipeFoodGroups.RemoveAt(index);

                Console.WriteLine("Recipe deleted successfully.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        private void DeleteAllRecipes(// delete all recipes
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
            Console.WriteLine("Are you sure you want to delete all recipes? (yes/no)");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "yes")
            {
                names.Clear();
                instructions.Clear();
                steps.Clear();
                ingredients.Clear();
                units.Clear();
                ingredientCalories.Clear();
                ingredientFoodGroups.Clear();
                totalCalories.Clear();
                recipeFoodGroups.Clear();

                Console.WriteLine("All recipes have been deleted.");
            }
            else if (confirmation == "no")
            {
                Console.WriteLine("Operation cancelled. No recipes were deleted.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
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

