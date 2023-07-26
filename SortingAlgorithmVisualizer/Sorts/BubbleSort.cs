namespace SortingAlgorithmVisualizer.Sorts;

internal class BubbleSort : SortBase
{
    public BubbleSort(MainPage m)
    {
        base.MainPage(m);
        timeComplexity = "O(n^2) θ(n^2) Ω(n)";
        spaceComplexity = "O(1)";
    }

    public override async Task Run(List<int> arr, int waitTime, CancellationToken ct)
    {
        for (int i = 0; i <= arr.Count - 2; i++)
        {
            for (int j = 0; j <= arr.Count - 2; j++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }

                if (arr[j] > arr[j + 1])
                {
                    comparisons++;

                    Swap(arr, j, j + 1);

                    await Task.Delay(waitTime);
                    page.Update();
                }
                else
                {
                    comparisons++;
                    page.Update();
                }
            }
        }
    }
} 

