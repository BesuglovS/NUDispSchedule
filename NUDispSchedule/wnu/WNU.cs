using System.IO;
using System.Net;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUDispSchedule.wnu
{
    public static class WNU
    {
        public static string PostRequest(string requestPath, string postData)
        {
            WebRequest request = null;
            Stream dataStream;

            try
            {
                // Create a request using a URL that can receive a post. 
                request = (HttpWebRequest)WebRequest.Create(requestPath);

                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Oops!");
                return e.Message;
            }           
            
            var webTask = Task.Factory.FromAsync<WebResponse>(
                request.BeginGetResponse,
                request.EndGetResponse,
                null);

            var resultTask = webTask.ContinueWith(antecedent =>
            {
                // Get the response.
                var response = antecedent.Result;
                
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Clean up the streams.
                    reader.Close();
                    dataStream.Close();
                    response.Close();

                    return responseFromServer;
                }

                return "dataStream == null";
            }
            );

            return resultTask.Result;
        }
    }
}
