using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }

        public List<Creature> Creatures { get; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }

        /// <summary>
        /// Cyclic list of creatures moves.
        /// Bad moves are ignored - use DirectionParser.
        /// First move is for first creature, second for second and so on.
        /// When all creatures make moves,
        /// next move is again for first creature and so on.
        /// </summary>
        private Direction[] moves;
        public string Moves
        {
            get => Moves;
            init => moves = DirectionParser.Parse(Moves);
        }

        /// <summary>
        /// Has all moves been done?
        /// </summary>
        public bool Finished = false;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public Creature CurrentCreature
        {
            get;
        }

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName
        {
            get;
        }

        public int i = 0;

        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from
        /// number of starting positions.
        /// </summary>
        public Simulation(Map map, List<Creature> creatures, List<Point> positions, string allMoves)
        {
            if (creatures.Count == 0) throw new Exception("No creatures");
            if (creatures.Count != positions.Count) throw new Exception("Invalid positions");


            else
            {
                Creatures = creatures;
                Moves = allMoves;

                foreach(Creature creature in creatures) map.Add(creature, positions[creatures.IndexOf(creature)]);

                foreach(char move in moves)
                {
                    CurrentCreature = Creatures[i];
                    CurrentMoveName = moves[i].ToString().ToLower();
                    Turn();
                    i++;
                }
                Finished = true;
            }

        }

        /// <summary>
        /// Makes one move of current creature in current direction.
        /// Throw error if simulation is finished.
        /// </summary>
        public void Turn()
        {
            Map.Move(CurrentCreature, moves[i]);
        }
    }
}
