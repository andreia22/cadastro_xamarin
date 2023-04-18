using Autofac;


// O resolvedor é responsável por criar objetos para nós com base no tipo que
// solicitamos.
//Vamos criar o resolvedor:
namespace Cadastro
{
    public static class Resolver
    {
        private static IContainer container;

        public static void Initialize(IContainer container)
        {
            Resolver.container = container;

            
        }
        public static T Resolve<T>()
        {
            return container.Resolve<T>();

        }

    }
}
//O método Resolve usa a propriedade container para resolver um
//tipo para uma instância de um objeto. Embora possa parecer estranho
//usar isso no começo,tornar-se muito mais fácil com a experiência.
