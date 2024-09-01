namespace SortingAlgorithmVisualizer.Sorts;

class RadixSort : SortBase
{
    public RadixSort(MainPage m)
    {
        base.MainPage(m);
        timeComplexity = "O(nk) θ(nk) Ω(nk)";
        spaceComplexity = "O(n+k)";
    }

    public override Task Run(List<int> arr)
    {
        throw new NotImplementedException();
    }
}
