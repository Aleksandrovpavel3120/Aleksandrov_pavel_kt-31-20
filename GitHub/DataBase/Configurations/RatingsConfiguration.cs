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
            //������ ��������� ����
            builder
                .HasKey(p => p.RaingsId)
                .HasName($"pk_{TableName}_ratings_id");

            //��� �������������� ���������� ����� ������ ������������� (� ������ ����� ������ ����� ��������� +1)
            builder.Property(p => p.RaingsId)
                    .ValueGeneratedOnAdd();

            //����������� ��� ����� ���������� ������� � ��, � ��� �� �� �������������� � ��
            builder.Property(p => p.RaingsId)
                .HasColumnName("ratings_id")
                .HasComment("������������� ��������");

            //HasComment ������� �����������, ������� ����� ������������ � ���� (��������� �� �������)
            builder.Property(p => p.RatingsName)
                .IsRequired()
                .HasColumnName("c_ratings_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("�������� ��������");

            builder.Property(p => p.GradeRatings)
                .IsRequired()
                .HasColumnName("c_ratings_grade")
                .HasColumnType(ColumnType.Int).HasMaxLength(100)
                .HasComment("������");



            builder.ToTable(TableName);



        }
    }
}