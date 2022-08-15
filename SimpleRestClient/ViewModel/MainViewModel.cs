using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using System.Windows.Input;
namespace SimpleRestClient.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        // Defining some properties we're going to bind with the elements on the main window.

        [ObservableProperty]
        public int frameWidth;

        public int ButtonWidth
        {
            get
            {
#if !WINDOWS
                return this.frameWidth;
#elif WINDOWS
                return 230;
#endif
            }
        }

        private string _labelText = string.Empty;
        private bool _executed = false;
        public string LabelText
        {
            get => this._labelText;
            private set => this._labelText = value;
        }

        [ObservableProperty]
        public string requestUri;

        [RelayCommand]
        public async Task ExecuteRequest()
        {
            if (string.IsNullOrEmpty(requestUri))
            {
                return;
            }

            string result = await RequestHandler.GetRequest(this.RequestUri);
            this.LabelText = result;
            this._executed = true;
            this.OnPropertyChanged(nameof(LabelText));
        }

        [RelayCommand]
        public async Task CopyResponseToClipboard()
        {
            if (this._executed)
            {
                await Clipboard.SetTextAsync(this._labelText);
                App.alertService.ShowAlert("Info", "Text copied to clipboard.");
                return;
            }
            App.alertService.ShowAlert("Error", "No request has been made previously.");
        }
    }
}
