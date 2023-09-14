// See https://aka.ms/new-console-template for more information
using Dominio;



Sistema sistema = new Sistema();


#region Precarga de Datos

#region Miembros
Miembro Juan = new Miembro("correo1@example.com", "contrasenia1", "Juan Perez", new DateTime(1990, 1, 1), false);
Miembro Ana = new Miembro( "correo2@example.com", "contrasenia2", "Ana Gomez", new DateTime(1985, 3, 15), false);
Miembro Luis = new Miembro( "correo3@example.com", "contrasenia3", "Luis Rodriguez", new DateTime(1995, 5, 20), true);
Miembro Maria = new Miembro( "correo4@example.com", "contrasenia4", "Maria Lopez", new DateTime(1980, 10, 10), false);
Miembro Sofia = new Miembro( "correo5@example.com", "contrasenia5", "Sofia Torres", new DateTime(1988, 6, 5), true);
Miembro Pedro = new Miembro("correo6@example.com", "contrasenia6", "Pedro Martinez", new DateTime(1992, 12, 30), false);
Miembro Laura = new Miembro("correo7@example.com", "contrasenia7", "Laura Sanchez", new DateTime(1993, 8, 25), true);
Miembro Carlos = new Miembro("correo8@example.com", "contrasenia8", "Carlos Gonzalez", new DateTime(1975, 4, 2), false);
Miembro Marta = new Miembro("correo9@example.com", "contrasenia9", "Marta Ramirez", new DateTime(1982, 7, 12), false);
Miembro Jose = new Miembro("correo10@example.com", "contrasenia10", "Jose Fernandez", new DateTime(1998, 11, 15), true);

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

sistema.AgregarPostMiembro(1, "Foto de mis vacaciones en la playa", "¡Hermoso día en la playa hoy!", "vacaciones_playa.jpg");
sistema.AgregarPostMiembro(2, "Nuevo libro recomendado", "Acabo de terminar de leer 'Harry Potter' de Martin Perez, ¡altamente recomendado!", "HarryPotter.jpg");
sistema.AgregarPostMiembro(2, "Receta de la semana", "Hoy les comparto mi receta favorita de lasaña casera. ¡Es deliciosa!", "receta_lasana.jpg");
sistema.AgregarPostMiembro(2, "Noticias de tecnología", "Apple anuncia el lanzamiento de su nuevo iPhone 15. ¡Estoy emocionado!", "iphone_15.jpg");
sistema.AgregarPostMiembro(5, "Mi mascota", "Conozcan a mi nuevo cachorro, se llama Sarna <3", "Sarna.jpg");


sistema.AgregarComentarioPost(0, 8,"Este es el titulo", "Este es el comentario");
sistema.AgregarComentarioPost(0, 1,"Este es el titulo de mi comentario", "Comentario 2 post 1");
sistema.AgregarComentarioPost(0, 2,"Este es el titulo de mi comentario", "Comentario 3 post 1");
sistema.AgregarComentarioPost(1, 0,"Este es el titulo de mi comentario", "Comentario 1 post 2");
sistema.AgregarComentarioPost(1, 1,"Este es el titulo de mi comentario", "Comentario 2 post 2");
sistema.AgregarComentarioPost(1, 8,"Este es el titulo de mi comentario", "Comentario 3 post 3");
sistema.AgregarComentarioPost(2, 8,"Este es el titulo de mi comentario", "Comentario 1 post 3");
sistema.AgregarComentarioPost(2, 8,"Este es el titulo de mi comentario", "Comentario 2 post 3");
sistema.AgregarComentarioPost(2, 2,"Este es el titulo de mi comentario", "Comentario 3 post 3");
sistema.AgregarComentarioPost(3, 2,"Este es el titulo de mi comentario", "Comentario 1 post 4");
sistema.AgregarComentarioPost(3, 3,"Este es el titulo de mi comentario", "Comentario 2 post 4");
sistema.AgregarComentarioPost(3, 8,"Este es el titulo de mi comentario", "Comentario 3 post 4");
sistema.AgregarComentarioPost(4, 6,"Este es el titulo de mi comentario", "Comentario 1 post 5");
sistema.AgregarComentarioPost(4, 5,"Este es el titulo de mi comentario", "Comentario 2 post 5");
sistema.AgregarComentarioPost(4, 8,"Este es el titulo de mi comentario", "Comentario 3 post 5");

#endregion

#endregion

#region Pruebas



