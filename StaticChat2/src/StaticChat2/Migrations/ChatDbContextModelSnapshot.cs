using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StaticChat.Models;

namespace StaticChat2.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    partial class ChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StaticChat.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MessageId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StaticChat.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Sign");

                    b.Property<string>("Text");

                    b.Property<DateTime>("When");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("StaticChat.Models.Comment", b =>
                {
                    b.HasOne("StaticChat.Models.Message", "Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageId");
                });
        }
    }
}
