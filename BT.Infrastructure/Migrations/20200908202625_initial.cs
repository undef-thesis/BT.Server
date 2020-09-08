using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BT.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avatar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaxParticipants = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MeetingOrganizerId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_MeetingOrganizerId",
                        column: x => x.MeetingOrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Revoked = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    MeetingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingImages_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeeting",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeeting", x => new { x.UserId, x.MeetingId });
                    table.ForeignKey(
                        name: "FK_UserMeeting_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeeting_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a7620c03-5ec6-48e8-823d-556fb754fadc"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(2200), "Basketball", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(2726) },
                    { new Guid("4288c454-116d-4fac-a1a0-9a662010311e"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3105), "Football", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3129) },
                    { new Guid("35a2cb97-aa21-4c16-9b5b-e7b31e648d1d"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3143), "Hokey", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3144) },
                    { new Guid("08942c16-8030-4920-ad64-85474a634973"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3147), "Running", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3148) },
                    { new Guid("13e15e4d-c673-44a9-bc3f-c4a290f44c50"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3150), "Ski", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3151) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Firstname", "Lastname", "Password", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("83b66e4c-792e-444c-b17b-861bf6a8a996"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5196), "admin@bt.com", "Aleksaner", "Ciechanowski", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5544) },
                    { new Guid("780191e1-b21c-4af0-9eba-1a0975573c9e"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5924), "admin1@bt.com", "Donald", "Lukaszenka", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5936) },
                    { new Guid("1a332175-00c6-4a12-ab53-2e8389927ca1"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5953), "admin2@bt.com", "Andrzej", "Kaczynski", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(5954) },
                    { new Guid("bb5cc0d6-40ec-44ab-9264-9ed9715dfbc4"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6163), "btmail@bt.com", "Jack", "Nowak", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6164) },
                    { new Guid("7168be64-1ad5-4579-b8a9-77362ef23c34"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6178), "btmail1@bt.com", "George", "Bush", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6179) },
                    { new Guid("a837f857-7848-492d-96a6-b06ce9f66a5e"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6181), "btmail2@bt.com", "Alina", "Ivanov", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6182) },
                    { new Guid("6a01ca03-2dde-4287-8e9e-19c24c17507f"), new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6185), "btmail3@bt.com", "Ksenya", "Barbie", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 9, 8, 20, 26, 24, 835, DateTimeKind.Utc).AddTicks(6186) }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Date", "Description", "MaxParticipants", "MeetingOrganizerId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9dc55c24-d2db-443d-9b8d-f79e3fbc961d"), new Guid("a7620c03-5ec6-48e8-823d-556fb754fadc"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(7721), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(3966), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("83b66e4c-792e-444c-b17b-861bf6a8a996"), "Find people to play basketball", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(8011) },
                    { new Guid("d0cf5f72-67ab-479d-9a52-2763e285622f"), new Guid("4288c454-116d-4fac-a1a0-9a662010311e"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9156), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9154), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 3, new Guid("83b66e4c-792e-444c-b17b-861bf6a8a996"), "Footboll tomorrow", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9157) },
                    { new Guid("f4862ae4-5f07-4aa3-843f-092616a5b677"), new Guid("08942c16-8030-4920-ad64-85474a634973"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9174), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9172), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 100, new Guid("83b66e4c-792e-444c-b17b-861bf6a8a996"), "Marathon", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9175) },
                    { new Guid("8c405e97-e3e9-4170-915e-e922913b3c99"), new Guid("13e15e4d-c673-44a9-bc3f-c4a290f44c50"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9185), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9176), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 1, new Guid("83b66e4c-792e-444c-b17b-861bf6a8a996"), "Ski in Tatry", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9186) },
                    { new Guid("6dc22a95-7b14-4d5c-84eb-d9698fc9f962"), new Guid("4288c454-116d-4fac-a1a0-9a662010311e"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9151), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9148), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 21, new Guid("780191e1-b21c-4af0-9eba-1a0975573c9e"), "Find friends to casual play", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9153) },
                    { new Guid("cae59f2f-587f-4f88-8963-61ca0246f9c9"), new Guid("35a2cb97-aa21-4c16-9b5b-e7b31e648d1d"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9165), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9163), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("780191e1-b21c-4af0-9eba-1a0975573c9e"), "ICE IS COLD. THIS WEEKEND", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9166) },
                    { new Guid("361d0fb2-7927-4338-8861-976e9a186be8"), new Guid("13e15e4d-c673-44a9-bc3f-c4a290f44c50"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9190), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9187), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("780191e1-b21c-4af0-9eba-1a0975573c9e"), "Ski next winter group", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9190) },
                    { new Guid("55baa25c-1a76-4749-bc3f-935b9dd9d2cc"), new Guid("a7620c03-5ec6-48e8-823d-556fb754fadc"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9111), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9015), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 6, new Guid("1a332175-00c6-4a12-ab53-2e8389927ca1"), "Find 6 guys to our basketball team", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9118) },
                    { new Guid("ae63279e-780c-4576-9f17-04dd29f0c567"), new Guid("35a2cb97-aa21-4c16-9b5b-e7b31e648d1d"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9161), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9159), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 6, new Guid("1a332175-00c6-4a12-ab53-2e8389927ca1"), "Find team to game", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9162) },
                    { new Guid("64050891-f745-4c38-9c5d-50a5ea81f2ed"), new Guid("08942c16-8030-4920-ad64-85474a634973"), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9170), new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9167), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
                            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
                            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
                            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
                            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
                            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
                            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
                            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
                            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
                            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
                            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
                            varius justo. Nam finibus fringilla leo eu lacinia.", 2, new Guid("1a332175-00c6-4a12-ab53-2e8389927ca1"), "Find somebody to running together", new DateTime(2020, 9, 8, 20, 26, 24, 837, DateTimeKind.Utc).AddTicks(9171) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_MeetingId",
                table: "Address",
                column: "MeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_UserId",
                table: "Avatar",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MeetingId",
                table: "Comments",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingImages_MeetingId",
                table: "MeetingImages",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CategoryId",
                table: "Meetings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingOrganizerId",
                table: "Meetings",
                column: "MeetingOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_MeetingId",
                table: "UserMeeting",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MeetingImages");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserMeeting");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
