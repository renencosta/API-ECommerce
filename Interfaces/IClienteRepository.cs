﻿using API_ECommerce.DTO;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {   
        //Ler
        List<ListarClienteViewodel> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha (string email, string senha);
        
        //Criar
        void Cadastrar(CadastrarClienteDto cliente);

        //Atualizar
        void Atualizar(int id, Cliente cliente);

        //Deletar
        void Deletar (int id);

        List<Cliente> BuscarClientePorNome(string nome);
    }
}
