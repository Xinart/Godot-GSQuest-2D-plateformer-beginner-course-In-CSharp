
using System;
using Godot;

[Tool]
public class ChangeSceneButton : Button
{
    [Export(PropertyHint.File, "*.tscn")] public String scene_to_load;

    public void _on_PlayButton_button_up()
    {
        GetTree().ChangeScene(scene_to_load);
        GetTree().Paused = false;
    }
    public override string _GetConfigurationWarning()
    {
        return scene_to_load == "" ? "scene_to_load must be set " : "";
    }
}
