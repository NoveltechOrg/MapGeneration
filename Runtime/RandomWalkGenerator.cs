using System.Collections.Generic;
using UnityEngine;

public class RandomWalkGenerator
{
    public bool[,] GenerateMap(Vector2Int size_map, int nb_steps)
    {
        // create the grid, which will be filled with false value
        // true values define valid cells which are part of our visited map
        bool[,] grid = new bool[size_map.x, size_map.y];

        // choose a random starting point
        System.Random rnd = new System.Random();
        Vector2Int curr_pos = new Vector2Int(rnd.Next(size_map.x), rnd.Next(size_map.y));

        // register this position in the grid 
        grid[curr_pos.x, curr_pos.y] = true;

        // define allowed movements: left, up, right, down
        List<Vector2Int> allowed_movements = new List<Vector2Int>
        {
            Vector2Int.left,
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down
        };

        // iterate on the number of steps and move around
        for (int id_step = 0; id_step < nb_steps; id_step++) {
            // for each step, we try to find a new cell to go to. 
            // We are not guaranteed to find a position that is valid (i.e. inside the grid)
            // So we use a while loop to allow us to check multiple positions and break out of it
            // when we find a valid one 
            while (true) {
                // choose a random direction 
                Vector2Int new_pos = curr_pos + allowed_movements[rnd.Next(allowed_movements.Count)];
                // check if the new position is in the grid 
                if (new_pos.x >= 0 && new_pos.x < size_map.x && new_pos.y >= 0 && new_pos.y < size_map.y) {
                    // this is a valid position, we set it in the grid 
                    grid[new_pos.x, new_pos.y] = true;

                    // replace curr_pos with new_pos 
                    curr_pos = new_pos;

                    // and finally break of the infinite loop
                    break;
                }
            }
        }

        return grid;
    }
}
