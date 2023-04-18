using Cadastro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cadastro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel
            )
        {
            InitializeComponent();

            viewModel.Navigation = Navigation;
            BindingContext = viewModel;

            ItemsListView.PessoaSelected += (s, e) => ItemsListView.SelectedPessoa = null;

        }
    }
}
