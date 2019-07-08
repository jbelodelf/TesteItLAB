using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.ItLAB.Bussines.Interface;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.WebAplication.Models;

namespace Teste.ItLAB.WebAplication.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ITipoProdutoBussines _tipoBussines;
        private readonly IProdutoBussines _produtoBussines;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoBussines produtoBussines, ITipoProdutoBussines tipoBussines, IMapper mapper)
        {
            _produtoBussines = produtoBussines;
            _tipoBussines = tipoBussines;
            _mapper = mapper;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var comboTipos = new List<SelectListItem>();
            var tipoProdutos = _tipoBussines.GetTiposProdutos().ToList();
            foreach (var item in tipoProdutos.OrderBy(t => t.NOME))
            {
                var comboTipo = new SelectListItem()
                {
                    Value = item.ID.ToString(),
                    Text = item.NOME,
                    Selected = false
                };
                comboTipos.Add(comboTipo);
            }
            ViewBag.ComboTipos = comboTipos;

            return View();
        }

        // GET: Produto
        public ActionResult ListarProdutos()
        {
            List<ProdutoViewModel> produtoView = new List<ProdutoViewModel>();
            try
            {
                var produto = _produtoBussines.GetProdutos();
                produtoView = _mapper.Map<List<ProdutoViewModel>>(produto);
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Error");
            }
            return PartialView("~/Views/Produto/_ListarProdutos.cshtml", produtoView);
        }

        // GET: Produto
        public ActionResult ChecarDuplicidade(string Nome)
        {
            bool retorno = false;
            string massage = "";

            try
            {
                var produtoDTO = _produtoBussines.GetProduto(Nome);
                if(produtoDTO != null)
                {
                    massage = "Esse produto já existe!!!";
                    retorno = true;
                }
            }
            catch (Exception)
            {
                massage = " Erro ao tentar buscar o produto";
            }
            return Json(new { retorno = retorno, mensagem = massage });
        }

        // GET: Produto
        public ActionResult EditarProduto(int Id)
        {
            ProdutoViewModel produtoView = null;
            try
            {
                var produto = _produtoBussines.GetProduto(Id);
                produtoView = _mapper.Map<ProdutoViewModel>(produto);
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(new { retorno = "Ok", Produto = produtoView });
        }

        // GET: Produto
        [HttpPost]
        public ActionResult Salvar(ProdutoViewModel produto)
        {
            bool retorno = false;
            string massage = "";

            try
            {
                if (produto.ID > 0)
                {
                    ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produto);
                    retorno = _produtoBussines.UpdateProduto(produtoDTO);
                    massage = "Produto salvo com sucesso";
                }
                else
                {
                    produto.DATACADASTRO = DateTime.Now;
                    ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produto);
                    retorno = _produtoBussines.AddProduto(produtoDTO);
                    massage = "Produto salvo com sucesso";
                }
            }
            catch (Exception)
            {
                massage = " Erro ao tentar salvar o produto";
            }
            return Json(new { retorno = retorno, mensagem = massage });
        }

        // GET: Produto
        public ActionResult DeletarProduto(int Id)
        {
            bool retorno = false;
            string massage = "";

            try
            {
                _produtoBussines.DeleteProduto(Id);

                massage = "Produto deletado com sucesso";
                retorno = true;
            }
            catch (Exception)
            {
                massage = " Erro ao tentar deletar o produto";
            }
            return Json(new { retorno = retorno, mensagem = massage });
        }
    }
}