using System;
using Godot;

public class Portal : Node2D
{
    private AnimationPlayer _anim_player;
    [Export] public PackedScene next_scene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _anim_player = GetNode<AnimationPlayer>("Area2D/AnimationPlayer");
    }

    override public String _GetConfigurationWarning()
    {
        if (next_scene == null) return "The next scene property cannot be empty";
        return "";
    }

    public void _on_portal_body_entered(PhysicsBody2D body)
    {
        _teleport();
    }

    private async void _teleport()
    {
        _anim_player.Play("fade_in");
        // wait this signal to be emmited befor to continue
        await ToSignal(_anim_player, "animation_finished");
        GetTree().ChangeSceneTo(next_scene);
    }

}
