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

        public override async Task Run(List<int> arr)
        {
            if (arr.Count <= 1)
            {
                return;
            }

            int middle = arr.Count / 2;

            List<int> leftArray = arr.GetRange(0, middle);
            List<int> rightArray = arr.GetRange(middle, arr.Count - middle);

            await Run(leftArray);
            await Run(rightArray);
            Merge(arr, leftArray, rightArray);
        }


        private async void Merge(List<int> arr, List<int> leftArr, List<int> rightArr)
        {
            int lSize = (arr.Count) / 2;
            int rSize = arr.Count - lSize;

            int i = 0, l = 0, r = 0;

            while (l < lSize && r < rSize)
            {
                Cancel();

                comparisons += 3;
                if (leftArr[l] < rightArr[r])
                {
                    arr[i] = leftArr[l];
                    i++;
                    l++;
                }
                else
                {
                    arr[i] = rightArr[r];
                    i++;
                    r++;
                }
                await Task.Delay(waitTime);
            }

            while (l < lSize)
            {
                Cancel();

                arr[i] = leftArr[l];
                i++;
                l++;
                comparisons++;
                await Task.Delay(waitTime);
            }

            while (r < rSize)
            {
                Cancel();

                arr[i] = rightArr[r];
                i++;
                r++;
                comparisons++;
                await Task.Delay(waitTime);
            }

            page.Update();
        }
    }
}
