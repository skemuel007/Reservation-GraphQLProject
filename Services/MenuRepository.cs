using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuRepository : IMenuRepository
{
    private readonly GraphQlDbContext _context;

    public MenuRepository(GraphQlDbContext context)
    {
        _context = context;
    }

    public List<Menu> GetAllMenu()
    {
        return _context.Menus.ToList();
    }

    public Menu GetMenuById(int id)
    {
        return _context.Menus.SingleOrDefault(m => m.Id == id);
    }

    public Menu AddMenu(Menu menu)
    {
        _context.Menus.Add(menu);
        _context.SaveChanges();
        return menu;
    }

    public Menu UpdateMenu(int id, Menu menu)
    {
        if (!_context.Menus.Any())
            throw new Exception($"There are no items in the menu");

        var menuToUpdate = _context.Menus.SingleOrDefault(m => m.Id == id);

        if (menuToUpdate is null)
            throw new Exception($"Menu with {id} not found");

        menuToUpdate.Name = menu.Name;
        menuToUpdate.Description = menu.Description;
        menuToUpdate.Price = menu.Price;
        _context.Menus.Update(menuToUpdate);
        _context.SaveChanges();

        return menuToUpdate;
    }

    public void DeleteMenu(int id)
    {
        var menu = _context.Menus.SingleOrDefault(m => m.Id == id);
        if (menu is not null)
        {
            _context.Menus.Remove(menu);
            _context.SaveChanges();
        }
    }
}