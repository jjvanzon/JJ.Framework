// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace JJ.Framework.Validation.Legacy.Tests.Helpers;

internal class TestModel
{
    public string    Name        { get; set; }
    public string    Description { get; set; }
    public string    Tag         { get; set; }
    public string    Status      { get; set; }
    public int       Score       { get; set; }
    public int       Level       { get; set; }
    public ColorEnum Color       { get; set; }
}