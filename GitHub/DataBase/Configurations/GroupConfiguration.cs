using GitHub.Database.Helpers;
using GitHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitHub.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //������ ��������� ����
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            //��� �������������� ���������� ����� ������ ������������� (� ������ ����� ������ ����� ��������� +1)
            builder.Property(p => p.GroupId)
                    .ValueGeneratedOnAdd();

            //����������� ��� ����� ���������� ������� � ��, � ��� �� �� �������������� � ��
            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("������������� ������ ������");

            //HasComment ������� �����������, ������� ����� ������������ � ���� (��������� �� �������)
            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("�������� ������");

            builder.ToTable(TableName);
        }
    }
}