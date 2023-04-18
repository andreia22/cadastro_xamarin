using Cadastro.Models;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;


//TodoItemViewModel é a classe ViewModel que representa cada item na lista de tarefas
//no MainView. Ele não tem uma visão inteira própria (embora pudesse ter), mas é
//em vez disso, renderizado por um modelo em ListView
namespace Cadastro.ViewModels

//passamos uma instância da classe TodoItem para o construtor que
//o objeto ViewModel usará para expor à exibição.
//O manipulador de eventos ItemStatusChanged será usado posteriormente quando quisermos sinalizar para o
//veja que o estado da classe TodoItem foi alterado.
{
    public class CadastroPessoaViewModel : ViewModel
    {

// A propriedade Item nos permite acessar o item que passamos
        public CadastroPessoa Pessoa { get; private set; } 
        
        public CadastroPessoaViewModel(CadastroPessoa pessoa) => Pessoa = pessoa;

        public event EventHandler PessoaStatusChanged;

//A propriedade StatusText é usada para tornar o status do item de tarefa legível em
//a vista.
        public string StatusText => (Pessoa.Completed ? "Reativar" : " Completo");

       

    }
}
