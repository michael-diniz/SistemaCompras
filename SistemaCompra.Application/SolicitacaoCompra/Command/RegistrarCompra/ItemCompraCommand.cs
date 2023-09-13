using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class ItemCompraCommand
    {
        public Guid ProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
    }
}
