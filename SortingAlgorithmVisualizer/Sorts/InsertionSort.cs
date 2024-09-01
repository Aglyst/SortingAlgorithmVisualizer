namespace SortingAlgorithmVisualizer.Sorts
{
    internal class InsertionSort : SortBase
    {
        public InsertionSort(MainPage m)
        {
            base.MainPage(m);
            timeComplexity = "O(n^2) θ(n^2) Ω(n)";
            spaceComplexity = "O(1)";
        }

        public override async Task Run(List<int> arr)
        {
            for (int i = 1; i< arr.Count; i++)
            {
                int temp = arr[i];
                int j = i-1;
                while (j >= 0 && arr[j] > temp)
                {
                    Cancel();

                    arr[j + 1] = arr[j];
                    j--;

                    swaps++;
                    comparisons++;

                    await Task.Delay(waitTime);
                    page.Update();
                }
                arr[j + 1] = temp;
                swaps++;

                await Task.Delay(waitTime);
                page.Update();
            }
        }
    }
}
