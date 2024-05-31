using ST10362208_Prog6221_Part2.ed;



namespace ST10362208_Prog6221_Part2.ed
{
    public class Calculation
    {
        // Method to increase volume and adjust calories accordingly
        public int CalculateTotalCalories(List<float> units, List<int> ingredientCalories)
        {
            int totalCalories = 0;
            for (int i = 0; i < units.Count; i++)
            {
                totalCalories += (int)(units[i] * ingredientCalories[i]);
            }
            return totalCalories;
        }

        public void IncreaseVolume(List<float> units, List<int> ingredientCalories, float volumeFactor)
        {
            if (volumeFactor <= 0)
            {
                Console.WriteLine("Volume factor must be greater than zero.");
                return;
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i] *= volumeFactor; // Increase units

               
                ingredientCalories[i] = (int)Math.Round(ingredientCalories[i] * volumeFactor);
            }

            Console.WriteLine("Volume increased successfully.");
        }
    }
}