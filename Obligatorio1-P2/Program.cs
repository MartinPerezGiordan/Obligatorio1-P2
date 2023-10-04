// See https://aka.ms/new-console-template for more information
using Dominio;

Sistema sistema = Sistema.Instancia;
Console.WriteLine(DateTime.Now.AddYears(-13));
#region Precarga de Datos

#region Miembros

Miembro Juan = new Miembro("correo0@example.com", "contrasenia1", "Juan", "Perez", new DateTime(1990, 1, 1), false);
Miembro Ana = new Miembro("correo1@example.com", "contrasenia2", "Ana",  "Gomez", new DateTime(1985, 3, 15), false);
Miembro Luis = new Miembro("correo2@example.com", "contrasenia3", "Luis", "Rodriguez", new DateTime(1995, 5, 20), false);
Miembro Maria = new Miembro("correo3@example.com", "contrasenia4", "Maria", "Lopez", new DateTime(1980, 10, 10), false);
Miembro Sofia = new Miembro("correo4@example.com", "contrasenia5", "Sofia", "Torres", new DateTime(1988, 6, 5), false);
Miembro Pedro = new Miembro("correo5@example.com", "contrasenia6", "Pedro", "Martinez", new DateTime(1992, 12, 30), false);
Miembro Laura = new Miembro("correo6@example.com", "contrasenia7", "Laura", "Sanchez", new DateTime(1993, 8, 25), false);
Miembro Carlos = new Miembro("correo7@example.com", "contrasenia8", "Carlos", "Gonzalez", new DateTime(1975, 4, 2), false);
Miembro Marta = new Miembro("correo8@example.com", "contrasenia9", "Marta", "Ramirez", new DateTime(1982, 7, 12), false);
Miembro Jose = new Miembro("correo9@example.com", "contrasenia10", "Jose", "Fernandez", new DateTime(1998, 11, 15), false);

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

#endregion Miembros

#region Administradores

Administrador Lucas = new Administrador("correo@admin.com", "adminContrasenia1");

sistema.AgregarAdministrador(Lucas);

#endregion Administradores

#region Invitaciones

// Invitaciones para cada uno de los miembros
sistema.EnviarInvitacion(Luis.Id, Juan.Id);
sistema.EnviarInvitacion(Marta.Id, Ana.Id);
sistema.EnviarInvitacion(Juan.Id, Maria.Id);
sistema.EnviarInvitacion(Jose.Id, Luis.Id);
sistema.EnviarInvitacion(Ana.Id, Sofia.Id);
sistema.EnviarInvitacion(Maria.Id, Pedro.Id);
sistema.EnviarInvitacion(Sofia.Id, Laura.Id);
sistema.EnviarInvitacion(Laura.Id, Carlos.Id);
sistema.EnviarInvitacion(Jose.Id, Marta.Id);
sistema.EnviarInvitacion(Pedro.Id, Jose.Id);

// Dos miembros sean amigos del resto de miembros
sistema.EnviarInvitacion(Luis.Id, Juan.Id);
sistema.EnviarInvitacion(Jose.Id, Juan.Id);
sistema.EnviarInvitacion(Ana.Id, Juan.Id);
sistema.EnviarInvitacion(Maria.Id, Juan.Id);
sistema.EnviarInvitacion(Sofia.Id, Juan.Id);
sistema.EnviarInvitacion(Laura.Id, Juan.Id);
sistema.EnviarInvitacion(Pedro.Id, Juan.Id);
sistema.EnviarInvitacion(Carlos.Id, Juan.Id);
sistema.EnviarInvitacion(Marta.Id, Juan.Id);

sistema.EnviarInvitacion(Luis.Id, Marta.Id);
sistema.EnviarInvitacion(Jose.Id, Marta.Id);
sistema.EnviarInvitacion(Ana.Id, Marta.Id);
sistema.EnviarInvitacion(Maria.Id, Marta.Id);
sistema.EnviarInvitacion(Sofia.Id, Marta.Id);
sistema.EnviarInvitacion(Laura.Id, Marta.Id);
sistema.EnviarInvitacion(Pedro.Id, Marta.Id);
sistema.EnviarInvitacion(Carlos.Id, Marta.Id);
sistema.EnviarInvitacion(Juan.Id, Marta.Id);

foreach (Invitacion invitacion in Juan.GetInvitacionesRecibidas())
{
    sistema.AceptarInvitacion(invitacion);
}
foreach (Invitacion invitacion in Marta.GetInvitacionesRecibidas())
{
    sistema.AceptarInvitacion(invitacion);
}

