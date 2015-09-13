using System;

class EventStudent<T> : EventArgs
{
    public EventStudent(string propName, T oldValue, T newValue)
    {
        this.ChangedPropName = propName;
        this.OldValue = oldValue;
        this.NewValue = newValue;
    }

    public string ChangedPropName { get; set; }
    public T OldValue { get; set; }
    public T NewValue { get; set; }
}