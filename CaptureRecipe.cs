using System;
using System.Collections.Generic;

namespace ST10362208_Prog6221_Part2.ed
{
    public delegate void CalculationMethod(List<float> units, List<int> ingredientCalories, float volumeFactor);// declear delgate
    //(see Delegates in C# - a practical demonstration, including action and Func. 2018). 
    public class CaptureRecipe
    {
        private List<string> names = new List<string>();
        private List<List<string>> instructions = new List<List<string>>();
        private List<int> steps = new List<int>();
        private List<List<string>> ingredients = new List<List<string>>();
        private List<List<float>> units = new List<List<float>>();
        private List<List<int>> ingredientCalories = new List<List<int>>();
        private List<List<string>> ingredientFoodGroups = new List<List<string>>();
        private List<int> totalCalories = new List<int>();
        public List<string> RecipeFoodGroups { get; set; } = new List<string>();

        private Calculation calculation = new Calculation();

        // Method to capture recipe details
        public bool Capture()
        {
            string input;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("-----------Capture Recipe-----------");
                Console.ResetColor();

                try
                {
                    // Capture recipe information
                    CaptureRecipeInformation();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine("Enter 'home' to return to the home page or any other key to continue adding recipes:");
                input = Console.ReadLine();

                if (input.ToLower() == "home")
                {
                    return true; // Return true to indicate returning to the main method
                }

            } while (true); // Loop indefinitely until the user chooses to return
        }

        // Method to capture rezcipe information
        private void CaptureRecipeInformation()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();//(W3Schools  [s.a.]).
            names.Add(name);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("--------------------------------------");
            Console.ResetColor();
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            steps.Add(numSteps);

            List<string> stepInstructions = new List<string>();
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("--------------------------------------");
                Console.ResetColor();
                Console.Write($"Enter instruction for step {i + 1}: ");
                stepInstructions.Add(Console.ReadLine());
            }
            instructions.Add(stepInstructions);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            List<string> ingredientNames = new List<string>();
            List<float> ingredientUnits = new List<float>();
            List<int> ingredientCals = new List<int>();
            List<string> ingredientFoodGroupsList = new List<string>();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("--------------------------------------");
                Console.ResetColor();
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                ingredientNames.Add(Console.ReadLine());
                Console.WriteLine("--------------------------------------");
                Console.ResetColor();
                Console.Write($"Enter the units for ingredient {i + 1}: ");
                ingredientUnits.Add(float.Parse(Console.ReadLine()));
                Console.WriteLine("--------------------------------------");
                Console.ResetColor();
                Console.Write($"Enter the calories for ingredient {i + 1}: ");
                ingredientCals.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine("--------------------------------------");
                Console.ResetColor();
                Console.Write($"Enter the food group for ingredient {i + 1}: ");
                ingredientFoodGroupsList.Add(Console.ReadLine());
            }

            ingredients.Add(ingredientNames);
            units.Add(ingredientUnits);
            ingredientCalories.Add(ingredientCals);
            ingredientFoodGroups.Add(ingredientFoodGroupsList);

            // Calculate total calories for the recipe
            int totalCal = calculation.CalculateTotalCalories(ingredientUnits, ingredientCals);
            totalCalories.Add(totalCal);

            CheckCalorieWarning(totalCal);
            Console.WriteLine($"Total calories for this recipe: {totalCal}");
        }

        // Method to check if total calories exceed 500 and display a warning
        private void CheckCalorieWarning(int totalCalories)
        {
            if (totalCalories > 500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning! The total calories exceed 500.");
                Console.ResetColor();
            }
        }

        public void AddToRecipe(
            List<string> existingIngredients,
            List<float> existingUnits,
            List<int> existingIngredientCalories,
            List<string> existingIngredientFoodGroups)
        {
            Console.WriteLine("Adding to Recipe");
            Console.Write("Enter the name of the ingredient: ");
            string newIngredient = Console.ReadLine();
            Console.Write("Enter the units for the ingredient: ");
            float newUnits = float.Parse(Console.ReadLine());
            Console.Write("Enter the calories for the ingredient: ");
            int newCalories = int.Parse(Console.ReadLine());
            Console.Write("Enter the food group for the ingredient: ");
            string newFoodGroup = Console.ReadLine();

            // Add new ingredient details to the existing lists if they're not null
            if (existingIngredients != null && existingUnits != null && existingIngredientCalories != null && existingIngredientFoodGroups != null)
            {
                // Add new ingredient details to the existing lists
                existingIngredients.Add(newIngredient);
                existingUnits.Add(newUnits);
                existingIngredientCalories.Add(newCalories);
                existingIngredientFoodGroups.Add(newFoodGroup);

                Console.WriteLine("Ingredient added to the recipe.");
            }
            else
            {
                Console.WriteLine("Existing lists are not properly initialized.");
            }
        }

        // Properties to access recipe details
        public List<string> Names { get { return names; } }
        public List<List<string>> Instructions { get { return instructions; } }
        public List<int> Steps { get { return steps; } }
        public List<List<string>> Ingredients { get { return ingredients; } }
        public List<List<float>> Units { get { return units; } }
        public List<List<int>> IngredientCalories { get { return ingredientCalories; } }
        public List<List<string>> IngredientFoodGroups { get { return ingredientFoodGroups; } }
        public List<int> TotalCalories { get { return totalCalories; } }
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

