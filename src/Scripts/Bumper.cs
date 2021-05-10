using System;
using Godot;
namespace PlateformerGame2D
{
    public class Bumper : StaticBody2D, I_StompBouncible
    {
        [Export] public int stomp_bounce_impulse { get; set; } = 800;
    }
}
