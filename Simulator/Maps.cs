using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public List<string> creatures = new();
        public List<string> creaturesLocations = new();
        public List<string> animals = new();
        public List<string> animalsLocations = new();

        public void Add(Creature creature, Point point)
        {
            creatures.Add(creature.Name);
            creature.Spawn(point, this);
            creaturesLocations.Add(creature.Position.ToString());
        }

        public void Remove(Creature creature)
        {
            creaturesLocations.RemoveAt(creatures.IndexOf(creature.Name));
            creature.Despawn();
            creatures.Remove(creature.Position.ToString());
            
        }

        public void Add(Animals animal, Point point)
        {
            animals.Add(animal.Description);
            animalsLocations.Add(animal.Description);
            animal.Spawn(point, this);
        }

        public void Remove(Animals animal)
        {
            animalsLocations.RemoveAt(animals.IndexOf(animal.Description));
            animals.Remove(animal.Description);
            animal.Despawn();
        }

        public void Move(Creature creature, Direction direction)
        {
            creature.Go(direction);

        }

        public void Move(Animals animal, Direction direction)
        {
            animal.Position.Next(direction);
        }

        public List<string> At(Point point)
        {
            List<string> contain = new();

            foreach(string creature in creatures)
            {
                if (point.ToString() == creaturesLocations[creatures.IndexOf(creature)]) contain.Add(creature);
            }

            foreach (string animal in animals)
            {
                if (point.ToString() == animalsLocations[animals.IndexOf(animal)]) contain.Add(animal);
            }

            return contain;
        }

        public List<string> At(int x, int y) => At(new Point(x, y));

        public Rectangle Square;
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public abstract bool Exist(Point p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);

        public Map(int SizeX, int SizeY)
        {
            if (SizeX < 5 || SizeY < 5) { throw new ArgumentOutOfRangeException("Invalid Map Size"); }
            else Square = new(0, 0, SizeX - 1, SizeY - 1);
        }
    }

    
    
    
}

