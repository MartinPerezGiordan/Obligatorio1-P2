namespace Dominio
{
    public class Comentario : Publicacion
    {
        public int IdPost { get; set; }
        public Comentario(int idPost, Miembro autor,string titulo, string texto) : base(autor, texto, titulo)
        {
            this.IdPost = idPost;
        }

        public override string ToString()
        {
            return $"Id: {this.IdPost} {Environment.NewLine}Autor: {this.Autor.Nombre} {Environment.NewLine}Texto: {this.Texto} {Environment.NewLine}Fecha: {this.Fecha.ToString()} {Environment.NewLine}";
        }
    }
}