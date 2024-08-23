using Godot;
using System;

public partial class Player : Area2D
{

	    private const int MoveSpeed = 100;

    // All three of these change for each paddle.
    private int _ballDir;
    private string _up;
    private string _down;

    public override void _Ready()
    {
        string name = Name.ToString().ToLower();
        _up = "move_up";
        _down = "move_down";
    }

    public override void _Process(double delta)
    {

        float inputY = 0;
        float inputX = 0;
        // Move up and down based on input.
        if (Input.IsKeyPressed(Key.Up)){
            inputY += -1;
        }
        if (Input.IsKeyPressed(Key.Down)){
            inputY += 1;
        }
        if (Input.IsKeyPressed(Key.Right)){
            inputX += 1;
        }
        if (Input.IsKeyPressed(Key.Left)){
            inputX += -1;
        }
        Vector2 position = Position; // Required so that we can modify position.y.
        position += new Vector2(inputX * MoveSpeed * (float)delta, inputY * MoveSpeed * (float)delta);
        position = new(position.X, Mathf.Clamp(position.Y, 16, GetViewportRect().Size.X - 16));
        Position = position;
    }


}
