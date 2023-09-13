// See https://aka.ms/new-console-template for more information
using Dominio;



Sistema sistema = new Sistema();


#region Precarga de Datos

#region Miembros
Miembro Juan = new Miembro("correo1@example.com", "contrasenia1", "Juan Perez", new DateOnly(1990, 1, 1), false);
Miembro Ana = new Miembro( "correo2@example.com", "contrasenia2", "Ana Gomez", new DateOnly(1985, 3, 15), false);
Miembro Luis = new Miembro( "correo3@example.com", "contrasenia3", "Luis Rodriguez", new DateOnly(1995, 5, 20), true);
Miembro Maria = new Miembro( "correo4@example.com", "contrasenia4", "Maria Lopez", new DateOnly(1980, 10, 10), false);
Miembro Sofia = new Miembro( "correo5@example.com", "contrasenia5", "Sofia Torres", new DateOnly(1988, 6, 5), true);
Miembro Pedro = new Miembro("correo6@example.com", "contrasenia6", "Pedro Martinez", new DateOnly(1992, 12, 30), false);
Miembro Laura = new Miembro("correo7@example.com", "contrasenia7", "Laura Sanchez", new DateOnly(1993, 8, 25), true);
Miembro Carlos = new Miembro(   "correo8@example.com", "contrasenia8", "Carlos Gonzalez", new DateOnly(1975, 4, 2), false);
Miembro Marta = new Miembro("correo9@example.com", "contrasenia9", "Marta Ramirez", new DateOnly(1982, 7, 12), false);
Miembro Jose = new Miembro("correo10@example.com", "contrasenia10", "Jose Fernandez", new DateOnly(1998, 11, 15), true);

sistema.AgregarMiembro(Juan);
sistema.AgregarMiembro(Ana);
sistema.AgregarMiembro(Luis);
sistema.AgregarMiembro(Maria);
sistema.AgregarMiembro(Sofia);
sistema.AgregarMiembro(Pedro);
sistema.AgregarMiembro(Laura);
sistema.AgregarMiembro(Carlos);
sistema.AgregarMiembro(Marta);
sistema.AgregarMiembro(Jose);
#endregion

#region Administradores
Administrador Lucas = new Administrador("correo@admin.com", "adminContrasenia1");

sistema.AgregarAdministrador(Lucas);
#endregion

#region Invitaciones
Invitacion invitacionDeLaura = new Invitacion(Laura.GetId(), Juan.GetId(), new DateTime(2002, 9, 23));

sistema.AgregarInvitacion(invitacionDeLaura);
#endregion

#region Post y Comentarios

sistema.AgregarPostMiembro(1, "Post 1", "Uno.jpg");
sistema.AgregarPostMiembro(2, "Post 2", "Dos.jpg");
sistema.AgregarPostMiembro(2, "Post 3", "tres.jpg");
sistema.AgregarPostMiembro(3, "Post 4", "cuatro.jpg");
sistema.AgregarPostMiembro(8, "Post 5", "cinco.jpg");

sistema.AgregarComentarioPost(0, 8, "Comentario 1 post 1");
sistema.AgregarComentarioPost(0, 1, "Comentario 2 post 1");
sistema.AgregarComentarioPost(0, 2, "Comentario 3 post 1");

sistema.AgregarComentarioPost(1, 0, "Comentario 1 post 2");
sistema.AgregarComentarioPost(1, 1, "Comentario 2 post 2");
sistema.AgregarComentarioPost(1, 8, "Comentario 3 post 3");

sistema.AgregarComentarioPost(2, 8, "Comentario 1 post 3");
sistema.AgregarComentarioPost(2, 4, "Comentario 2 post 3");
sistema.AgregarComentarioPost(2, 5, "Comentario 3 post 3");

sistema.AgregarComentarioPost(3, 2, "Comentario 1 post 4");
sistema.AgregarComentarioPost(3, 3, "Comentario 2 post 4");
sistema.AgregarComentarioPost(3, 8, "Comentario 3 post 4");

sistema.AgregarComentarioPost(4, 6, "Comentario 1 post 5");
sistema.AgregarComentarioPost(4, 5, "Comentario 2 post 5");
sistema.AgregarComentarioPost(4, 8, "Comentario 3 post 5");

#endregion

#endregion

#region Pruebas



/* PRUEBA DE GetPublicacionesPorEmail, IdentificarComentarios, IdentificarPosts

foreach(Publicacion publicacion in sistema.GetPublicacionesPorEmail("correo9@example.com"))
{
    Console.WriteLine(publicacion.ToString());
}
Console.WriteLine("Fin Publicaciones");

foreach (Comentario comentario in sistema.IdentificarComentarios(sistema.GetPublicacionesPorEmail("correo9@example.com")))
{
    Console.WriteLine(comentario.ToString());
}
Console.WriteLine("Fin Comentarios");

foreach (Post post in sistema.IdentificarPosts(sistema.GetPublicacionesPorEmail("correo9@example.com")))
{
    Console.WriteLine(post.ToString());
}
Console.WriteLine("Fin Posts");

*/


