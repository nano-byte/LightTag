// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Windows.Forms;

namespace NanoByte.LightTag
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0) Application.Run(new SearchForm());
            else Application.Run(new TaggingForm(args));
        }
    }
}
