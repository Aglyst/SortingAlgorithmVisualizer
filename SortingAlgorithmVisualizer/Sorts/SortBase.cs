namespace SortingAlgorithmVisualizer.Sorts;

public abstract class SortBase
{
    protected MainPage page;

    public int comparisons;
    public int swaps;

    public string timeComplexity;
    public string spaceComplexity;

    public CancellationToken ct;
    public int waitTime;

    public void MainPage(MainPage m)
    {
        page = m;
    }

    public abstract Task Run(List<int> arr);

    public void ClearValues()
    {
        comparisons = 0;
        swaps = 0;
    }

    protected void Swap(List<int> arr, int ind1, int ind2)
    {
        int temp = arr[ind1];
        arr[ind1] = arr[ind2];
        arr[ind2] = temp;
        swaps++;
    }

    protected void Cancel()
    {
        if (ct.IsCancellationRequested)
        {
            ct.ThrowIfCancellationRequested();
        }
    }
}

