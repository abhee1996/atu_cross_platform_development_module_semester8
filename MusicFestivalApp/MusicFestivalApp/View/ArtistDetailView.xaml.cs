using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class ArtistDetailView : ContentPage
{
	public ArtistDetailView()
	{
		InitializeComponent();
		this.BindingContext = new ArtistDetailViewModel();

    }
}