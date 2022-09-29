namespace SortingAlgorithmVisualizer.Sorts;

public abstract class SortBase
{
    protected MainPage page;

    public int comparisons;
    public int swaps;

    public string timeComplexity;
    public string spaceComplexity;

    public void MainPage(MainPage m)
    {
        page = m;
    }

    public abstract Task Run(List<int> arr, int waitTime);

    public void ClearValues()
    {
        comparisons = 0;
        swaps = 0;
    }
}

