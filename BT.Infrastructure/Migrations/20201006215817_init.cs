using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BT.Infrastructure.Migrations
{
    public partial class init : Migration
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
                    ParticipantCount = table.Column<int>(nullable: false),
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
                    Range = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
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
                    { new Guid("1f70d917-509b-4203-a9a7-a195f01c1ca1"), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(3354), "Basketball", new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(3843) },
                    { new Guid("51771ba3-80f5-45e2-9bda-6d9cc3b939f6"), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4314), "Football", new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4349) },
                    { new Guid("619b475a-81d4-4c55-8e48-2349bac9a37f"), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4364), "Hokey", new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4365) },
                    { new Guid("f16d8ed3-d085-4eaf-8071-f71332d49f80"), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4381), "Running", new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4382) },
                    { new Guid("e5db81e8-61b2-4323-b32a-4afe91e890d4"), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4386), "Ski", new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(4387) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Firstname", "Lastname", "Password", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b23033ad-a3b6-41fd-9273-0a8add33990a"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(2696), "admin@bt.com", "Aleksaner", "Ciechanowski", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(3403) },
                    { new Guid("6fe8e178-20a8-4be7-92b0-70db4e6d39c4"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4073), "admin1@bt.com", "Donald", "Lukaszenka", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4089) },
                    { new Guid("10fa020f-0948-4057-b442-70c6f336e273"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4109), "admin2@bt.com", "Andrzej", "Kaczynski", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4111) },
                    { new Guid("b2131cb2-ec73-470d-bba5-0a350c3c64b4"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4406), "btmail@bt.com", "Jack", "Nowak", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4407) },
                    { new Guid("05ac4842-73f2-47f9-8bc5-ddc2baf26e21"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4411), "btmail1@bt.com", "George", "Bush", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4412) },
                    { new Guid("77525bc2-3b61-4e1f-ac07-5ad1a8d9fbf1"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4415), "btmail2@bt.com", "Alina", "Ivanov", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4416) },
                    { new Guid("1022fd8f-28fd-46c4-88d4-00924f4c99b4"), new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4420), "btmail3@bt.com", "Ksenya", "Barbie", "123456", new byte[] { 98, 116, 45, 115, 97, 108, 116 }, new DateTime(2020, 10, 6, 21, 58, 16, 451, DateTimeKind.Utc).AddTicks(4421) }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Date", "Description", "MaxParticipants", "MeetingOrganizerId", "Name", "ParticipantCount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5ccbb1ca-0a0b-4ee2-a66d-f1c1411a23d2"), new Guid("1f70d917-509b-4203-a9a7-a195f01c1ca1"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(181), new DateTime(2020, 10, 6, 21, 58, 16, 453, DateTimeKind.Utc).AddTicks(5459), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("b23033ad-a3b6-41fd-9273-0a8add33990a"), "Find people to play basketball", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(559) },
                    { new Guid("de2f774f-9d26-4886-8499-9fa4b7620dbc"), new Guid("51771ba3-80f5-45e2-9bda-6d9cc3b939f6"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2029), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2012), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 3, new Guid("b23033ad-a3b6-41fd-9273-0a8add33990a"), "Footboll tomorrow", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2031) },
                    { new Guid("efd637ec-4458-4154-9b49-e3b182543950"), new Guid("f16d8ed3-d085-4eaf-8071-f71332d49f80"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2064), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2061), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 100, new Guid("b23033ad-a3b6-41fd-9273-0a8add33990a"), "Marathon", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2065) },
                    { new Guid("d41c6422-33b1-4ab9-b9b5-c43a89ca4421"), new Guid("e5db81e8-61b2-4323-b32a-4afe91e890d4"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2070), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2067), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 1, new Guid("b23033ad-a3b6-41fd-9273-0a8add33990a"), "Ski in Tatry", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2072) },
                    { new Guid("eccc001f-55c0-4b88-b77a-3bf593a420c2"), new Guid("51771ba3-80f5-45e2-9bda-6d9cc3b939f6"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2008), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2003), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 21, new Guid("6fe8e178-20a8-4be7-92b0-70db4e6d39c4"), "Find friends to casual play", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2010) },
                    { new Guid("a226c49f-ae4e-4170-8302-77aebedfa022"), new Guid("619b475a-81d4-4c55-8e48-2349bac9a37f"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2042), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2039), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("6fe8e178-20a8-4be7-92b0-70db4e6d39c4"), "ICE IS COLD. THIS WEEKEND", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2043) },
                    { new Guid("56b39e65-217a-42a2-80d4-86686beaeb00"), new Guid("e5db81e8-61b2-4323-b32a-4afe91e890d4"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2076), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2073), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 12, new Guid("6fe8e178-20a8-4be7-92b0-70db4e6d39c4"), "Ski next winter group", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2078) },
                    { new Guid("0115c83b-7c52-4944-86f1-cc84c16dc258"), new Guid("1f70d917-509b-4203-a9a7-a195f01c1ca1"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(1952), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(1747), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 6, new Guid("10fa020f-0948-4057-b442-70c6f336e273"), "Find 6 guys to our basketball team", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(1967) },
                    { new Guid("90418db2-0429-41c8-95b1-88ba140db598"), new Guid("619b475a-81d4-4c55-8e48-2349bac9a37f"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2036), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2032), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 6, new Guid("10fa020f-0948-4057-b442-70c6f336e273"), "Find team to game", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2037) },
                    { new Guid("1d8fab4f-2a9b-47d2-ae00-9c09de237f83"), new Guid("f16d8ed3-d085-4eaf-8071-f71332d49f80"), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2058), new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2045), @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
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
                            varius justo. Nam finibus fringilla leo eu lacinia.", 2, new Guid("10fa020f-0948-4057-b442-70c6f336e273"), "Find somebody to running together", 0, new DateTime(2020, 10, 6, 21, 58, 16, 454, DateTimeKind.Utc).AddTicks(2059) }
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
