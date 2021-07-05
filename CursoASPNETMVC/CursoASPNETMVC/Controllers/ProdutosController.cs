﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CursoASPNETMVC.Context;
using CursoASPNETMVC.Models;

namespace CursoASPNETMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();
        private Produto produto;

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos =
                context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).
                OrderBy(n => n.Nome);

                return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome),
             "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome),
             "FabricanteId", "Nome");
            
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                context.Produtos.Add(produto);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
