using System;
using Godot;
using PlateformerGame2D;

public class Level : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        KinematicBody2D player = GetNode<KinematicBody2D>("Player");
        foreach (Enemy enemy in GetNode("Enemies").GetChildren())
        {
            enemy.decide_direction(player.GlobalPosition);
        }
    }
}
