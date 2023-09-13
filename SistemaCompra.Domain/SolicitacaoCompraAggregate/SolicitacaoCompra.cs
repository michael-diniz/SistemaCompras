using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra()
        { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            TotalGeral = new Money();
            Itens = new List<Item>();
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
            TotalGeral.Add(CalcularValor(produto.Preco.Value, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens.Sum(item => item.Qtde) <= 0) throw new BusinessRuleException("A solicitação de compra deve ter pelo menos um item.");

            CondicaoPagamento = (TotalGeral.Value > 50000) ? new CondicaoPagamento(30) : new CondicaoPagamento(0);

            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }

        private Money CalcularValor(decimal preco, int quantidade)
        {
            return new Money(preco * quantidade);
        }
    }
}