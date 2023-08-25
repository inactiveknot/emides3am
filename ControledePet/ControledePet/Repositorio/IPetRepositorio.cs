using ControledePet.Models;

namespace ControledePet.Repositorio
{
    public interface IPetRepositorio
    {
        PetModel listarporid(int id);
        List<PetModel> BuscarTodos();

        PetModel Adicionar(PetModel pet);
        
        PetModel Atualizar(PetModel pet);
    }
}
