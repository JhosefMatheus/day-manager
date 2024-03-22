namespace backend.Models;

public class RequestVariant
{
    public string Variant { get; }

    private RequestVariant(string variant)
    {
        this.Variant = variant;
    }

    public static RequestVariant Success => new("success");
    public static RequestVariant Error => new("error");
    public static RequestVariant Warning => new("warning");
    public static RequestVariant Info => new("info");
    public static RequestVariant Default => new("default");

    public override string ToString()
    {
        return this.Variant;
    }
}