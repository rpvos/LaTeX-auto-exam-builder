using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace LaTeX_auto_exam_builder_console_application
{
    class Program
    {
        static void Main(string[] args)
        {

            #region create folders

            Directory.CreateDirectory("output");
            Directory.CreateDirectory("input");


            #endregion

            #region check for arguments

            // Check if the file is specified
            if (args.Length != 1)
            {
                // Check if there are more parameters given
                if (args.Length > 1)
                    throw new ArgumentException("Must pass only the file name");

                // Check if there is a file given
                if (args.Length == 0)
                    throw new ArgumentException("Must pass an file name");

            }

            // If the argument is help we specify how to use the application
            if (args[0] == "help")
                throw new ArgumentException("Must pass an file name after the exe file \n" +
                    "Like so \"LaTeX-auto-ecam-builder-console-application.exe example.tex\"");

            // Get the filename from the given parameter
            string filename = args[0];

            // Check if the file has an extension else we add one
            if (!filename.EndsWith(".tex"))
                filename += ".tex";

            // Check if a full path is given or a file from input is used
            if (!filename.Contains("\\"))
                filename = Environment.CurrentDirectory + "/input/" + filename;

            #endregion

            // This method converts the filename to a pdf
            LaTeXToPdf.Converter.convert(filename);

        }
    }
}
