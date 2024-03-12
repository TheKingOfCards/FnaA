public class Henry: Animatronic
{
    public Henry(int moveOp, int timerMax)
    {
        _moveOp = moveOp;
        _timerMax = timerMax;

        
        _positions.Add(7);
        _positions.Add(5);
        _positions.Add(2);
        _positions.Add(1);
        _positions.Add(0);
    }

    // public override void Move()
    // {
    //     base.Move();
    // }
}