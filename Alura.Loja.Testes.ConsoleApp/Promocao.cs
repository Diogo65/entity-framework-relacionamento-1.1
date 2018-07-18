
using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        //deve ser criado uma chave primaria composta, na classe LojaContext
        public int Id { get; set; }
        public DateTime DataInicio { get; internal set; }
        public string Descricao { get; internal set; }
        public DateTime DataTermino { get; internal set; }
        private IList<PromocaoProduto> Produtos { get; set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        internal void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}
