// See https://aka.ms/new-console-template for more information
using Dominio;

Console.WriteLine("Hello, World!");


Sistema sistema = new Sistema();


#region Precarga de Datos

Miembro Juan = new Miembro("correo1@example.com", "contrasenia1", "Juan Perez", new DateTime(1990, 1, 1), false);
Miembro Ana = new Miembro("correo2@example.com", "contrasenia2", "Ana Gomez", new DateTime(1985, 3, 15), false);
Miembro Luis = new Miembro("correo3@example.com", "contrasenia3", "Luis Rodriguez", new DateTime(1995, 5, 20), true);
Miembro Maria = new Miembro("correo4@example.com", "contrasenia4", "Maria Lopez", new DateTime(1980, 10, 10), false);
Miembro Sofia = new Miembro("correo5@example.com", "contrasenia5", "Sofia Torres", new DateTime(1988, 6, 5), true);
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

