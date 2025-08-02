using System;

namespace pso_hamit_severge
{
    public class Particle
    {
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }
        public double[] PersonalBest { get; set; }
        public double PersonalBestFitness { get; set; }
        public double CurrentFitness { get; set; }

        private Random random;
        private int dimension;

        public Particle(int dimension, double[] lowerBounds, double[] upperBounds)
        {
            this.dimension = dimension;
            random = new Random(Guid.NewGuid().GetHashCode());
            
            Position = new double[dimension];
            Velocity = new double[dimension];
            PersonalBest = new double[dimension];
            
            // Initialize position randomly within bounds
            for (int i = 0; i < dimension; i++)
            {
                Position[i] = lowerBounds[i] + random.NextDouble() * (upperBounds[i] - lowerBounds[i]);
                Velocity[i] = 0; // Initialize velocity as zero
            }
            
            // Set initial position as personal best
            Array.Copy(Position, PersonalBest, dimension);
        }

        public void UpdateVelocity(double[] globalBest, double c1, double c2, double maxVelocity)
        {
            double r1, r2;
            
            for (int i = 0; i < dimension; i++)
            {
                r1 = random.NextDouble();
                r2 = random.NextDouble();
                
                Velocity[i] = Velocity[i] + 
                              c1 * r1 * (PersonalBest[i] - Position[i]) + 
                              c2 * r2 * (globalBest[i] - Position[i]);
                
                // Apply velocity clamping if needed
                if (Velocity[i] > maxVelocity)
                    Velocity[i] = maxVelocity;
                else if (Velocity[i] < -maxVelocity)
                    Velocity[i] = -maxVelocity;
            }
        }

        public void UpdatePosition(double[] lowerBounds, double[] upperBounds)
        {
            for (int i = 0; i < dimension; i++)
            {
                Position[i] = Position[i] + Velocity[i];
                
                // Ensure the particle stays within bounds
                if (Position[i] < lowerBounds[i])
                    Position[i] = lowerBounds[i];
                else if (Position[i] > upperBounds[i])
                    Position[i] = upperBounds[i];
            }
        }

        public void UpdatePersonalBest()
        {
            if (CurrentFitness < PersonalBestFitness)
            {
                PersonalBestFitness = CurrentFitness;
                Array.Copy(Position, PersonalBest, dimension);
            }
        }
    }
} 