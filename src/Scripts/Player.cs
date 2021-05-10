using System;
using Godot;

namespace PlateformerGame2D
{
    public class Player : Actor
    {
        /// <summary>
        /// Force applyied to the Player to make him bounce when stomping
        /// </summary>

        public void _on_EnemyDetector_body_entered(PhysicsBody2D body)
        {
            die();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(float delta)
        {
            bool is_jump_interupted = (Input.IsActionJustReleased("jump") && _velocity.y < 0);
            Vector2 direction = _get_direction();
            _velocity = _calculate_move_velocity(_velocity, direction, speed, is_jump_interupted);
            Vector2 snap = direction.y == 0 ? Vector2.Down * 20 : Vector2.Zero;
            _velocity = MoveAndSlideWithSnap(_velocity, snap, _FLOOR_NORMAL, true, 4, (float)Math.PI / 3);

            _handle_stomp_collisions();

        }

        /// <summary>
        ///  Handle actions related to specific stomp collisions
        /// </summary>
        private void _handle_stomp_collisions()
        {
            // Loop on all collisions when MoveAndSlide() is called for this frame
            for (int i = 0; i < GetSlideCount(); i++)
            {
                KinematicCollision2D collision = GetSlideCollision(i);
                Godot.Object collider = collision.Collider;
                if (collider.GetScript() != null)
                {
                    bool is_stomping = (
                        IsOnFloor()
                        // If the collision comes from (aproximatly) above from an angle perspective
                        && collision.Normal.Dot(Vector2.Up) > 0.7f
                        );
                    if (is_stomping && collider is I_StompBouncible)
                    {
                        _velocity.y = -(collider as I_StompBouncible).stomp_bounce_impulse;
                        if (collider is Enemy) (collider as Enemy).die();
                    }
                }
            }
        }

        /// <summary>
        /// Remove the Player instance from the actual scene
        /// </summary>
        public void die()
        {
            QueueFree();
        }

        /// <summary>
        /// Return the actuall direction of the Player according to the Inputs
        /// </summary>
        /// <returns>Vector2(direction_x, direction_y)</returns>
        private Vector2 _get_direction()
        {
            float direction_x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
            float direction_y = (Input.IsActionJustPressed("jump") && IsOnFloor()) ? -1 : 0;
            return new Vector2(direction_x, direction_y);
        }

        /// <summary>
        /// Calculate the final Player velocity for the next frame
        /// </summary>
        /// <param name="linear_velocity">Initial current velocity of the player before next frame</param>
        /// <param name="direction">Player direction for the next frame</param>
        /// <param name="speed">Player speed for the next frame</param>
        /// <param name="is_jump_interupted">If set to true, will set the calculated velocity on Y axis to 0</param>
        private Vector2 _calculate_move_velocity(
            Vector2 linear_velocity,
            Vector2 direction,
            Vector2 speed,
            bool is_jump_interupted
            )
        {
            Vector2 new_velocity = linear_velocity;
            new_velocity.x = speed.x * direction.x;
            new_velocity.y += gravity * GetPhysicsProcessDeltaTime();
            if (direction.y == -1)
            {
                new_velocity.y = speed.y * direction.y;
            }
            if (is_jump_interupted)
            {
                new_velocity.y = 0;
            }
            return new_velocity;
        }
    }
}

