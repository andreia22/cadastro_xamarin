using System;
using System.Collections.Generic;
using System.Text;
using Cadastro.Models;
using Cadastro.Repositories;
using System.Windows.Input;
using Xamarin.Forms;
using Cadastro.ViewModels;

//ItemViewModel representa o item da lista de tarefas em uma exibição
//que pode ser usada para criar novos itens e editar itens existentes:
namespace Cadastro.ViewModels
{
    public class CadastroPessoaViewModel : ViewModel

    {
        private readonly CadastroPessoaRepository repository;

        public CadastroPessoa Pessoa { get; set; }

        public CadastroPessoaViewModel(CadastroRepository repository)
        {
            this.repository = repository;
         //   Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };


        }
        public ICommand Save => new Command(async () => { 

            await repository.AddOrUpdate(Pessoa);
            await Navigation.PopAsync();    



        } );
    }
}


/*
 O padrão é o mesmo das duas classes ViewModel anteriores:
Usamos injeção de dependência para passar a classe TodoItemRepository para o
Objeto ViewModel.
Usamos a herança da classe base ViewModel para adicionar os recursos comuns
definido pela classe base */