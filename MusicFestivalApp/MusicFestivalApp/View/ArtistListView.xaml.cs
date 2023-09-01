using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class ArtistListView : ContentPage
{
    private ArtistListViewModel _viewModel;

    public ArtistListView(ArtistListViewModel viewModel)
	{
		InitializeComponent();
        //this.BindingContext = new ArtistListViewModel();
        //this.BindingContext = new FestivalListViewModel();
        _viewModel = viewModel;
        this.BindingContext = viewModel;

    }

  
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetArtistListCommand.Execute(null);
    }
}