namespace SortingAlgorithmVisualizer.Sorts
{
    internal class MergeSort : SortBase
    {
        public MergeSort(MainPage m)
        {
            base.MainPage(m);
            timeComplexity = "O(nlogn) θ(nlogn) Ω(nlogn)";
            spaceComplexity = "O(n)";
        }

        public override async Task Run(List<int> arr, int waitTime, CancellationToken ct)
        {

        }
    }
}
