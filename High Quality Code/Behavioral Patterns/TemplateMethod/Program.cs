using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    using TemplateMethod.FileTypes;

    class Program
    {
        static void Main(string[] args)
        {
            var randomStuff = new File("gosho pesho gosho tosho gosho tosho");
            var hodorsTodoList = new File("hodor hodor hodor HODOR hodor hodor!");
            var js = new File("function() {console.log('kopon');}");
            var emptyFile = new File(null);

            var arraySender = new ArrayCompressionSender();
            var dictSender = new DictionaryCompressionSender();

            arraySender.Send(randomStuff, "telerikacademy.com");
            arraySender.Send(js, "github.com");
            dictSender.Send(hodorsTodoList, "telerikacademy.com");
            dictSender.Send(emptyFile, "piratebay.net");
            dictSender.Send(js, "sdfjsdfjl.bg");

            foreach (var domain in Internet.Domains)
            {
                Console.WriteLine(domain.Key+":");

                foreach (var file in domain.Value.Files)
                {
                    Console.WriteLine(file.Content);
                }

                Console.WriteLine();
            }
        }
    }
}
