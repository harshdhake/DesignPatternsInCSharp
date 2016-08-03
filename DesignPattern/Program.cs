using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    //Use this pattern when you feel that Some classes have similer methods or propery so that we can convert Common property to base class.
    //Facory method is responsible for creation of Object based on the data provided to that method.
    class Program
    {
        static void Main(string[] args)
        {
            var docFac = new DocumentFactoy();
            var pdfDoc = docFac.CreateDoc(DocType.PDF);
            pdfDoc.Open("D:\\harsh.txt");

            var htmlDoc=docFac.CreateDoc(DocType.Html);
            htmlDoc.save("D:\\venky.html");
        }
    }

    public enum DocType
    {
        Html, PDF, Word
    }
    public class DocumentFactoy
    {
        public IDocument CreateDoc(DocType type)
        {
            switch (type)
            {
                case DocType.Html:
                    return new HTMLDoc();
                case DocType.PDF:
                    return new PDFDoc();
                case DocType.Word:
                default:
                    return new WordDoc();
            }
        }
    }

    public interface IDocument
    {
        void Open(string filepath);
        void close(string filepath);
        void save(string filepath);
    }

    public class HTMLDoc : IDocument
    {

        public void Open(string filepath)
        {
            Console.WriteLine(filepath + " :: HTML doc is Opened");
        }

        public void close(string filepath)
        {
            Console.WriteLine(filepath + " :: HTML doc is Closed");
        }

        public void save(string filepath)
        {
            Console.WriteLine(filepath + "  ::HTML doc is Saved");
        }
    }

    public class PDFDoc : IDocument
    {

        public void Open(string filepath)
        {
            Console.WriteLine(filepath + "  ::PDF doc is Opened");
        }

        public void close(string filepath)
        {
            Console.WriteLine(filepath + "  ::PDF doc is Closed");
        }

        public void save(string filepath)
        {
            Console.WriteLine(filepath + "  ::PDF doc is Saved");
        }
    }

    public class WordDoc : IDocument
    {

        public void Open(string filepath)
        {
            Console.WriteLine(filepath + " :: Word doc is Opened");
        }

        public void close(string filepath)
        {
            Console.WriteLine(filepath + " :: Word doc is Closed");
        }

        public void save(string filepath)
        {
            Console.WriteLine(filepath + " :: Word doc is Saved");
        }
    }

}
