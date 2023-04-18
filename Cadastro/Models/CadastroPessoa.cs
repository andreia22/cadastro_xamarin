using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace Cadastro.Models
{
    public  class CadastroPessoa

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public  string BirthDate { get; set; }

        public string Sex { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }


        

    }
}
