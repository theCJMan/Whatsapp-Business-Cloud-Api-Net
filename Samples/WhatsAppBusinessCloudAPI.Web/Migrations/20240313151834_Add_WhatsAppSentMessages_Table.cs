using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsAppBusinessCloudAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class Add_WhatsAppSentMessages_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendTextPayload",
                columns: table => new
                {
                    tID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewUrl = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendTextPayload", x => x.tID);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppMedia",
                columns: table => new
                {
                    tID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppMedia", x => x.tID);
                });

            migrationBuilder.CreateTable(
                name: "WhatsappTemplate",
                columns: table => new
                {
                    tID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Params = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsappTemplate", x => x.tID);
                });

            migrationBuilder.CreateTable(
                name: "SendWhatsAppPayload",
                columns: table => new
                {
                    tID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendTexttID = table.Column<int>(type: "int", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    MediatID = table.Column<int>(type: "int", nullable: false),
                    TemplatetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendWhatsAppPayload", x => x.tID);
                    table.ForeignKey(
                        name: "FK_SendWhatsAppPayload_SendTextPayload_SendTexttID",
                        column: x => x.SendTexttID,
                        principalTable: "SendTextPayload",
                        principalColumn: "tID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendWhatsAppPayload_WhatsAppMedia_MediatID",
                        column: x => x.MediatID,
                        principalTable: "WhatsAppMedia",
                        principalColumn: "tID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendWhatsAppPayload_WhatsappTemplate_TemplatetID",
                        column: x => x.TemplatetID,
                        principalTable: "WhatsappTemplate",
                        principalColumn: "tID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "whatsAppSentMessages",
                columns: table => new
                {
                    tID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhatsAppMessagetID = table.Column<int>(type: "int", nullable: false),
                    WamID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whatsAppSentMessages", x => x.tID);
                    table.ForeignKey(
                        name: "FK_whatsAppSentMessages_SendWhatsAppPayload_WhatsAppMessagetID",
                        column: x => x.WhatsAppMessagetID,
                        principalTable: "SendWhatsAppPayload",
                        principalColumn: "tID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendWhatsAppPayload_MediatID",
                table: "SendWhatsAppPayload",
                column: "MediatID");

            migrationBuilder.CreateIndex(
                name: "IX_SendWhatsAppPayload_SendTexttID",
                table: "SendWhatsAppPayload",
                column: "SendTexttID");

            migrationBuilder.CreateIndex(
                name: "IX_SendWhatsAppPayload_TemplatetID",
                table: "SendWhatsAppPayload",
                column: "TemplatetID");

            migrationBuilder.CreateIndex(
                name: "IX_whatsAppSentMessages_WhatsAppMessagetID",
                table: "whatsAppSentMessages",
                column: "WhatsAppMessagetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "whatsAppSentMessages");

            migrationBuilder.DropTable(
                name: "SendWhatsAppPayload");

            migrationBuilder.DropTable(
                name: "SendTextPayload");

            migrationBuilder.DropTable(
                name: "WhatsAppMedia");

            migrationBuilder.DropTable(
                name: "WhatsappTemplate");
        }
    }
}
