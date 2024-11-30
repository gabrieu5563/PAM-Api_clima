namespace Api_Clima.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.WeatherViewModel();
	}
}