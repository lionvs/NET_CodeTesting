This project is an example of testable and maintainable code.

Yes, it contains logic mistakes.

How to prepare and run application:
1. Run application once. Nuget will restore all packages and an empty test database "Cashbox.DataAccess.CashboxDbContext"
   will be created in your SQL Server instance.
2. There is a database migration step with test seed data to play with. Just open the Package Manager Console
   (Tools -> NuGet Package Manager -> Package Manager Console) and run the command Update-Database.

The example application doesn't provide a possibilty to edit accounts, products, etc. You can do this only directly in
the database. You can open the database "Cashbox.DataAccess.CashboxDbContext" using the Server Explorer in Visual Studio
or using the Microsoft SQL Server Management Studio (comes with full SQL Server package of any edition).

If you have a compilation error because of missing reference "System.Windows.Interactivity" then check that you have
installed Blend with Visual Studio: the required DLL should be located in the Blend folder -
"C:\Program Files (x86)\Microsoft SDKs\Expression\Blend\.NETFramework\v4.5\Libraries\".