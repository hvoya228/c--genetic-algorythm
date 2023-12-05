
int populationSize = 50; // кількість індивідумів у популяції
int numberOfBits = 8; // кількість символів в одній хромосомі
int chromosomeSize = 4; // кількість хромосом в індивідума
int generations = 100; // кількість поколінь
double mutationRate = 0.01; // ймовірність мутації

// Ініціалізація початкової популяції
List<string> population = GeneticAlgorythm.InitializePopulation(populationSize, numberOfBits, chromosomeSize);

for (int generation = 0; generation < generations; generation++)
{
    // Створення нової популяції
    List<string> newPopulation = new List<string>();
    for (int i = 0; i < populationSize; i += 2)
    {
        // Вибір батьків
        string parent1 = population[i];
        string parent2 = population[i + 1];

        // Кросовер
        string child1 = GeneticAlgorythm.Crossover(parent1, parent2);
        string child2 = GeneticAlgorythm.Crossover(parent1, parent2);

        // Мутація
        GeneticAlgorythm.Mutate(ref child1, mutationRate);
        GeneticAlgorythm.Mutate(ref child2, mutationRate);

        newPopulation.Add(child1);
        newPopulation.Add(child2);
    }

    population = newPopulation;
}

// Знаходження найкращого розв'язку в останній популяції

double bestX = 0;
int bestXIndex = 0;
double bestFitness = 0;

for (int i = 0; i < population.Count; i++)
{
    string individual = population[i];
    double individualRepresantation = GeneticAlgorythm.BinaryToDecimal(individual);
    double fitness = GeneticAlgorythm.FitnessFunction(individualRepresantation);

    if (bestFitness < fitness)
    {
        bestFitness = fitness;
        bestX = individualRepresantation;
        bestXIndex = i;
    }
}

string bestXBinary = population[bestXIndex];

Console.WriteLine($"Best X index: {bestXIndex}");
Console.WriteLine($"Best X in binary code: {bestXBinary}");
Console.WriteLine($"Best X: {bestX}");
Console.WriteLine($"Fitness value: {bestFitness}");