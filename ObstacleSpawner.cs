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

    private float spawnTimer; //first obstacle occurence
    private float minInterval;
    private float maxInterval;

    public ObstacleSpawner(Texture2D texture, float groundY)
    {
        this.texture = texture;
        this.groundY = groundY;

        obstacles = new List<Obstacle>();
        random = new Random();

        minInterval = 1.2f;
        maxInterval = 2.2f;
        spawnTimer = 1.5f;
    }

    public void Update(GameTime gameTime)
    {
        spawnTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds; //for new obstacles to occur

        if(spawnTimer <= 0)
        {
            SpawnObstacle();

            spawnTimer = minInterval + (float)random.NextDouble()* (maxInterval - minInterval);
        }

        for (int i = obstacles.Count - 1; i >= 0; i--) //backwards for updating correctly
        {
            obstacles[i].Update();

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
    
}