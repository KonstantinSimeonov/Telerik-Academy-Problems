using System;
using System.Net;



class Downloader
{
    static void Main()
    {
        WebClient client = new WebClient();
        try
        {
            client.DownloadFile("http://telerikacademy.com/Content/Images/news-img01.png", "ninja.png");
        }
        catch (UriFormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (HttpListenerException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            client.Dispose();
        }
        

    }
}

