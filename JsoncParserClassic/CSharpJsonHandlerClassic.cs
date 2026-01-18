using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpJsonHandlerClassic: IJsonHandlerClassic
{
    private readonly JsoncParserClassic jsonParser;
    private readonly ObjectParserClassic objParser;
    // ReSharper disable once ConvertToPrimaryConstructor
    public CSharpJsonHandlerClassic(bool numberAsDecimal, bool forceAscii)
    {
        this.jsonParser = new JsoncParserClassic(numberAsDecimal);
        this.objParser = new ObjectParserClassic(forceAscii);
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
