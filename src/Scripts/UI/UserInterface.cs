using System;
using Godot;
using PlateformerGame2D;

public class UserInterface : Control
{
    private SceneTree _scene_tree;
    private ColorRect _pause_overlay;
    private Label _score_label;
    private Label _title_label;
    private Label _coin_label;
    private String _label_message_player_died = "You died";

    private bool __is_paused;
    public bool is_paused
    {
        get => __is_paused;
        set
        {
            __is_paused = value;
            _scene_tree.Paused = value;
            _pause_overlay.Visible = value;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _scene_tree = GetTree();
        _pause_overlay = GetNode<ColorRect>("PauseOverlay");
        _score_label = GetNode<Label>("ColorRect/VBoxContainer/ScoreLabel");
        _title_label = GetNode<Label>("PauseOverlay/Title");
        _coin_label = GetNode<Label>("ColorRect/VBoxContainer/HBoxContainer/Coinlabel");

        _pause_overlay.Visible = false;

        PlayerData player_data = (PlayerData)GetNode("/root/PlayerData");
        player_data.Connect(CONST.SIGNALS.SCORE_UPDATED, this, "update_interface");
        player_data.Connect(CONST.SIGNALS.PLAYER_DIED, this, "_on_PlayerData_player_died");
        update_interface();
    }

    public void update_interface()
    {
        PlayerData player_data = (PlayerData)GetNode("/root/PlayerData");
        _score_label.Text = "Score: " + player_data.score;
        _coin_label.Text = player_data.coins_recolted.ToString();
    }

    public void _on_PlayerData_player_died()
    {
        is_paused = true;
        _title_label.Text = _label_message_player_died;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("pause") && _title_label.Text != _label_message_player_died)
        {
            is_paused = !is_paused;
            // Stop the event and prevent iot to be processed by other scene components
            _scene_tree.SetInputAsHandled();
        }
    }


}
