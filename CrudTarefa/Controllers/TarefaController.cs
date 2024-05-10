using Microsoft.AspNetCore.Mvc;
using CrudTarefa.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudTarefa.Controllers;

public class TarefaController : Controller

{
    private static List<Tarefa> _tarefa = new List<Tarefa>()
    {
        new Tarefa  { TarefaId = 1, NomeTarefa = "Separar ingredientes", Concluida = false },
        new Tarefa  { TarefaId = 2, NomeTarefa = "Fazer a massa", Concluida = false  },
        new Tarefa  { TarefaId = 3, NomeTarefa = "Colocar no forno" , Concluida = false},
        new Tarefa  { TarefaId = 4, NomeTarefa = "Decorar", Concluida = false  },
    };

    public IActionResult ToDo()
    {
        return View(_tarefa);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            tarefa.TarefaId = _tarefa.Count > 0 ? _tarefa.Max(c => c.TarefaId) + 1 : 1;

            _tarefa.Add(tarefa);
        }
        return RedirectToAction("ToDo");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    [HttpPost] //voltou a informação pra ficar editada ao clicarmos em salvar
    public IActionResult Edit(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            var existingTarefa = _tarefa.FirstOrDefault(c => c.TarefaId == tarefa.TarefaId);
            if (existingTarefa != null)
            {
                existingTarefa.NomeTarefa = tarefa.NomeTarefa;
            }
            return RedirectToAction("ToDo");
        }
        return View(tarefa);
    }

    public IActionResult Delete(int id)
    {
        //arrow function
        var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id); //FirstOrDefault "percorre" a lista
        if (tarefa == null)
        {
            return NotFound();
        }

        _tarefa.Remove(tarefa);
        return RedirectToAction("ToDo");
    }

    public IActionResult Details(int id)
    {

        var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    public IActionResult MarkAsCheck(int id)
    {

        var tarefa = _tarefa.Find(c => c.TarefaId == id);
        if (tarefa != null)
        {
            tarefa.Concluida = true;
        }

        return RedirectToAction("ToDo");
    }

    public IActionResult Checked()
    {
        var tarefasConcluidas = _tarefa.Where(t => t.Concluida).ToList();
        return View(tarefasConcluidas);
    }

}
