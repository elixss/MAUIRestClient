using SimpleRestClient.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleRestClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}


