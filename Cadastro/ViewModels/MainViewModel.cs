using Cadastro.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cadastro.Views;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using Caliburn.Micro; 
using SQLite;
using Cadastro.Models;

//MainViewModel é a classe ViewModel para a primeira exibição que é
//exibida para o utilizador.É responsável por fornecer dados e
//lógica a uma lista de itens de lista de tarefas.

//Herdamos da classe ViewModel para obter acesso à lógica compartilhada, como
//a interface INotifyPropertyChanged e o código de navegação comum.
//Todas as dependências de outras classes, como repositórios e serviços, são passadas
//por meio do construtor de ViewModel

namespace Cadastro.ViewModels
{
    public class MainViewModel : ViewModel 
    {
        private readonly CadastroPessoaRepository repository;

        public ObservableCollection<CadastroPessoaViewModel> Pessoa { get; set; }   

        public MainViewModel(CadastroPessoaRepository repository)

// Usamos uma chamada assíncrona para LoadData() como um ponto de entrada
// para inicializar o Classe ViewModel.
        {

            repository.OnPessoaAdded += (sender, pessoa) =>
            Items.Add(CreateCadastroPessoaViewModel(cadastro));

            repository.OnPessoaUpdate += (sender, pessoa) =>
                Task.Run(async () => await LoadData());

            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        public CadastroPessoaModel SelectedPessoa
        {
            get { return null; }
            set 
            {
                Device.BeginInvokeOnMainThread(async  () => await NavigateCadPessoa(value));
                RaisePropertyChanged(nameof(SelectedPessoa));   
            }
        }

        private async Task NavigateCadPessoa(CadastroPessoaViewModel pessoa)
        {
            if (pessoa == null)
            {
                return
            }

            var pessoaView = Resolver.Resolve<PessoaView>();
            // vm é a ViewModel
            var vm = pessoaView.BindingContext as PessoaViewModel;
            vm.Pessoa = pessoa.Pessoa;
            await Navigation.PushAsync(pessoaView);
        }

        private async Task LoadData()
        {
            var pessoa = await repository.GetPessoa();
            if (!ShowAll)
            {
                pessoa = pessoa.Where(x => x.Completed == false).ToList();
            }

            var pessoaViewModels = pessoa.Select(i => CreateCadastroPessoaViewModel(i) );
            Pessoa = new ObservableCollection<CadastroPessoaViewModel>(cadastroPessoaViewModels);  

        }
        private CadastroPessoaViewModel CreateCadastroPessoaViewModel(CadastroPessoa pessoa)
        {
            var pessoaViewModel = new CadastroPessoaViewModel(pessoa);
            cadastroViewModel.pessoaStatusChanged += PessoaStatusChanged;
            return cadastroViewModel;

        }

        private void PessoaStatusChanged(object sender, EventArgs e)
        {
            if (sender is CreateCadastroPessoaViewModel pessoaViewModel)
            {
                if (!ShowAll && pessoa.Pessoa.Completed)
                {
                    Pessoa.Remove(pessoa);
                }
                Task.Run(async() =.await repository.UpPessoa(pessoa.Pessoa));
            }

        }
        public bool ShowAll { get; set; }

        public string FilterText => ShowAll ? "Todos" : "Ativos";

        public ICommand ToggleFilter => new ICommand(
            async () =>
            {
                ShowAll = !ShowAll;
                await LoadData();
            }
        );
        // Evento de click do botao para acicionar pessoa

        public ICommand AddPessoa => new Command(async () =>
        {
            var pessoaView = Resolver.Resolve<PessoaView>();
            await Navigation.PushAsync(pessoaView);

        });
    }
}
