namespace Dominio
{
    public class Comentario : Publicacion
    {
        public Comentario(Miembro autor, string texto) : base(autor, texto)
        {
        }

        public override string ToString()
        {
            return $"Id: {this.GetId()} {Environment.NewLine}Autor: {this.GetAutorNombre()} {Environment.NewLine}Texto: {this.GetTexto()} {Environment.NewLine}Fecha: {this.GetFechaString()} {Environment.NewLine}{Environment.NewLine}";
        }
    }
}