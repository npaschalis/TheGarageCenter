namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrandsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Brands (Id, Name) VALUES (1, 'Abarth')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (2, 'Alfa Romeo')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (3, 'Audi')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (4, 'Bentley')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (5, 'BMW')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (6, 'Citroen')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (7, 'Dacia')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (8, 'DS')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (9, 'Ferrari')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (10, 'Fiat')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (11, 'Ford')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (12, 'Honda')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (13, 'Hyundai')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (14, 'Jaguar')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (15, 'Jeep')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (16, 'Kia')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (17, 'Land Rover')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (18, 'Lexus')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (19, 'Mazda')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (20, 'Mercedes')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (21, 'Mini')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (22, 'Mitsubishi')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (23, 'Nissan')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (24, 'Opel')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (25, 'Peugeot')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (26, 'Porsche')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (27, 'Range Rover')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (28, 'Renault')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (29, 'Seat')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (30, 'Skoda')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (31, 'Smart')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (32, 'Subaru')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (33, 'Suzuki')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (34, 'Toyota')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (35, 'Volkswagen')");
            Sql("INSERT INTO Brands (Id, Name) VALUES (36, 'Volvo')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Brands WHERE Id >=1 AND Id <=36");
        }
    }
}
