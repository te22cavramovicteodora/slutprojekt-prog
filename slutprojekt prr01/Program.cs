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
Rectangle startknapp = new Rectangle(320, 140, 140, 30);
Rectangle bytalevel = new Rectangle(413, 545, 50, 50);
//  int main(void)
//  {
//     //inte min egenskrivna kod!
//     const int screenWidth = 800;
//     const int screenHeight = 450;

//    InitWindow(screenWidth, screenHeight, "raylib [audio] example - music playing (streaming)");
//        InitAudioDevice(); 
//         Music music = LoadMusicStream("resources/country.mp3");
//         PlayMusicStream(music);

//     float timePlayed = 0.0f;  
//      bool pause = false;
//      SetTargetFPS(30);  
//       //till hit
//  }
Texture2D image = Raylib.LoadTexture("grannyny.png");
Texture2D labyrintA = Raylib.LoadTexture("labyrintett.png");
Texture2D labyrintB = Raylib.LoadTexture("labyrinttva.png");
Raylib.InitAudioDevice();
Music granny = Raylib.LoadMusicStream("grannybattre.mp3");
Raylib.PlayMusicStream(granny);

Vector2 flytta;
Rectangle karaktar = new(345, 10, 25, 25);

while (!Raylib.WindowShouldClose())
{
    Raylib.UpdateMusicStream(granny);

    if (currentRoom == "start")
    {
        // Vector2 amira = new Vector2(320, 140);
        Vector2 mousePos = Raylib.GetMousePosition();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);

        Raylib.DrawText("VÄLKOMMEN TILL", 245, 40, 30, Color.Red);
        Raylib.DrawText("VERAS HOUSE OF HORRORS", 180, 70, 30, Color.Red);
        Raylib.DrawRectangleRec(startknapp, Color.Red);
        Raylib.DrawText("TRYCK HÄR", 322, 144, 23, Color.Black);
        // Image image = Raylib.LoadImage("raylincoolt.png");
        // Raylib.LoadTextureFromImage();
        Raylib.DrawTexture(image, 200, 200, Color.White);



        Raylib.EndDrawing();

        // Console.WriteLine(Raylib.IsMouseButtonPressed(MouseButton.Left) == true);

        if (Raylib.CheckCollisionPointRec(mousePos, startknapp))
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
        // Raylib.DrawText("Skriv numret av det minispelet du vill välja", 5, 580, 20, Color.Red);

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

        if (Raylib.CheckCollisionPointRec(mousePos, startknapp))
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                currentRoom = "labyrint";
            }
        }
    }

    else if (currentRoom == "labyrint ett")
    {
        Raylib.BeginDrawing();
    }
    if (currentRoom == "labyrint")
    {
        flytta = Vector2.Zero;
        float speed = 2;
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTexture(labyrintA, 0, 0, Color.White);
        Raylib.DrawRectangleRec(karaktar, Color.Red);
        Raylib.DrawRectangleRec(bytalevel, Color.Black);
    

        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            flytta.Y = -5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            flytta.Y = 5;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            flytta.X = 5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            flytta.X = -5;
        }

        if (flytta.Length() > 0)
        {
            flytta = Vector2.Normalize(flytta) * speed;
        }
        karaktar.X += flytta.X;
        karaktar.Y += flytta.Y;
        bool undoX = false;
        bool undoY = false;

        foreach(Rectangle wall in walls)
        {
             Raylib.DrawRectangleRec(wall, Color.DarkGray);  

             if (Raylib.CheckCollisionRecs(karaktar, wall))
             {
                
             }
        }


        if (undoX == true)
        {
            karaktar.X -= flytta.X;
        }
        if (undoY == true)
        {
            karaktar.Y -= flytta.Y;
        }

Raylib.EndDrawing();
if (Raylib.CheckCollisionRecs(karaktar, bytalevel))
{
currentRoom = "endscreen";
}     
    }

    else if (currentRoom == "endscreen")
    {
        Raylib.BeginDrawing();
        { 
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawText("DU NÅDDE SLUTET AV LABYRINTEN", 120, 200, 30, Color.Red);
        Raylib.DrawText("DU VANN OCH ÄR NU FRI!", 200, 300, 30, Color.Red);
        Raylib.EndDrawing();
    }
}

if (Raylib.IsMouseButtonDown(MouseButton.Left))
{
 currentRoom = "dundundun";
}
else if (currentRoom == "endscreen")
{
Raylib.BeginDrawing();
        
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawText("...", 120, 200, 30, Color.Red);
        Raylib.EndDrawing();
}


}

// shift alt f