using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Configuration;
//https://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table
namespace A2_2
{
    class YoYoDbContext : DbContext
    {
       
        public YoYoDbContext() : base("YoYo")
        {
            
        }
        #region Properties
        public DbSet<WorkArea> WorkAreas { get; set; }

        public DbSet<Line> Lines { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Serial> Serial { get; set; }
        public DbSet<SerialState> SerialState { get; set; }
        public DbSet<SerialProduct> SerialProduct { get; set; }
        #endregion
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Serial>()
        //        .HasMany<State>(s => s.State)
        //        .WithMany(c => c.Serial)
        //        .Map(cs =>
        //        {
        //            cs.MapLeftKey("SerialId");
        //            cs.MapRightKey("StateName");
        //            cs.ToTable("SerialState");
        //        });

        //    modelBuilder.Entity<Serial>()
        //        .HasMany<Product>(s => s.Product)
        //        .WithMany(c => c.Serial)
        //        .Map(cs =>
        //        {
        //            cs.MapLeftKey("SerialId");
        //            cs.MapRightKey("ProductId");
        //            cs.ToTable("ProductSerial");
        //        });
        //    modelBuilder.Entity<Serial>().HasKey(q => q.SerialId);
        //    modelBuilder.Entity<State>().HasKey(q => q.StateName);
        //    modelBuilder.Entity<SerialState>().HasKey(q => new { q.SerialId, q.StateName });
        //    modelBuilder.Entity<SerialState>()
        //    .HasRequired(t => t.Serial)
        //    .WithMany(t => t.SerialState)
        //    .HasForeignKey(t => t.SerialId);

        //    modelBuilder.Entity<SerialState>()
        //        .HasRequired(t => t.State)
        //        .WithMany(t => t.SerialState)
        //        .HasForeignKey(t => t.StateName);
        //}

    }
    [Table("WorkArea")]
    public class WorkArea
    {
        [Key]
        public string WorkAreaId { get; set; }

        // using Icollection<Line> here instead virtual WrokArea on Line class
        public virtual ICollection<Line> Line { get; set; }
        
    }
    [Table("Line")]
    public class Line
    {
        [Key]
        public string LineId { get; set; }
        public string WorkAreaId { get; set; }

        //[ForeignKey("WorkAreaId")]
        //public virtual WorkArea WorkArea { get; set; }
        

    }
    [Table("Serial")]
    public class Serial
    {
        [Key]
        public string SerialId { get; set; }
        public string LineId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("LineId")]
        public virtual Line Line { get; set; }
        public virtual ICollection<SerialState> SerialState { get; set; }
        public virtual ICollection<SerialProduct> Product { get; set; }
    }
    
    [Table("State")]
    public class State
    {
        
        [Key]
        public string StateName { get; set; }
        public virtual ICollection<SerialState> SerialState { get; set; }

    }
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SerialProduct> Serial { get; set; }
    }

    [Table("SerialState")]
    public class SerialState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialStateId { get; set; }//auto incrament
        public string SerialId { get; set; }
        public string StateName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }


        //[ForeignKey("SerialId")]
        public virtual Serial Serial { get; set; }
        //[ForeignKey("StateName")]
        public virtual State State { get; set; }
    }

    [Table("SerialProduct")]
    public class SerialProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialproductId { get; set; }// auto increment
        public string SerialId { get; set; }
        public int ProductId { get; set; }

        //[ForeignKey("SerialId")]
        public virtual Serial Serial { get; set; }
        //[ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
