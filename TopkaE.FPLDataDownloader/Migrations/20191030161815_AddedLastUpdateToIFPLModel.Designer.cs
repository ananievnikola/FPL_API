﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopkaE.FPLDataDownloader.DBContext;

namespace TopkaE.FPLDataDownloader.Migrations
{
    [DbContext(typeof(TopkaEContext))]
    [Migration("20191030161815_AddedLastUpdateToIFPLModel")]
    partial class AddedLastUpdateToIFPLModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TopkaE.FPLDataDownloader.Models.InputModels.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Assists");

                    b.Property<int>("Bonus");

                    b.Property<int>("Bps");

                    b.Property<int?>("ChanceOfPlayingNextRound");

                    b.Property<int?>("ChanceOfPlayingThisRound");

                    b.Property<int>("CleanSheets");

                    b.Property<int>("Code");

                    b.Property<int>("CostChangeEvent");

                    b.Property<int>("CostChangeEventFall");

                    b.Property<int>("CostChangeStart");

                    b.Property<int>("CostChangeStartFall");

                    b.Property<string>("Creativity");

                    b.Property<int>("DreamteamCount");

                    b.Property<int>("ElementType");

                    b.Property<string>("EpNext");

                    b.Property<string>("EpThis");

                    b.Property<int>("EventPoints");

                    b.Property<string>("FirstName");

                    b.Property<string>("Form");

                    b.Property<int>("GoalsConceded");

                    b.Property<int>("GoalsScored");

                    b.Property<string>("IctIndex");

                    b.Property<bool>("InDreamteam");

                    b.Property<string>("Influence");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int>("Minutes");

                    b.Property<string>("News");

                    b.Property<DateTime?>("NewsAdded");

                    b.Property<int>("NowCost");

                    b.Property<int>("OwnGoals");

                    b.Property<int>("PenaltiesMissed");

                    b.Property<int>("PenaltiesSaved");

                    b.Property<string>("Photo");

                    b.Property<string>("PointsPerGame");

                    b.Property<int>("RedCards");

                    b.Property<int>("Saves");

                    b.Property<string>("SecondName");

                    b.Property<string>("SelectedByPercent");

                    b.Property<bool>("Special");

                    b.Property<string>("Status");

                    b.Property<int>("Team");

                    b.Property<int>("TeamCode");

                    b.Property<string>("Threat");

                    b.Property<int>("TotalPoints");

                    b.Property<int>("TransfersIn");

                    b.Property<int>("TransfersInEvent");

                    b.Property<int>("TransfersOut");

                    b.Property<int>("TransfersOutEvent");

                    b.Property<string>("ValueForm");

                    b.Property<string>("ValueSeason");

                    b.Property<string>("WebName");

                    b.Property<int>("YellowCards");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}
