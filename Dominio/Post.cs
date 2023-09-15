﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio
{
    public class Post : Publicacion
    {

        #region Atributos

        private string _nombreImagen;
        private List<Comentario> _comentarios;
        private bool _privado;
        private bool _censurado;

        #endregion

        #region Constructor
        public Post(Miembro autor, string titulo, string texto, string nombreImagen, bool privado) : base(autor, texto, titulo)
        {

            this._privado = privado;
            this._censurado = false;
            this._comentarios = new List<Comentario>();
            this._nombreImagen = nombreImagen;

        }

        public Post(Miembro autor, string titulo, string texto, string nombreImagen, List<Comentario> comentarios) : base(autor,texto, titulo)
        {
            this._privado = false;
            this._censurado = false;
            this._comentarios = comentarios;
            this._nombreImagen = nombreImagen;
        }

        #endregion

        #region Get y Set

        
        public bool GetCensurado()
        {
            return this._censurado;
        }

        public bool GetPrivado()
        {
            return this._privado;
        }

        public List<Comentario> GetComentarios()
        {
            return this._comentarios;
        }

        public string GetNombreImagen()
        {
            return this._nombreImagen;
        }

        #endregion

        #region Metodos

        // Agregar Comentario al Post
        public void AgregarComentario(Comentario comentario)
        {
            if(this._censurado == false)
            {
                this._comentarios.Add(comentario);
            } else
            {
                throw new Exception("Post esta censurado");
            }
        }

        public void SetCensurado(bool censurar)
        {
            this._censurado = censurar;
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return $"Id: {this.GetId()} {Environment.NewLine}Autor: {this.GetAutorNombre()} {Environment.NewLine}Texto: {this.GetTexto()} {Environment.NewLine}Fecha: {this.GetFechaString()} {Environment.NewLine}Nombre Imagen: {this.GetNombreImagen()}{Environment.NewLine}";
        }

        #endregion
    }
}
