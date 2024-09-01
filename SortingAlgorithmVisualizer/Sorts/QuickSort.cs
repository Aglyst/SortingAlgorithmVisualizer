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
            await QSort(arr, 0, arr.Count - 1);
        }

        public async Task QSort(List<int> arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            comparisons++;

            int pivot = await Partition(arr, l, r);
            await QSort(arr, l, pivot - 1);
            await QSort(arr, pivot + 1, r);
        }

        public async Task<int> Partition(List<int> arr, int l, int r)
        {
            int pivotIndex = new Random().Next(l, r);
            Swap(arr, pivotIndex, r);
            int pivot = arr[r];

            int lp = l;
            int rp = r;

            while (lp < rp)
            {
                comparisons++;
                while (arr[lp] <= pivot && lp < rp)
                {
                    comparisons += 2;
                    lp++;

                    page.Update();
                    Cancel();
                }

                while (arr[rp] >= pivot && lp < rp)
                {
                    comparisons += 2;
                    rp--;

                    page.Update();
                    Cancel();
                }

                Swap(arr, lp, rp);
                await Task.Delay(waitTime);
            }
            Swap(arr, lp, r);
            await Task.Delay(waitTime);
            page.Update();
            return lp;
        }
    }
}