/* PRUEBA GetPublicacionesPorEmail, IdentificarComentarios, IdentificarPosts

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



// PRUEBA EnviarInvitaciones

//ListarMiembros();


//Pruebas con Invitaciones. Funciona: Enviar Invitacion, Rechazar Invitacion y las listas de amigos y de invitaciones
//ListarAmigos(Juan);
//sistema.EnviarInvitacion(Luis.GetId(), Juan.GetId());
//sistema.EnviarInvitacion(Marta.GetId(), Juan.GetId());
//sistema.EnviarInvitacion(Jose.GetId(), Juan.GetId());
//
//ListarInvitaciones(Juan);
//
//sistema.ActualizarListaDeInvitaciones(Juan);
//ListarInvitaciones(Juan);
//
//sistema.AceptarInvitacion(invitacionDeLaura);
//ListarAmigos(Juan);
//ListarAmigos(Laura);


#endregion



#region Menu

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
       */
        Console.WriteLine("1 - Ver Miembros");
        Console.WriteLine("2 - Ver Administradores");
        Console.WriteLine("3 - Registrarse a Social NetWork");
        Console.WriteLine("4 - Buscar Posts por rango de fechas");
        Console.WriteLine("5 - Mostrar Miembro con mayor cantidad de Publicaiones");
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
                DateTime fechaDeNacimiento = DateTime.Parse(Console.ReadLine());

                Miembro nuevoMiembro = new Miembro(email, contrasenia, nombre, fechaDeNacimiento, false);
                sistema.AgregarMiembro(nuevoMiembro);
                Console.WriteLine("Miembro registrado con exito");
                break;
            case 4:
                Console.WriteLine("Ingrese la primera fecha");
                DateTime fecha1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la segunda fecha");
                DateTime fecha2 = DateTime.Parse(Console.ReadLine());
                ListarPostsSegunFecha(fecha1, fecha2);
                break;

            case 5:
                ListarMiembroConMasPublicaciones();
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

//Esta funcion recibe dos parametros que son dos fechas. 
//Luego crea una lista vacia de posts postsAMostrar.
//Luego recorre todos los posts. Si cumplen con ser un post y estar entre las dos fechas recibidas por parametro
//Se agregan a la lista postsAMostrar
//Luego se ordena la lista
//Si la lista esta vacia da un aviso de que entre esas fechas no hay posts. 
//Se recorre la nueva lista y se verifica si el texto supera los 50 char, en cuyo caso se acorta a 50 char.
//Luego se muestran en consola los valores de los posts
void ListarPostsSegunFecha(DateTime fecha1, DateTime fecha2)
{
    if(fecha1 > fecha2)
    {
        Console.WriteLine("la primera fecha no puede ser posterior a la segunda.");
    }
    else { 
        List<Post> postsAMostrar = new List<Post>();
        foreach (Publicacion publicacionAMostrar in sistema.GetPublicaciones())
        {
            DateTime fechaDePublicacion = publicacionAMostrar.GetFecha();
            if (fechaDePublicacion >= fecha1 && fechaDePublicacion <= fecha2)
            {
                if (publicacionAMostrar is Post)
                {
                    postsAMostrar.Add((Post)publicacionAMostrar);
                }
            }
        }

        postsAMostrar.OrderBy(obj => obj.GetTitulo()).ToList();

        if(postsAMostrar.Count == 0) {
            Console.WriteLine("No hay ningun post entre esas fechas");
        }
        else
        {
            foreach (Post post in postsAMostrar)
            {
                int id = post.GetId();
                string titulo = post.GetTitulo();
                DateTime fecha = post.GetFecha();
                string texto = post.GetTexto();

                if(texto.Length > 50) {
                    texto = texto.Substring(0, 50);
                }
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Título: {titulo}");
                Console.WriteLine($"Fecha: {fecha}");
                Console.WriteLine($"Texto: {texto}");
                Console.WriteLine();

            }
        }
    }

}


void ListarMiembroConMasPublicaciones()
{
    int mayorCantidad = 0;
    List<Miembro> miembrosConMasPublicaciones = new List<Miembro>();

    foreach(Miembro miembro in sistema.GetMiembros())
    {
        if (miembro.CantidadDePublicaciones > mayorCantidad)
        {
            mayorCantidad = miembro.CantidadDePublicaciones;
            miembrosConMasPublicaciones.Clear();
            miembrosConMasPublicaciones.Add(miembro);
        }
        else if (miembro.CantidadDePublicaciones == mayorCantidad)
        {
            miembrosConMasPublicaciones.Add(miembro);
        }
    }

        Console.WriteLine("Miembro/s con mayor cantidad de publicaciones:");
    foreach(Miembro miembro in miembrosConMasPublicaciones)
    {
        Console.WriteLine($"{miembro.GetNombre()} hizo {mayorCantidad} publicaciones");
    }
}



#endregion

Console.WriteLine("Codigo Andando");
Console.ReadLine();