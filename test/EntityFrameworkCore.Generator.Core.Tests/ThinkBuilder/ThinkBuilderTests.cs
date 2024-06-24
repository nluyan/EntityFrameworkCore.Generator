using System.IO;

using EntityFrameworkCore.Generator.Options;

using FluentAssertions;

using FluentCommand.SqlServer.Tests;

using JsonFlatFileDataStore;

using Microsoft.Extensions.Logging.Abstractions;
using ThinkBuilder.Models.Studio;

using ThinkBuilder.Services.CodeGenerator.EFCore;

using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.Generator.Core.Tests;

public class ThinkBuilderTests : DatabaseTestBase
{
    public ThinkBuilderTests(ITestOutputHelper output, DatabaseFixture databaseFixture) : base(output, databaseFixture)
    {
    }

    [Fact]
    public void CodeGeneratorTest()
    {
        var file = @"D:\temp\EntityTest.json";
        if (File.Exists(file))
            File.Delete(file);
        using (var dataStore = new DataStore(file))
        {
            var entities = dataStore.GetCollection<EntityInfo>();

            Guid InstructorId = Guid.NewGuid();
            Guid DepartmentId = Guid.NewGuid();
            Guid CourseId = Guid.NewGuid();
            Guid EnrollmentId = Guid.NewGuid();
            Guid StudentId = Guid.NewGuid();
            Guid OfficeAssignmentId = Guid.NewGuid();

            entities.InsertMany(
            [
                //Instructor
                new EntityInfo
                    {
                        Id = InstructorId,
                        Key = "Instructor",
                        Name = "Instructor",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "LastName",
                                Desc = "LastName",
                                ColumnName = "LastName",
                                Type = PropertyTypeEnum.String,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "LastName",
                                Desc = "LastName",
                                ColumnName = "LastName",
                                Type = PropertyTypeEnum.String,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "HireDate",
                                Desc = "HireDate",
                                ColumnName = "HireDate",
                                Type = PropertyTypeEnum.DateTime
                            }
                        ]
                    },
                    //Department
                    new EntityInfo
                    {
                        Id = DepartmentId,
                        Key = "Department",
                        Name = "Department",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Name",
                                Desc = "Name",
                                ColumnName = "Name",
                                Type = PropertyTypeEnum.String,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Budget",
                                Desc = "Budget",
                                ColumnName = "Budget",
                                Type = PropertyTypeEnum.Money,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "StartDate",
                                Desc = "StartDate",
                                ColumnName = "StartDate",
                                Type = PropertyTypeEnum.DateTime,
                                IsNullable = true
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "InstructorId",
                                Desc = "InstructorId",
                                ColumnName = "InstructorId",
                                Type = PropertyTypeEnum.ID,
                                RelationshipAction = RelationshipActionEnum.Cascade,
                                Relationship = PropertyRelationshipEnum.OneToOne,
                                EntityId = InstructorId
                            }
                        ]
                    },
                    //Course
                    new EntityInfo
                    {
                        Id = CourseId,
                        Key = "Course",
                        Name = "Course",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Title",
                                Desc = "Title",
                                ColumnName = "Title",
                                Type = PropertyTypeEnum.String,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Credits",
                                Desc = "Credits",
                                ColumnName = "Credits",
                                Type = PropertyTypeEnum.Money,
                                Length = 255,
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "DepartmentId",
                                Desc = "DepartmentId",
                                ColumnName = "DepartmentId",
                                Type = PropertyTypeEnum.ID,
                                RelationshipAction = RelationshipActionEnum.Cascade,
                                Relationship = PropertyRelationshipEnum.OneToMany,
                                EntityId = DepartmentId
                            }
                        ]
                    },
                    //Enrollment
                    new EntityInfo
                    {
                        Id = EnrollmentId,
                        Key = "Enrollment",
                        Name = "Enrollment",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Grade",
                                Desc = "Title",
                                ColumnName = "Title",
                                Type = PropertyTypeEnum.Integer
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "StudentId",
                                Desc = "StudentId",
                                ColumnName = "StudentId",
                                Type = PropertyTypeEnum.ID,
                                RelationshipAction = RelationshipActionEnum.Cascade,
                                Relationship = PropertyRelationshipEnum.OneToMany,
                                EntityId = StudentId
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "CourseId",
                                Desc = "CourseId",
                                ColumnName = "CourseId",
                                Type = PropertyTypeEnum.ID,
                                RelationshipAction = RelationshipActionEnum.Cascade,
                                Relationship = PropertyRelationshipEnum.OneToMany,
                                EntityId = CourseId
                            }
                        ]
                    },
                    //Student
                    new EntityInfo
                    {
                        Id = StudentId,
                        Key = "Student",
                        Name = "Student",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Name",
                                Desc = "Name",
                                ColumnName = "Name",
                                Type = PropertyTypeEnum.String
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "EnrollmentDate",
                                Desc = "EnrollmentDate",
                                ColumnName = "EnrollmentDate",
                                Type = PropertyTypeEnum.DateTime
                            }
                        ]
                    },
                    //OfficeAssignment
                    new EntityInfo
                    {
                        Id = OfficeAssignmentId,
                        Key = "OfficeAssignment",
                        Name = "OfficeAssignment",
                        ModuleId = Guid.Parse("e49df5a0-efa7-4d9f-9544-8aebc2969018"),
                        Properties =
                        [
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "Location",
                                Desc = "Location",
                                ColumnName = "Location",
                                Type = PropertyTypeEnum.String
                            },
                            new EntityProperty
                            {
                                Id = Guid.NewGuid().ToString(),
                                Key = "InstructorId",
                                Desc = "InstructorId",
                                ColumnName = "InstructorId",
                                Type = PropertyTypeEnum.ID,
                                IsNullable = true,
                                RelationshipAction = RelationshipActionEnum.Cascade,
                                Relationship = PropertyRelationshipEnum.OneToOne,
                                EntityId = InstructorId
                            }
                        ]
                    },
                ]);
        }

        if (Directory.Exists(@"D:\temp\Code"))
            Directory.Delete(@"D:\temp\Code", true);
        Directory.CreateDirectory(@"D:\temp\Code");
        var generatorOptions = new GeneratorOptions();
        generatorOptions.Data.Context.Directory = @"D:\temp\Code";
        generatorOptions.Data.Entity.Directory = @"D:\temp\Code";
        generatorOptions.Data.Mapping.Directory = @"D:\temp\Code";
        generatorOptions.Data.Entity.BaseClass = "BaseClass";
        generatorOptions.Data.Query.Generate = true;
        generatorOptions.Data.Query.Directory = @"D:\temp\Code";

        generatorOptions.Model.Read.Generate = true;
        generatorOptions.Model.Read.Directory = @"D:\temp\Code";
        generatorOptions.Model.Update.Generate = true;
        generatorOptions.Model.Update.Directory = @"D:\temp\Code";
        generatorOptions.Model.Create.Generate = true;
        generatorOptions.Model.Create.Directory = @"D:\temp\Code";

        generatorOptions.Model.Validator.Generate = true;
        generatorOptions.Model.Validator.Directory = @"D:\temp\Code";

        generatorOptions.Model.Mapper.Generate = true;
        generatorOptions.Model.Mapper.Directory = @"D:\temp\Code";

        generatorOptions.Database.ConnectionString = $"{file};e49df5a0-efa7-4d9f-9544-8aebc2969018";
        var generator = new EFCoreGenerator(NullLoggerFactory.Instance);
        var result = generator.Generate(generatorOptions);


        result.Should().BeTrue();
    }
}

