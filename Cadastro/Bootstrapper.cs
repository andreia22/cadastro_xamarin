using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Cadastro.Views;
using Cadastro.ViewModels;
using Cadastro.Repositories;

//A responsabilidade do bootstrapper é inicializar o Autofac.
//É chamado na inicialização do aplicativo.
namespace Cadastro
{
    public abstract class Bootstrapper
    {

        protected ContainerBuilder ContainerBuilder

        {  get;  private set; }

        protected Bootstrapper()
        {

            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            var assemblyList =
                currentAssembly.DefinedTypes
                .Where( e => e.IsSubclassOf(typeof(Page)) || 
                             e.IsSubclassOf(typeof(ViewModel)) );

            foreach ( var type in assemblyList ) 
            {
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<CadastroPessoaRepository>()
                .SingleInstance();

            // esta operação sera executada para todo e qualquer classe de objeto que sejá necesssaria a inclusao para consulmo via ingeção de dependencia
                
            
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }

    }
}

/*A classe Bootstrapper é implementada por cada plataforma, pois é onde a execução
/do aplicativo começa. Isso também nos dá a opção de adicionar configurações específicas da plataforma. Para
garantir que herdamos da classe, nós a definimos como abstrata.
ContainerBuilder é uma classe definida no Autofac que se encarrega de criar o
container propriedade para nós depois que terminarmos a configuração. O edifício do
propriedade container acontece no método FinishInitialization definido no final
e é chamado pelo construtor logo após chamarmos o método virtual Initialize. Pudermos
substitua o método Initialize para adicionar registros personalizados a cada plataforma.
O método Initialize examina o assembly usando reflexão para quaisquer tipos que herdam
de Page ou ViewModel e os adiciona à propriedade do contêiner. Ele também adiciona o
Propriedade TodoItemRepository como um singleton para a propriedade container. Isso significa que
cada vez que solicitamos TodoItemRepository, obtemos a mesma instância. O padrão
comportamento para Autofac (isso pode variar entre bibliotecas) é dar uma nova instância para cada
resolução.

 
 o padrão de injeção de dependência, que afirma que todas as dependências,
como repositórios e modelos de exibição, devem ser passados ​​pelo construtor do
aula. Isso tem vários benefícios:
Aumenta a legibilidade do código, pois podemos determinar rapidamente todos os
dependências externas.
Isso torna possível a injeção de dependência.
Ele possibilita o teste de unidade simulando classes.
Podemos controlar o tempo de vida de um objeto especificando se ele deve ser um
singleton ou uma nova instância para cada resolução.
 */