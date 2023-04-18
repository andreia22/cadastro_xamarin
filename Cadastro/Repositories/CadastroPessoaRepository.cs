using Cadastro.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


// classe que implementa os metodos da interface ITodoItem, alem de fazer a conexão com
// o banco de dados SQLite e criar uma tabela chamada TodoItems.db
namespace Cadastro.Repositories
{
    public class CadastroPessoaRepository : ICadastroPessoaRepository
    {

        private SQLiteAsyncConnection connection;

        private async Task CreateConnection()
        {
            if (connection != null)
                return;

            var documentPath =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            var databasePath =
                Path.Combine(documentPath, "CadastroPessoa.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<CadastroPessoa>();
            // aqui poderiamos acicionar quantas tabelas existisem
            // no modelo de nossa aplicação

            if(await connection.Table<CadastroPessoa>().CountAsync() == 0 )
            {
                await connection.InsertAsync(
                    new CadastroPessoa() {

                        FirstName = "Andreia",
                        LastName = "Pasqual",
                        BirthDate = "22-06-82",
                        Sex = "Femenino",
                        Street = "Rua João Contini",
                        Neighborhood = "Matriz",
                        Number = "145",
                        City = "Videira",
                        State = "Santa Catarina",
                        Country = "Brasil"
                    }
                );
            }
        }

 // eventos definidos no código anterior.Eles serão usados ​​para notificar
//assinantes de uma lista cujos itens foram atualizados ou adicionados.

        public event EventHandler<CadastroPessoa> OnPessoaAdded;
        public event EventHandler<CadastroPessoa> OnPessoaUpdate;

        public async  Task AddCadastro(CadastroPessoa pessoa)
        {
            await CreateConnection();
            await connection.InsertAsync( pessoa );
            OnItemAdded?.Invoke(this, pessoa);
        }

        public async Task AddOrUpdate(CadastroPessoa pessoa)
        {
            if(cadastro.Id == 0)
            {
                await AddPessoa(pessoa);

            }
            else
            {
                await UpdatePessoa(pessoa)
;            }
        }

        public void DeletePessoaById(int id)
        {
            connection.Delete<Pessoa>(id);
        }

        public async Task<List<Cadastro>> GetPessoa()
        {
            await CreateConnection();
            return await connection.Table<CadastroPessoa>().ToListAsync();

        }

        public async Task UpdateCadastro(CadastroPessoa pessoa)
        {
            await CreateConnection();
            await connection.UpdateAsync( pessoa );
            OnCadastroUpdate?.Invoke(this, pessoa);

        }
    }
}
