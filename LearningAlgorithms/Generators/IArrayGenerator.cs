namespace LearningAlgorithms.Generators
{
    public interface IArrayGenerator
    {
        T[] Generate<T>(uint lenght) where T : struct;
    }
}