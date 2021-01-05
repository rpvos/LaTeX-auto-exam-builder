using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LaTeXToPdf
{
    public static class Converter
    {
        public static void convert(String filename)
        {

            // Base command we use to create pdf files from a tex file
            string command = $"pdflatex -halt-on-error -output-directory output {filename}";


            try
            {
                // Initiate a processStartInfo 
                // with cmd as the process we want to start
                // And /c to say we want to close it after it is run
                // After we add the command we want to execute
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                // This option enables the StandardOutput as the output stream
                processStartInfo.RedirectStandardOutput = true;

                // This option disables an extra popup window
                processStartInfo.CreateNoWindow = true;

                // We make a process that will handle the command
                Process process = new Process();

                // Asign the StartInfo
                process.StartInfo = processStartInfo;

                // Start the process
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

        }
    }
}
