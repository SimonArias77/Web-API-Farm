using API_Farm.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace API_Farm.Seeders;
public class AnimalSeeder
{
    public static void Seed(ModelBuilder modelBuilder, int amout)
    {
        var animals = GenerateAnimals(amout);
        modelBuilder.Entity<Animal>().HasData(animals);
    }

    private static IEnumerable<Animal> GenerateAnimals(int count)
    {
        var faker = new Faker<Animal>()
            .RuleFor(a => a.Id, f => f.IndexFaker + 1)
            .RuleFor(a => a.Name, f => f.Person.FirstName)
            .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
            .RuleFor(a => a.AnimalTypeId, f => f.PickRandom(1, 2, 3, 4, 5, 6))
            .RuleFor(a => a.WeightKg, f => f.Random.Double(0.1, 500))
            .RuleFor(a => a.BirthDate, f => DateOnly.FromDateTime(f.Date.Past(5)));

        return faker.Generate(count);
    }

}