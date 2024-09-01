namespace SortingAlgorithmVisualizer.Sorts;
class HeapSort : SortBase
{
    public HeapSort(MainPage m)
    {
        base.MainPage(m);
        timeComplexity = "O(nlogn) θ(nlogn) Ω(nlogn)";
        spaceComplexity = "O(1)";
    }

    public override async Task Run(List<int> arr)
    {
        throw new NotImplementedException();
    }
}

