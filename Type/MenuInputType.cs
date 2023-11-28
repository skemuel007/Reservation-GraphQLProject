using GraphQL.Types;

namespace GraphQLProject.Type;

public sealed class MenuInputType : InputObjectGraphType
{
    public MenuInputType()
    {
        Field<IntGraphType>("id");
        Field<StringGraphType>("name");
        Field<StringGraphType>("description");
        Field<FloatGraphType>("price");
        Field<StringGraphType>("imageUrl");
        Field<IntGraphType>("categoryId");
    }
}