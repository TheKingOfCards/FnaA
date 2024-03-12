using FnaF;
using Raylib_cs;

public class Animatronic
{
    protected int _moveOp;

    //Timer variabels
    float _deltaTime;
    float _timer;
    protected float _timerMax;
    public List<Texture2D> deathAnim;

    // Movement variabels
    protected List<int> _positions = new();
    protected int listIndex = 0;
    public int currentPosition = 8; // Is 8 becuse start pos



    public void Update()
    {
        _deltaTime = GameFunctions.GetdeltaTime();

        Move();
    }


    protected void LoadDeathAnim()
    {

    }

    protected virtual void Move()
    {
        if (_timer >= _timerMax)
        {
            _timer = 0;

            if (GameFunctions.CheckRandom(1, 21, _moveOp))
            {
                if (GameFunctions.CheckRandom(1, 101, 90)) // Random check for if animatronic should move forward or backwards
                {
                    if (listIndex != _positions.Count) // Prevents out of range error
                    {
                        currentPosition = _positions[listIndex++];
                    }
                }
                else // Move backwards
                {
                    if (listIndex != 0) // Prevents out of range error
                    {
                        currentPosition = _positions[listIndex--];
                    }
                }


                Console.WriteLine(currentPosition);
            }
        }
        else _timer += _deltaTime;
    }
}