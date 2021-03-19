using System;

namespace Catalogo
{
    public class Seriado : Entidadebase
    {
        private Genero Genero {get; set;}
        private string Nome {get; set;}
        private string Sinopse {get; set;}
        private int Ano_lançamento {get; set;}
        private bool Excluido {get; set;}

        public Seriado(int id, Genero genero, string nome, string sinopse, int ano_lançamento)
        {
            this.id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Sinopse = sinopse;
            this.Ano_lançamento = ano_lançamento;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string certo = "";
            certo += "Gênero: "+this.Genero+Environment.NewLine; 
            certo += "Nome: "+this.Nome+Environment.NewLine; 
            certo += $"Sinopse: {this.Sinopse}" + Environment.NewLine; 
            certo += "Ano de Lançamento: "+this.Ano_lançamento+Environment.NewLine; 
            certo += "Excluido: "+this.Excluido+"\n";
            return certo;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaid()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Exclue() 
        {
            this.Excluido = true;
        }

    }
}