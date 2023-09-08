﻿// See https://aka.ms/new-console-template for more information
using Dominio;



Sistema sistema = new Sistema();


#region Precarga de Datos

#region Miembros
Miembro Juan = new Miembro("correo1@example.com", "contrasenia1", "Juan Perez", new DateOnly(1990, 1, 1), false);
Miembro Ana = new Miembro("correo2@example.com", "contrasenia2", "Ana Gomez", new DateOnly(1985, 3, 15), false);
Miembro Luis = new Miembro("correo3@example.com", "contrasenia3", "Luis Rodriguez", new DateOnly(1995, 5, 20), true);
Miembro Maria = new Miembro("correo4@example.com", "contrasenia4", "Maria Lopez", new DateOnly(1980, 10, 10), false);
Miembro Sofia = new Miembro("correo5@example.com", "contrasenia5", "Sofia Torres", new DateOnly(1988, 6, 5), true);
Miembro Pedro = new Miembro("correo6@example.com", "contrasenia6", "Pedro Martinez", new DateOnly(1992, 12, 30), false);
Miembro Laura = new Miembro("correo7@example.com", "contrasenia7", "Laura Sanchez", new DateOnly(1993, 8, 25), true);
Miembro Carlos = new Miembro("correo8@example.com", "contrasenia8", "Carlos Gonzalez", new DateOnly(1975, 4, 2), false);
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

#endregion

#region Menu

int opcion = -1;
while (opcion != 0)
{
    try
    {
        Console.WriteLine("************* SOCIAL NETWORK *************");

        Console.WriteLine("0 - Salir");
        Console.WriteLine("1 - Registrarse a Social NetWork");
        Console.WriteLine("2 - Buscar Publicaciones de Miembros por Email");
        Console.WriteLine("3 - Buscar Posts comentados por Miembros por Email");
        Console.WriteLine("4 - Buscar Posts por rango de fechas");
        Console.WriteLine("5 - Mostrar Miembro con mayor cantidad de Publicaiones");
        Console.WriteLine("1 - Ver Miembros");
        Console.WriteLine("2 - Ver Administradores");
        opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                foreach (Miembro unMiembro in sistema.GetMiembros())
                {
                    Console.WriteLine(unMiembro.GetNombre());
                }
                break;
            case 2:
                foreach (Administrador unAdministrador in sistema.GetAdministradores())
                {
                    Console.WriteLine(unAdministrador.GetId());
                }
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