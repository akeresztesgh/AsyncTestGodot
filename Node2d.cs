using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Node2d : Node2D
{
    private List<int> ints = new List<int>();
    private bool isGeneratingChunk = false;
    public override async void _Process(double delta)
    {
        if (!isGeneratingChunk)
        {
            isGeneratingChunk = true;
            await CallSignal();
            isGeneratingChunk = false;            
        }
        GD.Print($"number of ints: {ints.Count} is generating chunk: {isGeneratingChunk}");
    }

    private async Task CallSignal()
    {
        var i = 0;
        while(i < 100)
        {
            await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);
            ints.Add(i++);
        }
    }
}
