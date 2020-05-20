using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PostgresBoolConverter.Model
{
	
	public partial class TableEntity  
	{
		public TableEntity()
		{
		}
		
		public string Item { get; set; }	
		
		public bool HasCustomers { get; set; }
	}	

	public class TableEntityConfiguration : IEntityTypeConfiguration<TableEntity>
    {
		public TableEntityConfiguration()
		{

		}
		public void Configure(EntityTypeBuilder<TableEntity> entity)
        {
			entity.HasKey(e => e.Item).HasName("PK_Items");

			var boolConverter = new BoolToTwoValuesConverter<char>('0', '1');

			entity.Property(e => e.Item).HasMaxLength(21).IsRequired().HasDefaultValueSql("('')");
				
			entity.Property(e => e.HasCustomers).HasColumnType("char(1)").HasConversion(boolConverter);
				
		}
	}
}