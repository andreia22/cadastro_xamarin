using Cadastro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Cadastro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PessoaView : ContentPage
    {
        public PessoaView(CadastroViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}