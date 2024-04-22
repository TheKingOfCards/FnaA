using System.Numerics;
using Raylib_cs;

namespace FnaF;

public class Button
{
    Action hoverAction;
    Action clickAction;
    Rectangle rect;


    public Button(Rectangle rectangle, Action hoverAct, Action clickAct)
    {
        rect = rectangle;
        hoverAction = hoverAct;
        clickAction = clickAct;
    }

    public void Update()
    {
        if (CheckOverlap())
        {
            hoverAction();

            Click();
        }
    }


    void Click()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            clickAction();
        }
    }


    bool CheckOverlap()
    {
        return Raylib.CheckCollisionPointRec(GameFunctions.GetMousePos(), rect);
    }
}
