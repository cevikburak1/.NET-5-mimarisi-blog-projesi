using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
   public class CategoryMap:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ıd);
            builder.Property(c => c.ıd).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDateTime).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    ıd = 1,
                    Name = "C#",
                    Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "C# Blog Kategorisi",
                },
                new Category
                {
                    ıd = 2,
                    Name = "C++",
                    Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "C++ Blog Kategorisi",
                },

                new Category
                {
                    ıd = 3,
                    Name = "JavaScript",
                    Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "JavaScript Blog Kategorisi",
                },
                new Category
                {
                    ıd = 4,
                    Name = "Typescript",
                    Description = "Typescript Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Typescript Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 5,
                    Name = "Java",
                    Description = "Java Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Java Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 6,
                    Name = "Python",
                    Description = "Python Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Python Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 7,
                    Name = "Php",
                    Description = "Php Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Php Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 8,
                    Name = "Kotlin",
                    Description = "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Kotlin Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 9,
                    Name = "Swift",
                    Description = "Swift Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Swift Blog Kategorisi",
                }
                ,
                new Category
                {
                    ıd = 10,
                    Name = "Ruby",
                    Description = "Ruby Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDateTime = DateTime.Now,
                    Note = "Ruby Blog Kategorisi",
                }
            );
        }
    }
}