// Invitacion rechazada
foreach (Invitacion invitacion in Carlos.GetInvitacionesRecibidas())
{
    sistema.RechazarInvitacion(invitacion);
}

#endregion

#region Post y Comentarios

//Ids publicacion de 0 a 5 son post
sistema.AgregarPostMiembro(0, "Foto de mis vacaciones en la playa", "¡Hermoso día en la playa hoy!", "vacaciones_playa.jpg", true);
sistema.AgregarPostMiembro(2, "Nuevo libro recomendado", "Acabo de terminar de leer 'Harry Potter' de Martin Perez, ¡altamente recomendado!", "HarryPotter.jpg", true);
sistema.AgregarPostMiembro(2, "Receta de la semana", "Hoy les comparto mi receta favorita de lasaña casera. ¡Es deliciosa!", "receta_lasana.jpg", true);
sistema.AgregarPostMiembro(2, "Noticias de tecnología", "Apple anuncia el lanzamiento de su nuevo iPhone 15. ¡Estoy emocionado!", "iphone_15.jpg", true);
sistema.AgregarPostMiembro(5, "Mi mascota", "Conozcan a mi nuevo cachorro, se llama Sarna <3", "Sarna.jpg", true);

// Post privado para pruebas
sistema.AgregarPostMiembro(9, "Post privado", "Privado!!", "soloamigoscomentan.jpg", false);

//Ids publicacion de 6 a 19 son comentario
sistema.AgregarComentarioPost(0, 8,"Este es el titulo 1", "Este es el comentario");
sistema.AgregarComentarioPost(0, 1,"Este es el titulo 2", "Comentario 2 post 1");
sistema.AgregarComentarioPost(0, 2,"Este es el titulo 3", "Comentario 3 post 1");
sistema.AgregarComentarioPost(1, 0,"Este es el titulo 4", "Comentario 1 post 2");
sistema.AgregarComentarioPost(1, 1,"Este es el titulo 5", "Comentario 2 post 2");
sistema.AgregarComentarioPost(1, 8,"Este es el titulo 6", "Comentario 3 post 3");
sistema.AgregarComentarioPost(2, 8,"Este es el titulo 7", "Comentario 1 post 3");
sistema.AgregarComentarioPost(2, 8,"Este es el titulo 8", "Comentario 2 post 3");
sistema.AgregarComentarioPost(2, 2,"Este es el titulo 9", "Comentario 3 post 3");
sistema.AgregarComentarioPost(3, 2,"Este es el titulo 10", "Comentario 1 post 4");
sistema.AgregarComentarioPost(3, 3,"Este es el titulo 11", "Comentario 2 post 4");
sistema.AgregarComentarioPost(3, 8,"Este es el titulo 12", "Comentario 3 post 4");
sistema.AgregarComentarioPost(4, 6,"Este es el titulo 13", "Comentario 1 post 5");
sistema.AgregarComentarioPost(4, 5,"Este es el titulo 14", "Comentario 2 post 5");
sistema.AgregarComentarioPost(4, 8,"Este es el titulo 15", "Comentario 3 post 5");

#endregion Post y Comentarios

#region Reacciones

//Likes a foto de vacaciones en la playa
sistema.LikearUnaPublicacion(1, 0, true);
sistema.LikearUnaPublicacion(2, 0, false);
sistema.LikearUnaPublicacion(3, 0, true);
sistema.LikearUnaPublicacion(4, 0, true);
sistema.LikearUnaPublicacion(5, 0, true);
sistema.LikearUnaPublicacion(1, 0, true);
sistema.LikearUnaPublicacion(2, 0, true);
sistema.LikearUnaPublicacion(3, 0, true);

//Likes a Nuevo libro
sistema.LikearUnaPublicacion(1, 1, true);
sistema.LikearUnaPublicacion(2, 1, false);
sistema.LikearUnaPublicacion(3, 1, true);
sistema.LikearUnaPublicacion(4, 1, true);
sistema.LikearUnaPublicacion(5, 1, true);
sistema.LikearUnaPublicacion(1, 1, true);
sistema.LikearUnaPublicacion(2, 1, true);
sistema.LikearUnaPublicacion(3, 1, false);

//Este es el titulo 1
sistema.LikearUnaPublicacion(1, 5, true);
sistema.LikearUnaPublicacion(2, 5, false);
sistema.LikearUnaPublicacion(3, 5, true);
sistema.LikearUnaPublicacion(4, 5, true);
sistema.LikearUnaPublicacion(5, 5, true);
sistema.LikearUnaPublicacion(1, 5, true);
sistema.LikearUnaPublicacion(2, 5, true);
sistema.LikearUnaPublicacion(3, 5, true);

