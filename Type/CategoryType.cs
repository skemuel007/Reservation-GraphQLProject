using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Type;

public sealed class CategoryType : ObjectGraphType<Category>
{
    public CategoryType(IMenuRepository menuRepository)
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.ImageUrl);
        Field<ListGraphType<MenuType>>("Menus")
            .Resolve(context => menuRepository.GetAllMenu());
    }
}