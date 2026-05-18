using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask1;

public interface IPrimeCounter
{
    PrimeCounterResult CountPrimes(
        int startNumber,
        int endNumber,
        int threadCount,
        bool verbose = false);
}
