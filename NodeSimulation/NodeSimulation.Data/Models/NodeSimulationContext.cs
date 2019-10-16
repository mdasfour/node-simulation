using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NodeSimulation.Data.Models
{
    public partial class NodeSimulationContext : DbContext
    {
        public NodeSimulationContext()
        {
        }

        public NodeSimulationContext(DbContextOptions<NodeSimulationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nodes> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NodeSimulation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Nodes>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("IX_City");

                entity.HasIndex(e => e.ConnectedClients)
                    .HasName("IX_Connected_Clients");

                entity.HasIndex(e => e.Deleted)
                    .HasName("IX_Deleted");

                entity.HasIndex(e => e.DownloadUtilization)
                    .HasName("IX_Download_Utilization");

                entity.HasIndex(e => e.ErrorRate)
                    .HasName("IX_Error_Rate");

                entity.HasIndex(e => e.IsOnline)
                    .HasName("IX_Is_Online");

                entity.HasIndex(e => e.MaxConnectedClients)
                    .HasName("IX_Max_Connected_Clients");

                entity.HasIndex(e => e.MaxDownloadUtilization)
                    .HasName("IX_Max_Download_Utilization");

                entity.HasIndex(e => e.MaxErrorRate)
                    .HasName("IX_Max_Error_Rate");

                entity.HasIndex(e => e.MaxUploadUtilization)
                    .HasName("IX_Max_Upload_Utilization");

                entity.HasIndex(e => e.NodeId)
                    .HasName("IX_Node_Id");

                entity.HasIndex(e => e.OnlineTime)
                    .HasName("IX_Online_Time");

                entity.HasIndex(e => e.UploadUtilization)
                    .HasName("IX_Upload_Utilization");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ConnectedClientsExceeded).HasComputedColumnSql("(case when [ConnectedClients]>[MaxConnectedClients] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)");

                entity.Property(e => e.DeletedDT)
                    .HasColumnName("DeletedDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DownloadUtilization).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.DownloadUtilizationExceeded).HasComputedColumnSql("(case when [DownloadUtilization]>[MaxDownloadUtilization] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)");

                entity.Property(e => e.ErrorRate).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ErrorRateExceeded).HasComputedColumnSql("(case when [ErrorRate]>[MaxErrorRate] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)");

                entity.Property(e => e.InsertedDT)
                    .HasColumnName("InsertedDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaxDownloadUtilization).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.MaxErrorRate).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.MaxUploadUtilization).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.OnlineTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDT)
                    .HasColumnName("UpdatedDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UploadUtilization).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.UploadUtilizationExceeded).HasComputedColumnSql("(case when [UploadUtilization]>[MaxUploadUtilization] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)");
            });
        }
    }
}
