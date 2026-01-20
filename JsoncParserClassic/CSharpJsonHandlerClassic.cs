// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpJsonHandlerClassic: IJsonHandlerClassic
{
    private readonly JsoncParserClassic jsonParser;
    private readonly PlainObjectConverter objParser;
    // ReSharper disable once ConvertToPrimaryConstructor
    public CSharpJsonHandlerClassic(bool numberAsDecimal, bool forceAscii)
    {
        this.jsonParser = new JsoncParserClassic(numberAsDecimal);
        this.objParser = new PlainObjectConverter(forceAscii);
    }
    public object Parse(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
    public string Stringify(object x, bool indent, bool sortKeys = false)
    {
        return this.objParser.Stringify(x, indent, sortKeys);
    }
}
