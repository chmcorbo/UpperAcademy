using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Web.Models;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Persistence.nHibernate.Servicos;

namespace UpperAcademy.Web.Controllers
{
    public class TurmaController : Controller
    {
        //
        // GET: /Turma/

        private RepositorioGenerico<Turma> repositorioTurma = new RepositorioGenerico<Turma>();
        private RepositorioAluno repositorioAluno = new RepositorioAluno();
        private RepositorioProfessor repositorioProfessor = new RepositorioProfessor();


        private void CarregarListaDeNiveis(Turma pTurma)
        {
            UpperAcademy.Dominio.Servicos.ServListaFixaNivel servListaFixaNivel = new Dominio.Servicos.ServListaFixaNivel();
            Int32 co = 1;
            IEnumerable<SelectListItem> niveis = servListaFixaNivel.Listar().Select(n =>
                new SelectListItem
                {
                    Selected = (pTurma.Nivel == co),
                    Value = co++.ToString(),
                    Text = n
                });
            ViewBag.ListaNiveis = niveis;
        }

        private Int16 ObterNivelSelecionado(FormCollection pForm)
        {
            Int16 resultado = 1;
            String _nivelSelecionado = pForm["ListaNiveis"];
            if (_nivelSelecionado != String.Empty)
            {
                Int16 idNivel = Int16.Parse(_nivelSelecionado);
                resultado = idNivel;
            }
            return resultado;
        }

        public ActionResult Listar()
        {
            return View(repositorioTurma.ListarTudo());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            Turma turma = new Turma();
            CarregarListaDeNiveis(turma);
            return View(turma);
        }

        [HttpPost]
        public ActionResult Adicionar(Turma turma, FormCollection form)
        {
            turma.Nivel = ObterNivelSelecionado(form);
            repositorioTurma.Adicionar(turma);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            Turma turma = repositorioTurma.ObterPorID(ID.ToString());
            CarregarListaDeNiveis(turma);
            Session.Add("turma", turma);
            return View("Editar", turma);
        }

        [HttpPost]
        public ActionResult Editar(Turma turma, FormCollection form)
        {
            turma.Nivel = ObterNivelSelecionado(form);
            repositorioTurma.Atualizar(turma);
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(Guid ID)
        {
            Turma turma = repositorioTurma.ObterPorID(ID.ToString());

            repositorioTurma.Excluir(turma);

            return RedirectToAction("Listar");
        }

        public ActionResult Detalhar(Guid ID)
        {
            Turma turma = repositorioTurma.ObterPorID(ID.ToString());

            return View("Detalhar", turma);
        }

        

        //* Métodos usados na matrícula de alunos

        [HttpGet]
        public ActionResult ListarAlunos()
        {
            TurmaViewModel turmaViewModel = new TurmaViewModel();
            turmaViewModel.Turma = (Turma)Session["turma"];
            return View(turmaViewModel);
        }

        [HttpPost]
        public ActionResult ListarAlunos(TurmaViewModel pTurmaViewModel)
        {
            // Refatorar. Verificar se tem alguma forma de recuperar a turma por meio dos métodos get ou post do html. Assim não necessitaria guardar na seção.
            pTurmaViewModel.Turma = (Turma)Session["turma"];
            // Refatorar. Toda hora um typecast de ToList()? Não tem outra forma?
            pTurmaViewModel.ListaAlunos = repositorioAluno.ListarPorNomeExcetoMatriculadoTurma(pTurmaViewModel.NomePesquisa, pTurmaViewModel.Turma).ToList();
            return View(pTurmaViewModel);
        }


        public ActionResult MatricularAluno(Guid ID)
        {
            Turma turma = (Turma)Session["turma"];
            Aluno alunoSelecionado = repositorioAluno.ObterPorID(ID.ToString());

            if (alunoSelecionado != null)
            {
                ServMatricularAluno servMatricularAluno = new ServMatricularAluno();
                servMatricularAluno.Executar(turma, alunoSelecionado);
            }
            TurmaViewModel turmaViewModel = new TurmaViewModel { NomePesquisa = "", Turma=turma, ListaAlunos = new List<Aluno>() };
            return View("ListarAlunos", turmaViewModel);
        }

        [HttpPost]
        public ActionResult FiltrarAlunos(String pNome)
        {
            Turma turma = (Turma)Session["turma"];
            
            TurmaViewModel turmaViewModel = new TurmaViewModel(){ 
                NomePesquisa=pNome, 
                Turma=turma, 
                ListaAlunos=repositorioAluno.ListarPorNomeExcetoMatriculadoTurma(pNome, turma).ToList()};
            
            return View("ListarAlunos",turmaViewModel);
        }

        public ActionResult CancelarMatricula(Guid ID)
        {
            Turma turma = (Turma)Session["turma"];
            Aluno aluno = turma.Alunos.Where(a => a.ID == ID.ToString()).FirstOrDefault();

        
            if (aluno != null)
            {
                turma.Alunos.Remove(aluno);
                repositorioTurma.Atualizar(turma);
            }

            return RedirectToAction("Editar", "Turma", new { ID = turma.ID });
        }
        //***** Fim ***
        //* Métodos usados na alocação de professores
        
        [HttpGet]
        public ActionResult ListarProfessores()
        {
            TurmaViewModel turmaViewModel = new TurmaViewModel();
            turmaViewModel.Turma = (Turma)Session["turma"];
            return View(turmaViewModel);
        }

        [HttpPost]
        public ActionResult ListarProfessores(TurmaViewModel pTurmaViewModel)
        {
            pTurmaViewModel.Turma = (Turma)Session["turma"];
            // Refatorar. Toda hora um typecast de ToList()? Não tem outra forma?
            pTurmaViewModel.ListaProfessores = repositorioProfessor.ListarPorNomeExcetoAlocadoTurma(pTurmaViewModel.NomePesquisa, pTurmaViewModel.Turma).ToList();
            return View(pTurmaViewModel);
        }


        public ActionResult AlocarProfessor(Guid ID)
        {
            // Refatorar - Verificar se não existe uma forma de trazer o objeto professor pelo método get ou post do Html. Desta forma, evitar de fazer a busca pelo id novamente.
            Turma turma = (Turma)Session["turma"];
            Professor professorSelecionado = repositorioProfessor.ObterPorID(ID.ToString());

            if (professorSelecionado != null)
            {
                ServAlocarProfessor servAlocarProfessor = new ServAlocarProfessor();
                servAlocarProfessor.Executar(turma, professorSelecionado);
            }
            TurmaViewModel turmaViewModel = new TurmaViewModel { NomePesquisa = "", Turma = turma, ListaProfessores = new List<Professor>() };
            return RedirectToAction("Editar","Turma", new {ID = turma.ID});
        }
    }
}
