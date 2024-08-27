using Godot;
using System;

public partial class Player : CharacterBody2D
{
    float gravity = 200f;
    float TERMINAL_VELOCITY= 1000f;
    RayCast2D floorDetector = null;

    public override void _Ready()
    {
        floorDetector = GetNode<RayCast2D>("RayCast2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        float VelocityY = MathF.Min(TERMINAL_VELOCITY, Velocity.Y + gravity * (float)delta);

        float velocityX = 0f;
        if (Input.IsKeyPressed(Key.Right)){
            velocityX += 50;
        }
        if (Input.IsKeyPressed(Key.Left)){
            velocityX += -50;
        }
        if (Input.IsKeyPressed(Key.Up) && floorDetector.IsColliding()){
            VelocityY += -30;
        }

        GD.Print("Colliding: " + floorDetector.IsColliding());
        Velocity = new Vector2(velocityX, VelocityY);
        //GD.Print("Physicsprocess " + Velocity );
        MoveAndSlide();


    }

}
