using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace OpenGLIV
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(900, 900),
                Title = "LearnOpenTK - Creating a Window",
            };

            using (var window = new Escenario(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
