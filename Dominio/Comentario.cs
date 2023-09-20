namespace Dominio
{
    public class Comentario : Publicacion
    {
        private int _idPost;
        public Comentario(int idPost, Miembro autor,string titulo, string texto) : base(autor, texto, titulo)
        {
            this._idPost = idPost;
        }

        public int GetIdPost()
        {
            return this._idPost;
        }

        public override string ToString()
        {
            return $"Id: {this.GetId()} {Environment.NewLine}Autor: {this.GetAutorNombre()} {Environment.NewLine}Texto: {this.GetTexto()} {Environment.NewLine}Fecha: {this.GetFechaString()} {Environment.NewLine}";
        }
    }
}