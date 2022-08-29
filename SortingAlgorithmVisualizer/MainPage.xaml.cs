using SortingAlgorithmVisualizer.Drawables;

namespace SortingAlgorithmVisualizer;

public partial class MainPage : ContentPage
{
	List<int> mainArray = new List<int>();
	int arrayLength = 0;
	bool isGenerated; // might remove if unnecesary;

	Random r;

    public MainPage()
	{
		InitializeComponent();
		
		r = new Random();
	}

	private void RunBtnClicked(object sender, EventArgs e)
	{
		if (isGenerated)
		{
            // Sort.Run(mainArray);
        }
		else
		{
            Shell.Current.DisplayAlert("Error", "Please generate an array", "Ok");
        }

        VisualizerView.Invalidate();	// Refresh for debugging purposes, need to remove later
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

        // Visualizer.mode = CanvasMode.Presort;
        // VisualizerView.Invalidate();

		Visualizer.mode = CanvasMode.Sorting;
        VisualizerView.Invalidate();

        //Visualizer.temp = r.Next().ToString();		// Also for debugging purposes, need to remove later
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

			Thread.Sleep(10);		// Need to put this due to race-condition(?), otherwise line below doesn't run; need to do more research
			Visualizer.arrayMax = arrayLength;
		}
		else
		{
			Shell.Current.DisplayAlert("Error", "Please enter a number", "Ok");
			return;
		}
	}
}

