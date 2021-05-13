using System;
using Godot;
namespace PlateformerGame2D
{
    public class Enemy : Actor, I_StompBouncible
    {
        [Export] public int stomp_bounce_impulse { get; set; } = 300;
        private int _score = 100;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            SetPhysicsProcess(false);
            _velocity.x += -speed.x;
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(float delta)
        {
            _velocity.y += gravity * delta;
            if (IsOnWall())
            {
                _velocity.x *= -1;
            }

            Vector2 snap = Vector2.Down * 20;
            _velocity.y = MoveAndSlideWithSnap(_velocity, snap, _FLOOR_NORMAL, true, 4, (float)Math.PI / 3).y;

        }

        /// <summary>
        /// Remove the enemy instance from the actual scene
        /// </summary>
        public void die()
        {
            QueueFree();
            PlayerData player_data = (PlayerData)GetNode("/root/PlayerData");
            player_data.score += _score;
        }

        public void decide_direction(Vector2 player_gloabal_position)
        {
            float direction = Godot.Mathf.Sign(player_gloabal_position.x - this.GlobalPosition.x);
            if (direction > 0.0)
            {
                _velocity.x *= -1;
            }
        }
    }
}
