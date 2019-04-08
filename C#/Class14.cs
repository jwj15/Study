using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class14
    {
        static void Main()
        {
            // request, response
            var uri = "https://www.google.com";
            var request = WebRequest.Create(uri) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            var status = response.StatusCode;
            
            // credential
            var username = "jespera";
            var password = "Pa$$w0rd";
            request.Credentials = new NetworkCredential(username, password);

            // data 전송
            var rawData = Encoding.Default.GetBytes("{\"emailAddress\":\"jesper@fourthcoffee.com\"}");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = rawData.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(rawData, 0, rawData.Length);
            dataStream.Close();

            // FTP uploading
            var uri2 = "ftp://sales.fourthcoffee.com/FileRepository/test.xlsx";
            var rawData2 = File.ReadAllBytes("C:\\test\\test.xlsx");
            var request2 = WebRequest.Create(uri2) as FtpWebRequest;
            request2.Method = WebRequestMethods.Ftp.UploadFile;
            request2.ContentLength = rawData2.Length;
            var dataStream2 = request2.GetRequestStream();
            dataStream2.Write(rawData2, 0, rawData2.Length);
            dataStream2.Close();

            // reading data
            var stream = new StreamReader(response.GetResponseStream());
            stream.Close();
            

        }
    }
}
