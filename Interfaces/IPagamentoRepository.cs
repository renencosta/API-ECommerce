using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPagamentoRepository
    {
        //Ler
        List<Pagamento> ListarTodos();
        Pagamento BuscarPorId(int id);

        //Criar
        void Cadastrar(Pagamento pagamento);

        //Atualizar
        void Atualizar(int id, Pagamento pagamento);

        //Deletar
        void Deletar(int id);
    }
}
