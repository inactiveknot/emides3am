using ControledePet.Data;
using ControledePet.Models;
using ControledePet.Repositorio;

namespace ControledePet.PetRepositorio
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PetRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<PetModel> BuscarTodos()
        {
            return _bancoContext.Pets.ToList();
        }
        public PetModel Adicionar(PetModel pet)
        {
            _bancoContext.Pets.Add(pet);
            _bancoContext.SaveChanges();
            return pet;
        }

        public PetModel listarporid(int id)
        {
            return _bancoContext.Pets.FirstOrDefault(x => x.Id == id);

        }

        public PetModel Atualizar(PetModel pet)
        {
            PetModel petDB = listarporid(pet.Id);
            if (petDB == null) throw new System.Exception("Houve um erro ao atualizar");

            petDB.Nome = pet.Nome;
            petDB.Genero = pet.Genero;
            petDB.Raca = pet.Raca;

            _bancoContext.Pets.Update(petDB);
            _bancoContext.SaveChanges();

            return petDB;
        }
    }
}

