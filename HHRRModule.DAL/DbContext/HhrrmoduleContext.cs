using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HHRRModule.Model;

public partial class HhrrmoduleContext : DbContext
{
    public HhrrmoduleContext()
    {
    }

    public HhrrmoduleContext(DbContextOptions<HhrrmoduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorization> Authorizations { get; set; }

    public virtual DbSet<Employed> Employeds { get; set; }

    public virtual DbSet<FieldFormat> FieldFormats { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<RequestFormat> RequestFormats { get; set; }

    public virtual DbSet<RequestFormatAuth> RequestFormatAuths { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TypeFieldFormat> TypeFieldFormats { get; set; }

    public virtual DbSet<TypeFormat> TypeFormats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserState> UserStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.HasKey(e => e.IdAuthorization).HasName("PK__Authoriz__03AB044D4ACBFFF7");

            entity.ToTable("Authorization");

            entity.Property(e => e.IdAuthorization).HasColumnName("idAuthorization");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdParentAuth).HasColumnName("idParentAuth");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.IdTypeFormat).HasColumnName("idTypeFormat");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdParentAuthNavigation).WithMany(p => p.InverseIdParentAuthNavigation)
                .HasForeignKey(d => d.IdParentAuth)
                .HasConstraintName("FK__Authoriza__idPar__5812160E");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Authorizations)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Authoriza__idRol__571DF1D5");

            entity.HasOne(d => d.IdTypeFormatNavigation).WithMany(p => p.Authorizations)
                .HasForeignKey(d => d.IdTypeFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Authoriza__idTyp__5629CD9C");
        });

        modelBuilder.Entity<Employed>(entity =>
        {
            entity.HasKey(e => e.IdEmployed).HasName("PK__Employed__227F26A482051331");

            entity.ToTable("Employed");

            entity.Property(e => e.IdEmployed).HasColumnName("idEmployed");
            entity.Property(e => e.ClientAssigned)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientAssigned");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .HasColumnName("department");
            entity.Property(e => e.EntryDate).HasColumnName("entryDate");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.TypeEmployed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeEmployed");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UrlPhoto).HasColumnName("urlPhoto");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.State).WithMany(p => p.Employeds)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employed__stateI__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.Employeds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employed__userId__412EB0B6");
        });

        modelBuilder.Entity<FieldFormat>(entity =>
        {
            entity.HasKey(e => e.IdField).HasName("PK__FieldFor__84964D884D05147A");

            entity.ToTable("FieldFormat");

            entity.Property(e => e.IdField).HasColumnName("idField");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdRequestFormat).HasColumnName("idRequestFormat");
            entity.Property(e => e.IdTypeField).HasColumnName("idTypeField");
            entity.Property(e => e.NameFieldRequest)
                .HasMaxLength(255)
                .HasColumnName("nameFieldRequest");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.ValueField).HasColumnName("valueField");

            entity.HasOne(d => d.IdRequestFormatNavigation).WithMany(p => p.FieldFormats)
                .HasForeignKey(d => d.IdRequestFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FieldForm__idReq__52593CB8");

            entity.HasOne(d => d.IdTypeFieldNavigation).WithMany(p => p.FieldFormats)
                .HasForeignKey(d => d.IdTypeField)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FieldForm__idTyp__5165187F");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__Logs__3C7153CA2C75BDD2");

            entity.Property(e => e.IdLog).HasColumnName("idLog");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Logs__userId__628FA481");
        });

        modelBuilder.Entity<RequestFormat>(entity =>
        {
            entity.HasKey(e => e.IdRequest).HasName("PK__RequestF__F4A4109EC3334FAC");

            entity.ToTable("RequestFormat");

            entity.Property(e => e.IdRequest).HasColumnName("idRequest");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdEmployed).HasColumnName("idEmployed");
            entity.Property(e => e.IdTypeFormat).HasColumnName("idTypeFormat");
            entity.Property(e => e.NameRequest)
                .HasMaxLength(255)
                .HasColumnName("nameRequest");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdEmployedNavigation).WithMany(p => p.RequestFormats)
                .HasForeignKey(d => d.IdEmployed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestFo__idEmp__48CFD27E");

            entity.HasOne(d => d.IdTypeFormatNavigation).WithMany(p => p.RequestFormats)
                .HasForeignKey(d => d.IdTypeFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestFo__idTyp__49C3F6B7");
        });

        modelBuilder.Entity<RequestFormatAuth>(entity =>
        {
            entity.HasKey(e => e.IdProcessState).HasName("PK__RequestF__D3E862A543933191");

            entity.ToTable("RequestFormatAuth");

            entity.Property(e => e.IdProcessState).HasColumnName("idProcessState");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.IdRequestFormat).HasColumnName("idRequestFormat");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Value)
                .HasDefaultValue(false)
                .HasColumnName("value");

            entity.HasOne(d => d.IdAutorizacionNavigation).WithMany(p => p.RequestFormatAuths)
                .HasForeignKey(d => d.IdAutorizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestFo__idAut__5BE2A6F2");

            entity.HasOne(d => d.IdRequestFormatNavigation).WithMany(p => p.RequestFormatAuths)
                .HasForeignKey(d => d.IdRequestFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequestFo__idReq__5CD6CB2B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Role__E5045C54E48375E4");

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .HasColumnName("nameRol");
            entity.Property(e => e.ParentRoleId).HasColumnName("parentRoleId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.ParentRole).WithMany(p => p.InverseParentRole)
                .HasForeignKey(d => d.ParentRoleId)
                .HasConstraintName("FK__Role__parentRole__3B75D760");
        });

        modelBuilder.Entity<TypeFieldFormat>(entity =>
        {
            entity.HasKey(e => e.IdTypeField).HasName("PK__TypeFiel__F035A1AD3EBA97A0");

            entity.ToTable("TypeFieldFormat");

            entity.Property(e => e.IdTypeField).HasColumnName("idTypeField");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdTypeFormat).HasColumnName("idTypeFormat");
            entity.Property(e => e.NameTypeField)
                .HasMaxLength(100)
                .HasColumnName("nameTypeField");
            entity.Property(e => e.TypeValue).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdTypeFormatNavigation).WithMany(p => p.TypeFieldFormats)
                .HasForeignKey(d => d.IdTypeFormat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TypeField__idTyp__4D94879B");
        });

        modelBuilder.Entity<TypeFormat>(entity =>
        {
            entity.HasKey(e => e.IdTypeFormat).HasName("PK__TypeForm__9E578407897C02E5");

            entity.ToTable("TypeFormat");

            entity.Property(e => e.IdTypeFormat).HasColumnName("idTypeFormat");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.NameType)
                .HasMaxLength(50)
                .HasColumnName("nameType");
            entity.Property(e => e.TypeCode)
                .HasMaxLength(50)
                .HasColumnName("typeCode");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__3717C982D62FABE3");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DocumentIdType)
                .HasMaxLength(10)
                .HasColumnName("documentIdType");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.IdentityDocument)
                .HasMaxLength(50)
                .HasColumnName("identityDocument");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UrlPhoto)
                .HasMaxLength(255)
                .HasColumnName("urlPhoto");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_StateUser");
        });

        modelBuilder.Entity<UserState>(entity =>
        {
            entity.HasKey(e => e.IdState).HasName("PK__UserStat__98CB37234EF98EE1");

            entity.ToTable("UserState");

            entity.Property(e => e.IdState).HasColumnName("idState");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.NameState)
                .HasMaxLength(50)
                .HasColumnName("nameState");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
