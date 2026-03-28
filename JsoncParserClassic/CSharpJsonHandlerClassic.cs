// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpJsonHandlerClassic: IParseJson
{
    private readonly JsoncParserClassic jsonParser;
    public CSharpJsonHandlerClassic(bool numberAsDecimal)
    {
        this.jsonParser = new JsoncParserClassic(numberAsDecimal);
    }
    public object ParseJson(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
    public object[] ParseJsonSequence(string jsonSequenceString)
    {
        object result = ParseJson(jsonSequenceString);
        if (result == null) { return null; }
        return new object[] { result };
    }
}
