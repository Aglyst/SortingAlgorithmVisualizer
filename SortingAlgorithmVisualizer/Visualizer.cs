using Microsoft.Maui.Graphics;

namespace SortingAlgorithmVisualizer.Drawables;

public class Visualizer : IDrawable
{
    public static CanvasMode mode = CanvasMode.Startup;

    public static string temp = "A";
    public static List<int> array = new List<int>();
    public static int arrayMax;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (mode is CanvasMode.Startup)
        {
            canvas.FillColor = Colors.Black;
            canvas.FillRectangle(dirtyRect);
        }
        else if (mode is CanvasMode.Sorting)
        {
            canvas.FillColor = Colors.Black;
            canvas.FillRectangle(dirtyRect);

            canvas.StrokeColor = Colors.White;
            canvas.FontColor = Colors.White;

            // render rectangles...
            // Note: Maui draws rectangles from top left(following coordinate system where top left of view is (0,0))
            float rectWidth = dirtyRect.Width / array.Count;

            for (int i = 0; i < array.Count; i++)
            {
                float height = 50 + ((float)array[i] / 500) * dirtyRect.Height;
                RectF r = new RectF(i * rectWidth, dirtyRect.Height - height, rectWidth, height + 50);
                canvas.DrawRectangle(r);

                if (array.Count < 66)   // checks if rectangle is wide enough for value display
                {
                    canvas.DrawString(array[i].ToString(), r.Center.X, r.Center.Y, HorizontalAlignment.Center);
                }
            }
        }
    }
}

public enum CanvasMode
{
    Startup,
    Sorting,
}

