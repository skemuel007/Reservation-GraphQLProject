using GraphQL.Types;

namespace GraphQLProject.Type;

public sealed class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Field<IntGraphType>("id");
        Field<StringGraphType>("name");
        Field<StringGraphType>("imageUrl");
    }
}