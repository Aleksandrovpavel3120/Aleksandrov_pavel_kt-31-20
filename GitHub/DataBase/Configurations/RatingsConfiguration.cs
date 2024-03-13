using GitHub.Database.Helpers;
using GitHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitHub.Data.Configurations
{
    public class RatingsConfiguration : IEntityTypeConfiguration<Ratings>
    {

        private const string TableName = "cd_ratings";
        public void Configure(EntityTypeBuilder<Ratings> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.RaingsId)
                .HasName($"pk_{TableName}_ratings_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.RaingsId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.RaingsId)
                .HasColumnName("ratings_id")
                .HasComment("Идентификатор экзамена");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.RatingsName)
                .IsRequired()
                .HasColumnName("c_ratings_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название экзамена");

            builder.Property(p => p.GradeRatings)
                .IsRequired()
                .HasColumnName("c_ratings_grade")
                .HasColumnType(ColumnType.Int).HasMaxLength(100)
                .HasComment("Оценка");



            builder.ToTable(TableName);



        }
    }
}