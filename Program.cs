using Database;

DatabaseManager dbManager = new DatabaseManager();
await dbManager.ConnectAsync();
dbManager.InsererAnimal("Hippotamus", "rouge", 18);

foreach (string nom in dbManager.RecupererListeAnimaux()){
    Console.WriteLine(nom);
}