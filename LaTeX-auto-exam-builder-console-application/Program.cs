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

            if (args.Length != 1)
            {
                if (args.Length > 1)
                    throw new ArgumentException("Must pass only the file name");

                if (args.Length == 0)
                    throw new ArgumentException("Must pass an file name");

                if (args[0] == "help")
                    throw new ArgumentException("Must pass an file name after the exe file \n" +
                        "Like so \"LaTeX-auto-ecam-builder-console-application.exe example.tex\"");
            }

            string filename = args[0];

            if (!filename.EndsWith(".tex"))
                filename += ".tex";

            if (!filename.Contains("\\"))
                filename = Environment.CurrentDirectory + "/input/" + filename;

            #endregion


            #region converting to latex

            string command = $"pdflatex -halt-on-error -output-directory output {filename}";


            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                processStartInfo.RedirectStandardOutput = true;

                // Do not create the black window.
                processStartInfo.CreateNoWindow = true;

                // Now we create a process, assign its ProcessStartInfo and start it
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.Start();

                // Get the output into a string
                string result = process.StandardOutput.ReadToEnd();

                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception exception)
            {
                // Log the exception
                Console.WriteLine(exception.Message);
            }

            #endregion


        }
    }
}
