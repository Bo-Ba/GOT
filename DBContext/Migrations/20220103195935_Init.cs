using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.DBContext.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "got");

            migrationBuilder.CreateTable(
                name: "PunktyTrasy",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "varchar(100)", nullable: true),
                    SzerokoscGeo = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DlugoscGeo = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    WysokoscNPM = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunktyTrasy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TerenyGorskie",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerenyGorskie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Imie = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nazwisko = table.Column<string>(type: "varchar(50)", nullable: false),
                    Haslo = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumerLegitymacji = table.Column<string>(type: "varchar(10)", nullable: true),
                    NrPrzodownika = table.Column<int>(type: "INTEGER", nullable: false),
                    RolaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Role_RolaID",
                        column: x => x.RolaID,
                        principalSchema: "got",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PunktTrasyTerenGorski",
                schema: "got",
                columns: table => new
                {
                    PunktyTrasyID = table.Column<int>(type: "INTEGER", nullable: false),
                    TerenyGorskieID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunktTrasyTerenGorski", x => new { x.PunktyTrasyID, x.TerenyGorskieID });
                    table.ForeignKey(
                        name: "FK_PunktTrasyTerenGorski_PunktyTrasy_PunktyTrasyID",
                        column: x => x.PunktyTrasyID,
                        principalSchema: "got",
                        principalTable: "PunktyTrasy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunktTrasyTerenGorski_TerenyGorskie_TerenyGorskieID",
                        column: x => x.TerenyGorskieID,
                        principalSchema: "got",
                        principalTable: "TerenyGorskie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trasy",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PunktyZaTrase = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusTrasy = table.Column<int>(type: "INTEGER", nullable: false),
                    Dlugosc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SumaPodejsc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PunktStartowyID = table.Column<int>(type: "INTEGER", nullable: false),
                    PunktKoncowyID = table.Column<int>(type: "INTEGER", nullable: false),
                    TerenGorskiID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trasy_PunktyTrasy_PunktKoncowyID",
                        column: x => x.PunktKoncowyID,
                        principalSchema: "got",
                        principalTable: "PunktyTrasy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trasy_PunktyTrasy_PunktStartowyID",
                        column: x => x.PunktStartowyID,
                        principalSchema: "got",
                        principalTable: "PunktyTrasy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trasy_TerenyGorskie_TerenGorskiID",
                        column: x => x.TerenGorskiID,
                        principalSchema: "got",
                        principalTable: "TerenyGorskie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odznaki",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rodzaj = table.Column<int>(type: "INTEGER", nullable: false),
                    Stopien = table.Column<int>(type: "INTEGER", nullable: false),
                    WymaganePunkty = table.Column<int>(type: "INTEGER", nullable: false),
                    PunktyPrzeniesione = table.Column<int>(type: "INTEGER", nullable: false),
                    UzytkownikID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odznaki", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Odznaki_Uzytkownicy_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wycieczki",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataUtworzeznia = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nazwa = table.Column<string>(type: "varchar(255)", nullable: false),
                    CzyPubliczna = table.Column<bool>(type: "bit", nullable: false),
                    AutorID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycieczki", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wycieczki_Uzytkownicy_AutorID",
                        column: x => x.AutorID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utrudnienia",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "varcahr(50)", nullable: false),
                    Opis = table.Column<string>(type: "varchar(255)", nullable: false),
                    DataWystapienia = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrasaID = table.Column<int>(type: "INTEGER", nullable: false),
                    ZglaszajacyID = table.Column<int>(type: "INTEGER", nullable: false),
                    Zweryfikowane = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeryfikujacyID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utrudnienia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utrudnienia_Trasy_TrasaID",
                        column: x => x.TrasaID,
                        principalSchema: "got",
                        principalTable: "Trasy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utrudnienia_Uzytkownicy_WeryfikujacyID",
                        column: x => x.WeryfikujacyID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utrudnienia_Uzytkownicy_ZglaszajacyID",
                        column: x => x.ZglaszajacyID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrasaWycieczka",
                schema: "got",
                columns: table => new
                {
                    TrasyID = table.Column<int>(type: "INTEGER", nullable: false),
                    WycieczkiID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasaWycieczka", x => new { x.TrasyID, x.WycieczkiID });
                    table.ForeignKey(
                        name: "FK_TrasaWycieczka_Trasy_TrasyID",
                        column: x => x.TrasyID,
                        principalSchema: "got",
                        principalTable: "Trasy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrasaWycieczka_Wycieczki_WycieczkiID",
                        column: x => x.WycieczkiID,
                        principalSchema: "got",
                        principalTable: "Wycieczki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZgloszeniaWycieczek",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataZgloszenia = table.Column<DateTime>(type: "datetime", nullable: false),
                    Punkty = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataZmianyStatusu = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataOdbyciaWycieczki = table.Column<DateTime>(type: "datetime", nullable: false),
                    WycieczkaID = table.Column<int>(type: "INTEGER", nullable: false),
                    OdznakaID = table.Column<int>(type: "INTEGER", nullable: false),
                    TurystaID = table.Column<int>(type: "INTEGER", nullable: false),
                    PrzodownikID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZgloszeniaWycieczek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZgloszeniaWycieczek_Odznaki_OdznakaID",
                        column: x => x.OdznakaID,
                        principalSchema: "got",
                        principalTable: "Odznaki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZgloszeniaWycieczek_Uzytkownicy_PrzodownikID",
                        column: x => x.PrzodownikID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZgloszeniaWycieczek_Uzytkownicy_TurystaID",
                        column: x => x.TurystaID,
                        principalSchema: "got",
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZgloszeniaWycieczek_Wycieczki_WycieczkaID",
                        column: x => x.WycieczkaID,
                        principalSchema: "got",
                        principalTable: "Wycieczki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zdjecia",
                schema: "got",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "varchar(100)", nullable: true),
                    Dane = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ZgloszenieWycieczkiID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zdjecia_ZgloszeniaWycieczek_ZgloszenieWycieczkiID",
                        column: x => x.ZgloszenieWycieczkiID,
                        principalSchema: "got",
                        principalTable: "ZgloszeniaWycieczek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "got",
                table: "Role",
                columns: new[] { "ID", "Nazwa" },
                values: new object[] { 1, "Turysta" });

            migrationBuilder.InsertData(
                schema: "got",
                table: "Role",
                columns: new[] { "ID", "Nazwa" },
                values: new object[] { 2, "Przodownik" });

            migrationBuilder.InsertData(
                schema: "got",
                table: "Role",
                columns: new[] { "ID", "Nazwa" },
                values: new object[] { 3, "Pracownik PTTK" });

            migrationBuilder.CreateIndex(
                name: "IX_Odznaki_UzytkownikID",
                schema: "got",
                table: "Odznaki",
                column: "UzytkownikID");

            migrationBuilder.CreateIndex(
                name: "IX_PunktTrasyTerenGorski_TerenyGorskieID",
                schema: "got",
                table: "PunktTrasyTerenGorski",
                column: "TerenyGorskieID");

            migrationBuilder.CreateIndex(
                name: "IX_PunktyTrasy_Nazwa",
                schema: "got",
                table: "PunktyTrasy",
                column: "Nazwa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrasaWycieczka_WycieczkiID",
                schema: "got",
                table: "TrasaWycieczka",
                column: "WycieczkiID");

            migrationBuilder.CreateIndex(
                name: "IX_Trasy_PunktKoncowyID",
                schema: "got",
                table: "Trasy",
                column: "PunktKoncowyID");

            migrationBuilder.CreateIndex(
                name: "IX_Trasy_PunktStartowyID",
                schema: "got",
                table: "Trasy",
                column: "PunktStartowyID");

            migrationBuilder.CreateIndex(
                name: "IX_Trasy_TerenGorskiID",
                schema: "got",
                table: "Trasy",
                column: "TerenGorskiID");

            migrationBuilder.CreateIndex(
                name: "IX_Utrudnienia_TrasaID",
                schema: "got",
                table: "Utrudnienia",
                column: "TrasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Utrudnienia_WeryfikujacyID",
                schema: "got",
                table: "Utrudnienia",
                column: "WeryfikujacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Utrudnienia_ZglaszajacyID",
                schema: "got",
                table: "Utrudnienia",
                column: "ZglaszajacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_Email_NumerLegitymacji_NrPrzodownika",
                schema: "got",
                table: "Uzytkownicy",
                columns: new[] { "Email", "NumerLegitymacji", "NrPrzodownika" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_RolaID",
                schema: "got",
                table: "Uzytkownicy",
                column: "RolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczki_AutorID",
                schema: "got",
                table: "Wycieczki",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_ZgloszenieWycieczkiID",
                schema: "got",
                table: "Zdjecia",
                column: "ZgloszenieWycieczkiID");

            migrationBuilder.CreateIndex(
                name: "IX_ZgloszeniaWycieczek_OdznakaID",
                schema: "got",
                table: "ZgloszeniaWycieczek",
                column: "OdznakaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZgloszeniaWycieczek_PrzodownikID",
                schema: "got",
                table: "ZgloszeniaWycieczek",
                column: "PrzodownikID");

            migrationBuilder.CreateIndex(
                name: "IX_ZgloszeniaWycieczek_TurystaID",
                schema: "got",
                table: "ZgloszeniaWycieczek",
                column: "TurystaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZgloszeniaWycieczek_WycieczkaID",
                schema: "got",
                table: "ZgloszeniaWycieczek",
                column: "WycieczkaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PunktTrasyTerenGorski",
                schema: "got");

            migrationBuilder.DropTable(
                name: "TrasaWycieczka",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Utrudnienia",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Zdjecia",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Trasy",
                schema: "got");

            migrationBuilder.DropTable(
                name: "ZgloszeniaWycieczek",
                schema: "got");

            migrationBuilder.DropTable(
                name: "PunktyTrasy",
                schema: "got");

            migrationBuilder.DropTable(
                name: "TerenyGorskie",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Odznaki",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Wycieczki",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Uzytkownicy",
                schema: "got");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "got");
        }
    }
}
