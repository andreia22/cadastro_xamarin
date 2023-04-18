using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cadastro.Models;
using SQLite;
using System.IO;


// interface que descreve um repositório para armazenar nossos itens de
// lista de tarefas, esta interface tem os metodos possiveis para
// pegar, acicionar, atualizar e adicionar ou atualizar esses metodos
// seram imprementadados na classe TodoItemRepository.cs, ela serve de isolamenmto
// e e passada como objeto para outras partes do aplicativo independente de como a 
// classe TodoItemRepositiry e imprementadada

namespace Cadastro.Repositories
{
    public interface ICadastroPessoaRepository
    {
 // Eventos que serão usados ​​para notificarassinantes de uma lista cujos itens
 // foram atualizados ou adicionados.

        event EventHandler<CadastroPessoa> OnPessoaAdded;
        event EventHandler<CadastroPessoa> OnPessoaUpdate;

        Task<List<Cadastro>> GetPessoa();

        Task AddCadastro(CadastroPessoa pessoa);

        Task DeleteByIdCadastro(CadastroPessoa pessoa);

        Task UpdateCadastro(CadastroPessoa pessoa);

        Task AddOrUpdate(CadastroPessoa pessoa);
    }
}
