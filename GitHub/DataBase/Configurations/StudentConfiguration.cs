using GitHub.Database.Helpers;
using GitHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GitHub.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        //�������� �������, ������� ����� ������������ � ��
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //������ ��������� ����
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //��� �������������� ���������� ����� ������ ������������� (� ������ ����� ������ ����� ��������� +1)
            builder.Property(p => p.StudentId)
                    .ValueGeneratedOnAdd();

            //����������� ��� ����� ���������� ������� � ��, � ��� �� �� �������������� � ��
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("������������� ������ ��������");

            //HasComment ������� �����������, ������� ����� ������������ � ���� (��������� �� �������)
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("��� ��������");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("������� ��������");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("�������� ��������");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("������������� ������");

            builder.Property(p => p.RatingsId)
                .IsRequired()
                .HasColumnName("f_ratings_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("������");

            builder.Property(p => p.TestId)
                .IsRequired()
                .HasColumnName("f_test_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("�����");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            //������� ����� ������������� ��������� ��������
            builder.Navigation(p => p.Group)
                .AutoInclude();

            builder.ToTable(TableName)
                .HasOne(p => p.Test)
                .WithMany()
                .HasForeignKey(p => p.TestId)
                .HasConstraintName("fk_f_test_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.TestId, $"idx_{TableName}_fk_f_test_id");

            //������� ����� ������������� ��������� ��������
            builder.Navigation(p => p.Test)
                .AutoInclude();

            builder.ToTable(TableName)
                .HasOne(p => p.Ratings)
                .WithMany()
                .HasForeignKey(p => p.RatingsId)
                .HasConstraintName("fk_f_ratings_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.RatingsId, $"idx_{TableName}_fk_f_ratings_id");

            //������� ����� ������������� ��������� ��������
            builder.Navigation(p => p.Ratings)
                .AutoInclude();
        }
    }
}