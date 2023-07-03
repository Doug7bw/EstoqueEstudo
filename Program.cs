using System;
using System.Globalization;
using System.Collections.Generic;

namespace Estoque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos produtos serão registrados? ");
            int n = int.Parse(Console.ReadLine());

            List<Produto> lista = new List<Produto>(n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nRegistro #{i + 1}: ");

                Console.Write("Ean do produto: ");
                string ean = Console.ReadLine();
                Console.Write("Quantidade no estoque: ");
                double quantidade = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Valor do produto: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Produto itemEan = lista.Find(x => x.Ean == ean);

                if (itemEan == null)
                {
                    lista.Add(new Produto(ean, quantidade, preco));
                }
                else
                {
                    Console.Write("\nO produto já foi cadastrado! Deseja alterar seus dados? (s/n) ");
                    char attProduto = char.Parse(Console.ReadLine().ToLower());

                    if (attProduto == 's')
                    {
                        itemEan.AtualizarRegistro(quantidade, preco);
                        i -= 1;
                    }
                }
            }

            Console.WriteLine("\nProdutos cadastrados: \n");

            foreach (Produto item in lista)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nDeseja adicionar quantidade ao estoque de algum produto? (s/n) ");
            char attEstoque = char.Parse(Console.ReadLine().ToLower());

            while (attEstoque == 's')
            {
                Console.Write("Digite o EAN do produto: ");
                string buscarEan = Console.ReadLine();
                Produto encontrarEan = lista.Find(x => x.Ean == buscarEan);

                if (encontrarEan != null)
                {
                    Console.Write("\nDigite a quantidade: ");
                    double qtd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    encontrarEan.AlterarEstoque(qtd);

                    Console.WriteLine("Quantidade adicionada com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado!");
                }

                Console.Write("\nDeseja adicionar quantidade ao estoque de algum produto? (s/n) ");
                attEstoque = char.Parse(Console.ReadLine().ToLower());
            }

            Console.WriteLine("\nDados atualizados: ");

            foreach (Produto item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}