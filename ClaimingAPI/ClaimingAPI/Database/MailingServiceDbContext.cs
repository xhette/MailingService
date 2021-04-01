using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using ClaimingAPI.Database.Models;

#nullable disable

namespace ClaimingAPI.Database
{
    public partial class MailingServiceDbContext : DbContext
    {
        public MailingServiceDbContext()
        {
        }

        public MailingServiceDbContext(DbContextOptions<MailingServiceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MailingPort> MailingPorts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageStatus> MessageStatuses { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=MailingServiceDb;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<MailingPort>(entity =>
            {
                entity.HasKey(e => e.PortId)
                    .HasName("mailing_ports_pkey");

                entity.ToTable("mailing_ports");

                entity.Property(e => e.PortId).HasColumnName("port_id");

                entity.Property(e => e.PortName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("port_name");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.MessageType).HasColumnName("message_type");

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SendingDate)
                    .HasColumnType("date")
                    .HasColumnName("sending_date");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.MessageTypeNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MessageType)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("messages_message_type_fkey");

                entity.HasOne(d => d.PortNavigation)
                    .WithMany(p => p.MessagePortNavigations)
                    .HasForeignKey(d => d.Port)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("messages_port_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.MessageStatusNavigations)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("messages_status_fkey");
            });

            modelBuilder.Entity<MessageStatus>(entity =>
            {
                entity.ToTable("message_statuses");

                entity.Property(e => e.MessageStatusId).HasColumnName("message_status_id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.ToTable("message_types");

                entity.Property(e => e.MessageTypeId).HasColumnName("message_type_id");

                entity.Property(e => e.MessageTemplate)
                    .HasMaxLength(500)
                    .HasColumnName("message_template");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
