using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Relacionamento muitos para muitos e a classe de join
            //Um produto pode estar associado a N Promoções
            //Promocao(N) - Produtos(N)
            //PromocaoProduto (Join)
            //
            //
            //é necessário criar IList<PromocaoProduto> na Tabela Produto e Promocao
            //
            //Mapear Chave Primária composta:
            //Para a chave primária da tabela PromocaoProduto, é necessário criá-la em LojaContext

            var p1 = new Produto() { Nome = "Suco de Fruta", Categoria = "Bebida", PrecoUnitario = 8, Unidade = "Litros"};
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebida", PrecoUnitario = 10, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrao", Categoria = "Alimentos", PrecoUnitario = 14, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            //Inserindo objetos relacionados
            using (var contexto = new LojaContext())
            {
                contexto.Promocoes.Add(promocaoDePascoa);
                contexto.SaveChanges();
            }
        }
    }
}
