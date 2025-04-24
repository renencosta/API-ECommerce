namespace API_ECommerce.DTO
{
    public class CadastrarPagamentoDto
    {
        public string FormaPagamento { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime Data { get; set; }

        public int IdPedido { get; set; }   
    }
}
