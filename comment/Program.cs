using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Towel;
using static Towel.Statics;
using System.Diagnostics;



#region Ascii

// ╔═══════════════════╦═══════════════════╗
// ║ · · · · · · · · · ║ · · · · · · · · · ║
// ║ · ╔═╗ · ╔═════╗ · ║ · ╔═════╗ · ╔═╗ · ║
// ║ + ╚═╝ · ╚═════╝ · ╨ · ╚═════╝ · ╚═╝ + ║
// ║ · · · · · · · · · · · · · · · · · · · ║
// ║ · ═══ · ╥ · ══════╦══════ · ╥ · ═══ · ║
// ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// ╚═════╗ · ╠══════   ╨   ══════╣ · ╔═════╝
//       ║ · ║                   ║ · ║
// ══════╝ · ╨   ╔════---════╗   ╨ · ╚══════
//         ·     ║ █ █   █ █ ║     ·        
// ══════╗ · ╥   ║           ║   ╥ · ╔══════
//       ║ · ║   ╚═══════════╝   ║ · ║
//       ║ · ║       READY       ║ · ║
// ╔═════╝ · ╨   ══════╦══════   ╨ · ╚═════╗
// ║ · · · · · · · · · ║ · · · · · · · · · ║
// ║ · ══╗ · ═══════ · ╨ · ═══════ · ╔══ · ║
// ║ + · ║ · · · · · · █ · · · · · · ║ · + ║
// ╠══ · ╨ · ╥ · ══════╦══════ · ╥ · ╨ · ══╣
// ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// ║ · ══════╩══════ · ╨ · ══════╩══════ · ║
// ║ · · · · · · · · · · · · · · · · · · · ║
// ╚═══════════════════════════════════════╝


