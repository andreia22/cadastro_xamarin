using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

//A classe ViewModel é uma classe base para todos os objetos ViewModel. Não é para ser
//instanciado por conta própria, então o marcamos como abstrato. ele implementa
//INotifyPropertyChanged, que é uma interface definida em System.ComponentModel

namespace Cadastro.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {

// PropertyChangedevento.Nossa classe ViewModel deve gerar este evento
// sempre que quisermos que a GUI esteja cientede qualquer alteração em umapropriedade
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CadastroPessoaViewModel> Pessoa { get; set; }

        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

//usaremos um pequeno atalho aqui adicionando uma propriedade INavigation a ViewModel.
//Isso nos ajudará com a navegação mais tarde
        public INavigation Navigation { get; set; }
    }
}
