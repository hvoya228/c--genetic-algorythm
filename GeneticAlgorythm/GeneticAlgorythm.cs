public class GeneticAlgorythm
{
    static Random random = new Random();

    public static double FitnessFunction(double x)
    {
        return Math.Pow(x, 2) + 2;
    }

    public static string DecimalToBinary(int decimalNumber, int numberOfBits)
    {
        // Переведення десяткового числа у двійковий код
        return Convert.ToString(decimalNumber, 2).PadLeft(numberOfBits, '0');
    }

    public static double BinaryToDecimal(string binaryNumber)
    {
        // Переведення двійкового коду у десяткове число
        return Convert.ToInt32(binaryNumber, 2);
    }

    public static List<string> InitializePopulation(int populationSize, int numberOfBits, int chromosomeSize)
    {
        List<string> population = new List<string>();

        for (int i = 0; i < populationSize; i++)
        {
            int randomDecimal = random.Next(0, (int)Math.Pow(2, numberOfBits));
            string binaryRepresentation = DecimalToBinary(randomDecimal, numberOfBits);

            var individual = binaryRepresentation.PadLeft(chromosomeSize * numberOfBits, '0');

            if (population.Contains(individual))
            {
                i--;
                continue;
            }

            population.Add(individual);
        }

        return population;
    }

    public static string Crossover(string parent1, string parent2)
    {
        // Рандомний кросовер
        int crossoverPoint = random.Next(1, parent1.Length);
        return parent1.Substring(0, crossoverPoint) + parent2.Substring(crossoverPoint);
    }

    public static void Mutate(ref string individual, double mutationRate)
    {
        // Мутація генів
        char[] genes = individual.ToCharArray();
        for (int i = 0; i < genes.Length; i++)
        {
            if (random.NextDouble() < mutationRate)
            {
                genes[i] = (genes[i] == '0') ? '1' : '0'; // Зміна значення гена
            }
        }
        individual = new string(genes);
    }

    // Метод вибору індексу батька за допомогою рулетки
    public static int SelectParentIndexByRoulette(double[] fitnessScores, double totalFitness)
    {
        double randomValue = random.NextDouble() * totalFitness;
        double cumulativeFitness = 0;

        for (int i = 0; i < fitnessScores.Length; i++)
        {
            cumulativeFitness += fitnessScores[i];
            if (cumulativeFitness >= randomValue)
            {
                return i;
            }
        }

        return fitnessScores.Length - 1;
    }
}