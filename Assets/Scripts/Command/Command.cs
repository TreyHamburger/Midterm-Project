using System.ComponentModel;
using UnityEditor.XR;

public abstract class Command
{
    public abstract void Execute();

    public abstract bool isComplete {  get; }
}
