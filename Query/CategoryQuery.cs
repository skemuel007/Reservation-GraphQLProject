using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public sealed class CategoryQuery : ObjectGraphType
{
    public CategoryQuery(ICategoryRepository categoryRepository)
    {
        Field<ListGraphType<CategoryType>>("Categories")
            .Resolve(context =>
            {
                return categoryRepository.GetCategories();
            });
    }
}