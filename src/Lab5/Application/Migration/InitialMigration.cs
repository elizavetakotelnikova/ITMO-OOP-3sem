using FluentMigrator;

namespace Application.Migration;
[Migration(2)]
public class InitialMigration : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Log2")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Text").AsString();
    }

    public override void Down()
    {
        Delete.Table("Log");
    }
}