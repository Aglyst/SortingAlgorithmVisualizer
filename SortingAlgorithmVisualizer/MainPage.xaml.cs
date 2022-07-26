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
		//Visualizer.mode = CanvasMode.Presort;
		//VisualizerView.Invalidate();

		// Sort.Run(mainArray);

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
		for (int i = 0; i <= (arrayLength-1); i++)
		{
			mainArray.Add(r.Next(1, 1000)); 
		}

		Visualizer.array = mainArray;
		isGenerated = true;



		//Visualizer.temp = r.Next().ToString();		// Also for debugging purposes, need to remove later
	}

	private void ArraySizeChanged(object sender, EventArgs e)
	{
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
			Visualizer.temp = arrayLength.ToString();
		}
		else
		{
			Shell.Current.DisplayAlert("Error", "Please enter a number", "Ok");
			return;
		}
	}
}

