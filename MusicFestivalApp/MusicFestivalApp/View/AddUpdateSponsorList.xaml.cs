using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class AddUpdateSponsorList : ContentPage
{
	public AddUpdateSponsorList(AddUpdateSponsorViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
   
}