// ReSharper disable once CheckNamespace
namespace Global;

public interface IJsonHandlerClassic
{
    public object Parse(string json);
    public string Stringify(object x, bool indent, bool sortKeys = false);
}
