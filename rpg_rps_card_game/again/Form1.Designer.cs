using Microsoft.Win32;
using System;
public class Nesne
{
    public float dayaniklik = 20;
    public float seviyePuani = 0;
    // parametre
    public Nesne(float dayaniklik, float seviyePuani)
    {
        // this.parametre = parametre
        this.dayaniklik = dayaniklik;
        this.seviyePuani = seviyePuani;
    }
    public float seviyePuaniGoster()
    {
        return this.seviyePuani;
    }
    public float dayaniklikGoster()
    {
        return this.dayaniklik;
    }
    public float etkiHesapla(float katilik, float nufuz, float keskinlik, float sicaklik, float kalinlik, float hiz) // used 
    {
        float etki;
        float a = 0.2f;
        etki = (katilik * sicaklik) / ((a * keskinlik * hiz) + (1 - a) * nufuz * kalinlik);
        if (etki > 0)
        {
            return etki;
        }
        etki = (nufuz * kalinlik) / ((a * katilik * sicaklik) + (1 - a) * keskinlik * hiz);
        if (etki > 0)
        {
            return etki;
        }
        etki = (keskinlik * hiz) / ((a * nufuz * kalinlik) + (1 - a) * kalinlik * sicaklik);
        if (etki > 0)
        {
            return etki;
        }
        return 0;
    }
    public void durumGuncelle(float etki, float ekpuan) // used
    {
        this.dayaniklik = this.dayaniklik - etki;
        this.seviyePuani = this.seviyePuani + ekpuan;
    }

}

public class tasSinifi : Nesne
{
    // parametre 
    public float katilik = 10;


    public tasSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
        this.katilik = katilik;
    }

    public static implicit operator List<object>(tasSinifi v)
    {
        throw new NotImplementedException();
    }
}


public class kagitSinifi : Nesne
{
    // parametre 
    public float nufuz = 10;

    public kagitSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
        this.nufuz = nufuz;
    }

    public float nufuzGoster()
    {
        return this.nufuz;
    }
}


public class makasSinifi : Nesne
{
    // parametre 
    public float keskinlik = 10;

    public makasSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
        this.keskinlik = keskinlik;
    }

    public float keskinlikGoster()
    {
        return this.keskinlik;
    }
}

public class agirTasSinifi : tasSinifi
{
    // parametre
    public float sicaklik = 2f;

    public agirTasSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
    }

    public float sicaklikGoster()
    {
        return sicaklik;
    }
}

public class ozelKagitSinifi : kagitSinifi
{
    // parametre
    public float kalinlik = 2f;

    public ozelKagitSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
    }

    public float kalinlikGoster()
    {
        return kalinlik;
    }
}

public class ustaMakasSinifi : makasSinifi
{
    // parametre
    public float hiz = 2f;

    public ustaMakasSinifi(float dayaniklik, float seviyePuani) : base(dayaniklik, seviyePuani)
    {
    }

    public float hizGoster()
    {
        return hiz;
    }
}


public class oyuncu
{
    public int[] oyuncuID;
    public String oyuncuAdi;
    public int skor;
    
    public struct deste
    {
        public tasSinifi taslar;
        public kagitSinifi kagitlar;
        public makasSinifi makaslar;
        public agirTasSinifi agirtaslar;
        public ozelKagitSinifi ozelkagitlar;
        public ustaMakasSinifi ustamakaslar;
    }

    public deste[] deste1 = new deste[5];

    public oyuncu(int[] oyuncuID, String oyuncuAdi, int skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;
    }


    public int whichone = 2;
    int defaulthealth = 20;
    public void nesneSec(int indis, char item)
    {
        Console.WriteLine("indis : " + indis + "  item : " + item);

        if (whichone == 0)
        {
            Console.WriteLine("shuffling comp deck");
            String computerChoice;
            String[] rps = { "R", "P", "S" };
            int i;
            Random random = new Random();

            for (i = 0; i < 5; i++)
            {
                int randint = random.Next(3);
                computerChoice = rps[randint];
                if (computerChoice.Equals("R"))
                {
                    System.Console.WriteLine("computer's Choice is Rock");
                    //buttonlist1[i].Image = global::again.Properties.Resources.tas;
                    deste1[i].taslar = new tasSinifi(defaulthealth, 0);
                    deste1[i].kagitlar = null;
                    deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("P"))
                {
                    System.Console.WriteLine("computer's Choice is Paper");
                    //buttonlist1[i].Image = global::again.Properties.Resources.kagit;
                    deste1[i].taslar = null;
                    deste1[i].kagitlar = new kagitSinifi(defaulthealth, 0);
                    deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("S"))
                {
                    System.Console.WriteLine("computer's Choice is Scissors");
                    //buttonlist1[i].Image = global::again.Properties.Resources.makas;
                    deste1[i].taslar = null;
                    deste1[i].kagitlar = null;
                    deste1[i].makaslar = new makasSinifi(defaulthealth, 0);
                }
            }
        }
        else if (whichone == 1)
        {
            Console.WriteLine("selecting user deck");

            if(item.Equals('R'))
            {
                deste1[indis].taslar = new tasSinifi(defaulthealth, 0);
                deste1[indis].kagitlar = null;
                deste1[indis].makaslar = null;
                Console.WriteLine("rock chosed");
            }
            else if (item.Equals('P'))
            {
                deste1[indis].taslar = null;
                deste1[indis].kagitlar = new kagitSinifi(defaulthealth, 0);
                deste1[indis].makaslar = null;
                Console.WriteLine("paper chosed");
            }
            else if (item.Equals('S'))
            {
                deste1[indis].taslar = null;
                deste1[indis].kagitlar = null;
                deste1[indis].makaslar = new makasSinifi(defaulthealth, 0);
                Console.WriteLine("scissor chosed");
            }
        }
    }
}

public class kullaniciSinifi : oyuncu
{
    //bilgisayar classindan metodlar override edilsin
    public kullaniciSinifi(int[] oyuncuID, String oyunncuAdi, int skor) : base(oyuncuID, oyunncuAdi, skor)
    {

    }

}

public class bilgisayarSinifi : oyuncu
{

    public bilgisayarSinifi(int[] oyuncuID, String oyunncuAdi, int skor) : base(oyuncuID, oyunncuAdi, skor)
    {

    }

}


public class totalTurn
{
    public  int counter;
}


public class program
{
    public void function1()
    {
        Console.WriteLine("saka mi button 1 calisti xd");
    }
}


