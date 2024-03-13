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
			//Задаем первичный ключ
			builder
				.HasKey(p => p.TestId)
				.HasName($"pk_{TableName}_test_id");

			//Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.TestId)
					.ValueGeneratedOnAdd();

			//Расписываем как будут называться колонки в БД, а так же их обязательность и тд
			builder.Property(p => p.TestId)
				.HasColumnName("test_id")
				.HasComment("Идентификатор зачета");

			//HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
			builder.Property(p => p.TestName)
				.IsRequired()
				.HasColumnName("c_test_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название зачета");

			builder.Property(p => p.IsTheTest)
				.IsRequired()
				.HasColumnName("c_test_ist")
				.HasColumnType(ColumnType.Int).HasMaxLength(100)
				.HasComment("Зачет или нет");



			builder.ToTable(TableName);
		}
	}
}