using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public sealed class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {

        Field<CategoryType>("CreateCategory").Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
            .Resolve(context => { return categoryRepository.AddCategory(context.GetArgument<Category>("category")); });
        
        Field<CategoryType>("UpdateCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" },
                new QueryArgument<MenuInputType> { Name = "category" }))
            .Resolve(context =>
            {

                var categoryId = context.GetArgument<int>("categoryId");
                var category = context.GetArgument<Category>("category");
                return categoryRepository.UpdateCategory(id: categoryId, category: category );
                
            });
        Field<StringGraphType>("DeleteCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
            .Resolve(context =>
            {
                categoryRepository.DeleteCategory(context.GetArgument<int>("category"));
                return "Your menu has been deleted.";
            });
    }

}