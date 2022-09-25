namespace SortingAlgorithmVisualizer.Sorts;

internal abstract class SortBase
{
    protected int comparisons;
    protected int swaps;
    protected int acceses;

    protected string timeComplexity;
    protected string spaceComplexity;

    protected void Swap(int val1, int val2)
    {
        int temp = val1;
        val1 = val2;
        val2 = temp;
    }

    public abstract void Run(List<int> arr, MainPage m);
}

