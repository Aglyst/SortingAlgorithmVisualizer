namespace SortingAlgorithmVisualizer.Sorts;

internal class BubbleSort : SortBase
{
    public BubbleSort()
    {
        
    }

    public override async Task Run(List<int> arr, GraphicsView g, int waitTime)
    {
        for (int i = 0; i <= arr.Count - 2; i++)
        {
            for (int j = 0; j <= arr.Count - 2; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;

                    await Task.Delay(waitTime);
                    g.Invalidate();
                }
            }
        }
    }
}

