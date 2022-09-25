namespace SortingAlgorithmVisualizer.Sorts;

internal class BubbleSort : SortBase
{
    public override void Run(List<int> arr, MainPage m)
    {
        for (int i = 0; i <= arr.Count - 2; i++)
        {
            for (int j = 0; j <= arr.Count - 2; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(arr[j + 1], arr[j]);
                    m.Refresh();
                }
            }
        }
    }
}

