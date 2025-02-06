#region 1. Importer Microsoft.Data.SqlClient
// tout d'abord, importer le package
// SqlConnection > ALT+ENTER > Install Microsoft.Data.SqlClient
using Microsoft.Data.SqlClient;
#endregion


#region 2. Créer une connexion
// créer la connexion
/* Infos de connexion, séparées par un ; --> connexion via Windows Authentication */
string connectionString = @"server=DESKTOP-E563U3H;database=DbSlide;integrated security=true;trustservercertificate=true";

// autre manière de se connecter
/* Infos de connexion, séparées par un ; --> connexion via uid et pwd */
string connectionString2 = @"server=DESKTOP-E563U3H;database=DbSlide;uid=sa;pwd=test1234;trustservercertificate=true";

// using : hérite de IDisposable > connexion automatiquement fermée à la fin de son utilisation et permet au garbage collection de libérer l'espace mémoire alloué
using SqlConnection connection = new(connectionString);
#endregion


#region 3. Ouvrir la connexion
// ouvrir la connexion
connection.Open();
#endregion


#region 4. Créer la commande SQL
// créer la commande SQL + (ajouter des paramètres à la commande)
// params pour éviter des injections SQL
using SqlCommand command = connection.CreateCommand();
command.CommandText = "SELECT * FROM student WHERE section_id = @sectionID";
command.Parameters.AddWithValue("sectionID", Console.ReadLine());
#endregion


#region 5. Exécuter la commande
// exécuter la commande
//// récupérer un ensemble de valeurs
//command.ExecuteReader(); // SELECT * FROM student -----> using SqlDataReader
//// récupérer une valeur
//command.ExecuteScalar(); // SELECT AVG(year_result) FROM student -----> using double
//// récupérer le nombre de lignes modifiées
//command.ExecuteNonQuery(); // DELETE FROM student WHERE student_id = 42 -----> using int

using SqlDataReader reader = command.ExecuteReader();
#endregion


#region (6.) Mapper le résultat dans des objets C#
// (mapper le résultat dans des objets C#)
// faire correspondre les colonnes de la db avec les propriétés de la class Student
List<Student> students = [];
// tant que le reader trouve une ligne
while (reader.Read())
{
    students.Add(new Student
    {
        Id = (int)reader["student_id"],
        Name = (string)reader["last_name"],
        FirstName = (string)reader["first_name"],
        BirthDate = (DateTime)reader["birth_date"]
    });
}
#endregion


#region 7. Fermer la connexion
// fermer la connexion
connection.Close();
#endregion


#region 8. Travailler avec les données
// travailler avec l'objet C# dans son programme
foreach (Student student in students)
{
    Console.WriteLine(student.Name);
    Console.WriteLine(student.FirstName);
}
#endregion

/*********/
class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;  // null forgiven : dit au System que l'info va être traitée plus tard = enlève le warning vert en souligné
    public string FirstName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}