internal class Program
{
    private static void Main(string[] args)
    {
        string WallsString =         // Dinh nghia ban do cua tro choi voi cac ky tu dac biet
    "╔═══════════════════╦═══════════════════╗\n" +
    "║                   ║                   ║\n" +
    "║   ╔═╗   ╔═════╗   ║   ╔═════╗   ╔═╗   ║\n" +
    "║   ╚═╝   ╚═════╝   ╨   ╚═════╝   ╚═╝   ║\n" +
    "║                                       ║\n" +
    "║   ═══   ╥   ══════╦══════   ╥   ═══   ║\n" +
    "║         ║         ║         ║         ║\n" +
    "╚═════╗   ╠══════   ╨   ══════╣   ╔═════╝\n" +
    "      ║   ║                   ║   ║      \n" +
    "══════╝   ╨   ╔════   ════╗   ╨   ╚══════\n" +
    "              ║           ║              \n" +
    "══════╗   ╥   ║           ║   ╥   ╔══════\n" +
    "      ║   ║   ╚═══════════╝   ║   ║      \n" +
    "      ║   ║                   ║   ║      \n" +
    "╔═════╝   ╨   ══════╦══════   ╨   ╚═════╗\n" +
    "║                   ║                   ║\n" +
    "║   ══╗   ═══════   ╨   ═══════   ╔══   ║\n" +
    "║     ║                           ║     ║\n" +
    "╠══   ╨   ╥   ══════╦══════   ╥   ╨   ══╣\n" +
    "║         ║         ║         ║         ║\n" +
    "║   ══════╩══════   ╨   ══════╩══════   ║\n" +
    "║                                       ║\n" +
    "╚═══════════════════════════════════════╝";

        string GhostWallsString =         // Dinh nghia ban do nhưng co bieu thi cac khu vuc gioi han cho Ghost
            "╔═══════════════════╦═══════════════════╗\n" +
            "║█                 █║█                 █║\n" +
            "║█ █╔═╗█ █╔═════╗█ █║█ █╔═════╗█ █╔═╗█ █║\n" +
            "║█ █╚═╝█ █╚═════╝█ █╨█ █╚═════╝█ █╚═╝█ █║\n" +
            "║█                                     █║\n" +
            "║█ █═══█ █╥█ █══════╦══════█ █╥█ █═══█ █║\n" +
            "║█       █║█       █║█       █║█       █║\n" +
            "╚═════╗█ █╠══════█ █╨█ █══════╣█ █╔═════╝\n" +
            "██████║█ █║█                 █║█ █║██████\n" +
            "══════╝█ █╨█ █╔════█ █════╗█ █╨█ █╚══════\n" +
            "             █║█         █║█             \n" +
            "══════╗█  ╥█ █║███████████║█ █╥█ █╔══════\n" +
            "██████║█  ║█ █╚═══════════╝█ █║█ █║██████\n" +
            "██████║█  ║█                 █║█ █║██████\n" +
            "╔═════╝█  ╨█ █══════╦══════█ █╨█ █╚═════╗\n" +
            "║█                 █║█                 █║\n" +
            "║█ █══╗█ █═══════█ █╨█ █═══════█ █╔══█ █║\n" +
            "║█   █║█                         █║█   █║\n" +
            "╠══█ █╨█ █╥█ █══════╦══════█ █╥█ █╨█ █══╣\n" +
            "║█       █║█       █║█       █║█       █║\n" +
            "║█ █══════╩══════█ █╨█ █══════╩══════█ █║\n" +
            "║█                                     █║\n" +
            "╚═══════════════════════════════════════╝";

        string DotsString =     // Dinh nghia cac vi tri cham nho PacMan se an khi di chuyen tren ban do 
            "                                         \n" +
            "  · · · · · · · · ·   · · · · · · · · ·  \n" +
            "  ·     ·         ·   ·         ·     ·  \n" +
            "  +     ·         ·   ·         ·     +  \n" +
            "  · · · · · · · · · · · · · · · · · · ·  \n" +
            "  ·     ·   ·               ·   ·     ·  \n" +
            "  · · · ·   · · · ·   · · · ·   · · · ·  \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "        ·                       ·        \n" +
            "  · · · · · · · · ·   · · · · · · · · ·  \n" +
            "  ·     ·         ·   ·         ·     ·  \n" +
            "  + ·   · · · · · ·   · · · · · ·   · +  \n" +
            "    ·   ·   ·               ·   ·   ·    \n" +
            "  · · · ·   · · · ·   · · · ·   · · · ·  \n" +
            "  ·               ·   ·               ·  \n" +
            "  · · · · · · · · · · · · · · · · · · ·  \n" +
            "                                         ";

        string[] PacManAnimations =    // Cac khung hinh cua PacMan khi chuyen dong
        [
            "\"' '\"",
            "n. .n",
            ")>- ->",
            "(<- -<",
        ];


        #endregion

        int OriginalWindowWidth = Console.WindowWidth;     // Luu chieu rong hien tai cua cua so Console
        int OriginalWindowHeight = Console.WindowHeight;   // Luu chieu cao hien tai cua cua so Console
        ConsoleColor OriginalBackgroundColor = Console.BackgroundColor;   // Luu mau nen hien tai cua Console        
        ConsoleColor OriginalForegroundColor = Console.ForegroundColor;   // Luu mau chu hien tai cua Console

        void ShowLogo()   // hien thi logo PacMan
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(45, 5);
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.SetCursorPosition(45, 6);
            Console.WriteLine("║              PAC-MAN !             ║");
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("╚════════════════════════════════════╝");


            // Hien thi hinh ASCII nghe thuat PacMan
            Console.OutputEncoding = System.Text.Encoding.UTF8;     // Dat ma hoa dau ra de ho tro ky tu dac biet (UTF - 8)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(53, 8);
            Console.WriteLine("⠀⠀⠀⠀⣀⣤⣴⣶⣶⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 9);
            Console.WriteLine("⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⢿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 10);
            Console.WriteLine("⢀⣾⣿⣿⣿⣿⣿⣿⣿⣅⢀⣽⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 11);
            Console.WriteLine("⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 12);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⠛⠁⠀⠀⣴⣶⡄⠀⣶⣶⡄⠀⣴⣶⡄");
            Console.SetCursorPosition(53, 13);
            Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣀⠀⠙⠋⠁⠀⠉⠋⠁⠀⠙⠋⠀");
            Console.SetCursorPosition(53, 14);
            Console.WriteLine("⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 15);
            Console.WriteLine("⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 16);
            Console.WriteLine("⠀⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(53, 17);
            Console.WriteLine("⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");

            // Hien thi thong bao nhac nguoi dung tiep tuc
            Console.SetCursorPosition(48, 18);
            Console.WriteLine("Nhan nut bat ki de tiep tuc...");

            // Cho nguoi dung nhan 1 phim bat ky
            Console.ReadKey(true);
            Console.Clear();
        }



        void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Hien thi khung Menu
            Console.SetCursorPosition(45, 5);
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.SetCursorPosition(45, 6);
            Console.Write("║ Enter your name:                   ║"); // Su dung Write de giu con tro tren cung dong
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("╚════════════════════════════════════╝");

            // Dat con tro vao vi tri nhap ten
            Console.SetCursorPosition(45 + 19, 6); // Sau "Enter your name:"

            // Doc ten nguoi choi
            Console.ForegroundColor = ConsoleColor.White;
            string playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;


            // Hien thi loi chao

            Console.SetCursorPosition(0, 9); // Dat con tro xuong phia duoi
            Console.WriteLine($"\nChao mung {playerName}!");
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Ve khung bao quanh 
                int width = 50; // Chieu rong khung
                int height = 15; // Chieu cao khung
                int left = 40; // Vi tri ben trai 
                int top = 3; // Vi tri tren cung

                // Ve goc tren trai
                Console.SetCursorPosition(left, top);
                Console.Write("╔" + new string('═', width - 2) + "╗");

                // Ve cac canh ben
                for (int i = 1; i < height - 1; i++)
                {
                    Console.SetCursorPosition(left, top + i);
                    Console.Write("║" + new string(' ', width - 2) + "║");
                }

                // Ve goc duoi phai
                Console.SetCursorPosition(left, top + height - 1);
                Console.Write("╚" + new string('═', width - 2) + "╝");

                // Hien thi noi dung Menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(left + 5, top + 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Chao nguoi choi: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(playerName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(left + 5, top + 4);
                Console.WriteLine("1. Bat dau tro choi");
                Console.SetCursorPosition(left + 5, top + 5);
                Console.WriteLine("2. Huong dan");
                Console.SetCursorPosition(left + 5, top + 6);
                Console.WriteLine("3. Thoat game");

                Console.SetCursorPosition(left + 5, top + 8);
                Console.Write("Chon: ");
                ConsoleKey choice = Console.ReadKey(true).Key;

                switch (choice)   //Kiem tra gia tri nguoi choi nhan
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        // Nguoi dung chon bat dau tro choi 
                        return; // Thoat khoi phuong thuc va bat dau tro choi
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        // Hien thi cac huong dan chi tiet ve cach choi PacMan
                        Console.SetCursorPosition(10, 5);
                        Console.WriteLine("1.De bat dau tro choi, nhan nut di chuyen (trai, phai, len, xuong) de di chuyen PacMan");
                        Console.WriteLine("2.Nhiem vu cua ban la dieu khien PacMan an het cac hat diem va hat nang luong trong khi ne cac con ma.Neu con ma bat duoc ban, ban se chat va man choi ket thuc");
                        Console.WriteLine("3.Khi PacMan an duoc hat nang luong, cac con ma se bi te liet và PacMan co the tieu diet chung bang cach cham vao chung, khi bi PacMan tieu diet, cac con ma se quay tro ve vi tri ban dau");
                        Console.WriteLine("4.PacMan se thang khi an het cac hat tren ban do va se thua khi bi ma bat");
                        Console.SetCursorPosition(10, 15);
                        Console.WriteLine("Nhan nut bat ki de quay lai Menu...");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        // Roi game 
                        Console.Clear();
                        Console.SetCursorPosition(10, 15);
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(100); // Tam dung chuong trinh trong 100ms de hien thi thong bao 
                        Environment.Exit(0); // Thoat khoi game
                        break;
                    // Truong hop nguoi dung nhan phim khong hop le 
                    default:
                        int positionX = 51; // Can le ngang 
                        int positionY = 11; // Dat con tro theo hang 
                        Console.SetCursorPosition(positionX, positionY);
                        break;
                }
            }
        }

        void BackgroundMusic(string filePath)
        {
            try
            {
                // tao 1 doi tuong de doc am thanh tu duong dan 
                using (var audioFile = new AudioFileReader(filePath))
                // tao 1 thiet bi phat am thanh 
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile); // Khoi tao thiet bi phat voi tep am thanh 
                    audioFile.Volume = 0.2f; // de nhac nen o muc 20% am luong 
                    outputDevice.Play(); // Phat nhac nen 

                    // Lap lai nen nhac lien tuc 
                    while (true)
                    {
                        if (audioFile.Position >= audioFile.Length) // Kiem tra neu nhac da phat het 
                        {
                            audioFile.Position = 0; // Dat lai vi tri phat nhac ve dau tep de phat lai 
                        }
                        Thread.Sleep(10); // Dung tam thoi trong 10ms 
                    }
                }
            }
            // Xu li ngoai le neu co loi xay ra trong qua trinh phat nhac 
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing background music: {ex.Message}");
            }
        }

