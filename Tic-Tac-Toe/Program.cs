using System;
using NStack;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;
            top.ColorScheme.Normal= Attribute.Make(Color.White,Color.Black);
            // Creates the top-level window to show
            var win = new Window("Tic-Tac-Toe")
            {
                X = 0,
                Y = 1, 

                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            var menu = new MenuBar(new[]
            {
                new MenuBarItem("_Game", new[]
                {
                    new MenuItem("_New", "Creates new game", NewGame),
                    new MenuItem("_Close", "", Close),
                    new MenuItem("_Quit", "", () =>
                    {
                        if (Quit()) top.Running = false;
                    })
                }),
                new MenuBarItem("_Edit", new[]
                {
                    new MenuItem("_Copy", "", null),
                    new MenuItem("C_ut", "", null),
                    new MenuItem("_Paste", "", null)
                })
            });
            top.Add(menu);

            var field = new Window("Field")
            {
                X = 3,
                Y = 2,
                Width = 17,
                Height = 7
            };
            field.ColorScheme.Focus = Attribute.Make(Color.Magenta,Color.Black);
            var figure = new RadioGroup(3, 0, new ustring[] { "X", "O" }){ DisplayMode = DisplayModeLayout.Horizontal,  };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var button = new Button(j*5,i*2,".")
                    {
                        Id = $"{i},{j}"
                    };
                    button.Clicked += delegate()
                    {
                        button.Text = figure.RadioLabels[figure.SelectedItem];
                    };
                    field.Add(button);
                }
            }

            field.Add(new Label(0,1,"---------------"));
            field.Add(new Label(0,3,"---------------"));

            win.Add(
                field,
                figure
            );

            Application.Run();
        }


        private static bool Quit()
        {
            
        }

        private static void Close()
        {
            throw new NotImplementedException();
        }

        private static void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}