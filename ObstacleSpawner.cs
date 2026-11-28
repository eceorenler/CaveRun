using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class ObstacleSpawner
{
    private List<Obstacle> obstacles;
    private Texture2D texture;
    private float groundY;
    private Random random;

    private float currentSpeed;
    private float maxSpeed;
    private float acceleration;

    private float distanceToNextSpawn;
    private float minGap;
    private float maxGap;

    public ObstacleSpawner(Texture2D texture, float groundY)
    {
        this.texture = texture;
        this.groundY = groundY;

        obstacles = new List<Obstacle>();
        random = new Random();

        currentSpeed = 5f;
        maxSpeed = 10f;
        acceleration = 0.1f;    

        minGap = 400; //in pixels
        maxGap = 700;
        distanceToNextSpawn = 300;  
    }

    public void Update(GameTime gameTime) 
    {
        //speeds the game 
        currentSpeed += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }


        distanceToNextSpawn -= currentSpeed;

        if (distanceToNextSpawn <= 0)
        {
            SpawnObstacle();
            distanceToNextSpawn = minGap + (float)random.NextDouble() * (maxGap - minGap);
        }


        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            obstacles[i].Update(currentSpeed);

            if (obstacles[i].IsOffScreen())
            {
                obstacles.RemoveAt(i);
            }
        }
    }

    private void SpawnObstacle()
    {
        bool isFlying = random.Next(0, 10) < 4;
        obstacles.Add(new Obstacle(texture, 820, groundY, isFlying));
    }

    public bool CheckCollision(Rectangle playerBounds)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            if (playerBounds.Intersects(obstacle.GetBounds()))
            {
                return true;
            }
        }

        return false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Draw(spriteBatch);
        }
    }
    
    public float GetSpeed()
    {
        return currentSpeed;
    }
}