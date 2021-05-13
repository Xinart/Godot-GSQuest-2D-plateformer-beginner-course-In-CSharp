using System;
using Godot;
namespace PlateformerGame2D
{
    public class PlayerData : Node
    {
        [Signal] delegate void score_updated();
        [Signal] delegate void player_died();

        private int _score;
        private int _deaths;
        private int _coins_recolted;

        public int score
        {
            get => _score;
            set
            {
                _score = value;
                EmitSignal(CONST.SIGNALS.SCORE_UPDATED);
            }
        }
        public int deaths
        {
            get => _deaths;
            set
            {
                _deaths = value;
                EmitSignal(CONST.SIGNALS.PLAYER_DIED);
            }
        }
        public int coins_recolted
        {
            get => _coins_recolted;
            set
            {
                _coins_recolted = value;
                EmitSignal(CONST.SIGNALS.SCORE_UPDATED);
            }
        }

        public override void _Ready()
        {
            reset();
        }

        public void reset()
        {
            _score = 0;
            _deaths = 0;
        }
    }
}
