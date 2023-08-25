using ControledePet.Data;
using ControledePet.Models;
using ControledePet.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControledePet.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetRepositorio _petRepositorio;
        public PetController(IPetRepositorio petRepositorio)
        {
            _petRepositorio = petRepositorio;
        }
        public IActionResult Index()
        {
           List<PetModel> pets = _petRepositorio.BuscarTodos();
            return View(pets);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar (int id)
        {
           PetModel model = _petRepositorio.listarporid(id);
            return View(model);
        }
        public IActionResult ApagarConfirmar()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(PetModel pet)
        {
            _petRepositorio.Adicionar(pet);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Alterar(PetModel pet)
        {
            _petRepositorio.Atualizar(pet);
            return RedirectToAction("index");
        }

    }
}
