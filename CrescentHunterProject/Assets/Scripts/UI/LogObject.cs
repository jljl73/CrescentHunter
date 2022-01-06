using M4u;

public class LogObject : M4uContext
{
    M4uProperty<string> text = new M4uProperty<string>();
    public string Text { get => text.Value; set => text.Value = value; }

}