//Este es el titulo 2
sistema.LikearUnaPublicacion(1, 6, true);
sistema.LikearUnaPublicacion(2, 6, false);
sistema.LikearUnaPublicacion(3, 6, true);
sistema.LikearUnaPublicacion(4, 6, true);
sistema.LikearUnaPublicacion(5, 6, true);
sistema.LikearUnaPublicacion(1, 6, true);
sistema.LikearUnaPublicacion(2, 6, true);
sistema.LikearUnaPublicacion(3, 6, false);

#endregion Reacciones

#endregion

#region MenuDePruebas

void AbrirMenuDeTests()
{
    int opcionTest = -1;
    while (opcionTest != 0)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("************* MENU DE TESTS *************");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("1 - Ver Miembros");
            Console.WriteLine("2 - Ver Administradores");
            Console.WriteLine("3 - Registrarse a Social NetWork");
            Console.WriteLine("4 - PRUEBA GetPublicacionesPorEmail, IdentificarComentarios, IdentificarPosts");
            Console.WriteLine("5 - PRUEBA BloquearMiembro");
            Console.WriteLine("6 - Ver Comentarios");
            Console.WriteLine("7 - PRUEBA CensurarPost");
            Console.WriteLine("8 - PRUEBA EnviarInvitaciones");
            Console.WriteLine("9 - PRUEBA Likes y Dislikes");
            Console.WriteLine("10 - Login");

            opcionTest = int.Parse(Console.ReadLine());
            switch (opcionTest)
            {
                case 1:
                    Console.Clear();

                    ListarMiembros();
                    Console.ReadLine();
                    break;

                case 2:
                    Console.Clear();

                    foreach (Administrador unAdministrador in sistema.GetAdministradores())
                    {
                        Console.WriteLine(unAdministrador.Id);
                    }
                    Console.ReadLine();

                    break;

                case 3:
                    Console.Clear();

                    Console.WriteLine("Ingrese Nombre y Apellido");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("IngreseApellido");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese contraseña");
                    string contrasenia = Console.ReadLine();
                    Console.WriteLine("Ingrese Fecha de Nacimiento");
                    DateTime fechaDeNacimiento = DateTime.Parse(Console.ReadLine());

                    Miembro nuevoMiembro = new Miembro(email, contrasenia, nombre, apellido, fechaDeNacimiento, false);
                    sistema.AgregarMiembro(nuevoMiembro);
                    Console.WriteLine("Miembro registrado con exito");
                    Console.ReadLine();

                    break;

                case 4:
                    Console.Clear();

                    foreach (Publicacion publicacion in sistema.GetPublicacionesPorEmail("correo8@example.com"))
                    {
                        Console.WriteLine(publicacion.ToString());
                    }
                    Console.WriteLine("Fin Publicaciones");

                    foreach (Comentario comentario in sistema.IdentificarComentarios(sistema.GetPublicacionesPorEmail("correo8@example.com")))
                    {
                        Console.WriteLine(comentario.ToString());
                    }
                    Console.WriteLine("Fin Comentarios");

                    foreach (Post post in sistema.IdentificarPosts(sistema.GetPublicacionesPorEmail("correo8@example.com")))
                    {
                        Console.WriteLine(post.ToString());
                    }
                    Console.WriteLine("Fin Posts");
                    Console.ReadLine();

                    break;

                case 5:
                    Console.Clear();

                    Console.WriteLine(Juan.Bloqueado);
                    sistema.BloquearMiembro(0, true);
                    Console.WriteLine(Juan.Bloqueado);
                    Console.ReadLine();

                    break;

                case 6:
                    Console.Clear();

                    Console.WriteLine("Falta correccion");
                    // Publicacion publicacion = (Post)sistema.GetPublicacionById(1);
                    //
                    // foreach (Comentario comentario in publicacion.get
                    // {
                    //     Console.WriteLine(comentario.GetAutorNombre());
                    // }
                    Console.ReadLine();

                    break;

                case 7:
                    Console.Clear();

                    Console.WriteLine("Falta correccion");
                    //Console.WriteLine("Falta correccion");
                    //sistema.AgregarPostMiembro(8, "Post 6", "cinco.jpg");
                    //Console.WriteLine(sistema.GetPostById(5).GetCensurado());
                    //sistema.CensurarPost(5, true);
                    //Console.WriteLine(sistema.GetPostById(5).GetCensurado());
                    //sistema.AgregarComentarioPost(4, 8, "Comentario 3 post 5");
                    Console.ReadLine();

                    break;

                case 8:
                    Console.Clear();

                    //ListarMiembros();
                    //Pruebas con Invitaciones. Funciona: Enviar Invitacion, Rechazar Invitacion y las listas de amigos y de invitaciones

                    ListarAmigos(Juan);
                    sistema.EnviarInvitacion(Luis.Id, Juan.Id);
                    sistema.EnviarInvitacion(Marta.Id, Juan.Id);
                    sistema.EnviarInvitacion(Jose.Id, Juan.Id);

                    ListarInvitaciones(Juan);

                    ListarInvitaciones(Juan);

                    ListarAmigos(Juan);
                    ListarAmigos(Laura);
                    Console.ReadLine();

                    break;

                case 9:
                    Console.Clear();

                    foreach (Publicacion publicacion in sistema.GetPublicaciones())
                    {
                        Console.WriteLine("**************************************************************");
                        Console.WriteLine($"REACCIONES DE: {publicacion.Titulo}");

                        if (publicacion.GetReacciones().Count() > 0)
                        {
                            foreach (Reaccion reaccion in publicacion.GetReacciones())
                            {
                                Console.WriteLine(sistema.GetMiembroById(reaccion.IdMiembro) + " dio un " + (reaccion.Like ? "like" : "dislike"));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay reacciones para esta publicación.");
                        }

                        Console.WriteLine("VA de publicación es " + sistema.CalcularVA(publicacion.Id));
                        Console.WriteLine();
                    }
                    Console.ReadLine();

                    break;
                
                default:
                    Console.WriteLine("Opcion Incorrecta");
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Opcion Incorrecta.");
            opcionTest = -1;
        }
    }
    Console.Clear();
}

