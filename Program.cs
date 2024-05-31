using System;

namespace ST10362208_Prog6221_Part2.ed
{
    public class Program
    {
        static void Main(string[] args)
        {
            CaptureRecipe captureRecipe = new CaptureRecipe();
            DeleteFunctions deleteFunctions = new DeleteFunctions();
            DisplayRecipes displayRecipe = new DisplayRecipes();
            Calculation calculation = new Calculation();

            string userInput;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Welcome to Recipe CaptureSoftware");
                Console.ResetColor();

                Console.WriteLine("1. Capture Recipe");
                Console.WriteLine("2. Display Recipes");
                Console.WriteLine("3. Add More to Recipe");
                Console.WriteLine("4. Delete Recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        captureRecipe.Capture();
                        break;
                    case "2":
                        displayRecipe.Display(
                            captureRecipe.Names,
                            captureRecipe.Instructions,
                            captureRecipe.Steps,
                            captureRecipe.Ingredients,
                            captureRecipe.Units,
                            captureRecipe.IngredientCalories,
                            captureRecipe.IngredientFoodGroups,
                            captureRecipe.TotalCalories,
                            captureRecipe.RecipeFoodGroups);
                        
                        break;
                    case "3":
                        AddMore.DisplayAllRecipeInformation(
                                    0,
                                    captureRecipe.Names,
                                    captureRecipe.Instructions,
                                    captureRecipe.Steps,
                                    captureRecipe.Ingredients,
                                    captureRecipe.Units,
                                    captureRecipe.IngredientCalories,
                                    captureRecipe.IngredientFoodGroups,
                                    captureRecipe.TotalCalories,
                                    captureRecipe.RecipeFoodGroups,
                                    captureRecipe);
                        break;
                    case "4":
                        deleteFunctions.Delete(
                            captureRecipe.Names,
                            captureRecipe.Instructions,
                            captureRecipe.Steps,
                            captureRecipe.Ingredients,
                            captureRecipe.Units,
                            captureRecipe.IngredientCalories,
                            captureRecipe.IngredientFoodGroups,
                            captureRecipe.TotalCalories,
                            captureRecipe.RecipeFoodGroups
                        );
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (userInput != "5")
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (userInput != "5");
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

