using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace LaTeX_auto_exam_builder
{
    public class WebBrowserController
    {
        private string location;
        private string fileLocation;
        private WebBrowser webBrowser;

        public WebBrowserController(WebBrowser webBrowser)
        {
            this.location = Environment.CurrentDirectory;
            this.fileLocation = "/temp/temp.tex";
            this.webBrowser = webBrowser;
        }

        public string loadFile()
        {
            return File.ReadAllText(location + fileLocation);
        }

        public void loadTextField(string textfield)
        {
            // We save the textfield to a tex file
            saveTextFieldToTexFile(textfield);

            // We convert the tex file to a pdf
            LaTeXToPdf.Converter.convert(location + fileLocation);

            // We navigate the browser to the location
            webBrowser.Navigate(getOutputLocation());
        }

        private void saveTextFieldToTexFile(string textfield)
        {

            // Create the directory if nescecarry
            Directory.CreateDirectory(location);

            // Create the file with the recently written text
            File.WriteAllTextAsync(location + fileLocation, textfield);
        }

        public string getOutputLocation()
        {
            return location + "/output/temp.pdf";
        }
    }
}
