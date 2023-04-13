using System.Data.SQLite;
using System.Windows.Markup;

static SQliteConnection CreatConnection()
{
    SQLiteConnection connection = new SQLiteConnection("Data Source=mysdgsdfdb.db; Version = 3; New = True; Compress = True;");
    try

    {
        connection.Open();
        Console.WriteLine("DB found.");
    }
    catch
    {
        Console.WriteLine("DB not found.");

    }
    return connection;
} 

static void ReadData(SQLiteSonnection myConnection)
{
    Console.Clear();
    SQLiteDataReader reader;
    SQLiteCommand command;

    command = myConnection.CreateCommand();
    command.CommandText = "SELECT customer.firstName, customerlastName, status.statustype" +
        "From customerStatus" +
        "Join customer on customer.rowid = costomerStatus.customerId" +
        "JOIN status on status.rowid = customerStatus.statusId " +
        "ORDER BY status.statustype"; 

    reader = command.ExecuteReader(); 

    while (reader.Read())
    {
        string readerStringFirstName = reader.GetString(0);
        string readerStringLastName = reader.GetString(1);
        string readerStringDoB = reader.GetString(2);

        Console.WriteLine($"Full name: {readerStringFirstName} {readerStringLastName}; DoB: {readerStringDob}");

        
    }
    myConnection.Close();
}

static void Insertcustomer(SQLiteConnection myconnection)
{
    SQLiteCommand command;
    string fName, Lname, dob;

    Console.WriteLine("Enter first name:");
    fName = Console.ReadLine();
    Console.WriteLine("Enter last name:");
    Lname = Console.ReadLine();
    Console.WriteLine("Enter date of birth (mm-dd-yyyy):");
    dob = Console.ReadLine();

    command = myconnection.CreateCommand();
    command.CommandText = $"INSTER INTO customer(firstName, lastName, dataofBirth)" +
$"VALUES('{fName}', '{lName}', '{dob}')";      
    int rowInserted = command.ExecuteNonQuery();
    Console.WriteLine($"Row inserted: (rowInserted)"); 

    ReadData(myconnection);
}

static void RemoveCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;

    stringidToDelete;
    Console.WriteLine("Enter an id to delete the customer:"); 
    string idToUptade = Console.ReadLine(); 

    command=myConnection.CreateCommand();
    command.CommandText = $"DELETE FROM customer WHERE rowid = {idToDelete}";
    int rowRemoved = command.ExecuteNonQuery();
    Console.WriteLine($"{rowRemoved} was removed from the table customer");

    ReadData(myConnection); 

}

static void FindCustomer()
{

}




