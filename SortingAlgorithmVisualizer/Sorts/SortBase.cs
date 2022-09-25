namespace SortingAlgorithmVisualizer.Sorts;

internal abstract class SortBase
{
    protected int comparisons;
    protected int swaps;
    protected int acceses;

    protected string timeComplexity;
    protected string spaceComplexity;

    public abstract Task Run(List<int> arr, GraphicsView g, int waitTime);
}

