using System;
using Godot;

namespace PlateformerGame2D
{
    /// <summary>
    /// Interface enabling the player bouncing on the object when stomping on it
    /// </summary>
    public interface I_StompBouncible
    {

        /// <summary>
        // Stomp bounce impulse applied to the player when he is stomping on the object
        /// </summary>
        [Export] int stomp_bounce_impulse { get; set; }

    }
}

