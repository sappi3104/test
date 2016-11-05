using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using DxLibDLL;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            DX.ChangeWindowMode(DX.TRUE);

            // 画面モードの設定
            DX.SetGraphMode(800, 600, 16);

            // 描画先を裏画面にセット
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            //a
            if (DX.DxLib_Init() == -1)
                return;

            var privious = sw.ElapsedTicks;
            double lag = 0;
            uint kousin = 0;

            while (DX.ProcessMessage() == 0 && DX.CheckHitKey(DX.KEY_INPUT_ESCAPE) == 0)
            {

                var elaseped = (double)(sw.ElapsedTicks - privious) / (double)Stopwatch.Frequency;

                privious = sw.ElapsedTicks;

                lag += elaseped;

                while (lag >= 0.010)
                {
                    update();
                    lag -= 0.010;
                }

                render();
                kousin++;

                double fps = 1 / ((double)(sw.ElapsedTicks - privious) / (double)Stopwatch.Frequency);
                Console.WriteLine(fps);

            }
            DX.DxLib_End();

            //Console.ReadKey();
        }

        static void update()
        {
            System.Threading.Thread.Sleep(1);
        }

        static void render()
        {
            // 画面の初期化
            DX.ClearDrawScreen();

            //int x = 400;
            //int y = 300;

            //int zx = 0;
            //int zy = 0;
            //int a = 100;

            point p = new point();

            DX.DOUBLE4 aa = new DX.DOUBLE4();
            DX.DOUBLE4 bb = new DX.DOUBLE4();

            aa.x = 11;

            DX.QTCrossD(aa, bb);



            //DX.DrawTriangleAA(x + zx, y + zy, x + zx + a, y + zy, x + zx + a * (float)Math.Cos(Math.PI / 4), y + zy + a * (float)Math.Sin(Math.PI / 4), DX.GetColor(255, 255, 0), DX.TRUE);

            System.Threading.Thread.Sleep(16);
            // 裏画面の内容を表画面に反映
            DX.ScreenFlip();

        }

    }

    class point
    {
        //public float x1;
        //public float y1;
        //public float x2;
        //public float y2;
        //public float x3;
        //public float y3;
    }

}
