namespace SortingAlgorithmVisualizer.Sorts;

public abstract class SortBase
{
    public int comparisons;
    public int swaps;
    public int acceses;

    public string timeComplexity;
    public string spaceComplexity;

    public abstract Task Run(List<int> arr, GraphicsView g, int waitTime);
}

