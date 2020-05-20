using Microsoft.EntityFrameworkCore;

namespace PostgresBoolConverter.Entensions
{
    internal static class ModelBuilderExtension
    {
        public static void SolveNamesToLowerCase(this ModelBuilder modelBuilder) => modelBuilder.SolveNamesTo(false);
        public static void SolveNamesToUpperCase(this ModelBuilder modelBuilder) => modelBuilder.SolveNamesTo(true);

        /*
        private static void SolveNamesTo(this ModelBuilder modelBuilder, bool upperCase)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.Relational().TableName = upperCase ?
                        entity.Relational().TableName.ToUpperInvariant() :
                        entity.Relational().TableName.ToLowerInvariant();

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = upperCase ? property.Name.ToUpperInvariant() : property.Name.ToLowerInvariant();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = upperCase ?
                            key.Relational().Name.ToUpperInvariant() :
                            key.Relational().Name.ToLowerInvariant();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = upperCase ?
                            key.Relational().Name.ToUpperInvariant() :
                            key.Relational().Name.ToLowerInvariant();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = upperCase ?
                        index.Relational().Name.ToUpperInvariant() :
                        index.Relational().Name.ToLowerInvariant();
                }
            }
        }
        */
        private static void SolveNamesTo(this ModelBuilder modelBuilder, bool upperCase)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.SetTableName(upperCase ?
                        entity.GetTableName().ToUpperInvariant() :
                        entity.GetTableName().ToLowerInvariant());

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(upperCase ? property.Name.ToUpperInvariant() : property.Name.ToLowerInvariant());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(upperCase ?
                            key.GetName().ToUpperInvariant() :
                            key.GetName().ToLowerInvariant());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(upperCase ?
                            key.GetConstraintName().ToUpperInvariant() :
                            key.GetConstraintName().ToLowerInvariant());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(upperCase ?
                        index.GetName().ToUpperInvariant() :
                        index.GetName().ToLowerInvariant());
                }
            }
        }
    }
}
