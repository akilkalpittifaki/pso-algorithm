using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace pso_hamit_severge
{
    public class PSO
    {
        private int swarmSize;
        private int dimension;
        private int maxIterations;
        private double c1; // Cognitive coefficient
        private double c2; // Social coefficient
        private double maxVelocity;
        private double[] lowerBounds;
        private double[] upperBounds;
        
        private Particle[] swarm;
        private double[] globalBest;
        private double globalBestFitness;
        
        // For tracking convergence
        public List<double> ConvergenceHistory { get; private set; }
        
        // Event for tracking progress
        public event Action<int, double>? IterationCompleted;
        
        // Delegate for fitness function
        public delegate double FitnessFunction(double[] position);
        private FitnessFunction fitnessFunction;
        
        public PSO(int swarmSize, int dimension, int maxIterations, 
                  double c1, double c2, double maxVelocity,
                  double[] lowerBounds, double[] upperBounds, 
                  FitnessFunction fitnessFunction)
        {
            this.swarmSize = swarmSize;
            this.dimension = dimension;
            this.maxIterations = maxIterations;
            this.c1 = c1;
            this.c2 = c2;
            this.maxVelocity = maxVelocity;
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;
            this.fitnessFunction = fitnessFunction;
            
            // Initialize data structures
            swarm = new Particle[swarmSize];
            globalBest = new double[dimension];
            globalBestFitness = double.MaxValue;
            ConvergenceHistory = new List<double>();
            
            // Initialize swarm
            InitializeSwarm();
        }
        
        private void InitializeSwarm()
        {
            // Create particles with different random seeds
            for (int i = 0; i < swarmSize; i++)
            {
                swarm[i] = new Particle(dimension, lowerBounds, upperBounds);
                
                // Calculate fitness for the initial position
                swarm[i].CurrentFitness = fitnessFunction(swarm[i].Position);
                swarm[i].PersonalBestFitness = swarm[i].CurrentFitness;
                
                // Update global best if needed
                if (swarm[i].CurrentFitness < globalBestFitness)
                {
                    globalBestFitness = swarm[i].CurrentFitness;
                    Array.Copy(swarm[i].Position, globalBest, dimension);
                }
            }
            
            // Add initial best fitness to convergence history
            ConvergenceHistory.Add(globalBestFitness);
        }
        
        public (double[] solution, double fitness) Optimize()
        {
            ConvergenceHistory.Clear();
            ConvergenceHistory.Add(globalBestFitness);
            
            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                // Update each particle
                for (int i = 0; i < swarmSize; i++)
                {
                    // Update velocity and position
                    swarm[i].UpdateVelocity(globalBest, c1, c2, maxVelocity);
                    swarm[i].UpdatePosition(lowerBounds, upperBounds);
                    
                    // Calculate new fitness
                    swarm[i].CurrentFitness = fitnessFunction(swarm[i].Position);
                    
                    // Update personal best
                    swarm[i].UpdatePersonalBest();
                    
                    // Update global best if needed
                    if (swarm[i].PersonalBestFitness < globalBestFitness)
                    {
                        globalBestFitness = swarm[i].PersonalBestFitness;
                        Array.Copy(swarm[i].PersonalBest, globalBest, dimension);
                    }
                }
                
                // Record the best fitness for this iteration
                ConvergenceHistory.Add(globalBestFitness);
                
                // Notify of progress
                IterationCompleted?.Invoke(iteration, globalBestFitness);
                
                // Small delay to avoid UI thread blocking
                Thread.Sleep(1);
            }
            
            return (globalBest, globalBestFitness);
        }
        
        // Method to get all particles for visualization
        public Particle[] GetSwarm()
        {
            return swarm;
        }
    }
} 