/* PRUEBA BloquearMiembro

Console.WriteLine(Juan.GetBloqueado());
sistema.BloquearMiembro(0, true);
Console.WriteLine(Juan.GetBloqueado());

*/

/* PRUEBA GetComentarios

foreach (Comentario comentario in sistema.GetPostById(1).GetComentarios())
{
    Console.WriteLine(comentario.GetAutorNombre());
}

*/

/* PRUEBA CensurarPost

sistema.AgregarPostMiembro(8, "Post 6", "cinco.jpg");
Console.WriteLine(sistema.GetPostById(5).GetCensurado());
sistema.CensurarPost(5, true);
Console.WriteLine(sistema.GetPostById(5).GetCensurado());
sistema.AgregarComentarioPost(4, 8, "Comentario 3 post 5");

*/



#endregion

#region Menu

//ListarMiembros();


//Pruebas con Invitaciones. Funciona: Enviar Invitacion, Rechazar Invitacion y las listas de amigos y de invitaciones
//ListarAmigos(Juan);
//sistema.EnviarInvitacion(Luis.GetId(), Juan.GetId());
//sistema.EnviarInvitacion(Marta.GetId(), Juan.GetId());
//sistema.EnviarInvitacion(Jose.GetId(), Juan.GetId());

//ListarInvitaciones(Juan);

//sistema.ActualizarListaDeInvitaciones(Juan);
//ListarInvitaciones(Juan);

//sistema.AceptarInvitacion(invitacionDeLaura);
//ListarAmigos(Juan);
//ListarAmigos(Laura);
Console.ReadLine();


#endregion

#region Menu
/*
int opcion = -1;
while (opcion != 0)
{
    try
    {
        Console.WriteLine("************* SOCIAL NETWORK *************");
        Console.WriteLine("0 - Salir");
       /* Lista de Menu
        Console.WriteLine("2 - Buscar Publicaciones de Miembros por Email");
        Console.WriteLine("3 - Buscar Posts comentados por Miembros por Email");
        Console.WriteLine("4 - Buscar Posts por rango de fechas");
        Console.WriteLine("5 - Mostrar Miembro con mayor cantidad de Publicaiones");
       */
/*        Console.WriteLine("1 - Ver Miembros");
        Console.WriteLine("2 - Ver Administradores");
        Console.WriteLine("3 - Registrarse a Social NetWork");
        opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                ListarMiembros();
                break;
            case 2:
                foreach (Administrador unAdministrador in sistema.GetAdministradores())
                {
                    Console.WriteLine(unAdministrador.GetId());
                }
                break;
            case 3:
                Console.WriteLine("Ingrese Nombre y Apellido");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Email");
                string email = Console.ReadLine();
                Console.WriteLine("Ingrese contraseña");
                string contrasenia = Console.ReadLine();
                Console.WriteLine("Ingrese Fecha de Nacimiento");
                DateOnly fechaDeNacimiento = DateOnly.Parse(Console.ReadLine());

                Miembro nuevoMiembro = new Miembro(email, contrasenia, nombre, fechaDeNacimiento, false);
                sistema.AgregarMiembro(nuevoMiembro);
                Console.WriteLine("Miembro registrado con exito");
                break;



            default:
                Console.WriteLine("Opcion Incorrecta");
                break;
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Opcion Incorrecta.");
        opcion = -1;
    }
}Console.WriteLine("-- ¡Hasta pronto! --");
*/
#endregion

#region Funciones

void ListarMiembros()
{
    foreach (Miembro unMiembro in sistema.GetMiembros())
    {
        Console.WriteLine(unMiembro);
    }
}

void ListarAmigos(Miembro miembro) 
{
Console.WriteLine($"Amigos de {miembro.GetNombre()}:");
if (miembro.GetListaDeAmigos().Count == 0)
{
    Console.WriteLine("Aun no hay amigos :(");
}
else 
{
    foreach (Miembro amigo in miembro.GetListaDeAmigos())
    {
        Console.WriteLine(amigo.GetNombre());
    }
}
}

void ListarInvitaciones(Miembro miembro)
{
    Console.WriteLine($"Invitaciones recibidas de {miembro.GetNombre()}:");
    if (miembro.GetInvitacionesRecibidas().Count == 0) 
    {
        Console.WriteLine("Aun no ha recibido ninguna invitacion");
    }
    else
    {
        foreach (Invitacion invitacion in miembro.GetInvitacionesRecibidas())
        {
            Miembro miembroSolicitante = sistema.GetMiembroById(invitacion.GetIdMiembroSolicitante());
            Console.WriteLine(miembroSolicitante.GetNombre());
        }
    }
}

#endregion
