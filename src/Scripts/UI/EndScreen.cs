using System;
using Godot;
using PlateformerGame2D;

public class EndScreen : Control
{
    private Label _label;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _label = GetNode<Label>("ScoreLabel");
        PlayerData player_data = (PlayerData)GetNode("/root/PlayerData");
        _label.Text = "Your score is: " + player_data.score + "\nNumber of deaths : " + player_data.deaths;
    }
}
