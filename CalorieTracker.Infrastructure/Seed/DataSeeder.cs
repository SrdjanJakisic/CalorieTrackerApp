using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Interfaces;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure.Seed
{
    public class DataSeeder
    {
        public static async Task SeedFoodDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var excelPath = Path.Combine(AppContext.BaseDirectory, "database.xlsx");
            if (!File.Exists(excelPath)) return;

            using var workbook = new XLWorkbook(excelPath);
            var sheet = workbook.Worksheet("База");

            int seeded = 0;

            foreach(var row in sheet.RowsUsed().Skip(1))
            {
                var name = row.Cell(1).GetValue<string>();
                var categoryName = row.Cell(7).GetValue<string>();
                var manufacturer = row.Cell(8).GetValue<string>();
                var calories = row.Cell(2).GetValue<float>();
                var protein = row.Cell(3).GetValue<float>();
                var carbs = row.Cell(4).GetValue<float>();
                var fat = row.Cell(5).GetValue<float>();
                var lenten = row.Cell(10).GetValue<bool>();

                if (await unitOfWork.FoodItems.ExistsASync(name, manufacturer)) continue;

                var categories = await unitOfWork.FoodCategories.GetAllAsync();
                var category = categories.FirstOrDefault(x => x.Name == categoryName);
                if(category == null)
                {
                    category = new FoodCategory { Name = categoryName };
                    await unitOfWork.FoodCategories.CreateAsync(category);
                    await unitOfWork.SaveChangesAsync();
                }

                var item = new FoodItem
                {
                    Name = name,
                    Manufacturer = manufacturer,
                    CategoryId = category.Id,
                    CaloriesPer100g = calories,
                    ProteinPer100g = protein,
                    CarbsPer100g = carbs,
                    FatPer100g = fat,
                    IsApproved = true,
                    IsLenten = lenten
                };

                await unitOfWork.FoodItems.CreateAsync(item);
                seeded++;
            }

            await unitOfWork.SaveChangesAsync();
        }
    }
}
