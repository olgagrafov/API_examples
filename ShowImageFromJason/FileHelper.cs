using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace ShowImageFromJason
{
    class FileHelper
    {
        private static string FILETXT = "listyesno.txt";     
        private static string FULLHTML = "ShowImages.html";
        private static string NOLIST = "no_list.html";
        private static string YESLIST = "yes_list.html";

        private List<ImgModel> models;        
        public FileHelper() {
            models = new List<ImgModel>();
        }

        public void FileWriter(ImgModel model)
        {

            using (StreamWriter sw = File.AppendText(FILETXT))
            {
                sw.WriteLine(model);
            }
        }

        public void FileReader(bool print)
        {
            if (File.Exists(FILETXT))
            {
                if (!print)
                {
                    models.Clear();
                    foreach (string line in File.ReadLines(FILETXT))
                    {
                        string[] tmpStr = line.Split(" ");
                        ImgModel tmmImg = new ImgModel(tmpStr[0], tmpStr[1]);
                        models.Add(tmmImg);
                    }
                }
                else
                {
                    foreach (string line in File.ReadLines(FILETXT))
                        Console.WriteLine(line);
                }
            }
            else
            {
                models.Clear();
                Console.WriteLine("no data");
            }
        }
        public void RemoveDuplicate()
        {
           this.FileReader(false);
            
            var query = models.GroupBy(x => x.Image).Select(y => y.First());    

            StringBuilder sb = new StringBuilder();
            foreach (ImgModel img in query)
            {
                sb.Append(img.ToString());
                sb.Append("\n");
            }           
            File.WriteAllText(FILETXT, sb.ToString());
        }
        public void ShowHtmlFile()
        {
            this.FileReader(false);           
            //models.Sort();            
            StringBuilder sb_yes = new StringBuilder("<ul style='list-style-type: decimal;'>");
            StringBuilder sb_no = new StringBuilder("<ul style='list-style-type: decimal;'>");
            foreach (ImgModel img in models)
            {   
               if(img.Answer=="yes")
                   sb_yes.Append("<li><a href='" + img.Image + "' target='imgIframe' >" + img.Answer + "</a></li>");
               else
                    sb_no.Append("<li><a href='" + img.Image + "' target='imgIframe' >" + img.Answer + "</a></li>");
            }
            sb_yes.Append("</ul>");
            sb_no.Append("</ul>");
            File.WriteAllText(YESLIST, sb_yes.ToString());
            File.WriteAllText(NOLIST, sb_no.ToString());

            FileInfo f = new FileInfo(FULLHTML);
            if (f.Exists)
            {
                Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",f.FullName);
            }
            else
                Console.WriteLine("The File dosen't exist");
        }      
    }
}
