using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class CategoryRepository : ICategoryRepository
{
    private readonly GraphQlDbContext _context;

    public CategoryRepository(GraphQlDbContext context)
    {
        _context = context;
    }
    
    public List<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    public Category UpdateCategory(int id, Category category)
    {
        if (!_context.Categories.Any())
            throw new Exception($"No category found");

        var categoryToUpdate = _context.Categories.SingleOrDefault(m => m.Id == id);

        if (categoryToUpdate is null)
            throw new Exception($"Category with {id} not found");

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.ImageUrl = category.ImageUrl;

        _context.Categories.Update(categoryToUpdate);
        _context.SaveChanges();

        return categoryToUpdate;
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.SingleOrDefault(m => m.Id == id);
        if (category is not null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}