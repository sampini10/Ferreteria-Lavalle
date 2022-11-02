using BE_Ferreteria.Data.Interfaces;
using BE_Ferreteria.Data.Services;
using BE_Ferreteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace BE_Ferreteria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticuloController : Controller
    {

        private IArticuloRepository _articuloRepository;

        public ArticuloController(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        [HttpPost("GuardarArticulo")]
        public Respuesta GuardarArticulo(Articulo articulo)

        {
            Respuesta itemRespuesta = new Respuesta();
            
            try
            {
                bool resultado = _articuloRepository.CreateArticulo(articulo);
                itemRespuesta.Status = 200;
                itemRespuesta.Message = "";
                itemRespuesta.Data = resultado;
                itemRespuesta.Parameters = JsonSerializer.Serialize(articulo);
                itemRespuesta.Function = "GuardarArticulo";
            }
            catch (Exception msj)
            {
                itemRespuesta.Status = 500;
                itemRespuesta.Message = msj.Message;
                itemRespuesta.Data = null;
                itemRespuesta.Parameters = JsonSerializer.Serialize(articulo);
                itemRespuesta.Function = "GuardarArticulo";

            }

            return itemRespuesta;
        }
        [HttpGet("ObtenerArticulo")]
        public Respuesta ObtenerArticulo(int id)
        {
            Respuesta itemRespuesta = new Respuesta();
            Articulo articulo = new Articulo();
            try
            {
                articulo = _articuloRepository.GetArticuloDetails(id);
                itemRespuesta.Status = 200;
                itemRespuesta.Message = "";
                itemRespuesta.Data = true;
                itemRespuesta.Parameters = JsonSerializer.Serialize(articulo);
                itemRespuesta.Function = "ObtenerArticulo";
            }
            catch (Exception msj)
            {
                itemRespuesta.Status = 500;
                itemRespuesta.Message = msj.Message;
                itemRespuesta.Data = null;
                itemRespuesta.Parameters = null;
                itemRespuesta.Function = "ObtenerArticulo";

            }
            return itemRespuesta;
        }
        [HttpPut("UpdateArticulo")]
        public Respuesta UpdateArticulo(Articulo articulo)
        {
            Respuesta itemRespuesta = new Respuesta();
            try
            {
                bool resultado = _articuloRepository.UpdateArticulo(articulo);
                itemRespuesta.Status = 200;
                itemRespuesta.Message = "";
                itemRespuesta.Data = resultado;
                itemRespuesta.Parameters = JsonSerializer.Serialize(articulo);
                itemRespuesta.Function = "UpdateArticulo";
            }
            catch (Exception msj)
            {
                itemRespuesta.Status = 500;
                itemRespuesta.Message = msj.Message;
                itemRespuesta.Data = null;
                itemRespuesta.Parameters = JsonSerializer.Serialize(articulo);
                itemRespuesta.Function = "UpdateArticulo";

            }

            return itemRespuesta;
        }
        [HttpDelete("DeleteArticulo")]
        public Respuesta DeleteArticulo(int id)
        {
            Respuesta itemRespuesta = new Respuesta();
            try
            {
                bool resultado = _articuloRepository.DeleteArticulo(id);
                itemRespuesta.Status = 200;
                itemRespuesta.Message = "";
                itemRespuesta.Data = resultado;
                itemRespuesta.Parameters = JsonSerializer.Serialize(id);
                itemRespuesta.Function = "DeleteArticulo";
            }
            catch (Exception msj)
            {
                itemRespuesta.Status = 500;
                itemRespuesta.Message = msj.Message;
                itemRespuesta.Data = null;
                itemRespuesta.Parameters = JsonSerializer.Serialize(id);
                itemRespuesta.Function = "DeleteArticulo";

            }

            return itemRespuesta;
        }
        [HttpGet("ObtenerArticuloList")]
        public Respuesta GetAllArticuloDetails()
        {
            Respuesta itemRespuesta = new Respuesta();
            List<Articulo> listArticulo = new List<Articulo>();
            try
            {
                listArticulo = _articuloRepository.GetAllArticuloDetails();
                itemRespuesta.Status = 200;
                itemRespuesta.Message = "";
                itemRespuesta.Data = true;
                itemRespuesta.Parameters = JsonSerializer.Serialize(listArticulo);
                itemRespuesta.Function = "ObtenerArticulo";
            }
            catch (Exception msj)
            {
                itemRespuesta.Status = 500;
                itemRespuesta.Message = msj.Message;
                itemRespuesta.Data = null;
                itemRespuesta.Parameters = null;
                itemRespuesta.Function = "ObtenerArticulo";

            }
            return itemRespuesta;
        }





    }
}