#endregion MenuDePruebas

#region Menu

int opcion = -1;
while (opcion != 0)
{
    Console.WriteLine("************* SOCIAL NETWORK *************");
    Console.WriteLine("50 - Menu de Tests");
    Console.WriteLine("0 - Salir");
    Console.WriteLine("1 - Registrarse a Social NetWork");
    Console.WriteLine("2 - Buscar Publicaciones de Miembros por Email");
    Console.WriteLine("3 - Buscar Posts comentados por Miembros por Email");
    Console.WriteLine("4 - Buscar Posts por rango de fechas");
    Console.WriteLine("5 - Mostrar Miembro con mayor cantidad de Publicaiones");
    Console.WriteLine("6 - Login");
    try
    {
        opcion = int.Parse(Console.ReadLine());
    }
    catch (Exception e) 
    {
        opcion = -1;
    }
    switch (opcion)
    {
        case 50:
            AbrirMenuDeTests();
            break;
        case 1:
            Boolean seInserto = false;
            while(!seInserto)
            {
                try
                {
                    Console.WriteLine("Registro");
                    Console.WriteLine("Ingrese Nombre");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese contraseña");
                    string contrasenia = Console.ReadLine();
                    Console.WriteLine("Ingrese Fecha de Nacimiento");
                    DateTime fechaDeNacimiento = DateTime.Parse(Console.ReadLine());
                    Miembro nuevoMiembro = new Miembro(email, contrasenia, nombre, apellido, fechaDeNacimiento, false);
                    sistema.AgregarMiembro(nuevoMiembro);
                    Console.WriteLine("Miembro registrado con exito");
                    seInserto = true;
                } catch (Exception e) 
                { 
                    Console.WriteLine(e.Message); 
                    seInserto = false;
                }
            }
            break;
        case 2:
            try { 
                Console.WriteLine("Buscar Publicaciones de Miembros por Email");
                Console.WriteLine("Ingrese email");
                string emailBuscado = Console.ReadLine();
                Console.WriteLine("Posts:");
                foreach (Post post in sistema.IdentificarPosts(sistema.GetPublicacionesPorEmail(emailBuscado)))
                {
                    Console.WriteLine(post.ToString());
                }
                Console.WriteLine("Comentarios:");
                foreach (Comentario comentario in sistema.IdentificarComentarios(sistema.GetPublicacionesPorEmail(emailBuscado)))
                {
                    Console.WriteLine(comentario.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 3:
            try
            {
                Console.WriteLine("3 - Buscar Posts comentados por Miembros por Email");
                Console.WriteLine("Ingrese email");
                string email = Console.ReadLine();
                Console.WriteLine("Posts comentados:");
                foreach (Post post in sistema.GetPostPorComentarios(sistema.GetComentariosPorEmail(email)))
                {
                    Console.WriteLine(post.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
        case 6:
            Boolean seLogueo = false;
            while (!seLogueo)
            {
                try
                {
                    Console.WriteLine("Login");
                    Console.WriteLine("Ingrese Email");
                    string emailLogin = Console.ReadLine();
                    Console.WriteLine("Ingrese contraseña");
                    string contraseniaLogin = Console.ReadLine();
                    sistema.Login(emailLogin, contraseniaLogin);
                    Console.WriteLine("Login Exitoso");
                    seLogueo = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    seLogueo = false;
                }
            }
            break;

        default:
            Console.WriteLine("Opcion Incorrecta");
            break;
    }
}
Console.WriteLine("-- ¡Hasta pronto! --");

#endregion Menu

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
    Console.WriteLine($"Amigos de {miembro.Nombre}:");
    if (miembro.GetListaDeAmigos().Count == 0)
    {
        Console.WriteLine("Aun no hay amigos :(");
    }
    else
    {
        foreach (Miembro amigo in miembro.GetListaDeAmigos())
        {
            Console.WriteLine(amigo.Nombre);
        }
    }
}

void ListarInvitaciones(Miembro miembro)
{
    Console.WriteLine($"Invitaciones recibidas de {miembro.Nombre}:");
    if (miembro.GetInvitacionesRecibidas().Count == 0)
    {
        Console.WriteLine("Aun no ha recibido ninguna invitacion");
    }
    else
    {
        foreach (Invitacion invitacion in miembro.GetInvitacionesRecibidas())
        {
            Miembro miembroSolicitante = sistema.GetMiembroById(invitacion.GetIdMiembroSolicitante());
            Console.WriteLine(miembroSolicitante.Nombre);
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
    if (fecha1 > fecha2)
    {
        Console.WriteLine("la primera fecha no puede ser posterior a la segunda.");
    }
    else
    {
        List<Post> postsAMostrar = new List<Post>();
        foreach (Publicacion publicacionAMostrar in sistema.GetPublicaciones())
        {
            DateTime fechaDePublicacion = publicacionAMostrar.Fecha;
            if (fechaDePublicacion >= fecha1 && fechaDePublicacion <= fecha2)
            {
                if (publicacionAMostrar is Post)
                {
                    postsAMostrar.Add((Post)publicacionAMostrar);
                }
            }
        }
        
        List<Post> postsOrdenados = postsAMostrar.OrderBy(post => post.Titulo).ToList();

        if (postsOrdenados.Count == 0)
        {
            Console.WriteLine("No hay ningun post entre esas fechas");
        }
        else
        {
            foreach (Post post in postsOrdenados)
            {
                int id = post.Id;
                string titulo = post.Titulo;
                DateTime fecha = post.Fecha;
                string texto = post.Texto;

                if (texto.Length > 50)
                {
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
// Esta función busca al miembro o miembros con la mayor cantidad de publicaciones
// en una lista de miembros, utilizando 'mayorCantidad' para realizar un seguimiento
// de la cantidad máxima encontrada y 'miembrosConMasPublicaciones' para almacenar los miembros con mas publicaciones.
// Luego, imprime los miembros con la mayor cantidad de publicaciones en la consola.
void ListarMiembroConMasPublicaciones()
{
    bool hayRegistros = false;
    int mayorCantidad = 0;
    List<Miembro> miembrosConMasPublicaciones = new List<Miembro>();

    foreach (Miembro miembro in sistema.GetMiembros())
    {
        if (miembro.CantidadDePublicaciones > mayorCantidad)
        {
            mayorCantidad = miembro.CantidadDePublicaciones;
            miembrosConMasPublicaciones.Clear();
            miembrosConMasPublicaciones.Add(miembro);
            hayRegistros = true;
        }
        else if (miembro.CantidadDePublicaciones == mayorCantidad)
        {
            miembrosConMasPublicaciones.Add(miembro);
        }
    }

    Console.WriteLine("Miembro/s con mayor cantidad de publicaciones:");
    foreach (Miembro miembro in miembrosConMasPublicaciones)
    {
        Console.WriteLine($"{miembro.Nombre} hizo {mayorCantidad} publicaciones");
        Console.WriteLine($"DATOS DEL MIEMBRO:");
        Console.WriteLine(miembro);

    }

}

#endregion

