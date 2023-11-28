using Example22.Domain.Models;
using System.Text.Json;

namespace Example22.App {
    public partial class MainPage : ContentPage {

        // ASYNCHRONOUS PROGRAMMING:
        //
        // Synchronous programming is useful when the program does not need
        // asynchronous access to external resources.
        //
        // There are times, however, when access to these resources are necessary.
        // For example, when reaching a Web API, or a database, it may take a few miliseconds
        // (or even seconds) for the request to come back with a response.
        //
        // In these situations, applications may become unresponsive while it waits for the response
        // to come back with a result.
        //
        // The best approach for this scenario is asynchronous programming. It will allow
        // the application to retain control, while delegating operations that may take a "long"
        // time, for example, to a background thread. As a result, the process caller retains
        // control, and the application remains responsive the entire time.
        //
        // HTTP requests are a typical example of an asynchronous process, as a client that
        // sends a requests to a server may have to wait several miliseconds until a response
        // is received.

        public MainPage() {
            InitializeComponent();
        }

        private async void OnSendClicked(object sender, EventArgs e) {
            this.txtResult.Text = "Fetching users from web...";

            // Creating an HTTP request:
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("https://jsonplaceholder.org/users");

            // Creating an HTTP client to send the request:
            HttpClient client = new HttpClient();

            // Retrieving a response:
            // Since this operation can take a "long" time, we instruct the application
            // to "await" a response.
            HttpResponseMessage response = await client.SendAsync(request);

            // Parsing response into objects:
            string json = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(json);

            this.txtResult.Text = string.Join(Environment.NewLine, users);
        }
    }
}