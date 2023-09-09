namespace Dominio
{
    public class Comentario : Publicacion
    {
        public Comentario(Miembro autor, string texto) : base(autor, texto)
        {
        }
    }
}