using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Numerics;
using Raylib_cs;
using System.Security;

Raylib.InitWindow(800, 600, "VERAS HOUSE OF HORRORS");

Raylib.SetTargetFPS(60);

List<Rectangle> walls = new();
walls.Add(new(75, 73, 10, 458));//vänster sida
walls.Add(new(715, 73, 10, 458)); //höger sida

walls.Add(new(75, 70, 245, 10));//uppe vänster
walls.Add(new(400, 65, 325, 10));//uppe höger

walls.Add(new(75, 523, 325, 10));//ner vänster
walls.Add(new(475, 523, 250, 10));//ner höger

walls.Add(new(320, 370, 10, 160));//mitten bit vid ingång
walls.Add(new(320, 370, 10, 160));//mitten bit vid utgång 

walls.Add(new(400, 300, 10, 152));//längre bitar stående
walls.Add(new(235, 70, 10, 160));
walls.Add(new(315, 145, 10, 160));
walls.Add(new(480, 145, 10, 230));

walls.Add(new(240, 370, 10, 90));//små bitar stående
walls.Add(new(630, 370, 10, 80));
walls.Add(new(630, 150, 10, 90));
walls.Add(new(555, 220, 10, 90));
walls.Add(new(155, 220, 10, 90));
walls.Add(new(400, 65, 10, 86));

walls.Add(new(155, 450, 90, 10));//små bitar liggande
walls.Add(new(155, 140, 90, 10));
walls.Add(new(315, 140, 90, 10));
walls.Add(new(390, 220, 90, 10));

walls.Add(new(480, 144, 160, 10));//stora bitar liggande
walls.Add(new(480, 370, 160, 10));
walls.Add(new(560, 300, 160, 10));
walls.Add(new(80, 360, 170, 10));
walls.Add(new(160, 300, 240, 10));
walls.Add(new(400, 445, 240, 10));

walls.Add(new(310, 0, 10, 80));
walls.Add(new(400, 0, 10, 80));

walls.Add(new(390, 530, 10, 80));
walls.Add(new(475, 530, 10, 80));


string currentRoom = "start";
Raylib.BeginDrawing();
Rectangle startbutton = new Rectangle(320, 140, 140, 30);
Rectangle switchlevel = new Rectangle(423, 550, 30, 30);

Texture2D grannyny = Raylib.LoadTexture("grannyny.png");
Texture2D labyrintA = Raylib.LoadTexture("labyrintett.png");
Texture2D labyrintB = Raylib.LoadTexture("labyrinttva.png");
Texture2D eyes = Raylib.LoadTexture("eyee.png");
Texture2D stonedoor = Raylib.LoadTexture("stonedoor.png");
Texture2D glitch = Raylib.LoadTexture("glitchyoverlay.png");
Raylib.InitAudioDevice();
Music granny = Raylib.LoadMusicStream("grannybattre.mp3");
Raylib.PlayMusicStream(granny);

