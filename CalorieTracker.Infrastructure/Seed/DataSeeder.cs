using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;
using ClosedXML.Excel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalorieTracker.Infrastructure.Seed
{
    public class DataSeeder
    {
        public static async Task SeedFoodDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<DataSeeder>>();

            var excelPath = Path.Combine(AppContext.BaseDirectory, "database.xlsx");
            if (!File.Exists(excelPath)) return;

            using var workbook = new XLWorkbook(excelPath);
            var sheet = workbook.Worksheet("База");

            int seeded = 0;
            var categoryList = await unitOfWork.FoodCategories.GetAllAsync();
            var categoryMap = categoryList.ToDictionary(x => x.Name, x => x);

            foreach (var row in sheet.RowsUsed().Skip(1))
            {
                var name = row.Cell(1).GetValue<string>();
                var categoryName = row.Cell(7).GetValue<string>();
                var manufacturer = row.Cell(8).GetValue<string>();
                var calories = row.Cell(2).GetValue<float>();
                var protein = row.Cell(3).GetValue<float>();
                var carbs = row.Cell(4).GetValue<float>();
                var fat = row.Cell(5).GetValue<float>();
                var lenten = row.Cell(10).GetValue<bool>();

                manufacturer = string.IsNullOrWhiteSpace(manufacturer) ? null : manufacturer;
                if (await unitOfWork.FoodItems.ExistsAsync(name, manufacturer)) continue;

                if(!categoryMap.TryGetValue(categoryName, out var category))
                {
                    category = new FoodCategory { Name = categoryName };
                    await unitOfWork.FoodCategories.CreateAsync(category);
                    await unitOfWork.SaveChangesAsync();
                    categoryMap[categoryName] = category;
                }

                var item = new FoodItem
                {
                    Name = name,
                    Manufacturer = manufacturer,
                    CategoryId = category.Id,
                    Calories = calories,
                    Protein = protein,
                    Carbs = carbs,
                    Fat = fat,
                    IsApproved = true,
                    IsLenten = lenten
                };

                await unitOfWork.FoodItems.CreateAsync(item);
                seeded++;
            }

            await unitOfWork.SaveChangesAsync();
            logger.LogInformation("Сидер: учитано {Count} намирница.", seeded);
        }
    }
}
