using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class SponsorsListView : ContentPage
{
    private SponsorsListViewModel _viewModel;

    public SponsorsListView(SponsorsListViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }
  //  public async void Button_Sponsors1(object sender, EventArgs e)
  //  {
		//await Navigation.PopAsync();
  //  }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetSponsorsListCommand.Execute(null);
    }

}

