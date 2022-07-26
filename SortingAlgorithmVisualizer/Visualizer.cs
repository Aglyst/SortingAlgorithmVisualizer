using Microsoft.Maui.Graphics;

namespace SortingAlgorithmVisualizer.Drawables
{
    public class Visualizer : IDrawable
    {
        public static CanvasMode mode = CanvasMode.Startup;

        public static string temp = "A";
        public static List<int> array = new List<int>();
        Random random = new Random();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (mode is CanvasMode.Startup)
            {
                canvas.DrawRectangle(dirtyRect);
                canvas.DrawString(DateTime.Now.ToString(), 80, 10, HorizontalAlignment.Center);
                canvas.DrawString(temp, 10, 20, HorizontalAlignment.Center);
            }
            else if (mode is CanvasMode.Presort)
            {
                // calculate size of rectangles...
            }
            else if (mode is CanvasMode.Sorting)
            {
                // render rectangles...
            }

        }
    }

    public enum CanvasMode
    {
        Startup,
        Presort,
        Sorting,
        Postsort
    }
}
