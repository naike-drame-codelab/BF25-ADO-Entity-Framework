using DemoEntityFramework;
using DemoEntityFramework.Entities;

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
var students = context.Students
	// .Where(s => s.SectionId == 1320)
	//.OrderBy(s => s.Result) // ordonner par ordre croissant
	.OrderByDescending(s => s.Result) // ordonner par ordre décroissant
	.Skip(1) // passer le premier
	.Take(5) // prendre les 5 premiers
    .ToList();

double avg = context.Students.Average(s => s.Result);

foreach (Student student in students)
{
	Console.WriteLine($"{student.Name} {student.FirstName}");
}
Console.WriteLine(avg); // 8.76

/*
 Garcia Andy
Garner Jennifer
Berry Halle
Roberts Julia
Bacon Kevin
 */
#endregion