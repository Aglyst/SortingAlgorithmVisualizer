using SortingAlgorithmVisualizer.Drawables;
using SortingAlgorithmVisualizer.Sorts;

namespace SortingAlgorithmVisualizer;

public partial class MainPage : ContentPage
{
	public SortBase sort;

    List<int> mainArray = new List<int>();
	int arrayLength = 0;
	bool isGenerated; // might remove if unnecesary;
	Random r;

    public MainPage()
	{
		InitializeComponent();

		r = new Random();

		BindingContext = this;
    }

	private async void RunBtnClicked(object sender, EventArgs e)
	{
		if (isGenerated)
		{
			try
			{
				sort.ClearValues();
                await sort.Run(mainArray, (int)DelaySlider.Value);
            }
			catch
			{
                Shell.Current.DisplayAlert("Error", "Please Select a Sort", "Ok");
            }
		}
		else
		{
			Shell.Current.DisplayAlert("Error", "Please generate an array", "Ok");
		}

		VisualizerView.Invalidate();    // Refresh for debugging purposes, need to remove later
	}

	private void GenerateBtnClicked(object sender, EventArgs e)
	{
		// isGenerated = false
		if (arrayLength is 0)
		{
			Shell.Current.DisplayAlert("Error", "Please enter an array size!", "Ok");
			return;
		}

		mainArray.Clear();
		// generate array
		for (int i = 0; i < arrayLength; i++)
		{
			mainArray.Add(r.Next(1, 500));
		}

		Visualizer.array = mainArray;
		isGenerated = true;

		Visualizer.mode = CanvasMode.Sorting;
		VisualizerView.Invalidate();
	}

	private void ArraySizeChanged(object sender, EventArgs e)
	{
		isGenerated = false;

		string s = ((Entry)sender).Text;

		if (int.TryParse(s, out arrayLength))
		{
			if (arrayLength > 1000)
			{
				arrayLength = 0;
				Shell.Current.DisplayAlert("Error", "Array length can't exceed 1000", "Ok");
				return;
			}

			Thread.Sleep(10);       // Need to put this due to race-condition(?), otherwise line below doesn't run; need to do more research
			Visualizer.arrayMax = arrayLength;
		}
		else
		{
			Shell.Current.DisplayAlert("Error", "Please enter a number", "Ok");
			return;
		}
	}

	private void SortChanged(object sender, EventArgs e)
	{
		Picker p = (Picker)sender;
		string val = p.SelectedItem.ToString();

		if (val == "Bubble Sort")
		{
			sort = new BubbleSort(this);
		}
		else if (val == "Merge Sort")
		{
			sort = new MergeSort(this);
		}
		else if (val == "Quick Sort")
		{
			sort = new QuickSort(this);
		}

        SortInfo.Text = $"Comparisons: {sort.comparisons} | Swaps: {sort.swaps} | Time Complexity: {sort.timeComplexity} | Space Complexity: {sort.spaceComplexity}";
    }

    public void Update()
	{
		VisualizerView.Invalidate();
        SortInfo.Text = $"Comparisons: {sort.comparisons} | Swaps: {sort.swaps} | Time Complexity: {sort.timeComplexity} | Space Complexity: {sort.spaceComplexity}";
    }
}