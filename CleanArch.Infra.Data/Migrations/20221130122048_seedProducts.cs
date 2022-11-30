using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)"+
                "VALUES('Caderno espiral','Caderno espiral 100 fôlhas',7.45,50,'caderno1.jpg',1)" );

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Estojo escolar','Estojo escolar cinza',5.65,70,'estojo1.jpg',1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Borracha escolar','Borracha escolar branca pequena',2.25,100,'borracha1.jpg',1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Calculadora escolar','Calculadora simples',14.75,20,'calculadora1.jpg',2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
