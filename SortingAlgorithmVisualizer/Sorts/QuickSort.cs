namespace SortingAlgorithmVisualizer.Sorts
{
    internal class QuickSort : SortBase
    {
        public QuickSort(MainPage m)
        {
            base.MainPage(m);
            timeComplexity = "O(n^2) θ(nlogn) Ω(nlogn)";
            spaceComplexity = "O(n)";
        }

        public override async Task Run(List<int> arr)
        {
            throw new NotImplementedException();
        }
    }
}
