﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2022. 04. 28. 19:22:40
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace beadando
{

    public partial class cnbeadando : DbContext
    {

        public cnbeadando() : base() { }

        public cnbeadando(DbContextOptions<cnbeadando> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Adr\\source\\repos\\Nagybead\\Bead2.mdf; Integrated Security = True");
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }
        /*private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }*/

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<ruhák> ruháks
        {
            get;
            set;
        }

        public virtual DbSet<tipus> tipus
        {
            get;
            set;
        }

        public virtual DbSet<választott> választotts
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.ruhákMapping(modelBuilder);
            this.CustomizeruhákMapping(modelBuilder);

            this.tipusMapping(modelBuilder);
            this.CustomizetipusMapping(modelBuilder);

            this.választottMapping(modelBuilder);
            this.CustomizeválasztottMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region ruhák Mapping

        private void ruhákMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ruhák>().ToTable(@"ruháks");
            modelBuilder.Entity<ruhák>().Property(x => x.ruha).HasColumnName(@"ruha").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ruhák>().Property(x => x.jelleg).HasColumnName(@"jelleg").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ruhák>().HasKey(@"ruha");
        }

        partial void CustomizeruhákMapping(ModelBuilder modelBuilder);

        #endregion

        #region tipus Mapping

        private void tipusMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tipus>().ToTable(@"tipus");
            modelBuilder.Entity<tipus>().Property(x => x.id).HasColumnName(@"id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<tipus>().Property(x => x.típus).HasColumnName(@"típus").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<tipus>().Property(x => x.nem).HasColumnName(@"nem").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<tipus>().HasKey(@"id");
        }

        partial void CustomizetipusMapping(ModelBuilder modelBuilder);

        #endregion

        #region választott Mapping

        private void választottMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<választott>().ToTable(@"választotts");
            modelBuilder.Entity<választott>().Property(x => x.id).HasColumnName(@"id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<választott>().Property(x => x.nadrág).HasColumnName(@"nadrág").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<választott>().Property(x => x.felső).HasColumnName(@"felső").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<választott>().Property(x => x.cipő).HasColumnName(@"cipő").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<választott>().HasKey(@"id");
        }

        partial void CustomizeválasztottMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ruhák>().HasOne(x => x.tipus).WithMany(op => op.ruháks).HasForeignKey(@"jelleg").IsRequired(true);

            modelBuilder.Entity<tipus>().HasMany(x => x.ruháks).WithOne(op => op.tipus).HasForeignKey(@"jelleg").IsRequired(true);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
