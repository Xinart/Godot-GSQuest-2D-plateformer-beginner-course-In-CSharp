using System;
using Godot;
using PlateformerGame2D;

public class RetryButton : Button
{
    public void _on_RetryButton_up()
    {
        PlayerData player_data = (PlayerData)GetNode("/root/PlayerData");
        player_data.score = 0;
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
    }


}
