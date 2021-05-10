using System;
using Godot;
namespace PlateformerGame2D
{
    // Comments docs : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#see 
    // https://docs.microsoft.com/en-us/dotnet/csharp/codedoc 
    // Comments good practices : https://www.youtube.com/watch?v=uVdGIuVuSmo


    /// <summary>
    ///     Base class for other game component
    ///     that wanna take behaviours of NPC and PC in the video game
    /// <para>Public fields :</para>
    /// <list type="bullet">
    /// <item><term>float gravity</term><description> Gravity force applied to the actor</description></item>
    /// <item><term>Vector2 speed</term><description> Speed force applied to the actor</description></item>
    /// </list>
    /// <para>Protected fields :</para>
    /// <list type="bullet">
    /// <item><term>Vector2 FLOOR_NORMAL</term><description> Set up the floor when using MoveAndSlide()</description></item>
    /// <item><term>Vector2 _velocity</term><description> Final calculated force applied to the actor</description></item>
    /// </list>
    /// </summary>
    public abstract class Actor : KinematicBody2D
    {
        /// <summary>
        /// Used to push down on the y axis the Actor every frame to imit a gravity behaviour
        /// </summary>
        /// <remarks>Pushing down in the Y axis means to do + in Godot 2D World</remarks>
        [Export] public float gravity = 3_000.0f;
        /// <summary>
        /// Used to establish the Actor speed on X and Y axes of the 2D World
        /// </summary>
        [Export] public Vector2 speed = new Vector2(300.0f, 1_000.0f);

        /// <summary>
        /// <para>
        /// Value used to establish the floor by a Vector2 perpendicular to it. 
        /// The direction value used (-1 or +1) will establish the floor on his oposite direction. 
        /// This floor is used with the <c>MoveAndSlide()</c> method
        ///  Using this method with an Actor will tell him he must stick on the floor defined by this vector2
        /// </para>
        /// <para>To be used in the <c>MoveAndSlide()</c> method as following : </para>
        /// <para><c> MoveAndSlide(_velocity, FLOOR_NORMAL); </c></para>
        /// Used as above, this will determine the <c>IsOnFloor()</c> value beceaus this one is
        /// updated in the <c>MoveAndSlide()</c> method, depending on the FLOOR_NORMAL
        /// </summary>
        /// <value>new Vector2(0, -1)</value>
        protected Vector2 _FLOOR_NORMAL = Vector2.Up;

        /// <summary>
        /// Value used establish the final calculated Actor movement on the 2D World
        /// </summary>
        /// <value>new Vector2(0, 0)</value>
        protected Vector2 _velocity = Vector2.Zero;
    }
}