Vector2 move;
Rectangle character = new(345, 10, 25, 25);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.UpdateMusicStream(granny);

    if (currentRoom == "start")
    {

        Vector2 mousePos = Raylib.GetMousePosition();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);

        Raylib.DrawText("VÄLKOMMEN TILL", 245, 40, 30, Color.Red);
        Raylib.DrawText("VERAS HOUSE OF HORRORS", 180, 70, 30, Color.Red);
        Raylib.DrawRectangleRec(startbutton, Color.Red);
        Raylib.DrawText("TRYCK HÄR", 322, 144, 23, Color.Black);

        Raylib.DrawTexture(grannyny, 200, 200, Color.White);



        Raylib.EndDrawing();



        if (Raylib.CheckCollisionPointRec(mousePos, startbutton))
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                currentRoom = "menu";
                Rectangle tilllab = new Rectangle(225, 110, 350, 100);
            }
        }

    }
    else if (currentRoom == "menu")
    {
        Vector2 firstButtonPosition = new Vector2(530, 160);
        Vector2 secondButtonPosition = new Vector2(530, 270);
        Vector2 thirdButtonPosition = new Vector2(530, 380);
        Vector2 mousePos = Raylib.GetMousePosition();


        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawRectangle(225, 110, 350, 100, Color.Red);
        Raylib.DrawRectangle(225, 220, 350, 100, Color.Red);
        Raylib.DrawRectangle(225, 330, 350, 100, Color.Red);
        Raylib.DrawCircleV(firstButtonPosition, 30, Color.Black);
        Raylib.DrawCircleV(secondButtonPosition, 30, Color.Black);
        Raylib.DrawCircleV(thirdButtonPosition, 30, Color.Black);
        Raylib.DrawCircleV(firstButtonPosition, 25, Color.Red);
        Raylib.DrawCircleV(secondButtonPosition, 25, Color.Red);
        Raylib.DrawCircleV(thirdButtonPosition, 25, Color.Red);
        Raylib.DrawText("i", 529, 147, 33, Color.Black);
        Raylib.DrawText("i", 529, 257, 33, Color.Black);
        Raylib.DrawText("i", 529, 367, 33, Color.Black);
        Raylib.DrawText("1.Veras spegel labyrint", 245, 149, 20, Color.Black);
        Raylib.DrawText("2.Veras tetris extravaganza", 245, 259, 18, Color.Black);
        Raylib.DrawText("3.Veras easteregg hunt", 245, 369, 20, Color.Black);


        if (Raylib.CheckCollisionPointCircle(mousePos, firstButtonPosition, 30))
        {
            Raylib.DrawRectangle(5, 5, 790, 100, Color.Red);
            Raylib.DrawText("Veras spegellabyrint är ett labyrintspel helt utan jumpscares och easter-\neggs jag lovar. Målet med banan är att klara labyrinten.", 10, 10, 20, Color.Black);
        }
        if (Raylib.CheckCollisionPointCircle(mousePos, secondButtonPosition, 30))
        {
            Raylib.DrawRectangle(5, 5, 790, 100, Color.Red);
            Raylib.DrawText("Veras tetris extravaganza talar för sig själv. Vera älskar tetris och det\n gör alla andra på jorden också.", 10, 10, 20, Color.Black);
        }
        if (Raylib.CheckCollisionPointCircle(mousePos, thirdButtonPosition, 30))
        {
            Raylib.DrawRectangle(5, 5, 790, 100, Color.Red);
            Raylib.DrawText("Det svåraste, sorgligaste, mest utmärkta, ryggradskittlande, tår tårkande,\nmest faantastiska, uttänkta, A-i-slutbetyg-förtjänande, underbara,smarta,\n gjort av ett geni- spelet du någonsin kommer köra,synd bara att det inte\n finns än.", 10, 10, 20, Color.Black);
        }
        Raylib.EndDrawing();

        if (Raylib.CheckCollisionPointRec(mousePos, startbutton))
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                currentRoom = "labyrint";
            }
        }
    }

    else if (currentRoom == "labyrint one")
    {
        Raylib.BeginDrawing();
    }
    if (currentRoom == "labyrint")
    {
        move = Vector2.Zero;
        float speed = 2;
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTexture(labyrintA, 0, 0, Color.White);
        Raylib.DrawRectangleRec(character, Color.Red);
        Raylib.DrawRectangleRec(switchlevel, Color.Black);
        Raylib.DrawTexture(stonedoor, 413, 545, Color.White);


        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            move.Y = -5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            move.Y = 5;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            move.X = 5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            move.X = -5;
        }

        if (move.Length() > 0)
        {
            move = Vector2.Normalize(move) * speed;
        }
        character.X += move.X;
        character.Y += move.Y;
        bool undoX = false;
        bool undoY = false;

        if (character.X > 800 - character.Width || character.X < 0)
        {

            undoX = true;
        }
        if (character.Y > 600 - character.Height || character.Y < 0)
        {

            undoY = true;
        }

        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.DarkGray);

            if (Raylib.CheckCollisionRecs(character, wall))
            {

                Raylib.DrawTexture(eyes, 200, 180, Color.White);
                Raylib.DrawTexture(eyes, 230, 100, Color.White);
                Raylib.DrawTexture(eyes, 130, 300, Color.White);
                Raylib.DrawTexture(eyes, 430, 500, Color.White);
                Raylib.DrawTexture(eyes, 400, 310, Color.White);
                Raylib.DrawTexture(eyes, 120, 410, Color.White);
                Raylib.DrawTexture(eyes, 530, 320, Color.White);
                Raylib.DrawTexture(eyes, 120, 500, Color.White);
                Raylib.DrawTexture(eyes, 320, 500, Color.White);
                Raylib.DrawTexture(eyes, 420, 500, Color.White);
                Raylib.DrawTexture(eyes, 140, 680, Color.White);
                Raylib.DrawTexture(eyes, 330, 700, Color.White);
                Raylib.DrawTexture(eyes, 600, 100, Color.White);
                Raylib.DrawTexture(eyes, 760, 80, Color.White);
                Raylib.DrawTexture(eyes, 20, 20, Color.White);
                Raylib.DrawTexture(eyes, 60, 100, Color.White);
                Raylib.DrawText("VAKNA", 30, 30, 30, Color.Blue);
                Raylib.DrawText("HON SER DIG", 300, 250, 30, Color.Blue);
                Raylib.DrawText("VERA COHEN", 570, 400, 30, Color.Blue);
                Raylib.DrawTexture(grannyny, 0, 10, Color.White);
                Raylib.DrawTexture(glitch, 0, 0, Color.White);
                undoX = true;
                undoY = true;


            }
        }


        if (undoX == true)
        {
            character.X -= move.X;
        }
        if (undoY == true)
        {
            character.Y -= move.Y;
        }

        Raylib.EndDrawing();
        if (Raylib.CheckCollisionRecs(character, switchlevel))
        {
            currentRoom = "endscreen";
        }
    }

    else if (currentRoom == "endscreen")
    {
        Raylib.BeginDrawing();
        {
            Duvann();
        }
    }

}


void Duvann()
{
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawText("DU NÅDDE SLUTET AV LABYRINTEN", 120, 200, 30, Color.Red);
            Raylib.DrawText("DU VANN OCH ÄR NU FRI!", 200, 300, 30, Color.Red);
            Raylib.DrawText("...eller?", 500, 370, 10, Color.Red);
            Raylib.EndDrawing();
}
// shift alt f