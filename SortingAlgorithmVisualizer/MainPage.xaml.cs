using SortingAlgorithmVisualizer.Drawables;
using SortingAlgorithmVisualizer.Sorts;
using System.ComponentModel;
namespace SortingAlgorithmVisualizer;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public SortBase sort;
	CancellationTokenSource cancellationToken = null;

    public event PropertyChangedEventHandler PropertyChanged;
    public bool currentlySorting = false;
    public bool CurrentlySorting
    {
        get => currentlySorting;
		set
        {
            currentlySorting = value;
            NotifyPropertyChanged(nameof(CurrentlySorting));
            NotifyPropertyChanged(nameof(NotCurrentlySorting));
        }
    }

    public bool NotCurrentlySorting => !CurrentlySorting;
    /*public bool NotCurrentlySorting
	{
        get => !currentlySorting;
        set
        {
            currentlySorting = value;
            NotifyPropertyChanged(nameof(NotCurrentlySorting));
        }
    }*/

    List<int> mainArray = new List<int>();
	int arrayLength = 0;
	bool isGenerated; // might remove if unnecesary;
	Random r;

    public MainPage()
	{
		InitializeComponent();

		r = new Random();
    }

	private async void RunBtnClicked(object sender, EventArgs e)
	{
		if (isGenerated)
		{
			try
			{
				sort.ClearValues();
				cancellationToken = new CancellationTokenSource();
				try
				{
					CurrentlySorting = true;
                    await sort.Run(mainArray, (int)DelaySlider.Value, cancellationToken.Token);
					CurrentlySorting = false;
                }
				catch (OperationCanceledException ex) { }
				finally
				{
					cancellationToken.Dispose();
				}
            }
			catch
			{
                await Shell.Current.DisplayAlert("Error", "Please Select a Sort", "Ok");
            }
		}
		else
		{
			await Shell.Current.DisplayAlert("Error", "Please generate an array", "Ok");
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

    private void StopSorting(object sender, EventArgs e)
    {
		cancellationToken.Cancel();
		CurrentlySorting = false;
    }

    public void Update()
	{
		VisualizerView.Invalidate();
        SortInfo.Text = $"Comparisons: {sort.comparisons} | Swaps: {sort.swaps} | Time Complexity: {sort.timeComplexity} | Space Complexity: {sort.spaceComplexity}";
    }

	public void NotifyPropertyChanged(string name)
	{
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}