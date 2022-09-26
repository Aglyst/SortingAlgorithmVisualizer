namespace SortingAlgorithmVisualizer.Sorts;

public class BubbleSort : SortBase
{
    public BubbleSort()
    {
        timeComplexity = "BS 0(n^2)";
        spaceComplexity = "BS O(n)";
    }
    public override async Task Run(List<int> arr, GraphicsView g, int waitTime)
    {
        for (int i = 0; i <= arr.Count - 2; i++)
        {
            for (int j = 0; j <= arr.Count - 2; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    acceses += 2;
                    comparisons += 3;
                    int temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                    swaps += 1;
                    await Task.Delay(waitTime);
                    g.Invalidate();
                }
            }
        }
    }
}

