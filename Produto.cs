using System;
using System.Globalization;
using System.Collections.Generic;

namespace Estoque
{
    internal class Produto
    {
        public string Ean { get; private set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(string ean, double quantidade, double preco)
        {
            Ean = ean;
            Quantidade = quantidade;
            Preco = preco;
        }

        public Produto(double quantidade, double preco)
        {
            Quantidade = quantidade;
            Preco = preco;
        }

        public void AlterarEstoque(double quantidade)
        {
            Quantidade += quantidade;
        }

        public void AtualizarRegistro(double quantidade, double preco)
        {
            Quantidade = quantidade;
            Preco = preco;
        }

        public double CalcularPrecoEstoque()
        {
            return Quantidade * Preco;
        }

        public override string ToString()
        {
            return $"EAN: {Ean}\n" +
                $"Quantidade: {Quantidade.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Preço: R$ {Preco.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Valor do estoque: R$ {CalcularPrecoEstoque().ToString("F2", CultureInfo.InvariantCulture)}\n";
        }
    }
}
