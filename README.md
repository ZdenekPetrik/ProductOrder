# EF6-Code-First-Demo
Entity Framework 6 Code-First Demo Project


Solution ProductOrder se skládá ze 3 Projektů:

1. DBProductOrder - knihovna, která řeší přístup k databázi přes Entity Framework. Pomocí návrhového vzoru "Code First" jsou v něm deklarovány čtyři entity (Customer,Order,Product,OrderItem), které pak mají svůj obraz v tabulkách databáze. 

 

2. ProductOrderManipulation. Konzolová aplikace. V App.Config je sekce

  <connectionStrings>

    <add name="ProductOrderDatabase"

         providerName="System.Data.SqlClient"

         connectionString="Data Source=localhost;Initial Catalog=ProductOrderDatabase;Integrated Security=True;MultipleActiveResultSets=true "/>

  </connectionStrings>

kterou stačí přepsat Vaším Connection stringem. Po spuštění program vytvoří databázi a testovací data.

 

3. ProductOrder. Web application. Connection string najdete ve Web.config.

Program umožňuje plnou editaci Customers a Product. 

Order má dvě stránky. Jednu informativní, kde ke každé objednávce zobrazuje všechny objednané produkty, a druhou editační, kde je možné vytvářet nové prázdné objednávky (pro Customer) nebo mazat již existující objednávky. Dále je možné ke každé objednávce přidávat/ubírat produkty. Cena za objednávku se přepočívá automaticky.

 

 

S pozdravem

Zdeněk Petřík
