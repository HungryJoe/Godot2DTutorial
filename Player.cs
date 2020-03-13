using Godot;
using System;

public class Player : Node2D
{
    public int vertVel {get; set;}

    private const int HOR_SPEED = 150;
    private const int VERT_SPEED_INCREMENT = 10;
    private const int MAX_VERTICAL_SPEED = 200;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
      vertVel = 0;
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
    MoveLocalX(HOR_SPEED * delta);

    float sizeY = GetViewportRect().Size.y;
    if (this.Position.y > 1 && this.Position.y <= sizeY) {
      MoveLocalY(vertVel * delta);
    } else {
      if (this.Position.y < 1) {
        MoveLocalY(VERT_SPEED_INCREMENT);
        vertVel = -1 * vertVel;
      } else if (this.Position.y > sizeY) {
        MoveLocalY(-1 * VERT_SPEED_INCREMENT);
        vertVel = -1 * vertVel;
      }
    }
  }

  //Handles user input events
  public override void _Input(InputEvent @event) {
    if (@event.IsAction("player_up") && vertVel >= -1 * MAX_VERTICAL_SPEED) {
      vertVel -= VERT_SPEED_INCREMENT;
    } else if (@event.IsAction("player_down") && vertVel <= MAX_VERTICAL_SPEED) {
      vertVel += VERT_SPEED_INCREMENT;
    }
  }
}
