using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Seat
    {
        private int n, m;
        private bool[][] matriz;
        private int y = 5;
        private char[] letter = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W' };

        public Seat(int n, int m, bool[][] matriz)
        {
            this.n = n > 0 && n < 26 ? n : 5;
            this.m = m > 0 ? m : 5;
            this.matriz = matriz;
        }

        private void showMenu(string name, int quantity)
        {
            y = 5;
            int x = 2;
            for (int j = 0; j < matriz[0].Length; j++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  {0}  ", j + 1);
                x += 5;
            }
            Console.SetCursorPosition(8, 2);
            Console.Write("PELICULA: {0}", name);
            Console.SetCursorPosition(8, 4);
            Console.Write("SELECCIONE LOS {0} ASIENTOS QUE DESEA", quantity);
            y++;
            for (int i = 0; i < matriz.Length; i++)
            {
                x = 2;
                Console.SetCursorPosition(0, y);
                Console.Write("{0}", letter[i]);
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" {0}  ", matriz[i][j] ? String.Format("{0}{1}", letter[i], j+1) : "X");
                    x += 5;
                }
                y++;
            }
            int space = matriz[0].Length*5 + 5;
            Console.SetCursorPosition(space + 2, 5);
            Console.Write("Muevase con las flechas arriba, abajo, izquierda y derecha");
            Console.SetCursorPosition(space + 2, 6);
            Console.Write("S: Seleccionado");
            Console.SetCursorPosition(space + 2, 7);
            Console.Write("X: No disponible");

        }

        private bool isFree(int n, int m)
        {
            return matriz[n][m];
        }

        public List<OptionSeat> getIndex(int v, string name)
        {
            showMenu(name, v);
            List<OptionSeat> value = new List<OptionSeat>();
            int x = 2, optionx = 0, optiony = 0;
            var c = ConsoleKey.DownArrow;
            y = 6;
            Console.SetCursorPosition(x, y);
            Console.Write("|{0} |", matriz[optiony][optionx] ? String.Format("{0}{1}", letter[0],  1) : "X");
            Console.SetCursorPosition(x, y);
            while (v > 0)
            {
                var last = c;
                c = Console.ReadKey().Key;
                if (last != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(x + optionx * 5, y + optiony);
                    Console.Write(" {0}  ", matriz[optiony][optionx] ? String.Format("{0}{1}", letter[optiony], optionx+1) : "X");
                    Console.SetCursorPosition(x + optionx * 5, y + optiony);
                }
                switch (c)
                {
                    case ConsoleKey.LeftArrow:
                        if (optionx > 0) optionx--;
                        else optionx = matriz[0].Length - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (optionx < matriz[0].Length - 1) optionx++;
                        else optionx = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (optiony > 0) optiony--;
                        else optiony = matriz.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (optiony < matriz.Length - 1) optiony++;
                        else optiony = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (matriz[optiony][optionx])
                        {
                            Console.SetCursorPosition(x + optionx * 5, y + optiony);
                            Console.Write("  {0}  ", matriz[optiony][optionx] ? 'S' : 'X');
                            Console.SetCursorPosition(x + optionx * 5, y + optiony);
                        }
                        else
                        {
                            Console.SetCursorPosition(x + optionx * 5, y + optiony);
                            Console.Write("  X  ");
                            Console.SetCursorPosition(x + optionx * 5, y + optiony);
                        }
                        break;

                }

                if (c == ConsoleKey.Enter)
                {
                    if (matriz[optiony][optionx])
                    {
                        matriz[optiony][optionx] = false;
                        value.Add(new OptionSeat(optionx, optiony));
                        v--;
                    }
                }
                else
                {
                    Console.SetCursorPosition(x + optionx * 5, y + optiony);
                    Console.Write("|{0} |", matriz[optiony][optionx] ? String.Format("{0}{1}", letter[optiony], optionx + 1) : "X");
                    Console.SetCursorPosition(x + optionx * 5, y + optiony);
                }

            }
            return value;
        }


    }
}
