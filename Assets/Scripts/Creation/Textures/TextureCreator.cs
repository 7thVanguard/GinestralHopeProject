using UnityEngine;
using System.Collections;

public static class TextureCreator
{
   public static Texture2D CreateCircle(Texture2D circle)  
    {
        // Create a 8x8 texture ARGB32 (32 bit with alpha) and no mipmaps
        circle = new Texture2D(24, 24, TextureFormat.ARGB32, false);

        // set the pixel values
        for (int i = 0; i < circle.width; i++)
            for (int j = 0; j < circle.height; j++)
            {
                if (Mathf.Sqrt((i - circle.width / 2 + 0.5f) * (i - circle.width / 2 + 0.5f) + (j - circle.height / 2 + 0.5f) * (j - circle.height / 2 + 0.5f)) > 11.8f)
                    circle.SetPixel(i, j, new Color(0, 0, 0, 0));
                else if (Mathf.Sqrt((i - circle.width / 2 + 0.5f) * (i - circle.width / 2 + 0.5f) + (j - circle.height / 2 + 0.5f) * (j - circle.height / 2 + 0.5f)) > 10.2f)
                    circle.SetPixel(i, j, new Color(1, 1, 1, 1));
                else
                    circle.SetPixel(i, j, new Color(0, 0, 0, 0));
            }

        // Apply all SetPixel calls
        circle.Apply();

        return circle;
    }


    public static Texture2D CreateCross(Texture2D cross)
    {
        // Create a 8x8 texture ARGB32 (32 bit with alpha) and no mipmaps
        cross = new Texture2D(32, 32, TextureFormat.ARGB32, false);

        // set the pixel values
        for (int i = 0; i < cross.width; i++)
            for (int j = 0; j < cross.height; j++)
            {
                if (i == cross.width / 2 - 1 || i == cross.width / 2 || j == cross.height / 2 - 1 || j == cross.height / 2)
                    cross.SetPixel(i, j, Color.white);
                else
                    cross.SetPixel(i, j, new Color(0, 0, 0, 0));
            }

        // Apply all SetPixel calls
        cross.Apply();

        return cross;
    }


    public static Texture2D CreatePixel(Texture2D pixel, Color pixelColor)
    {
        // Create a 1x1 texture ARGB32 (32 bit with alpha) and no mipmaps
        pixel = new Texture2D(1, 1, TextureFormat.ARGB32, false);

        // set the pixel values
        pixel.SetPixel(0, 0, pixelColor);

        // Apply all SetPixel calls
        pixel.Apply();

        return pixel;
    }
}
