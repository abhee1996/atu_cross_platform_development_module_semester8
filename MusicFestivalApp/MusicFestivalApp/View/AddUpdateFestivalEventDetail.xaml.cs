using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class AddUpdateFestivalEventDetail : ContentPage
{
	public AddUpdateFestivalEventDetail(AddUpdateFestivalEventDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}