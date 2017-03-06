using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.Networking
{
    public class HttpClientExamples
    {
        private const string NorthwindURL = "http://services.odata.org/V3/Northwind/Northwind.svc/Regions";
        private const string IncorrectURL = "http://services.odata.org/V3/Northwind1/Northwind.svc/Regions";

        public static async void AsyncGetRequestExample()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(NorthwindURL);

                if (response.IsSuccessStatusCode)
                {
                    WriteLine($"Response Status Code: {(int)response.StatusCode}" +
                        $"{response.ReasonPhrase}");

                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Recieved Payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }//end if response.IsSuccessStatusCode
            }//end using HttpClient
        }

        public static async void AsyncGetRequestThrowException()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(IncorrectURL);
                    response.EnsureSuccessStatusCode();

                    //if (response.IsSuccessStatusCode)
                    //{
                    WriteLine($"StatusCode: {(int)response.StatusCode} {response.ReasonPhrase}");

                    string responseText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Recieved Payload of {responseText.Length} characters");

                    WriteLine();
                    WriteLine(responseText);
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adding Headers to get the response in JSON format
        /// </summary>
        public static async void AsyncGetRequestPassingHeaders()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");
                ShowHeaders("Request Headers", client.DefaultRequestHeaders);

                var response = await client.GetAsync(NorthwindURL);
                response.EnsureSuccessStatusCode();

                ShowHeaders("Response Headers", response.Headers);
                WriteLine($"StatusCode: {(int)response.StatusCode} {response.ReasonPhrase}");

                string responseText = await response.Content.ReadAsStringAsync();
                WriteLine($"Recieved Payload of {responseText.Length} characters");
                WriteLine();
                WriteLine(responseText);
            }
        }

        private static void ShowHeaders(string title, HttpHeaders headers)
        {
            WriteLine($"Title: {title}");

            foreach (var header in headers)
            {
                var value = string.Join(" ", header.Value);
                WriteLine($"Header: {header.Key} Value: {value}");
            }

            WriteLine();
        }

        public static async void AsyncGetRequestWithCustomHandler()
        {
            try
            {
                using (var client = new HttpClient(new CustomMessageHandler("error")))
                {
                    ShowHeaders("Request Headers", client.DefaultRequestHeaders);

                    var response = await client.GetAsync(NorthwindURL);
                    response.EnsureSuccessStatusCode();

                    ShowHeaders("Response Headers", response.Headers);
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static async void CreatingHttpReqMsgUsingSendAsync()
        {
            using (var client = new HttpClient())
            {
                //Any http verbs can be used, e.g. Get, Post, Delete, Put etc.
                var reqMsg = new HttpRequestMessage(HttpMethod.Get, NorthwindURL);

                var response = await client.SendAsync(reqMsg);
                response.EnsureSuccessStatusCode();

                WriteLine($"Status Code: {response.StatusCode} {response.ReasonPhrase}");

                string responseText = await response.Content.ReadAsStringAsync();
                WriteLine($"Recieved payload {responseText.Length} characters.");

                WriteLine();
                WriteLine(responseText);
            }
        }

        public static void ShowURLDetail()
        {
            URLDetails(NorthwindURL);
        }

        private static void URLDetails(string url)
        {
            var page = new Uri(url);

            WriteLine($"Scheme:{page.Scheme}");

            //#if NET46
            WriteLine($"Host: {page.Host}, Type: {page.HostNameType}");
            WriteLine($"IdnHost: {page.IdnHost}");
            WriteLine($"Port: {page.Port}");
            WriteLine($"AbsolutePath: {page.AbsolutePath}");
            WriteLine($"Querystring: {page.Query}");

            foreach (var segment in page.Segments)
            {
                WriteLine($"Segment: {segment}");
            }

            WriteLine($"AbsoluteUri: {page.AbsoluteUri}");
            WriteLine($"Authority: {page.Authority}");
            WriteLine($"DnsSafeHost: {page.DnsSafeHost}");
            WriteLine($"Fragment: {page.Fragment}");
            WriteLine($"IsDefaultPort: {page.IsDefaultPort}");
            WriteLine($"IsAbsoluteUri: {page.IsAbsoluteUri}");
            WriteLine($"IsFile: {page.IsFile}");
            WriteLine($"IsLoopback: {page.IsLoopback}");
            WriteLine($"LocalPath: {page.LocalPath}");
            WriteLine($"OriginalString: {page.OriginalString}");
            WriteLine($"PathAndQuery: {page.PathAndQuery}");
            WriteLine($"UserInfo: {page.UserInfo}");
        }

        public static void BuildURLExample()
        {
            var builder = new UriBuilder
            {
                Host = "www.cninnovation.com",
                Port = 80,
                Path = "training/MVC"
            };

            var url = builder.Uri;
            WriteLine(url);
        }

        public static void IPAddressExample()
        {
            WriteLine("Example 1:\n");
            ShowIPAddressDetail("137.117.17.70");

            WriteLine("\n\nExample 2:\n");
            ShowIPAddressDetail("65.52.128.33");

            WriteLine("\n\nExample 2:\n");
            ShowIPAddressDetail("127.0.0.1");
        }

        private static void ShowIPAddressDetail(string ipAddressString)
        {
            IPAddress address;
            if (!IPAddress.TryParse(ipAddressString, out address))
            {
                WriteLine($"{ipAddressString} cannot be parsed.");
                return;
            }

            var bytes = address.GetAddressBytes();
            for (int i = 0; i < bytes.Length; i++)
            {
                WriteLine($"byte {i}: {bytes[i]}");
            }

            WriteLine($"Family: {address.AddressFamily}, Map to IPV4: {address.MapToIPv4()}, Map to IPV6: {address.MapToIPv6()}");
            WriteLine($"IsIPv4MappedToIPv6: {address.IsIPv4MappedToIPv6}");
            WriteLine($"IsIPv6LinkLocal: {address.IsIPv6LinkLocal}");
            WriteLine($"IsIPv6Multicast: {address.IsIPv6Multicast}");
            WriteLine($"IsIPv6SiteLocal: {address.IsIPv6SiteLocal}");
            WriteLine($"IsIPv6Teredo: {address.IsIPv6Teredo}");
            //WriteLine($"ScopeId: {address.ScopeId}");

            WriteLine("\n\nSpecial Properties\n\n");
            WriteLine($"IPAddress.Any: {IPAddress.Any}");
            WriteLine($"IPAddress.Broadcast: {IPAddress.Broadcast}");
            WriteLine($"IPAddress.IPv6Any: {IPAddress.IPv6Any}");
            WriteLine($"IPAddress.IPv6Loopback: {IPAddress.IPv6Loopback}");
            WriteLine($"IPAddress.IPv6None: {IPAddress.IPv6None}");
            WriteLine($"IPAddress.Loopback: {IPAddress.Loopback}");
            WriteLine($"IPAddress.None: {IPAddress.None}");
        }

        public static void GetHostEntryAsyncExample()
        {
            do
            {
                WriteLine("Hostname:\t");
                var hostname = ReadLine();

                if (hostname.CompareTo("exist") == 0)
                {
                    WriteLine("bye!");
                    return;
                }

                OnLookupAsync(hostname).Wait();

                WriteLine();
            } while (true);
        }

        private static async Task OnLookupAsync(string hostname)
        {
            try
            {
                IPHostEntry ipHost = await Dns.GetHostEntryAsync(hostname);
                WriteLine($"Hostname: {ipHost.HostName}");

                foreach (var ipAddress in ipHost.AddressList)
                {
                    WriteLine($"Address Family: {ipAddress.AddressFamily}");
                    WriteLine($"IP Address: {ipAddress}");
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}