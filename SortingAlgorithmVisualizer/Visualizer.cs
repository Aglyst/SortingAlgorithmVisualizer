﻿using Microsoft.Maui.Graphics;

namespace SortingAlgorithmVisualizer.Drawables;

public class Visualizer : IDrawable
{
    public static CanvasMode mode = CanvasMode.Startup;

    public static string temp = "A";
    public static List<int> array = new List<int>();
    public static int arrayMax;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // canvas.StrokeColor = Colors.White;

        if (mode is CanvasMode.Startup)
        {
            canvas.DrawRectangle(dirtyRect);
        }
        //else if (mode is CanvasMode.Presort)
        //{
        //    
        //}
        else if (mode is CanvasMode.Sorting)
        {
            // render rectangles...
            // Note: Maui draws rectangles from top left(following coordinate system where top left of view is (0,0))
            float rectWidth = dirtyRect.Width / array.Count;

            for (int i = 0; i < array.Count; i++)
            {
                float height = ((float)array[i] / 500) * dirtyRect.Height;
                RectF r = new RectF(i * rectWidth, dirtyRect.Height - height, rectWidth, height);
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
    Presort,    // might need to remove
    Sorting,
    Postsort    // might need to remove
}

