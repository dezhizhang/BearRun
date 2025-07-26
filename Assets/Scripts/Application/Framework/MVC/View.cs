using System.Collections.Generic;

public abstract class View
{
    public abstract string Name { get; }

    public List<string> attentionList = new List<string>();

    public abstract void HandleEvent(string eventName, object data);
}