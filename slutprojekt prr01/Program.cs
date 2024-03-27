using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Numerics;
using Raylib_cs;
using System.Security;

Raylib.InitWindow(800, 600, "VERAS HOUSE OF HORRORS");

Raylib.SetTargetFPS(60);

string currentRoom = "start";
Rectangle amira = new Rectangle(320, 140, 140, 30);
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
Rectangle litengrej = new(25, 25, 25, 25);

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
        Raylib.DrawRectangleRec(amira, Color.Red);
        Raylib.DrawText("TRYCK HÄR", 322, 144, 23, Color.Black);
        // Image image = Raylib.LoadImage("raylincoolt.png");
        // Raylib.LoadTextureFromImage();
        Raylib.DrawTexture(image, 200, 200, Color.White);



        Raylib.EndDrawing();

        // Console.WriteLine(Raylib.IsMouseButtonPressed(MouseButton.Left) == true);

        if (Raylib.CheckCollisionPointRec(mousePos, amira))
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

        if (Raylib.CheckCollisionPointRec(mousePos, amira))
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
        Raylib.ClearBackground(Color.Black);
        Vector2 Zero = new Vector2(0, 0);
        Raylib.DrawTexture(labyrintA, 0, 0, Color.White);
    }
    if (currentRoom == "labyrint")
    {
        flytta = Vector2.Zero;
        float speed = 2;
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTexture(labyrintA, 0, 0, Color.White);
        Raylib.DrawRectangleRec(litengrej, Color.Blue);

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
        litengrej.X += flytta.X;
        litengrej.Y += flytta.Y;
        bool undoX = false;
        bool undoY = false;

        if (undoX == true)
        {
            litengrej.X -= flytta.X;
        }
        if (undoY == true)
        {
            litengrej.Y -= flytta.Y;
        }



        Raylib.EndDrawing();
    }
}

// shift alt f