        void EatingDotSound()
        {
            string eatSoundFile = "eatingSound.wav"; // Duong dan tep am thanh khi PacMan an diem 

            // Thuc thi viec phat am thanh trong 1 tac vu khong dong bo de khong chan luong chinh 
            Task.Run(() =>
            {
                try
                {
                    using (var eatingSound = new AudioFileReader(eatSoundFile)) // Tạo 1 doi tuong de doc tep am thanh 
                    using (var eatingPlayer = new WaveOutEvent()) // Tao 1 thiet bi phat am thanh 
                    {
                        eatingPlayer.Init(eatingSound);
                        eatingPlayer.Play();
                        // Cho am thanh phat xong ma khong chan luong chinh 
                        while (eatingPlayer.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(1); // Tam dung trong 1 ms de giam tai CPU 
                        }
                    }
                }
                // Xu ly ngoai le neu phat sinh loi trong qua trinh phat am thanh 
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing eating sound: {ex.Message}");
                }
            });
        }

        void DeadSound()
        {
            // Thuc thi viec phat am thanh trong 1 tac vu khong dong bo de khong chan luong chinh 
            Task.Run(() =>
            {
                try
                {
                    string deadSoundFile = "DeadSound.wav"; // Duong dan tep am thanh khi PacMan bi chet 
                    // Phat am thanh 
                    using (var deadSound = new AudioFileReader(deadSoundFile))
                    using (var player = new WaveOutEvent())
                    {
                        player.Init(deadSound); // Khoi tao thiet bi phat voi tep am thanh 
                        player.Play(); // Bat dau phat am thanh 

                        // Cho cho den khi am thanh phat xong 
                        while (player.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(10); // Tam dung trong 10 ms de giam tai CPU 
                        }
                    }
                }
                // Xu ly ngoai le neu phat sinh loi trong qua trinh phat am thanh 
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing Pac-Man dead sound: {ex.Message}");
                }
            });
        }

        Stopwatch gameTimer = new Stopwatch(); // Bo dem thoi gian de theo doi nguoi choi 
        void ShowGameTimer()
        {
            // Vi tri hien thi bo dem thoi gian tren giao dien Console 
            int timerX = 0; // truc X
            int timerY = 24; // truc Y
            TimeSpan elapsed = gameTimer.Elapsed; Console.SetCursorPosition(timerX, timerY); // Lay thoi gian da troi qua tu bo dem thoi gian 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Thoi gian da choi: {elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}");
        }


        char[,] Dots; // Mang 2 chieu de luu vi tri cac diem tren ban do 
        int Score; // bien luu tru diem so cua nguoi choi 
        (int X, int Y) PacManPosition; // Toa do hien tai cua PacMan 
        Direction? PacManMovingDirection = default; // Huong di chuyen hien tai cua PacMan 
        int? PacManMovingFrame = default; // Khung hinh hien tai trong qua trinh di chuyen cua PacMan 
        const int FramesToMoveHorizontal = 12; // So khung hinh can de PacMan di chuyen 1 o theo chieu ngang 
        const int FramesToMoveVertical = 12; // So khung hinh can de PAcMan di chuyen 1 o theo chieu doc 
        Ghost[] Ghosts; // Tao mang 
        const int GhostWeakTime = 200; // Thoi gian tinh bang khung hinh khi ma bi yeu 
        (int X, int Y)[] Locations = GetLocations(); // Mang chua toa do cac vi tri tren ban do tro choi
        Console.Clear(); // Xoa man hinh Console 

        ShowLogo(); // Hien thi logo PacMan tren man hinh 
        Task.Run(() => BackgroundMusic("background.wav")); // Phat nhac nen 
        ShowMenu(); // Hien thi menu chinh 


        try
        {
            if (OperatingSystem.IsWindows()) // Kiem tra he dieu hanh xem co phai la Windows hay khong 
            {
                Console.WindowWidth = 50; // Dat chieu rong cua so 
                Console.WindowHeight = 30; // Dat chieu cao cua so 
            }
            Console.CursorVisible = false; // An con tro tren Console 
            Console.BackgroundColor = ConsoleColor.Black; // Mau nen 
            Console.ForegroundColor = ConsoleColor.Yellow; // Mau chu 
            Score = 0; // Khoi tao diem ban dau 
        NextRound:
            Score = 0; // Dat lai diem va lam moi man hinh cho man choi moi 
            Console.Clear();
            SetUpDots(); // Goi ham de tam cac diem tren ban do 
            PacManPosition = (20, 17); // Vi tri khoi dau cua PacMan 

            Ghost a = new(); // Tao va cau hinh con ma voi cac thuoc tinh ban dau 
            a.Position = a.StartPosition = (16, 10);
            a.Color = ConsoleColor.Red;
            a.FramesToUpdate = 14; // So khung hinh de cap nhat 
            a.Update = () => UpdateGhost(a);

            Ghost b = new();
            b.Position = b.StartPosition = (18, 10);
            b.Color = ConsoleColor.DarkGreen;
            b.Destination = GetRandomLocation(); // Muc tieu ngau nhien 
            b.FramesToUpdate = 16;
            b.Update = () => UpdateGhost(b);

            Ghost c = new();
            c.Position = c.StartPosition = (22, 10);
            c.Color = ConsoleColor.Magenta;
            c.FramesToUpdate = 14;
            c.Update = () => UpdateGhost(c);

            Ghost d = new();
            d.Position = d.StartPosition = (24, 10);
            d.Color = ConsoleColor.DarkCyan;
            d.Destination = GetRandomLocation();
            d.FramesToUpdate = 16;
            d.Update = () => UpdateGhost(d);

            Ghosts = [a, b, c, d,]; // Khoi tao mang chua cac con ma 
            // Ve cac yeu to ban dau cua ban do 
            RenderWalls(); // Ve tuong 
            RenderGate(); // Ve cong 
            RenderDots(); // Ve cac diem 
            RenderReady(); // Hien thi man hinh "Ready" 
            RenderPacMan(); // Ve PacMan o vi tri khoi dau 
            RenderGhosts(); // Ve cac con ma 
            RenderScore(); // Hien thi diem  
            ShowGameTimer(); // Hien thi bo dem thoi gian 
            // Doi nguoi dung chon huong di chuyen de bat dau 
            if (GetStartingDirectionInput())
            {
                return; // Nguoi dung nhan phim thoat 
            }
            PacManMovingFrame = 0; // Dat lai khung hinh di chuyen 
            EraseReady(); // Xoa man hinh "Ready" 
            gameTimer.Start(); // Bat dau dem thoi gian choi 
            while (CountDots() > 0) // Tiep tuc cho den khi cac diem bi an 
            {
                if (HandleInput())
                {
                    return; // Nguoi dung nhan phim thoat 
                }
                UpdatePacMan(); // Cap nhat trang thai va vi tri cua PacMan 
                UpdateGhosts(); // Cap nhat trang thai va vi tri cua cac con ma 
                RenderScore(); // Hien thi diem so 
                RenderDots(); // Cap nhat hien thi cac diem tren ban do 
                RenderPacMan(); // Cap nhat vi tri PacMan tren man hinh
                RenderGhosts(); // Cap nhat vi tri cua cac con ma 
                ShowGameTimer(); // Cap nhat hien thi thoi gian choi 
                foreach (Ghost ghost in Ghosts) // Kiem tra va cham giua PacMan va ma
                {
                    if (ghost.Position == PacManPosition) // Neu PacMan cham vao vi tri cua ma 
                    {
                        if (ghost.Weak) // Neu ma dang yeu 
                        {
                            ghost.Position = ghost.StartPosition; // Dua ma ve vi tri ban dau 
                            ghost.Weak = false; // Dat trang thai ma ve binh thuong 
                            Score += 10; // Tang 10 diem 
                        }
                        else // Neu ma khong yeu 
                        {
                            DeadSound(); // Phat am thanh thua 
                            Console.SetCursorPosition(0, 24);
                            Console.WriteLine("Game Over!"); // Hien thi thong bao ket thuc tro choi 
                            Console.WriteLine("[enter] de choi lai hoac [escape] de thoat?");
                        GetInput:
                            switch (Console.ReadKey(true).Key) // Cho nguoi dung nhap phim 
                            {
                                case ConsoleKey.Enter: goto NextRound; // Choi lai 
                                case ConsoleKey.Escape: Console.Clear(); return; // Thoat tro choi 
                                default: goto GetInput; // Neu nhap sai thi yeu cau nhap lai 
                            }
                        }
                    }
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(20)); // Ngat 20ms giua cac vong lap de giam tai CPU 
            }
            goto NextRound; // Khi tat ca cac diem da bi an, bat dau vong choi moi 
        }
        finally // Luon thuc thi khoi lenh de giai phong tai nguyen 
        {
            Console.CursorVisible = false; // An con tro chuot tren Console 
            if (OperatingSystem.IsWindows()) // Kiem tra neu dang chay tren Windows
            {
                Console.WindowWidth = OriginalWindowWidth; // Dat lai chieu rong ve gia tri ban dau 
                Console.WindowHeight = OriginalWindowHeight; // Dat lai chieu cao ve gia tri ban dau 
            }
            Console.BackgroundColor = OriginalBackgroundColor; // Dat lai mau nen ve gia tri ban dau 
            Console.ForegroundColor = OriginalForegroundColor; // Dat lai mau chu ve gia tri ban dau 
            Score = 0; // Dat diem so tro choi ve 0 
        }


        bool GetStartingDirectionInput()
        {
        GetInput: // Cho input tu nguoi choi roi moi bat dau 
            ConsoleKey key = Console.ReadKey(true).Key; // Doc phim duoc nhan boi nguoi choi ma khong hien thi tren man hinh 
            switch (key) // Xu ly huong hoac yeu cau thoat tro choi 
            {
                case ConsoleKey.LeftArrow: PacManMovingDirection = Direction.Left; break;
                case ConsoleKey.RightArrow: PacManMovingDirection = Direction.Right; break;
                case ConsoleKey.Escape: Console.Clear(); Console.Write("PacMan was closed."); return true;
                default: goto GetInput; // Neu input khong hop le, quay lai cho input khac 
            }
            return false; // Tra ve false neu tro choi tiep tuc ( nguoi choi khong nhan ESC) 
        }

        bool HandleInput()
        // Tra ve TRUE neu nguoi choi nhan ESC de thoat tro choi 
        // Tra ve FALSE neu khong co phim yeu cau thoat tro choi duoc nhan 
        {
            bool moved = false; // Bien danh dau trang thai di chuyen cua PacMan 
            void TrySetPacManDirection(Direction direction)
            {
                if (!moved && // Kiem tra neu PacMan chua di chuyen 
                    PacManMovingDirection != direction && // Dam bao huong moi khac huong hien tai 
                    CanMove(PacManPosition.X, PacManPosition.Y, direction)) // Kiem tra xem PacMan co the di chuyen theo huong moi hay khong 
                {
                    PacManMovingDirection = direction; // Cap nhat huong di chuyen cua PacMan 
                    PacManMovingFrame = 0; // Dat lai khung hinh di chuyen 
                    moved = true; // Danh dau rang PacMan da di chuyen trong vong lap nay 
                }
            }
            while (Console.KeyAvailable) // Kiem tra xem co phim nao dang cho xu li khong 
            {
                switch (Console.ReadKey(true).Key) // Doc phim duoc nhan va xu li 
                {
                    case ConsoleKey.UpArrow: TrySetPacManDirection(Direction.Up); break;
                    case ConsoleKey.DownArrow: TrySetPacManDirection(Direction.Down); break;
                    case ConsoleKey.LeftArrow: TrySetPacManDirection(Direction.Left); break;
                    case ConsoleKey.RightArrow: TrySetPacManDirection(Direction.Right); break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.Write("Ban da an Escape. Thoat tro choi!");
                        Console.ReadKey();
                        return true;
                        // Nguoi choi nhan ESC de thaot tro choi 
                }
            }
            return false; // Tro choi tiep tuc neu khong co phim ESC duoc nhan 
        }

        //x la cot, y la hang
        char BoardAt(int x, int y) => WallsString[y * 42 + x];

        bool IsWall(int x, int y) => BoardAt(x, y) is not ' ';

        bool CanMove(int x, int y, Direction direction) => direction switch
        {
            Direction.Up => //check 3 ô phía trên 
                !IsWall(x - 1, y - 1) && //ô trên trái
                !IsWall(x, y - 1) &&  //ô trên giữa
                !IsWall(x + 1, y - 1), //ô trên phải
            Direction.Down =>
                !IsWall(x - 1, y + 1) && //ô dưới trái
                !IsWall(x, y + 1) && //ô dưới giữa
                !IsWall(x + 1, y + 1), //ô dưới phải
            Direction.Left =>
                x - 2 < 0 || !IsWall(x - 2, y), //0 là border trái của map
            Direction.Right =>
                x + 2 > 40 || !IsWall(x + 2, y), //40 là border phải của map
            _ => throw new NotImplementedException(),
        };

        void SetUpDots() // Ham SetUpDots thiet lap ma tran Dots tu chuoi DotsString
        {
            string[] rows = DotsString.Split("\n"); //chia DotsString thanh cac hang dua tren ky tu xuong dong "\n"
            int rowCount = rows.Length; // Xac dinh so luong hang trong ma tran 
            int columnCount = rows[0].Length; // Xac dinh so luong cot dua tren do dai cua hang dau tien
            Dots = new char[columnCount, rowCount]; // Tao ma tran dots
            for (int row = 0; row < rowCount; row++)   // Duyet qua tung hang 
            {
                for (int column = 0; column < columnCount; column++) // Duyet qua tung cot trong hang 
                {
                    Dots[column, row] = rows[row][column]; // Gan gia tri tu chuoi "rows" vao mang "Dots"
                }
            }
        }
        // Dem so luong diem hien co trong ma tran 
        int CountDots()
        {
            int count = 0;
            int columnCount = Dots.GetLength(0); // Lay so luong cot trong ma tran Dots
            int rowCount = Dots.GetLength(1); // Lay so luong hang trong ma tran Dots
            for (int row = 0; row < rowCount; row++) // Duyet qua tung hang trong ma tran 
            {
                for (int column = 0; column < columnCount; column++) // Duyet qua tung cot trong hang 
                {
                    if (!char.IsWhiteSpace(Dots[column, row])) // Kiem tra neu ky tu tai vi tri (column, row) khong phai khoang trang 
                    {
                        count++;
                    }
                }
            }
            return count; // Tra ve tong so diem da dem duoc 
        }

        void UpdatePacMan()
        {
            if (PacManMovingDirection.HasValue) // Kiem tra neu PacMan dang di chuyen 
            {
                // Kiem tra neu PacMan da di chuyen du so khung hinh can thiet theo huong hien tai 
                if ((PacManMovingDirection == Direction.Left || PacManMovingDirection == Direction.Right) && PacManMovingFrame >= FramesToMoveHorizontal ||
                    (PacManMovingDirection == Direction.Up || PacManMovingDirection == Direction.Down) && PacManMovingFrame >= FramesToMoveVertical)
                {
                    PacManMovingFrame = 1; // Dat lai khung hinh di chuyen (Toc do di chuyen cua PacMan)
                    // Xac dinh dieu chinh toa do X dua tren huong di chuyen 
                    int x_adjust =
                        PacManMovingDirection == Direction.Left ? -1 : // Di chuyen trai giam X
                        PacManMovingDirection == Direction.Right ? 1 : // Di chuyen phai tang X
                        0; // Khong thay doi neu di chuyen theo truc Y
                    // Xac dinh dieu chinh toa do Y dua tren huong di chuyen 
                    int y_adjust =
                        PacManMovingDirection == Direction.Up ? -1 : // Di chuyen len giam Y
                        PacManMovingDirection == Direction.Down ? 1 : // Di chuyen xuong tang Y
                        0; // Khong thay doi neu di chuyen theo truc X
                    // Xoa ky tu cu cua PacMan tai vi tri hien tai tren man hinh 
                    Console.SetCursorPosition(PacManPosition.X, PacManPosition.Y);
                    Console.Write(" ");
                    PacManPosition = (PacManPosition.X + x_adjust, PacManPosition.Y + y_adjust); // Cap nhat vi tri moi cua PacMan 
                    // Xu ly vong lap khi PacMan di ra ngoaif gioi han ngang  (trai hoac phai man hinh)
                    if (PacManPosition.X < 0)
                    {
                        PacManPosition.X = 40; // Neu ra khoi bien trai, dat PacMan o bien phai 
                    }
                    else if (PacManPosition.X > 40)
                    {
                        PacManPosition.X = 0; // Neu ra khoir bien phai, dat PacMan o bien trai
                    }
                    if (Dots[PacManPosition.X, PacManPosition.Y] is '·') // Kiem tra neu vi tri moi cua PacMan co diem de an 
                    {
                        Dots[PacManPosition.X, PacManPosition.Y] = ' '; // Xoa diem da an 
                        Score += 1; // Tang so diem 
                        EatingDotSound(); // Goi ham phat am thanh khi an diem 


                    }
                    if (Dots[PacManPosition.X, PacManPosition.Y] is '+') // Khi PacMan an diem '+'
                    {
                        foreach (Ghost ghost in Ghosts) // Lam tat ca con ma tro nen yeu 
                        {
                            ghost.Weak = true; // Dat trang thai yeu cho ma 
                            ghost.WeakTime = 0; // Dat thoi gian yeu bat dau tu 0 
                        }
                        Dots[PacManPosition.X, PacManPosition.Y] = ' '; // Xoa ky tu '+' tren mang Dots
                        Score += 3; // Tang diem so them 3 
                    }
                    // Kiem tra neu PacMan khong the di chuyen theo huong hien tai 
                    if (!CanMove(PacManPosition.X, PacManPosition.Y, PacManMovingDirection.Value))
                    {
                        PacManMovingDirection = null; // Ngung di chuyen neu khong the tiep tuc 
                    }
                }
                else
                {
                    PacManMovingFrame++; // Neu chua dat so khung hinh de di chuyen tiep, tang so khung hinh 
                }
            }
        }

        void RenderReady()
        {
            Console.SetCursorPosition(18, 13); // Dat con tro den vi tri (18,13) tren man hinh 
            WithColors(ConsoleColor.White, ConsoleColor.Black, () =>
            {
                Console.Write("READY");
            });
        }

        void EraseReady() //xoa chu Ready
        {
            Console.SetCursorPosition(18, 13);
            Console.Write("     ");
        }

        void RenderScore()
        {
            Console.SetCursorPosition(0, 23);
            Console.Write("Score: " + Score);
        }

        void RenderGate()
        {
            Console.SetCursorPosition(19, 9);
            WithColors(ConsoleColor.Magenta, ConsoleColor.Black, () =>
            {
                Console.Write("---");
            });
        }

        void RenderWalls()
        {
            Console.SetCursorPosition(0, 0);
            WithColors(ConsoleColor.Blue, ConsoleColor.Black, () =>
            {
                Render(WallsString, false);
            });
        }

        void RenderDots()
        {
            Console.SetCursorPosition(0, 0); // Dat con tro ve vi tri goc tren ben trai cua man hinh Console 
            WithColors(ConsoleColor.DarkYellow, ConsoleColor.Black, () => // Hien thi cac diem 
            {
                for (int row = 0; row < Dots.GetLength(1); row++) // Duyet qua tung hang trong mang Dots
                {
                    for (int column = 0; column < Dots.GetLength(0); column++) // Duyet qua tung cot trong mang Dots
                    {
                        if (!char.IsWhiteSpace(Dots[column, row])) // Kiem tra neu ky tu tai vi tri (column, row) khong phai khoang trang
                        {
                            Console.SetCursorPosition(column, row); // Dat con tro den vi tri (column, row) de in ky tu 
                            Console.Write(Dots[column, row]); // Hien thi ky tu tai (column, row)
                        }
                    }
                }
            });
        }
        // Ve trang thai hien tai cua PacMan 
        void RenderPacMan()
        {
            Console.SetCursorPosition(PacManPosition.X, PacManPosition.Y);
            WithColors(ConsoleColor.Black, ConsoleColor.Yellow, () =>
            {
                if (PacManMovingDirection.HasValue && PacManMovingFrame.HasValue) // Kiem tra xem huong di chuyen va khung hinh dong cua PacMan co gia tri hay khong 
                {
                    int frame = (int)PacManMovingFrame % PacManAnimations[(int)PacManMovingDirection].Length; // Tinh toan khung hinh dong hien tai cua PacMan 
                    Console.Write(PacManAnimations[(int)PacManMovingDirection][frame]); // Hien thi khung hinh dong hien tai cua PacMan 
                }
                else
                {
                    Console.Write(' '); // Hien thi khoang trang neu khong co khung hinh hoac huong di chuyen 
                }
            });
        }

        void RenderGhosts()
        {
            foreach (Ghost ghost in Ghosts) // Duyet tat ca ma trong danh sach 
            {
                Console.SetCursorPosition(ghost.Position.X, ghost.Position.Y);
                WithColors(ConsoleColor.White, ghost.Weak ? ConsoleColor.Blue : ghost.Color, () => Console.Write('"')); // Neu ma dang yeu, nen se co mau xanh duong, nguoc lai su dung mau cua ma 
            }
        }

        // Thay doi mau nen va mau chu 
        void WithColors(ConsoleColor foreground, ConsoleColor background, Action action)
        {
            // Luu mau chu va mau nen ban dau 
            ConsoleColor originalForeground = Console.ForegroundColor;
            ConsoleColor originalBackground = Console.BackgroundColor;
            try
            {
                // Dat mau chu va mau nen moi 
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                action(); // Thuc thi hanh dong chuyen vao 
            }
            finally
            {
                // Khoi phuc mau chu va mau nen ban dau 
                Console.ForegroundColor = originalForeground;
                Console.BackgroundColor = originalBackground;
            }
        }
        // Hien thi chuoi van ban len Console 
        void Render(string @string, bool renderSpace = true)
        {
            // Luu vi tri con tro hien tai 
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            foreach (char c in @string)
            {
                if (c is '\n') // Neu gap ky tu xuong dong thi chuyen con tro xuong dong moi 
                {
                    Console.SetCursorPosition(x, ++y);
                }
                else if (c is not ' ' || renderSpace) // Neu ky tu khong phai khoang trang hoac 'renderSpace' duoc bat thi hien thi ky tu 
                {
                    Console.Write(c);
                }
                // Neu la khoang trang va khong hien thi, di chuyen con tro sang phai 
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
            }
        }
        // Cap nhat trang thai cua tat ca ma trong danh sach 
        void UpdateGhosts()
        {
            foreach (Ghost ghost in Ghosts)
            {
                ghost.Update!(); // Goi phuong thuc cap nhat trang thai cua tung con ma 
            }
        }
        // Cap nhat trang thai cua mot con ma cu the 
        void UpdateGhost(Ghost ghost)
        {
            if (ghost.Destination.HasValue && ghost.Destination == ghost.Position) // Kiem tra neu con ma da den vi tri dich, dat diem dich moi 
            {
                ghost.Destination = GetRandomLocation();
            }
            if (ghost.Weak) // Neu ma dang yeu, tang thoi gian yeu va kiem tra neu het thoi gian 
            {
                ghost.WeakTime++;
                if (ghost.WeakTime > GhostWeakTime)
                {
                    ghost.Weak = false; // Con ma khong con yeu 
                }
            }
            // Neu con ma chua den khung hinh can cap nhat, tang so khung hinh da xu ly 
            else if (ghost.UpdateFrame < ghost.FramesToUpdate)
            {
                ghost.UpdateFrame++;
            }
            // Di chuyen con ma den vi tri tiep theo 
            else
            {
                Console.SetCursorPosition(ghost.Position.X, ghost.Position.Y); // Xoa vi tri cua con ma tren Console 
                Console.Write(' ');
                ghost.Position = GetGhostNextMove(ghost.Position, ghost.Destination ?? PacManPosition); // Tinh toan vi tri moi va di chuyen con ma 
                ghost.UpdateFrame = 0; // Dat lai so khung hinh da xu ly 
            }
        }



        (int X, int Y)[] GetLocations()
        {
            // Tao danh sach cac vi tri tu chuoi GhostWallString 
            List<(int X, int Y)> list = new();
            int x = 0;
            int y = 0;
            foreach (char c in GhostWallsString)
            {
                if (c is '\n') // Khi gap ky tu xuong dong, chuyen sang hang tiep theo 
                {
                    x = 0;
                    y++;
                }
                else
                {
                    if (c is ' ') // Neu ky tu la khoang trang, them toa do vao danh sach 
                    {
                        list.Add((x, y));
                    }
                    x++;
                }
            }
            return [.. list]; // Tra ve danh sach cac toa do 
        }
        // Chon vi tri ngau nhien tu danh sach cac toa do co the su dung duoc 
        (int X, int Y) GetRandomLocation() => Random.Shared.Choose(Locations);

        (int X, int Y) GetGhostNextMove((int X, int Y) position, (int X, int Y) destination)
        {
            HashSet<(int X, int Y)> alreadyUsed = new(); // Tap hop luu cac toa do da kiem tra 

            char BoardAt(int x, int y) => GhostWallsString[y * 42 + x]; // Lay ky tu tai mot vi tri cu the tren bang 

            bool IsWall(int x, int y) => BoardAt(x, y) is not ' '; // Kiem tra xem co phai tuong khong

            void Neighbors((int X, int Y) currentLocation, Action<(int X, int Y)> neighbors) // Tim cac vi tri lang gieng cua vi tri hien tai 
            {
                void HandleNeighbor(int x, int y)
                {
                    if (!alreadyUsed.Contains((x, y)) && x >= 0 && x <= 40 && !IsWall(x, y)) // Neu vi tri chua duoc kiem tra, khong nam ngoai bien va khong phai tuong, them vao danh sach 
                    {
                        alreadyUsed.Add((x, y));
                        neighbors((x, y));
                    }
                }

                int x = currentLocation.X;
                int y = currentLocation.Y;
                // Kiem tra cac lang gieng theo huong: trai, tren, phai, duoi 
                HandleNeighbor(x - 1, y);
                HandleNeighbor(x, y + 1);
                HandleNeighbor(x + 1, y);
                HandleNeighbor(x, y - 1);
            }
            // Ham Heuristic de danh gia khoang cach tu vi tri hien tai toi PacMan 
            int Heuristic((int X, int Y) node)
            {
                int x = node.X - PacManPosition.X;
                int y = node.Y - PacManPosition.Y;
                return x * x + y * y;
            }
            // Tim duong di toi uu tu vi tri hien tai toi dich 
            Action<Action<(int X, int Y)>> path = SearchGraph(position, Neighbors, Heuristic, node => node == destination)!;
            (int X, int Y)[] array = path.ToArray();
            return array[1]; // Tra ve buoc tiep theo trong duong di 
        }
    }
}

// Lop mo ta thong tin va trang thai cua con ma 
class Ghost
{
    public (int X, int Y) StartPosition; // vi tri ban dau cua con ma 
    public (int X, int Y) Position; // vi tri hien tai cua con ma 
    public bool Weak;   //trang thai yeu cua ma 
    public int WeakTime; //thoi gian con lai khi con ma yeu 
    public ConsoleColor Color;   // mau cua con ma 
    public Action? Update;  //hanh dong cap nhat trang thai va vi tri cua con ma 
    public int UpdateFrame; // so khung hinh da cap nhat 
    public int FramesToUpdate; // so khung hinh can de con ma di chuyen 
    public (int X, int Y)? Destination; // diem den cua con ma 
    enum Direction // Xac dinh huong di chuyen cua PacMan dua tren dau vao cua nguoi choi 
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }



