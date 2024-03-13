using GitHub.Database.Helpers;
using GitHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitHub.Data.Configurations
{
	public class TestConfiguration : IEntityTypeConfiguration<Test>
	{
		private const string TableName = "cd_test";
		public void Configure(EntityTypeBuilder<Test> builder)
		{
			//������ ��������� ����
			builder
				.HasKey(p => p.TestId)
				.HasName($"pk_{TableName}_test_id");

			//��� �������������� ���������� ����� ������ ������������� (� ������ ����� ������ ����� ��������� +1)
			builder.Property(p => p.TestId)
					.ValueGeneratedOnAdd();

			//����������� ��� ����� ���������� ������� � ��, � ��� �� �� �������������� � ��
			builder.Property(p => p.TestId)
				.HasColumnName("test_id")
				.HasComment("������������� ������");

			//HasComment ������� �����������, ������� ����� ������������ � ���� (��������� �� �������)
			builder.Property(p => p.TestName)
				.IsRequired()
				.HasColumnName("c_test_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("�������� ������");

			builder.Property(p => p.IsTheTest)
				.IsRequired()
				.HasColumnName("c_test_ist")
				.HasColumnType(ColumnType.Int).HasMaxLength(100)
				.HasComment("����� ��� ���");



			builder.ToTable(TableName);
		}
	}
}