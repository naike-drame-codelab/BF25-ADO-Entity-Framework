using DemoEntityFramework;
using DemoEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

#region Installer Entity Framework Core, Sql Server & Tools 
// Tools : permet de créer db via le code
// si on veut utiliser un autre service, Postgres par exemple, il faut installer le package EF correspondant
#endregion

#region Importer le context personnalisé et 
using SchoolContext context = new SchoolContext();

#endregion


#region Création d'une liste pour exploiter les données + requête LINQ vers SQL
// SQL Server Profiler : permet de traquer les requêtes SQL faites

// avantage : requête côté client et non côté server
//List<Student> students = context.Students.Where(s => s.SectionId == 1110).ToList();

// !!! faire la requête AVANT le ToList() car données filtrées avant d'être transformées
// tout ce qu'on fait avec le DbContext : 
// - tout ce qui est fait avant le ToList() : côté SQL
// - tout ce qui est fait après le ToList() : côté C#
var students = context.Students
    // joindre la table des sections via .Include() (nécessaire si on veut afficher l'info)
    .Include(s => s.Section)
	// .Where(s => s.SectionId == 1320)
	// parfois la requête LINQ est intraduisible en SQL -> le System va s'arrêter et déclencher une erreur ---> doit être placé après le ToList() car on peut faire davantage côté C#, ex. API
	// .Where (s => new HttpClient().GetAsync("").Result.IsSuccessStatusCode)
	// autre type de jointure, sans le Include() il va qd m^m faire la jointure dans la requête SQL
	.Where (s => s.Section.Name.StartsWith("M"))
	//.OrderBy(s => s.Result) // ordonner par ordre croissant
	.OrderByDescending(s => s.Result) // ordonner par ordre décroissant
	.Skip(1) // passer le premier
	.Take(5) // prendre les 5 premiers

    .ToList();

// requête pour des fonctions d'aggrégation permettant de faire des groupements
double avg = context.Students.Average(s => s.Result);

foreach (Student student in students)
{
	Console.WriteLine($"{student.Name} {student.FirstName} {student.Section.Name}");
}
Console.WriteLine(avg); // 8.76

#endregion

/* clients, chambres, options, taille/nb pers, reservations, promotions*/