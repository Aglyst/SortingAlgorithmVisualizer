using System.Diagnostics;

namespace SortingAlgorithmVisualizer.Sorts
{
    internal class SelectionSort : SortBase
    {
        public SelectionSort(MainPage m)
        {
            base.MainPage(m);
            timeComplexity = "O(n^2) θ(n^2) Ω(n^2)";
            spaceComplexity = "O(1)";
        }

        public override async Task Run(List<int> arr)
        {
            int minInd = 0;
            for(int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)
                {
                    Cancel();

                    if (arr[j] < arr[minInd])
                    {
                        minInd = j;
                        comparisons++;
                    }
                }

                //if (minInd != i)
                //{
                //  comparisons++;
                Swap(arr, i, minInd);
                await Task.Delay(waitTime);
                page.Update();
                //}
                minInd = i + 1;
            }
        }
    }
}