namespace again
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        ///
        
        //define decks
        program prgram1 = new program();
        // pvc mode :
        Button[] pvcbuttonlist1 = new Button[5]; // computer's deck
        Button[] pvcbuttonlist2 = new Button[5]; //user's deck
        // cvc mode :
        Button[] buttonlist1 = new Button[5]; // top user's deck
        Button[] buttonlist2 = new Button[5]; // bottom user's deck
                                              // deck1 :
        List<Nesne>[] deck1 = new List<Nesne>[5];

        kullaniciSinifi player1 = new kullaniciSinifi(null,null,0);
        bilgisayarSinifi player2 = new bilgisayarSinifi(null, null, 0);
        bilgisayarSinifi player3 = new bilgisayarSinifi(null, null, 0);

        totalTurn turns = new totalTurn();
        totalTurn turns2 = new totalTurn(); 
        int choiceindex = 0;
        public int TOTALROUND = 100;
        int righttopscore = 0;
        int leftbottomscore = 0;
        int HEALTH = 20; // dayanıklılık değiştirmek için



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cvcbutton = new System.Windows.Forms.Button();
            this.pvcbutton = new System.Windows.Forms.Button();
            this.computerdeck = new System.Windows.Forms.GroupBox();
            this.compbutton5 = new System.Windows.Forms.Button();
            this.compbutton4 = new System.Windows.Forms.Button();
            this.compbutton3 = new System.Windows.Forms.Button();
            this.compbutton2 = new System.Windows.Forms.Button();
            this.compbutton1 = new System.Windows.Forms.Button();
            this.comp_user_deck = new System.Windows.Forms.GroupBox();
            this.cmpusrbutton5 = new System.Windows.Forms.Button();
            this.cmpusrbutton4 = new System.Windows.Forms.Button();
            this.cmpusrbutton1 = new System.Windows.Forms.Button();
            this.cmpusrbutton3 = new System.Windows.Forms.Button();
            this.cmpusrbutton2 = new System.Windows.Forms.Button();
            this.sec1box = new System.Windows.Forms.GroupBox();
            this.secim13button = new System.Windows.Forms.Button();
            this.secim12button = new System.Windows.Forms.Button();
            this.secim11button = new System.Windows.Forms.Button();
            this.sec2box = new System.Windows.Forms.GroupBox();
            this.secim23button = new System.Windows.Forms.Button();
            this.secim22button = new System.Windows.Forms.Button();
            this.secim21button = new System.Windows.Forms.Button();
            this.sec3box = new System.Windows.Forms.GroupBox();
            this.secim33button = new System.Windows.Forms.Button();
            this.secim32button = new System.Windows.Forms.Button();
            this.secim31button = new System.Windows.Forms.Button();
            this.secimyapbox = new System.Windows.Forms.GroupBox();
            this.done = new System.Windows.Forms.Button();
            this.sec5box = new System.Windows.Forms.GroupBox();
            this.secim53button = new System.Windows.Forms.Button();
            this.secim52button = new System.Windows.Forms.Button();
            this.secim51button = new System.Windows.Forms.Button();
            this.sec4box = new System.Windows.Forms.GroupBox();
            this.secim43button = new System.Windows.Forms.Button();
            this.secim42button = new System.Windows.Forms.Button();
            this.secim41button = new System.Windows.Forms.Button();
            this.playerinputs = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.playernametextbox = new System.Windows.Forms.TextBox();
            this.playername = new System.Windows.Forms.Label();
            this.playerIDtextbox = new System.Windows.Forms.TextBox();
            this.playerIDlabel = new System.Windows.Forms.Label();
            this.user1scoreboard = new System.Windows.Forms.GroupBox();
            this.scoretext1 = new System.Windows.Forms.Label();
            this.user1score = new System.Windows.Forms.Label();
            this.user1ID = new System.Windows.Forms.Label();
            this.user1name = new System.Windows.Forms.Label();
            this.user2scoreboard = new System.Windows.Forms.GroupBox();
            this.score2text = new System.Windows.Forms.Label();
            this.user2score = new System.Windows.Forms.Label();
            this.user2ID = new System.Windows.Forms.Label();
            this.user2name = new System.Windows.Forms.Label();
            this.vsmenu = new System.Windows.Forms.GroupBox();
            this.rounds = new System.Windows.Forms.Label();
            this.tickbutton = new System.Windows.Forms.Button();
            this.healthdata2 = new System.Windows.Forms.Label();
            this.healthdata1 = new System.Windows.Forms.Label();
            this.damagedata1 = new System.Windows.Forms.Label();
            this.damagedata2 = new System.Windows.Forms.Label();
            this.healthtext2 = new System.Windows.Forms.Label();
            this.healthtext1 = new System.Windows.Forms.Label();
            this.damagetext2 = new System.Windows.Forms.Label();
            this.damagetext1 = new System.Windows.Forms.Label();
            this.vstext = new System.Windows.Forms.Label();
            this.compusr2picturebox = new System.Windows.Forms.PictureBox();
            this.comp1picturebox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.next_game_menu = new System.Windows.Forms.GroupBox();
            this.exit = new System.Windows.Forms.Button();
            this.playagain = new System.Windows.Forms.Button();
            this.scores = new System.Windows.Forms.Label();
            this.winner = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.computerdeck.SuspendLayout();
            this.comp_user_deck.SuspendLayout();
            this.sec1box.SuspendLayout();
            this.sec2box.SuspendLayout();
            this.sec3box.SuspendLayout();
            this.secimyapbox.SuspendLayout();
            this.sec5box.SuspendLayout();
            this.sec4box.SuspendLayout();
            this.playerinputs.SuspendLayout();
            this.user1scoreboard.SuspendLayout();
            this.user2scoreboard.SuspendLayout();
            this.vsmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compusr2picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comp1picturebox)).BeginInit();
            this.next_game_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::again.Properties.Resources.background2;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cvcbutton);
            this.groupBox1.Controls.Add(this.pvcbutton);
            this.groupBox1.Location = new System.Drawing.Point(220, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("ArcadeClassic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(802, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "ROCK PAPER SCISSORS";
            // 
            // cvcbutton
            // 
            this.cvcbutton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cvcbutton.BackgroundImage = global::again.Properties.Resources.cvcbackground;
            this.cvcbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cvcbutton.Font = new System.Drawing.Font("Arcade", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cvcbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cvcbutton.Location = new System.Drawing.Point(464, 148);
            this.cvcbutton.Name = "cvcbutton";
            this.cvcbutton.Size = new System.Drawing.Size(359, 154);
            this.cvcbutton.TabIndex = 1;
            this.cvcbutton.Text = "computer vs computer";
            this.cvcbutton.UseVisualStyleBackColor = false;
            this.cvcbutton.Click += new System.EventHandler(this.cvcbutton_Click);
            // 
            // pvcbutton
            // 
            this.pvcbutton.BackColor = System.Drawing.Color.RosyBrown;
            this.pvcbutton.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.pvcbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pvcbutton.Font = new System.Drawing.Font("Arcade", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pvcbutton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pvcbutton.Location = new System.Drawing.Point(21, 148);
            this.pvcbutton.Name = "pvcbutton";
            this.pvcbutton.Size = new System.Drawing.Size(359, 154);
            this.pvcbutton.TabIndex = 0;
            this.pvcbutton.Text = "player vs computer";
            this.pvcbutton.UseVisualStyleBackColor = false;
            this.pvcbutton.Click += new System.EventHandler(this.pvcbutton_Click);
            // 
            // computerdeck
            // 
            this.computerdeck.BackColor = System.Drawing.Color.IndianRed;
            this.computerdeck.BackgroundImage = global::again.Properties.Resources.computerbackground;
            this.computerdeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.computerdeck.Controls.Add(this.compbutton5);
            this.computerdeck.Controls.Add(this.compbutton4);
            this.computerdeck.Controls.Add(this.compbutton3);
            this.computerdeck.Controls.Add(this.compbutton2);
            this.computerdeck.Controls.Add(this.compbutton1);
            this.computerdeck.Location = new System.Drawing.Point(187, 3);
            this.computerdeck.Name = "computerdeck";
            this.computerdeck.Size = new System.Drawing.Size(975, 168);
            this.computerdeck.TabIndex = 1;
            this.computerdeck.TabStop = false;
            this.computerdeck.Visible = false;
            // 
            // compbutton5
            // 
            this.compbutton5.Location = new System.Drawing.Point(789, 27);
            this.compbutton5.Name = "compbutton5";
            this.compbutton5.Size = new System.Drawing.Size(180, 130);
            this.compbutton5.TabIndex = 4;
            this.compbutton5.UseVisualStyleBackColor = true;
            this.compbutton5.Visible = false;
            this.compbutton5.Click += new System.EventHandler(this.button7_Click);
            // 
            // compbutton4
            // 
            this.compbutton4.Location = new System.Drawing.Point(593, 26);
            this.compbutton4.Name = "compbutton4";
            this.compbutton4.Size = new System.Drawing.Size(180, 130);
            this.compbutton4.TabIndex = 3;
            this.compbutton4.UseVisualStyleBackColor = true;
            this.compbutton4.Visible = false;
            this.compbutton4.Click += new System.EventHandler(this.button6_Click);
            // 
            // compbutton3
            // 
            this.compbutton3.Location = new System.Drawing.Point(398, 26);
            this.compbutton3.Name = "compbutton3";
            this.compbutton3.Size = new System.Drawing.Size(180, 130);
            this.compbutton3.TabIndex = 2;
            this.compbutton3.UseVisualStyleBackColor = true;
            this.compbutton3.Visible = false;
            this.compbutton3.Click += new System.EventHandler(this.button5_Click);
            // 
            // compbutton2
            // 
            this.compbutton2.Location = new System.Drawing.Point(202, 26);
            this.compbutton2.Name = "compbutton2";
            this.compbutton2.Size = new System.Drawing.Size(180, 130);
            this.compbutton2.TabIndex = 1;
            this.compbutton2.UseVisualStyleBackColor = true;
            this.compbutton2.Visible = false;
            this.compbutton2.Click += new System.EventHandler(this.button4_Click);
            // 
            // compbutton1
            // 
            this.compbutton1.Location = new System.Drawing.Point(9, 26);
            this.compbutton1.Name = "compbutton1";
            this.compbutton1.Size = new System.Drawing.Size(180, 130);
            this.compbutton1.TabIndex = 0;
            this.compbutton1.UseVisualStyleBackColor = true;
            this.compbutton1.Visible = false;
            this.compbutton1.Click += new System.EventHandler(this.compbutton1_Click);
            // 
            // comp_user_deck
            // 
            this.comp_user_deck.BackColor = System.Drawing.Color.CadetBlue;
            this.comp_user_deck.BackgroundImage = global::again.Properties.Resources.userbackground;
            this.comp_user_deck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comp_user_deck.Controls.Add(this.cmpusrbutton5);
            this.comp_user_deck.Controls.Add(this.cmpusrbutton4);
            this.comp_user_deck.Controls.Add(this.cmpusrbutton1);
            this.comp_user_deck.Controls.Add(this.cmpusrbutton3);
            this.comp_user_deck.Controls.Add(this.cmpusrbutton2);
            this.comp_user_deck.Location = new System.Drawing.Point(187, 612);
            this.comp_user_deck.Name = "comp_user_deck";
            this.comp_user_deck.Size = new System.Drawing.Size(975, 161);
            this.comp_user_deck.TabIndex = 2;
            this.comp_user_deck.TabStop = false;
            this.comp_user_deck.Visible = false;
            // 
            // cmpusrbutton5
            // 
            this.cmpusrbutton5.Location = new System.Drawing.Point(789, 14);
            this.cmpusrbutton5.Name = "cmpusrbutton5";
            this.cmpusrbutton5.Size = new System.Drawing.Size(180, 130);
            this.cmpusrbutton5.TabIndex = 7;
            this.cmpusrbutton5.UseVisualStyleBackColor = true;
            this.cmpusrbutton5.Click += new System.EventHandler(this.button12_Click);
            // 
            // cmpusrbutton4
            // 
            this.cmpusrbutton4.Location = new System.Drawing.Point(593, 14);
            this.cmpusrbutton4.Name = "cmpusrbutton4";
            this.cmpusrbutton4.Size = new System.Drawing.Size(180, 130);
            this.cmpusrbutton4.TabIndex = 6;
            this.cmpusrbutton4.UseVisualStyleBackColor = true;
            this.cmpusrbutton4.Click += new System.EventHandler(this.button11_Click);
            // 
            // cmpusrbutton1
            // 
            this.cmpusrbutton1.Location = new System.Drawing.Point(6, 14);
            this.cmpusrbutton1.Name = "cmpusrbutton1";
            this.cmpusrbutton1.Size = new System.Drawing.Size(180, 130);
            this.cmpusrbutton1.TabIndex = 3;
            this.cmpusrbutton1.UseVisualStyleBackColor = true;
            this.cmpusrbutton1.Click += new System.EventHandler(this.button8_Click);
            // 
            // cmpusrbutton3
            // 
            this.cmpusrbutton3.Location = new System.Drawing.Point(398, 14);
            this.cmpusrbutton3.Name = "cmpusrbutton3";
            this.cmpusrbutton3.Size = new System.Drawing.Size(180, 130);
            this.cmpusrbutton3.TabIndex = 5;
            this.cmpusrbutton3.UseVisualStyleBackColor = true;
            this.cmpusrbutton3.Click += new System.EventHandler(this.button10_Click);
            // 
            // cmpusrbutton2
            // 
            this.cmpusrbutton2.Location = new System.Drawing.Point(202, 14);
            this.cmpusrbutton2.Name = "cmpusrbutton2";
            this.cmpusrbutton2.Size = new System.Drawing.Size(180, 130);
            this.cmpusrbutton2.TabIndex = 4;
            this.cmpusrbutton2.UseVisualStyleBackColor = true;
            this.cmpusrbutton2.Click += new System.EventHandler(this.button9_Click);
            // 
            // sec1box
            // 
            this.sec1box.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sec1box.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.sec1box.Controls.Add(this.secim13button);
            this.sec1box.Controls.Add(this.secim12button);
            this.sec1box.Controls.Add(this.secim11button);
            this.sec1box.Location = new System.Drawing.Point(9, 0);
            this.sec1box.Name = "sec1box";
            this.sec1box.Size = new System.Drawing.Size(125, 97);
            this.sec1box.TabIndex = 5;
            this.sec1box.TabStop = false;
            // 
            // secim13button
            // 
            this.secim13button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim13button.Location = new System.Drawing.Point(0, 64);
            this.secim13button.Name = "secim13button";
            this.secim13button.Size = new System.Drawing.Size(119, 29);
            this.secim13button.TabIndex = 2;
            this.secim13button.Text = "scissor";
            this.secim13button.UseVisualStyleBackColor = true;
            this.secim13button.Click += new System.EventHandler(this.secim13button_Click);
            // 
            // secim12button
            // 
            this.secim12button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim12button.Location = new System.Drawing.Point(0, 38);
            this.secim12button.Name = "secim12button";
            this.secim12button.Size = new System.Drawing.Size(119, 25);
            this.secim12button.TabIndex = 1;
            this.secim12button.Text = "paper";
            this.secim12button.UseVisualStyleBackColor = true;
            this.secim12button.Click += new System.EventHandler(this.secim12button_Click);
            // 
            // secim11button
            // 
            this.secim11button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim11button.Location = new System.Drawing.Point(0, 9);
            this.secim11button.Name = "secim11button";
            this.secim11button.Size = new System.Drawing.Size(119, 30);
            this.secim11button.TabIndex = 0;
            this.secim11button.Text = "rock";
            this.secim11button.UseVisualStyleBackColor = true;
            this.secim11button.Click += new System.EventHandler(this.button13_Click);
            // 
            // sec2box
            // 
            this.sec2box.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sec2box.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.sec2box.Controls.Add(this.secim23button);
            this.sec2box.Controls.Add(this.secim22button);
            this.sec2box.Controls.Add(this.secim21button);
            this.sec2box.Location = new System.Drawing.Point(202, 0);
            this.sec2box.Name = "sec2box";
            this.sec2box.Size = new System.Drawing.Size(122, 97);
            this.sec2box.TabIndex = 6;
            this.sec2box.TabStop = false;
            // 
            // secim23button
            // 
            this.secim23button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim23button.Location = new System.Drawing.Point(0, 66);
            this.secim23button.Name = "secim23button";
            this.secim23button.Size = new System.Drawing.Size(119, 29);
            this.secim23button.TabIndex = 2;
            this.secim23button.Text = "scissor";
            this.secim23button.UseVisualStyleBackColor = true;
            this.secim23button.Click += new System.EventHandler(this.secim23button_Click);
            // 
            // secim22button
            // 
            this.secim22button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim22button.Location = new System.Drawing.Point(0, 34);
            this.secim22button.Name = "secim22button";
            this.secim22button.Size = new System.Drawing.Size(119, 32);
            this.secim22button.TabIndex = 1;
            this.secim22button.Text = "paper";
            this.secim22button.UseVisualStyleBackColor = true;
            this.secim22button.Click += new System.EventHandler(this.secim22button_Click);
            // 
            // secim21button
            // 
            this.secim21button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim21button.Location = new System.Drawing.Point(0, 9);
            this.secim21button.Name = "secim21button";
            this.secim21button.Size = new System.Drawing.Size(119, 25);
            this.secim21button.TabIndex = 0;
            this.secim21button.Text = "rock";
            this.secim21button.UseVisualStyleBackColor = true;
            this.secim21button.Click += new System.EventHandler(this.secim21button_Click);
            // 
            // sec3box
            // 
            this.sec3box.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sec3box.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.sec3box.Controls.Add(this.secim33button);
            this.sec3box.Controls.Add(this.secim32button);
            this.sec3box.Controls.Add(this.secim31button);
            this.sec3box.Location = new System.Drawing.Point(398, 0);
            this.sec3box.Name = "sec3box";
            this.sec3box.Size = new System.Drawing.Size(126, 97);
            this.sec3box.TabIndex = 7;
            this.sec3box.TabStop = false;
            // 
            // secim33button
            // 
            this.secim33button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim33button.Location = new System.Drawing.Point(0, 65);
            this.secim33button.Name = "secim33button";
            this.secim33button.Size = new System.Drawing.Size(119, 29);
            this.secim33button.TabIndex = 2;
            this.secim33button.Text = "scissor";
            this.secim33button.UseVisualStyleBackColor = true;
            this.secim33button.Click += new System.EventHandler(this.secim33button_Click);
            // 
            // secim32button
            // 
            this.secim32button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim32button.Location = new System.Drawing.Point(0, 38);
            this.secim32button.Name = "secim32button";
            this.secim32button.Size = new System.Drawing.Size(119, 28);
            this.secim32button.TabIndex = 1;
            this.secim32button.Text = "paper";
            this.secim32button.UseVisualStyleBackColor = true;
            this.secim32button.Click += new System.EventHandler(this.button20_Click);
            // 
            // secim31button
            // 
            this.secim31button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim31button.Location = new System.Drawing.Point(0, 9);
            this.secim31button.Name = "secim31button";
            this.secim31button.Size = new System.Drawing.Size(119, 30);
            this.secim31button.TabIndex = 0;
            this.secim31button.Text = "rock";
            this.secim31button.UseVisualStyleBackColor = true;
            this.secim31button.Click += new System.EventHandler(this.secim31button_Click);
            // 
            // secimyapbox
            // 
            this.secimyapbox.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.secimyapbox.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.secimyapbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.secimyapbox.Controls.Add(this.done);
            this.secimyapbox.Controls.Add(this.sec5box);
            this.secimyapbox.Controls.Add(this.sec4box);
            this.secimyapbox.Controls.Add(this.sec3box);
            this.secimyapbox.Controls.Add(this.sec1box);
            this.secimyapbox.Controls.Add(this.sec2box);
            this.secimyapbox.Location = new System.Drawing.Point(187, 509);
            this.secimyapbox.Name = "secimyapbox";
            this.secimyapbox.Size = new System.Drawing.Size(975, 97);
            this.secimyapbox.TabIndex = 3;
            this.secimyapbox.TabStop = false;
            this.secimyapbox.Visible = false;
            // 
            // done
            // 
            this.done.BackColor = System.Drawing.Color.Brown;
            this.done.Font = new System.Drawing.Font("ArcadeClassic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.done.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.done.Location = new System.Drawing.Point(917, 61);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(52, 26);
            this.done.TabIndex = 10;
            this.done.Text = "done";
            this.done.UseVisualStyleBackColor = false;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // sec5box
            // 
            this.sec5box.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sec5box.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.sec5box.Controls.Add(this.secim53button);
            this.sec5box.Controls.Add(this.secim52button);
            this.sec5box.Controls.Add(this.secim51button);
            this.sec5box.Location = new System.Drawing.Point(789, 0);
            this.sec5box.Name = "sec5box";
            this.sec5box.Size = new System.Drawing.Size(127, 97);
            this.sec5box.TabIndex = 9;
            this.sec5box.TabStop = false;
            // 
            // secim53button
            // 
            this.secim53button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim53button.Location = new System.Drawing.Point(0, 66);
            this.secim53button.Name = "secim53button";
            this.secim53button.Size = new System.Drawing.Size(119, 27);
            this.secim53button.TabIndex = 2;
            this.secim53button.Text = "scissor";
            this.secim53button.UseVisualStyleBackColor = true;
            this.secim53button.Click += new System.EventHandler(this.secim53button_Click);
            // 
            // secim52button
            // 
            this.secim52button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim52button.Location = new System.Drawing.Point(0, 38);
            this.secim52button.Name = "secim52button";
            this.secim52button.Size = new System.Drawing.Size(119, 28);
            this.secim52button.TabIndex = 1;
            this.secim52button.Text = "paper";
            this.secim52button.UseVisualStyleBackColor = true;
            this.secim52button.Click += new System.EventHandler(this.secim52button_Click);
            // 
            // secim51button
            // 
            this.secim51button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim51button.Location = new System.Drawing.Point(0, 9);
            this.secim51button.Name = "secim51button";
            this.secim51button.Size = new System.Drawing.Size(119, 30);
            this.secim51button.TabIndex = 0;
            this.secim51button.Text = "rock";
            this.secim51button.UseVisualStyleBackColor = true;
            this.secim51button.Click += new System.EventHandler(this.secim51button_Click);
            // 
            // sec4box
            // 
            this.sec4box.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.sec4box.BackgroundImage = global::again.Properties.Resources.pvcbackground;
            this.sec4box.Controls.Add(this.secim43button);
            this.sec4box.Controls.Add(this.secim42button);
            this.sec4box.Controls.Add(this.secim41button);
            this.sec4box.Location = new System.Drawing.Point(593, 0);
            this.sec4box.Name = "sec4box";
            this.sec4box.Size = new System.Drawing.Size(128, 97);
            this.sec4box.TabIndex = 8;
            this.sec4box.TabStop = false;
            // 
            // secim43button
            // 
            this.secim43button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim43button.Location = new System.Drawing.Point(0, 66);
            this.secim43button.Name = "secim43button";
            this.secim43button.Size = new System.Drawing.Size(119, 31);
            this.secim43button.TabIndex = 2;
            this.secim43button.Text = "scissor";
            this.secim43button.UseVisualStyleBackColor = true;
            this.secim43button.Click += new System.EventHandler(this.secim43button_Click);
            // 
            // secim42button
            // 
            this.secim42button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim42button.Location = new System.Drawing.Point(0, 38);
            this.secim42button.Name = "secim42button";
            this.secim42button.Size = new System.Drawing.Size(119, 28);
            this.secim42button.TabIndex = 1;
            this.secim42button.Text = "paper";
            this.secim42button.UseVisualStyleBackColor = true;
            this.secim42button.Click += new System.EventHandler(this.secim42button_Click);
            // 
            // secim41button
            // 
            this.secim41button.Font = new System.Drawing.Font("ArcadeClassic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secim41button.Location = new System.Drawing.Point(0, 9);
            this.secim41button.Name = "secim41button";
            this.secim41button.Size = new System.Drawing.Size(119, 30);
            this.secim41button.TabIndex = 0;
            this.secim41button.Text = "rock";
            this.secim41button.UseVisualStyleBackColor = true;
            this.secim41button.Click += new System.EventHandler(this.secim41button_Click);
            // 
            // playerinputs
            // 
            this.playerinputs.BackgroundImage = global::again.Properties.Resources.userbackground;
            this.playerinputs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerinputs.Controls.Add(this.button1);
            this.playerinputs.Controls.Add(this.playernametextbox);
            this.playerinputs.Controls.Add(this.playername);
            this.playerinputs.Controls.Add(this.playerIDtextbox);
            this.playerinputs.Controls.Add(this.playerIDlabel);
            this.playerinputs.Location = new System.Drawing.Point(12, 393);
            this.playerinputs.Name = "playerinputs";
            this.playerinputs.Size = new System.Drawing.Size(327, 203);
            this.playerinputs.TabIndex = 4;
            this.playerinputs.TabStop = false;
            this.playerinputs.UseWaitCursor = true;
            this.playerinputs.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("ArcadeClassic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(244, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "done";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.UseWaitCursor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playernametextbox
            // 
            this.playernametextbox.BackColor = System.Drawing.Color.LemonChiffon;
            this.playernametextbox.Font = new System.Drawing.Font("ArcadeClassic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playernametextbox.Location = new System.Drawing.Point(150, 99);
            this.playernametextbox.Name = "playernametextbox";
            this.playernametextbox.Size = new System.Drawing.Size(171, 33);
            this.playernametextbox.TabIndex = 5;
            this.playernametextbox.UseWaitCursor = true;
            // 
            // playername
            // 
            this.playername.AutoSize = true;
            this.playername.Font = new System.Drawing.Font("ArcadeClassic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playername.Location = new System.Drawing.Point(1, 105);
            this.playername.Name = "playername";
            this.playername.Size = new System.Drawing.Size(143, 23);
            this.playername.TabIndex = 5;
            this.playername.Text = "Player Name";
            this.playername.UseWaitCursor = true;
            // 
            // playerIDtextbox
            // 
            this.playerIDtextbox.BackColor = System.Drawing.Color.LemonChiffon;
            this.playerIDtextbox.Font = new System.Drawing.Font("ArcadeClassic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerIDtextbox.Location = new System.Drawing.Point(141, 45);
            this.playerIDtextbox.Name = "playerIDtextbox";
            this.playerIDtextbox.Size = new System.Drawing.Size(171, 29);
            this.playerIDtextbox.TabIndex = 5;
            this.playerIDtextbox.Text = "2102010";
            this.playerIDtextbox.UseWaitCursor = true;
            // 
            // playerIDlabel
            // 
            this.playerIDlabel.AutoSize = true;
            this.playerIDlabel.BackColor = System.Drawing.Color.LemonChiffon;
            this.playerIDlabel.Font = new System.Drawing.Font("ArcadeClassic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerIDlabel.Location = new System.Drawing.Point(6, 45);
            this.playerIDlabel.Name = "playerIDlabel";
            this.playerIDlabel.Size = new System.Drawing.Size(127, 25);
            this.playerIDlabel.TabIndex = 5;
            this.playerIDlabel.Text = "Player ID";
            this.playerIDlabel.UseWaitCursor = true;
            // 
            // user1scoreboard
            // 
            this.user1scoreboard.BackgroundImage = global::again.Properties.Resources.backgroundmenu2;
            this.user1scoreboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user1scoreboard.Controls.Add(this.scoretext1);
            this.user1scoreboard.Controls.Add(this.user1score);
            this.user1scoreboard.Controls.Add(this.user1ID);
            this.user1scoreboard.Controls.Add(this.user1name);
            this.user1scoreboard.Location = new System.Drawing.Point(1168, 6);
            this.user1scoreboard.Name = "user1scoreboard";
            this.user1scoreboard.Size = new System.Drawing.Size(166, 165);
            this.user1scoreboard.TabIndex = 5;
            this.user1scoreboard.TabStop = false;
            this.user1scoreboard.Visible = false;
            // 
            // scoretext1
            // 
            this.scoretext1.AutoSize = true;
            this.scoretext1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.scoretext1.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoretext1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoretext1.Location = new System.Drawing.Point(11, 126);
            this.scoretext1.Name = "scoretext1";
            this.scoretext1.Size = new System.Drawing.Size(87, 27);
            this.scoretext1.TabIndex = 3;
            this.scoretext1.Text = "score";
            // 
            // user1score
            // 
            this.user1score.AutoSize = true;
            this.user1score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.user1score.Font = new System.Drawing.Font("ArcadeClassic", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user1score.ForeColor = System.Drawing.Color.Yellow;
            this.user1score.Location = new System.Drawing.Point(104, 114);
            this.user1score.Name = "user1score";
            this.user1score.Size = new System.Drawing.Size(41, 42);
            this.user1score.TabIndex = 2;
            this.user1score.Text = "0";
            // 
            // user1ID
            // 
            this.user1ID.AutoSize = true;
            this.user1ID.BackColor = System.Drawing.Color.Purple;
            this.user1ID.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user1ID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.user1ID.Location = new System.Drawing.Point(11, 73);
            this.user1ID.Name = "user1ID";
            this.user1ID.Size = new System.Drawing.Size(72, 27);
            this.user1ID.TabIndex = 1;
            this.user1ID.Text = "none";
            // 
            // user1name
            // 
            this.user1name.AutoSize = true;
            this.user1name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.user1name.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user1name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.user1name.Location = new System.Drawing.Point(11, 23);
            this.user1name.Name = "user1name";
            this.user1name.Size = new System.Drawing.Size(72, 27);
            this.user1name.TabIndex = 0;
            this.user1name.Text = "none";
            // 
            // user2scoreboard
            // 
            this.user2scoreboard.BackgroundImage = global::again.Properties.Resources.userbackground;
            this.user2scoreboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user2scoreboard.Controls.Add(this.score2text);
            this.user2scoreboard.Controls.Add(this.user2score);
            this.user2scoreboard.Controls.Add(this.user2ID);
            this.user2scoreboard.Controls.Add(this.user2name);
            this.user2scoreboard.Location = new System.Drawing.Point(12, 612);
            this.user2scoreboard.Name = "user2scoreboard";
            this.user2scoreboard.Size = new System.Drawing.Size(166, 165);
            this.user2scoreboard.TabIndex = 6;
            this.user2scoreboard.TabStop = false;
            this.user2scoreboard.Visible = false;
            // 
            // score2text
            // 
            this.score2text.AutoSize = true;
            this.score2text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.score2text.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.score2text.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.score2text.Location = new System.Drawing.Point(10, 122);
            this.score2text.Name = "score2text";
            this.score2text.Size = new System.Drawing.Size(87, 27);
            this.score2text.TabIndex = 3;
            this.score2text.Text = "score";
            // 
            // user2score
            // 
            this.user2score.AutoSize = true;
            this.user2score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.user2score.Font = new System.Drawing.Font("ArcadeClassic", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user2score.ForeColor = System.Drawing.Color.Yellow;
            this.user2score.Location = new System.Drawing.Point(103, 110);
            this.user2score.Name = "user2score";
            this.user2score.Size = new System.Drawing.Size(41, 42);
            this.user2score.TabIndex = 2;
            this.user2score.Text = "0";
            // 
            // user2ID
            // 
            this.user2ID.AutoSize = true;
            this.user2ID.BackColor = System.Drawing.Color.Olive;
            this.user2ID.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user2ID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.user2ID.Location = new System.Drawing.Point(10, 74);
            this.user2ID.Name = "user2ID";
            this.user2ID.Size = new System.Drawing.Size(72, 27);
            this.user2ID.TabIndex = 1;
            this.user2ID.Text = "none";
            // 
            // user2name
            // 
            this.user2name.AutoSize = true;
            this.user2name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.user2name.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user2name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.user2name.Location = new System.Drawing.Point(10, 23);
            this.user2name.Name = "user2name";
            this.user2name.Size = new System.Drawing.Size(72, 27);
            this.user2name.TabIndex = 0;
            this.user2name.Text = "none";
            // 
            // vsmenu
            // 
            this.vsmenu.BackColor = System.Drawing.Color.Orange;
            this.vsmenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vsmenu.BackgroundImage")));
            this.vsmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vsmenu.Controls.Add(this.rounds);
            this.vsmenu.Controls.Add(this.tickbutton);
            this.vsmenu.Controls.Add(this.healthdata2);
            this.vsmenu.Controls.Add(this.healthdata1);
            this.vsmenu.Controls.Add(this.damagedata1);
            this.vsmenu.Controls.Add(this.damagedata2);
            this.vsmenu.Controls.Add(this.healthtext2);
            this.vsmenu.Controls.Add(this.healthtext1);
            this.vsmenu.Controls.Add(this.damagetext2);
            this.vsmenu.Controls.Add(this.damagetext1);
            this.vsmenu.Controls.Add(this.vstext);
            this.vsmenu.Controls.Add(this.compusr2picturebox);
            this.vsmenu.Controls.Add(this.comp1picturebox);
            this.vsmenu.Location = new System.Drawing.Point(44, 174);
            this.vsmenu.Name = "vsmenu";
            this.vsmenu.Size = new System.Drawing.Size(1269, 321);
            this.vsmenu.TabIndex = 7;
            this.vsmenu.TabStop = false;
            this.vsmenu.Visible = false;
            // 
            // rounds
            // 
            this.rounds.AutoSize = true;
            this.rounds.BackColor = System.Drawing.Color.Purple;
            this.rounds.Font = new System.Drawing.Font("ArcadeClassic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rounds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rounds.Location = new System.Drawing.Point(571, 277);
            this.rounds.Name = "rounds";
            this.rounds.Size = new System.Drawing.Size(116, 28);
            this.rounds.TabIndex = 11;
            this.rounds.Text = "round : 0";
            // 
            // tickbutton
            // 
            this.tickbutton.BackgroundImage = global::again.Properties.Resources.tick;
            this.tickbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tickbutton.Location = new System.Drawing.Point(15, 238);
            this.tickbutton.Name = "tickbutton";
            this.tickbutton.Size = new System.Drawing.Size(70, 70);
            this.tickbutton.TabIndex = 8;
            this.tickbutton.UseVisualStyleBackColor = true;
            this.tickbutton.Visible = false;
            this.tickbutton.Click += new System.EventHandler(this.tickbutton_Click);
            // 
            // healthdata2
            // 
            this.healthdata2.AutoSize = true;
            this.healthdata2.BackColor = System.Drawing.Color.Snow;
            this.healthdata2.Font = new System.Drawing.Font("ArcadeClassic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.healthdata2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.healthdata2.Location = new System.Drawing.Point(867, 238);
            this.healthdata2.Name = "healthdata2";
            this.healthdata2.Size = new System.Drawing.Size(106, 37);
            this.healthdata2.TabIndex = 10;
            this.healthdata2.Text = "00,00";
            // 
            // healthdata1
            // 
            this.healthdata1.AutoSize = true;
            this.healthdata1.BackColor = System.Drawing.Color.Snow;
            this.healthdata1.Font = new System.Drawing.Font("ArcadeClassic", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.healthdata1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.healthdata1.Location = new System.Drawing.Point(311, 238);
            this.healthdata1.Name = "healthdata1";
            this.healthdata1.Size = new System.Drawing.Size(106, 37);
            this.healthdata1.TabIndex = 9;
            this.healthdata1.Text = "00,00";
            // 
            // damagedata1
            // 
            this.damagedata1.AutoSize = true;
            this.damagedata1.BackColor = System.Drawing.Color.Snow;
            this.damagedata1.Font = new System.Drawing.Font("ArcadeClassic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.damagedata1.ForeColor = System.Drawing.Color.Red;
            this.damagedata1.Location = new System.Drawing.Point(311, 101);
            this.damagedata1.Name = "damagedata1";
            this.damagedata1.Size = new System.Drawing.Size(101, 43);
            this.damagedata1.TabIndex = 8;
            this.damagedata1.Text = "0,00";
            // 
            // damagedata2
            // 
            this.damagedata2.AutoSize = true;
            this.damagedata2.BackColor = System.Drawing.Color.Snow;
            this.damagedata2.Font = new System.Drawing.Font("ArcadeClassic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.damagedata2.ForeColor = System.Drawing.Color.Red;
            this.damagedata2.Location = new System.Drawing.Point(872, 110);
            this.damagedata2.Name = "damagedata2";
            this.damagedata2.Size = new System.Drawing.Size(101, 43);
            this.damagedata2.TabIndex = 7;
            this.damagedata2.Text = "0,00";
            // 
            // healthtext2
            // 
            this.healthtext2.AutoSize = true;
            this.healthtext2.BackColor = System.Drawing.Color.DarkOrange;
            this.healthtext2.Font = new System.Drawing.Font("ArcadeClassic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.healthtext2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.healthtext2.Location = new System.Drawing.Point(310, 195);
            this.healthtext2.Name = "healthtext2";
            this.healthtext2.Size = new System.Drawing.Size(102, 28);
            this.healthtext2.TabIndex = 6;
            this.healthtext2.Text = "health";
            // 
            // healthtext1
            // 
            this.healthtext1.AutoSize = true;
            this.healthtext1.BackColor = System.Drawing.Color.DarkOrange;
            this.healthtext1.Font = new System.Drawing.Font("ArcadeClassic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.healthtext1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.healthtext1.Location = new System.Drawing.Point(871, 196);
            this.healthtext1.Name = "healthtext1";
            this.healthtext1.Size = new System.Drawing.Size(102, 27);
            this.healthtext1.TabIndex = 5;
            this.healthtext1.Text = "health";
            // 
            // damagetext2
            // 
            this.damagetext2.AutoSize = true;
            this.damagetext2.BackColor = System.Drawing.Color.DarkOrange;
            this.damagetext2.Font = new System.Drawing.Font("ArcadeClassic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.damagetext2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.damagetext2.Location = new System.Drawing.Point(871, 61);
            this.damagetext2.Name = "damagetext2";
            this.damagetext2.Size = new System.Drawing.Size(102, 28);
            this.damagetext2.TabIndex = 4;
            this.damagetext2.Text = "damage";
            // 
            // damagetext1
            // 
            this.damagetext1.AutoSize = true;
            this.damagetext1.BackColor = System.Drawing.Color.DarkOrange;
            this.damagetext1.Font = new System.Drawing.Font("ArcadeClassic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.damagetext1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.damagetext1.Location = new System.Drawing.Point(311, 61);
            this.damagetext1.Name = "damagetext1";
            this.damagetext1.Size = new System.Drawing.Size(102, 28);
            this.damagetext1.TabIndex = 3;
            this.damagetext1.Text = "damage";
            // 
            // vstext
            // 
            this.vstext.AutoSize = true;
            this.vstext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.vstext.Font = new System.Drawing.Font("ArcadeClassic", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vstext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vstext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.vstext.Location = new System.Drawing.Point(526, 110);
            this.vstext.Name = "vstext";
            this.vstext.Size = new System.Drawing.Size(203, 132);
            this.vstext.TabIndex = 2;
            this.vstext.Text = "vs";
            // 
            // compusr2picturebox
            // 
            this.compusr2picturebox.BackColor = System.Drawing.Color.DarkOrange;
            this.compusr2picturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.compusr2picturebox.Location = new System.Drawing.Point(990, 61);
            this.compusr2picturebox.Name = "compusr2picturebox";
            this.compusr2picturebox.Size = new System.Drawing.Size(240, 214);
            this.compusr2picturebox.TabIndex = 1;
            this.compusr2picturebox.TabStop = false;
            // 
            // comp1picturebox
            // 
            this.comp1picturebox.BackColor = System.Drawing.Color.DarkOrange;
            this.comp1picturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comp1picturebox.Location = new System.Drawing.Point(61, 61);
            this.comp1picturebox.Name = "comp1picturebox";
            this.comp1picturebox.Size = new System.Drawing.Size(236, 214);
            this.comp1picturebox.TabIndex = 0;
            this.comp1picturebox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // next_game_menu
            // 
            this.next_game_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.next_game_menu.Controls.Add(this.exit);
            this.next_game_menu.Controls.Add(this.playagain);
            this.next_game_menu.Controls.Add(this.scores);
            this.next_game_menu.Controls.Add(this.winner);
            this.next_game_menu.Location = new System.Drawing.Point(73, 226);
            this.next_game_menu.Name = "next_game_menu";
            this.next_game_menu.Size = new System.Drawing.Size(1174, 357);
            this.next_game_menu.TabIndex = 8;
            this.next_game_menu.TabStop = false;
            this.next_game_menu.Visible = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exit.Font = new System.Drawing.Font("ArcadeClassic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit.Location = new System.Drawing.Point(974, 259);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(167, 73);
            this.exit.TabIndex = 3;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // playagain
            // 
            this.playagain.BackColor = System.Drawing.Color.YellowGreen;
            this.playagain.Font = new System.Drawing.Font("ArcadeClassic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playagain.Location = new System.Drawing.Point(32, 262);
            this.playagain.Name = "playagain";
            this.playagain.Size = new System.Drawing.Size(297, 73);
            this.playagain.TabIndex = 2;
            this.playagain.Text = "play again";
            this.playagain.UseVisualStyleBackColor = false;
            this.playagain.Click += new System.EventHandler(this.playagain_Click);
            // 
            // scores
            // 
            this.scores.AutoSize = true;
            this.scores.BackColor = System.Drawing.Color.Gold;
            this.scores.Font = new System.Drawing.Font("ArcadeClassic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scores.Location = new System.Drawing.Point(258, 167);
            this.scores.Name = "scores";
            this.scores.Size = new System.Drawing.Size(568, 47);
            this.scores.TabIndex = 1;
            this.scores.Text = " player1 : 00  - player2 : 00";
            // 
            // winner
            // 
            this.winner.AutoSize = true;
            this.winner.BackColor = System.Drawing.Color.Yellow;
            this.winner.Font = new System.Drawing.Font("ArcadeClassic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winner.Location = new System.Drawing.Point(153, 49);
            this.winner.Name = "winner";
            this.winner.Size = new System.Drawing.Size(654, 80);
            this.winner.TabIndex = 0;
            this.winner.Text = "winner is : xxxxx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImage = global::again.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 785);
            this.Controls.Add(this.next_game_menu);
            this.Controls.Add(this.vsmenu);
            this.Controls.Add(this.user2scoreboard);
            this.Controls.Add(this.user1scoreboard);
            this.Controls.Add(this.playerinputs);
            this.Controls.Add(this.secimyapbox);
            this.Controls.Add(this.comp_user_deck);
            this.Controls.Add(this.computerdeck);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.computerdeck.ResumeLayout(false);
            this.comp_user_deck.ResumeLayout(false);
            this.sec1box.ResumeLayout(false);
            this.sec2box.ResumeLayout(false);
            this.sec3box.ResumeLayout(false);
            this.secimyapbox.ResumeLayout(false);
            this.sec5box.ResumeLayout(false);
            this.sec4box.ResumeLayout(false);
            this.playerinputs.ResumeLayout(false);
            this.playerinputs.PerformLayout();
            this.user1scoreboard.ResumeLayout(false);
            this.user1scoreboard.PerformLayout();
            this.user2scoreboard.ResumeLayout(false);
            this.user2scoreboard.PerformLayout();
            this.vsmenu.ResumeLayout(false);
            this.vsmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compusr2picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comp1picturebox)).EndInit();
            this.next_game_menu.ResumeLayout(false);
            this.next_game_menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button cvcbutton;
        private Button pvcbutton;
        private GroupBox computerdeck;
        private Button compbutton5;
        private Button compbutton4;
        private Button compbutton3;
        private Button compbutton2;
        private Button compbutton1;
        private GroupBox comp_user_deck;
        private Button cmpusrbutton5;
        private Button cmpusrbutton4;
        private Button cmpusrbutton3;
        private Button cmpusrbutton2;
        private Button cmpusrbutton1;
        public Label label1;
        private GroupBox sec1box;
        private Button secim11button;
        private GroupBox secimyapbox;
        private GroupBox sec3box;
        private Button secim33button;
        private Button secim32button;
        private Button secim31button;
        private GroupBox sec2box;
        private Button secim23button;
        private Button secim22button;
        private Button secim21button;
        private Button secim13button;
        private Button secim12button;
        private GroupBox sec5box;
        private Button secim53button;
        private Button secim52button;
        private Button secim51button;
        private GroupBox sec4box;
        private Button secim43button;
        private Button secim42button;
        private Button secim41button;
        private Button done;
        private GroupBox playerinputs;
        private Label playerIDlabel;
        private TextBox playerIDtextbox;
        private TextBox playernametextbox;
        private Label playername;
        private Button button1;
        private GroupBox user1scoreboard;
        private Label scoretext1;
        private Label user1score;
        private Label user1ID;
        private Label user1name;
        private GroupBox user2scoreboard;
        private Label score2text;
        private Label user2score;
        private Label user2ID;
        private Label user2name;
        private GroupBox vsmenu;
        private PictureBox compusr2picturebox;
        private PictureBox comp1picturebox;
        private Label vstext;
        private Label health2;
        private Label health1;
        private Label damagetext2;
        private Label damagetext1;
        private Label damage1;
        private Label damage2;
        private Label healthdata2;
        private Label healthdata1;
        private Label healthtext2;
        private Label healthtext1;
        private Label damagedata1;
        private Label damagedata2;
        private System.Windows.Forms.Timer timer1;
        private Button tickbutton;
        private Label rounds;
        private GroupBox next_game_menu;
        private Button exit;
        private Button playagain;
        private Label scores;
        private Label winner;
    }
}