using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class AddUpdateArtistList : ContentPage
{
	public AddUpdateArtistList(AddUpdateArtistViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
