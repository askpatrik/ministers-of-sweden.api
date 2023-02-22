using System.Text.Json;
using ministers_of_sweden.api.Entities;

namespace ministers_of_sweden.api.Data
{
    public class SeedData
    {
           public static async Task LoadPartyData(MinistersOfSwedenContext context)
        {
           
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (context.Parties.Any()) return;
            var json = System.IO.File.ReadAllText("Data/json/parties.json");

            var parties = JsonSerializer.Deserialize<List<Party>>(json, options);

            if (parties is not null && parties.Count > 0)
            {
                await context.Parties.AddRangeAsync(parties);
                await context.SaveChangesAsync();
            }
        }
            public static async Task LoadDepartmentData(MinistersOfSwedenContext context)
        {
           
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (context.Departments.Any()) return;
            var json = System.IO.File.ReadAllText("Data/json/departments.json");

            var departments = JsonSerializer.Deserialize<List<Department>>(json, options);

            if (departments is not null && departments.Count > 0)
            {
                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }
        }
               public static async Task LoadAcademicFieldsData(MinistersOfSwedenContext context)
        {
           
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (context.AcademicFields.Any()) return;
            var json = System.IO.File.ReadAllText("Data/json/academicfields.json");

            var academicfields = JsonSerializer.Deserialize<List<AcademicField>>(json, options);

            if (academicfields is not null && academicfields.Count > 0)
            {
                await context.AcademicFields.AddRangeAsync(academicfields);
                await context.SaveChangesAsync();
            }
        }
                 public static async Task LoadMinisterData(MinistersOfSwedenContext context)
        {
           
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (context.Ministers.Any()) return;
            var json = System.IO.File.ReadAllText("Data/json/ministers.json");

            var ministers = JsonSerializer.Deserialize<List<Minister>>(json, options);

            if (ministers is not null && ministers.Count > 0)
            {
                await context.Ministers.AddRangeAsync(ministers);
                await context.SaveChangesAsync();
            }
        }
      
            
        }
    }
