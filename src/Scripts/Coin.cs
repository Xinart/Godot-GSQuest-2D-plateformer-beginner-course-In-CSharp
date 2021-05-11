using System;
using Godot;

public class Coin : Node2D
{
    private AnimationPlayer _anim_player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _anim_player = GetNode<AnimationPlayer>("Area2D/AnimationPlayer");
    }

    public void _on_Coin_body_entered(PhysicsBody2D body)
    {
        _anim_player.Play("fade_out");
    }
}
