using System;

namespace TerraNullius
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (main game = new main())
            {
                game.Run();
            }
        }
    }
#endif
}

