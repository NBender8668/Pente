using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacePeice : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;

    private Vector3Int previous;

    // do late so that the player has a chance to move in update if necessary
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // get current grid location
            Vector3Int currentCell = highlightMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // add one in a direction (you'll have to change this to match your directional control)
            currentCell.x += 1;

            // if the position has changed
            if (currentCell != previous)
            {
                // set the new tile
                highlightMap.SetTile(currentCell, highlightTile);

                // erase previous
                highlightMap.SetTile(previous, null);

                // save the new position for next frame
                previous = currentCell;
            }
        }
    }
}
