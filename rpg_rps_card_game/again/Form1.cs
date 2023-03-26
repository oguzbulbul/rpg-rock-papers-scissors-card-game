
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text.RegularExpressions;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Timer = System.Windows.Forms.Timer;




namespace again
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pvcbutton_Click(object sender, EventArgs e) // player vs computer
        {
            player2.whichone = 0; // nesneSec if(whichone == 0) create comp's deck 
            player2.nesneSec(-1,'N');
            player1.whichone = 1;

            pvcbutton.Click += pvcbutton_Click;
            groupBox1.Visible = false;
            computerdeck.Visible = false;
            comp_user_deck.Visible = false;
            secimyapbox.Visible = false;
            playerinputs.Visible = true;
            

            //comp deck
            pvcbuttonlist1[0] = compbutton1;
            pvcbuttonlist1[1] = compbutton2;
            pvcbuttonlist1[2] = compbutton3;
            pvcbuttonlist1[3] = compbutton4;
            pvcbuttonlist1[4] = compbutton5;
            
            int i;

            for (i = 0; i < 5; i++)
            {
                if (player2.deste1[i].taslar != null)
                {
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.tas;
                }
                else if (player2.deste1[i].kagitlar != null)
                {
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.kagit;
                }
                else if (player2.deste1[i].makaslar != null)
                {
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.makas;
                }
            }
            /*
            String computerChoice;
            String[] rps = { "R", "P", "S" };
            int i;
            //Nesne[] nesneler1 = new Nesne[5];
            Random random = new Random();


            for (i = 0; i < 5; i++)
            {
                int randint = random.Next(3);
                computerChoice = rps[randint];
                if (computerChoice.Equals("R"))
                {
                    System.Console.WriteLine("computer's Choice is Rock");
                    //nesneler1[i] = new tasSinifi(20, 0);
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.tas;
                    player2.deste1[i].taslar = new tasSinifi(20, 0);
                    player2.deste1[i].kagitlar = null;
                    player2.deste1[i].makaslar = null;

                }
                if (computerChoice.Equals("P"))
                {
                    System.Console.WriteLine("computer's Choice is Paper");
                    //nesneler1[i] = new kagitSinifi(20, 0);
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.kagit;
                    player2.deste1[i].taslar = null;
                    player2.deste1[i].kagitlar = new kagitSinifi(20,0);
                    player2.deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("S"))
                {
                    System.Console.WriteLine("computer's Choice is Scissors");
                    //nesneler1[i] = new makasSinifi(20, 0);
                    pvcbuttonlist1[i].Image = global::again.Properties.Resources.makas;
                    player2.deste1[i].taslar = null;
                    player2.deste1[i].kagitlar = null;
                    player2.deste1[i].makaslar = new makasSinifi(20,0);
                }
            }
            */

            //computerdeck.Visible = true;

            // user deck
            pvcbuttonlist2[0] = cmpusrbutton1;
            pvcbuttonlist2[1] = cmpusrbutton2;
            pvcbuttonlist2[2] = cmpusrbutton3;
            pvcbuttonlist2[3] = cmpusrbutton4;
            pvcbuttonlist2[4] = cmpusrbutton5;

        }

        private void cvcbutton_Click(object sender, EventArgs e) // computer vs computer
        {

            player3.whichone = 0; // nesneSec if(whichone == 0) create comp's deck 
            player2.whichone = 0; // nesneSec if(whichone == 0) create comp's deck 
            player3.nesneSec(-1,'N');
            player2.nesneSec(-1,'N');

            cvcbutton.Click += cvcbutton_Click;
            groupBox1.Visible = false;
            computerdeck.Visible = false;
            comp_user_deck.Visible = false;
            secimyapbox.Visible = false;
            Console.WriteLine("uc ssaniye bekledi ins");

            String computerChoice;
            String[] rps = { "R", "P", "S" };
            int i;
            Random random = new Random();

            buttonlist1[0] = compbutton1;
            buttonlist1[1] = compbutton2;
            buttonlist1[2] = compbutton3;
            buttonlist1[3] = compbutton4;
            buttonlist1[4] = compbutton5;

            buttonlist2[0] = cmpusrbutton1;
            buttonlist2[1] = cmpusrbutton2;
            buttonlist2[2] = cmpusrbutton3;
            buttonlist2[3] = cmpusrbutton4;
            buttonlist2[4] = cmpusrbutton5;

            for (i = 0; i < 5; i++)
            {
                if (player3.deste1[i].taslar != null)
                {
                    buttonlist1[i].Image = global::again.Properties.Resources.tas;
                }
                else if (player3.deste1[i].kagitlar != null)
                {
                    buttonlist1[i].Image = global::again.Properties.Resources.kagit;
                }
                else if (player3.deste1[i].makaslar != null)
                {
                    buttonlist1[i].Image = global::again.Properties.Resources.makas;
                }
            }
            for (i = 0; i < 5; i++)
            {
                if (player2.deste1[i].taslar != null)
                {
                    buttonlist2[i].Image = global::again.Properties.Resources.tas;
                }
                else if (player2.deste1[i].kagitlar != null)
                {
                    buttonlist2[i].Image = global::again.Properties.Resources.kagit;
                }
                else if (player2.deste1[i].makaslar != null)
                {
                    buttonlist2[i].Image = global::again.Properties.Resources.makas;
                }
            }

            /*
            for (i = 0; i < 5; i++)
            {
                int randint = random.Next(3);
                computerChoice = rps[randint];
                if (computerChoice.Equals("R"))
                {
                    System.Console.WriteLine("computer's Choice is Rock");
                    buttonlist1[i].Image = global::again.Properties.Resources.tas;
                    player3.deste1[i].taslar = new tasSinifi(HEALTH, 0);
                    player3.deste1[i].kagitlar = null;
                    player3.deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("P"))
                {
                    System.Console.WriteLine("computer's Choice is Paper");
                    buttonlist1[i].Image = global::again.Properties.Resources.kagit;
                    player3.deste1[i].taslar = null;
                    player3.deste1[i].kagitlar = new kagitSinifi(HEALTH, 0);
                    player3.deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("S"))
                {
                    System.Console.WriteLine("computer's Choice is Scissors");
                    buttonlist1[i].Image = global::again.Properties.Resources.makas;
                    player3.deste1[i].taslar = null;
                    player3.deste1[i].kagitlar = null;
                    player3.deste1[i].makaslar = new makasSinifi(HEALTH, 0);
                }
            }
            */

            /*
            for (i = 0; i < 5; i++)
            {
                int randint = random.Next(3);
                computerChoice = rps[randint];
                if (computerChoice.Equals("R"))
                {
                    System.Console.WriteLine("user2 Choice is Rock");
                    //Nesneler[i] = new tasSinifi(20, 0);
                    buttonlist2[i].Image = global::again.Properties.Resources.tas;
                    player2.deste1[i].taslar = new tasSinifi(HEALTH, 0);
                    player2.deste1[i].kagitlar = null;
                    player2.deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("P"))
                {
                    System.Console.WriteLine("user2 Choice is Paper");
                    //Nesneler[i] = new kagitSinifi(20, 0);
                    buttonlist2[i].Image = global::again.Properties.Resources.kagit;
                    player2.deste1[i].taslar = null;
                    player2.deste1[i].kagitlar = new kagitSinifi(HEALTH, 0);
                    player2.deste1[i].makaslar = null;
                }
                if (computerChoice.Equals("S"))
                {
                    System.Console.WriteLine("user2 Choice is Scissors");
                    //Nesneler[i] = new makasSinifi(20, 0);
                    buttonlist2[i].Image = global::again.Properties.Resources.makas;
                    player2.deste1[i].taslar = null;
                    player2.deste1[i].kagitlar = null;
                    player2.deste1[i].makaslar = new makasSinifi(HEALTH, 0);
                }
            }
            */


            //COMBAT SCENE AT TIMER ACTION
            comp_user_deck.Visible = true;
            computerdeck.Visible = true;

            user2name.Text = "computer2";
            user2ID.Text = "000000000";
            user1ID.Text = "000000000";
            user1name.Text = "computer1";
            user1scoreboard.Visible = true;
            user2scoreboard.Visible = true;

            turns.counter = 0;
            timer1.Interval = 3000;
            timer1.Enabled = true;

        }

        private void compbutton1_Click(object sender, EventArgs e) // compbutton1
        {

        }

        private void button4_Click(object sender, EventArgs e) // compbutton2
        {

        }

        private void button5_Click(object sender, EventArgs e) // compbutton3
        {

        }

        private void button6_Click(object sender, EventArgs e) // compbutton4
        {

        }

        private void button7_Click(object sender, EventArgs e) // compbutton5
        {


        }
        private void button8_Click(object sender, EventArgs e) // cmpusrbutton1
        {
            cmpusrbutton1.Click += button8_Click;
            if (player1.deste1[0].taslar != null)
            {
                Console.WriteLine(player1.deste1[0].taslar);
                comp1picturebox.Image = global::again.Properties.Resources.tas;
                float health1 = player1.deste1[0].taslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 0;
                if (player1.deste1[0].taslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.agirtas; }
                if (player1.deste1[0].taslar.dayaniklik <= 0) { cmpusrbutton1.Enabled = false; }
            }
            else if (player1.deste1[0].kagitlar != null)
            {
                Console.WriteLine(player1.deste1[0].kagitlar);
                comp1picturebox.Image = global::again.Properties.Resources.kagit;
                float health1 = player1.deste1[0].kagitlar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 0;
                if (player1.deste1[0].kagitlar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ozelkagit; }
                if (player1.deste1[0].kagitlar.dayaniklik <= 0) { cmpusrbutton1.Enabled = false; }
            }
            else if (player1.deste1[0].makaslar != null)
            {
                Console.WriteLine(player1.deste1[0].makaslar);
                comp1picturebox.Image = global::again.Properties.Resources.makas;
                float health1 = player1.deste1[0].makaslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 0;
                if (player1.deste1[0].makaslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ustamakas; }
                if (player1.deste1[0].makaslar.dayaniklik <= 0) { cmpusrbutton1.Enabled = false; }
            }
            else
            {
                Console.WriteLine("cmpsusrbutton1 is empty !");
            }
            Console.WriteLine(choiceindex);

        }

        private void button9_Click(object sender, EventArgs e) // cmpuserbutton2
        {
            cmpusrbutton2.Click += button9_Click;
            if (player1.deste1[1].taslar != null)
            {
                Console.WriteLine(player1.deste1[1].taslar);
                comp1picturebox.Image = global::again.Properties.Resources.tas;
                float health1 = player1.deste1[1].taslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 1;
                if (player1.deste1[1].taslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.agirtas; }
                if (player1.deste1[1].taslar.dayaniklik <= 0) { cmpusrbutton2.Enabled = false; }

            }
            else if (player1.deste1[1].kagitlar != null)
            {
                Console.WriteLine(player1.deste1[1].kagitlar);
                comp1picturebox.Image = global::again.Properties.Resources.kagit;
                float health1 = player1.deste1[1].kagitlar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 1;
                if (player1.deste1[1].kagitlar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ozelkagit; }
                if (player1.deste1[1].kagitlar.dayaniklik <= 0) { cmpusrbutton2.Enabled = false; }

            }
            else if (player1.deste1[1].makaslar != null)
            {
                Console.WriteLine(player1.deste1[1].makaslar);
                comp1picturebox.Image = global::again.Properties.Resources.makas;
                float health1 = player1.deste1[1].makaslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 1;
                if (player1.deste1[1].makaslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ustamakas; }
                if (player1.deste1[1].makaslar.dayaniklik <= 0) { cmpusrbutton2.Enabled = false; }
            }
            else
            {
                Console.WriteLine("compusrbutton2 is empty !");
            }
            Console.WriteLine(choiceindex);

        }

        private void button10_Click(object sender, EventArgs e) // cmpusrbutton3
        {
            cmpusrbutton3.Click += button10_Click;
            if (player1.deste1[2].taslar != null)
            {
                Console.WriteLine(player1.deste1[2].taslar);
                comp1picturebox.Image = global::again.Properties.Resources.tas;
                float health1 = player1.deste1[2].taslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 2;
                if (player1.deste1[2].taslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.agirtas; }
                if (player1.deste1[2].taslar.dayaniklik <= 0) { cmpusrbutton3.Enabled = false; }

            }
            else if (player1.deste1[2].kagitlar != null)
            {
                Console.WriteLine(player1.deste1[2].kagitlar);
                comp1picturebox.Image = global::again.Properties.Resources.kagit;
                float health1 = player1.deste1[2].kagitlar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 2;
                if (player1.deste1[2].kagitlar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ozelkagit; }
                if (player1.deste1[2].kagitlar.dayaniklik <= 0) { cmpusrbutton3.Enabled = false; }

            }
            else if (player1.deste1[2].makaslar != null)
            {
                Console.WriteLine(player1.deste1[2].makaslar);
                comp1picturebox.Image = global::again.Properties.Resources.makas;
                float health1 = player1.deste1[2].makaslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 2;
                if (player1.deste1[2].makaslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ustamakas; }
                if (player1.deste1[2].makaslar.dayaniklik <= 0) { cmpusrbutton3.Enabled = false; }
            }
            else
            {
                Console.WriteLine("compusrbutton3 is empty !");
            }
            Console.WriteLine(choiceindex);

        }
        private void button11_Click(object sender, EventArgs e) // cmpusrbutton4
        {
            cmpusrbutton4.Click += button11_Click;
            if (player1.deste1[3].taslar != null)
            {
                Console.WriteLine(player1.deste1[3].taslar);
                comp1picturebox.Image = global::again.Properties.Resources.tas;
                float health1 = player1.deste1[3].taslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 3;
                if (player1.deste1[3].taslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.agirtas; }
                if (player1.deste1[3].taslar.dayaniklik <= 0) { cmpusrbutton4.Enabled = false; }

            }
            else if (player1.deste1[3].kagitlar != null)
            {
                Console.WriteLine(player1.deste1[3].kagitlar);
                comp1picturebox.Image = global::again.Properties.Resources.kagit;
                float health1 = player1.deste1[3].kagitlar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 3;
                if (player1.deste1[3].kagitlar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ozelkagit; }
                if (player1.deste1[3].kagitlar.dayaniklik <= 0) { cmpusrbutton4.Enabled = false; }

            }
            else if (player1.deste1[3].makaslar != null)
            {
                Console.WriteLine(player1.deste1[3].makaslar);
                comp1picturebox.Image = global::again.Properties.Resources.makas;
                float health1 = player1.deste1[3].makaslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 3;
                if (player1.deste1[3].makaslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ustamakas; }
                if (player1.deste1[3].makaslar.dayaniklik <= 0) { cmpusrbutton4.Enabled = false; }
            }
            else
            {
                Console.WriteLine("compusrbutton4 is empty !");
            }
            Console.WriteLine(choiceindex);

        }
        private void button12_Click(object sender, EventArgs e) // cmpusrbutton5
        {
            cmpusrbutton5.Click += button12_Click;
            if (player1.deste1[4].taslar != null)
            {
                Console.WriteLine(player1.deste1[4].taslar);
                cmpusrbutton1.Image = global::again.Properties.Resources.tas;
                float health1 = player1.deste1[4].taslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 4;
                if (player1.deste1[4].taslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.agirtas; }
            }
            else if (player1.deste1[4].kagitlar != null)
            {
                Console.WriteLine(player1.deste1[4].kagitlar);
                comp1picturebox.Image = global::again.Properties.Resources.kagit;
                float health1 = player1.deste1[4].kagitlar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 4;
                if (player1.deste1[4].kagitlar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ozelkagit; }
            }
            else if (player1.deste1[4].makaslar != null)
            {
                Console.WriteLine(player1.deste1[4].makaslar);
                comp1picturebox.Image = global::again.Properties.Resources.makas;
                float health1 = player1.deste1[4].makaslar.dayaniklik;
                string health2 = health1.ToString();
                healthdata1.Text = health2;
                choiceindex = 4;
                if (player1.deste1[4].makaslar.seviyePuani > 30) { comp1picturebox.Image = global::again.Properties.Resources.ustamakas; }
            }
            else
            {
                Console.WriteLine("compusrbutton5 is empty !");
            }
            Console.WriteLine(choiceindex);

        }

        // ________________user selecting items by buttons _________________

        private void button13_Click(object sender, EventArgs e)
        {
            secim11button.Click += button13_Click;
            //sec1box.Visible = false;
            cmpusrbutton1.Image = global::again.Properties.Resources.tas;
            player1.nesneSec(0, 'R');
        }

        private void secim12button_Click(object sender, EventArgs e)
        {
            secim12button.Click += secim12button_Click;
            //sec1box.Visible = false;
            cmpusrbutton1.Image = global::again.Properties.Resources.kagit;
            player1.nesneSec(0, 'P');
        }

        private void secim13button_Click(object sender, EventArgs e)
        {
            secim13button.Click += secim13button_Click;
            //sec1box.Visible = false;
            cmpusrbutton1.Image = global::again.Properties.Resources.makas;
            player1.nesneSec(0, 'S');
        }

        private void secim21button_Click(object sender, EventArgs e)
        {
            secim21button.Click += secim21button_Click;
            //sec2box.Visible = false;
            cmpusrbutton2.Image = global::again.Properties.Resources.tas;
            player1.nesneSec(1, 'R');
        }

        private void secim22button_Click(object sender, EventArgs e)
        {
            secim22button.Click += secim22button_Click;
            //sec2box.Visible = false;
            cmpusrbutton2.Image = global::again.Properties.Resources.kagit;
            player1.nesneSec(1, 'P');

        }

        private void secim23button_Click(object sender, EventArgs e)
        {
            secim23button.Click += secim23button_Click;
            //sec2box.Visible = false;
            cmpusrbutton2.Image = global::again.Properties.Resources.makas;
            player1.nesneSec(1, 'S');
        }

        private void secim31button_Click(object sender, EventArgs e)
        {
            secim31button.Click += secim31button_Click;
            //sec3box.Visible = false;
            cmpusrbutton3.Image = global::again.Properties.Resources.tas;
            player1.nesneSec(2, 'R');
        }
        private void button20_Click(object sender, EventArgs e)
        {
            secim32button.Click += button20_Click;
            //sec3box.Visible = false;
            cmpusrbutton3.Image = global::again.Properties.Resources.kagit;
            player1.nesneSec(2, 'P');
        }

        private void secim33button_Click(object sender, EventArgs e)
        {
            secim33button.Click += secim33button_Click;
            //sec3box.Visible = false;
            cmpusrbutton3.Image = global::again.Properties.Resources.makas;
            player1.nesneSec(2, 'S');
        }

        private void secim41button_Click(object sender, EventArgs e)
        {
            secim41button.Click += secim41button_Click;
            //sec4box.Visible = false;
            cmpusrbutton4.Image = global::again.Properties.Resources.tas;
            player1.nesneSec(3, 'R');
        }

        private void secim42button_Click(object sender, EventArgs e)
        {
            secim42button.Click += secim42button_Click;
            //sec4box.Visible = false;
            cmpusrbutton4.Image = global::again.Properties.Resources.kagit;
            player1.nesneSec(3, 'P');
        }

        private void secim43button_Click(object sender, EventArgs e)
        {
            secim43button.Click += secim43button_Click;
            //sec4box.Visible = false;
            cmpusrbutton4.Image = global::again.Properties.Resources.makas;
            player1.nesneSec(3, 'S');
        }

        private void secim51button_Click(object sender, EventArgs e)
        {
            secim51button.Click += secim51button_Click;
            //sec5box.Visible = false;
            cmpusrbutton5.Image = global::again.Properties.Resources.tas;
            player1.nesneSec(4, 'R');
        }

        private void secim52button_Click(object sender, EventArgs e)
        {
            secim52button.Click += secim52button_Click;
            //sec5box.Visible = false;
            cmpusrbutton5.Image = global::again.Properties.Resources.kagit;
            player1.nesneSec(4, 'P');
        }

        private void secim53button_Click(object sender, EventArgs e)
        {
            secim53button.Click += secim53button_Click;
            //sec5box.Visible = false;
            cmpusrbutton5.Image = global::again.Properties.Resources.makas;
            player1.nesneSec(4, 'S');
        }

        private void done_Click(object sender, EventArgs e)
        {
            done.Click += done_Click;
            secimyapbox.Visible = false;
            vsmenu.Visible = true;
            tickbutton.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Click += button1_Click;
            playerinputs.Visible = false;
            secimyapbox.Visible = true;
            comp_user_deck.Visible = true;
            user2name.Text =playernametextbox.Text;
            player1.oyuncuAdi = playernametextbox.Text;
            user2ID.Text = playerIDtextbox.Text;
            //player1.oyuncuID = playerIDtextbox.Text;
            user1ID.Text = "000000000";
            user1name.Text = "computer1";
            user1scoreboard.Visible = true;
            user2scoreboard.Visible = true;
        }


        //________________________________COMPUTER VS COMPUTER SCENE _________________________
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            compbutton1.Visible = true;
            compbutton2.Visible = true;
            compbutton3.Visible = true;
            compbutton4.Visible = true;
            compbutton5.Visible = true;
            //__________________________________________________________________________________
            //while dongusune girsin
            //kosul 1 : hamle sayýsý kadar veya nesneler tukenene kadar
            int p = 0;
            for (p = 0; p < 1; p++)
            {
                float katilik2 = 0f;
                float katilik3 = 0f;
                float nufuz2 = 0f;
                float nufuz3 = 0f;
                float keskinlik2 = 0f;
                float keskinlik3 = 0f;

                float health1 = 0f;
                Random random = new Random();
                int[] elements = { 0, 1, 2, 3, 4 };
                int chos = elements[random.Next(elements.Length)];
                int elementToRemove;
                //elements = elements.Where(val => val != elementToRemove).ToArray();

                if (player2.deste1[chos].taslar != null) // right picturebox
                {
                    Console.WriteLine(player2.deste1[chos].taslar);
                    comp1picturebox.Image = global::again.Properties.Resources.tas;
                    health1 = player2.deste1[chos].taslar.dayaniklik;
                    katilik2 = player2.deste1[chos].taslar.katilik;
                    string health3 = health1.ToString();
                    healthdata1.Text = health3;
                    if (player2.deste1[chos].taslar.seviyePuani > 30) 
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.agirtas; 
                    }
                }
                else if (player2.deste1[chos].kagitlar != null)
                {
                    Console.WriteLine(player2.deste1[chos].kagitlar);
                    comp1picturebox.Image = global::again.Properties.Resources.kagit;
                    health1 = player2.deste1[chos].kagitlar.dayaniklik;
                    nufuz2 = player2.deste1[chos].kagitlar.nufuz;
                    string health3 = health1.ToString();
                    healthdata1.Text = health3;
                    if (player2.deste1[chos].kagitlar.seviyePuani > 30)
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.ozelkagit;
                    }

                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    Console.WriteLine(player2.deste1[chos].makaslar);
                    comp1picturebox.Image = global::again.Properties.Resources.makas;
                    health1 = player2.deste1[chos].makaslar.dayaniklik;
                    keskinlik2 = player2.deste1[chos].makaslar.keskinlik;
                    string health3 = health1.ToString();
                    healthdata1.Text = health3;
                    if (player2.deste1[chos].makaslar.seviyePuani > 30)
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.ustamakas;
                    }
                }
                else
                {
                    Console.WriteLine("yok");
                }

                float health2 = 0f;
                int[] elements1 = { 0, 1, 2, 3, 4 };
                int chos1 = elements1[random.Next(elements1.Length)];
                int elementToRemove1;

                if (player3.deste1[chos1].taslar != null) // left picturebox
                {
                    Console.WriteLine(player3.deste1[chos].taslar);
                    compusr2picturebox.Image = global::again.Properties.Resources.tas;
                    health2 = player3.deste1[chos1].taslar.dayaniklik;
                    katilik3 = player3.deste1[chos1].taslar.katilik;
                    string health4 = health2.ToString();
                    healthdata2.Text = health4;
                    if (player3.deste1[chos1].taslar.seviyePuani > 30)
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.agirtas;
                    }
                }
                else if (player3.deste1[chos1].kagitlar != null)
                {
                    Console.WriteLine(player3.deste1[chos].taslar);
                    compusr2picturebox.Image = global::again.Properties.Resources.kagit;
                    health2 = player3.deste1[chos1].kagitlar.dayaniklik;
                    nufuz3 = player3.deste1[chos1].kagitlar.nufuz;
                    string health4 = health2.ToString();
                    healthdata2.Text = health4;
                    if (player3.deste1[chos1].kagitlar.seviyePuani > 30)
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.ozelkagit;
                    }

                }
                else if (player3.deste1[chos1].makaslar != null)
                {
                    Console.WriteLine(player3.deste1[chos].makaslar);
                    compusr2picturebox.Image = global::again.Properties.Resources.makas;
                    health2 = player3.deste1[chos1].makaslar.dayaniklik;
                    keskinlik3 = player3.deste1[chos1].makaslar.keskinlik;
                    string health4 = health2.ToString();
                    healthdata2.Text = health4;
                    if (player3.deste1[chos1].makaslar.seviyePuani > 30)
                    {
                        comp1picturebox.Image = global::again.Properties.Resources.ustamakas;
                    }

                }
                else
                {
                    Console.WriteLine("yok");
                }
                //____________________________COMBAT____________________________________________________________
                float damage2 = 0f;
                float damage3 = 0f;
                //player 2 is left one
                float sicaklik1 = 1f;
                float kalinlik1 = 1f;
                float hiz1 = 1f;
               
                if (player2.deste1[chos].taslar != null)
                {
                    if (player2.deste1[chos].taslar.seviyePuani > 30) 
                    {
                        buttonlist1[chos].Image = global::again.Properties.Resources.agirtas;
                        player2.deste1[chos].agirtaslar = new agirTasSinifi(player2.deste1[chos].taslar.dayaniklik, 0);
                        sicaklik1 = player2.deste1[chos].agirtaslar.sicaklik;
                    } // seviye atlasýn


                    if (player3.deste1[chos1].taslar != null)
                    {
                        damage2 = 0f;
                        Console.WriteLine(" damage of left is " + damage2);
                    }
                    else if (player3.deste1[chos1].kagitlar != null)
                    {
                        damage2 = player2.deste1[chos].taslar.etkiHesapla(katilik2, nufuz3, 0, sicaklik1, kalinlik1, hiz1);
                        Console.WriteLine(" damage of left is " + damage2);
                    }
                    else if (player3.deste1[chos1].makaslar != null)
                    {
                        damage2 = player2.deste1[chos].taslar.etkiHesapla(katilik2, 0, keskinlik3, sicaklik1, kalinlik1, hiz1);
                        //damage2 = damage2 * 4;
                        //player3.deste1[chos1].makaslar.dayaniklik -= damage2;
                        //player2.deste1[chos].taslar.seviyePuani += 20;
                        leftbottomscore = leftbottomscore + 1;

                        player3.deste1[chos1].makaslar.durumGuncelle(damage2,0);
                        player2.deste1[chos].taslar.durumGuncelle(0, 20);
                        Console.WriteLine("left bottom's current score : " + player3.skor);

                        Console.WriteLine("__ damage of left is " + damage2);
                    }

                    if (player2.deste1[chos].taslar.dayaniklik <= 0)
                    {
                        elementToRemove = chos;
                        elements = elements.Where(val => val != elementToRemove).ToArray();
                        buttonlist2[chos].Image = global::again.Properties.Resources.skull;

                    }

                }
                else if (player2.deste1[chos].kagitlar != null)
                {
                    if (player2.deste1[chos].kagitlar.seviyePuani > 30)
                    {
                        buttonlist1[chos].Image = global::again.Properties.Resources.ozelkagit;
                        player2.deste1[chos].ozelkagitlar = new ozelKagitSinifi(player2.deste1[chos].kagitlar.dayaniklik, 0);
                        kalinlik1 = player2.deste1[chos].ozelkagitlar.kalinlik;
                    } // seviye atlasýn


                    if (player3.deste1[chos1].taslar != null)
                    {
                        damage2 = player2.deste1[chos].kagitlar.etkiHesapla(katilik3, nufuz2, 0, sicaklik1, kalinlik1, hiz1);
                        damage2 = damage2 * 4;

                        //player3.deste1[chos1].taslar.dayaniklik -= damage2;
                        //player2.deste1[chos].kagitlar.seviyePuani += 20;
                        //leftbottomscore = leftbottomscore + 1;

                        player3.deste1[chos1].taslar.durumGuncelle(damage2, 0);
                        player2.deste1[chos].kagitlar.durumGuncelle(0, 20);
                        player2.skor += 1;
                        Console.WriteLine(" damage of left is " + damage2);
                        Console.WriteLine("left bottom's current score : " + player3.skor);

                    }
                    else if (player3.deste1[chos1].kagitlar != null)
                    {
                        damage2 = 0f;
                        Console.WriteLine(" damage of left is " + damage2);
                    }
                    else if (player3.deste1[chos1].makaslar != null)
                    {
                        damage2 = player2.deste1[chos].kagitlar.etkiHesapla(0, nufuz2, keskinlik3, sicaklik1, kalinlik1, hiz1);
                        Console.WriteLine(" damage of left is " + damage2);
                    }

                    if (player2.deste1[chos].kagitlar.dayaniklik <= 0)
                    {
                        elementToRemove = chos;
                        elements = elements.Where(val => val != elementToRemove).ToArray();
                        buttonlist2[chos].Image = global::again.Properties.Resources.skull;

                    }


                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    if (player2.deste1[chos].makaslar.seviyePuani > 30)
                    {
                        buttonlist1[chos].Image = global::again.Properties.Resources.ustamakas;
                        player2.deste1[chos].ustamakaslar = new ustaMakasSinifi(player2.deste1[chos].makaslar.dayaniklik, 0);
                        hiz1 = player2.deste1[chos].ustamakaslar.hiz;
                    } // seviye atlasýn


                    if (player3.deste1[chos1].taslar != null)
                    {
                        damage2 = player2.deste1[chos].makaslar.etkiHesapla(katilik3, 0, keskinlik2, sicaklik1, kalinlik1, hiz1);
                        damage2 = damage2 / 4;
                        Console.WriteLine(" *** damage of player2 is " + damage2);
                    }
                    else if (player3.deste1[chos1].kagitlar != null)
                    {
                        damage2 = player2.deste1[chos].makaslar.etkiHesapla(0, nufuz3, keskinlik2, sicaklik1, kalinlik1, hiz1);
                        damage2 = damage2 * 4;

                        //player3.deste1[chos1].kagitlar.dayaniklik -= damage2;
                        //player2.deste1[chos].makaslar.seviyePuani += 20;
                        leftbottomscore = leftbottomscore + 1;

                        player3.deste1[chos1].kagitlar.durumGuncelle(damage2, 0);
                        player2.deste1[chos].makaslar.durumGuncelle(0, 20);
                        player2.skor += 1;

                        Console.WriteLine(" damage of player2 is " + damage2);
                        Console.WriteLine("left bottom's current score : " + player3.skor);

                    }
                    else if (player3.deste1[chos1].makaslar != null)
                    {
                        damage2 = 0f;
                        Console.WriteLine(" damage of player2 is " + damage2);
                    }

                    if (player2.deste1[chos].makaslar.dayaniklik <= 0)
                    {
                        elementToRemove = chos;
                        elements = elements.Where(val => val != elementToRemove).ToArray();
                        buttonlist2[chos].Image = global::again.Properties.Resources.skull;

                    }
                }


                float sicaklik2 = 1f;
                float kalinlik2 = 1f;
                float hiz2 = 1f;
                if (player3.deste1[chos1].taslar != null)
                {
                    if (player3.deste1[chos1].taslar.seviyePuani > 30)
                    {
                        buttonlist2[chos1].Image = global::again.Properties.Resources.agirtas;
                        player3.deste1[chos1].agirtaslar = new agirTasSinifi(player3.deste1[chos1].taslar.dayaniklik, 0);
                        sicaklik2 = player3.deste1[chos1].agirtaslar.sicaklik;
                    } // seviye atlasýn


                    if (player2.deste1[chos].taslar != null)
                    {
                        damage3 = 0f;
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }
                    else if (player2.deste1[chos].kagitlar != null)
                    {
                        damage3 = player3.deste1[chos1].taslar.etkiHesapla(katilik3, nufuz2, 0, sicaklik2, kalinlik2, hiz2);
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }
                    else if (player2.deste1[chos].makaslar != null)
                    {
                        damage3 = player3.deste1[chos1].taslar.etkiHesapla(katilik3, 0, keskinlik2, sicaklik2, kalinlik2, hiz2);
                        //damage3 = damage3 * 4;

                        //player2.deste1[chos].makaslar.dayaniklik -= damage3;
                        //player3.deste1[chos1].taslar.seviyePuani += 20;
                        righttopscore = righttopscore + 1;

                        player2.deste1[chos].makaslar.durumGuncelle(damage3, 0);
                        player3.deste1[chos1].taslar.durumGuncelle(0,20);
                        player3.skor += 1;

                        Console.WriteLine("** damage of player3 is " + damage3);
                        Console.WriteLine("right top's current score : " + player2.skor);

                    }

                    if (player3.deste1[chos1].taslar.dayaniklik <= 0)
                    {
                        elementToRemove1 = chos1;
                        elements1 = elements1.Where(val => val != elementToRemove1).ToArray();
                        buttonlist1[chos1].Image = global::again.Properties.Resources.skull;

                    }

                }
                else if (player3.deste1[chos1].kagitlar != null)
                {
                    if (player3.deste1[chos1].kagitlar.seviyePuani > 30)
                    {
                        buttonlist2[chos1].Image = global::again.Properties.Resources.ozelkagit;
                        player3.deste1[chos1].ozelkagitlar = new ozelKagitSinifi(player3.deste1[chos1].kagitlar.dayaniklik, 0);
                        kalinlik2 = player3.deste1[chos1].ozelkagitlar.kalinlik;
                    } // seviye atlasýn


                    if (player2.deste1[chos].taslar != null)
                    {
                        damage3 = player3.deste1[chos1].kagitlar.etkiHesapla(katilik2, nufuz3, 0, sicaklik2, kalinlik2, hiz2);
                        damage3 = damage3 * 4;

                        //player2.deste1[chos].taslar.dayaniklik -= damage3;
                        //player3.deste1[chos1].kagitlar.seviyePuani += 20;
                        righttopscore =  righttopscore + 1;

                        player2.deste1[chos].taslar.durumGuncelle(damage3, 0);
                        player3.deste1[chos1].kagitlar.durumGuncelle(0,20);
                        player3.skor += 1;

                        Console.WriteLine(" damage of player3 is " + damage3);
                        Console.WriteLine("right top's current score : " + player2.skor);

                    }
                    else if (player2.deste1[chos].kagitlar != null)
                    {
                        damage3 = 0f;
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }
                    else if (player2.deste1[chos].makaslar != null)
                    {
                        damage3 = player3.deste1[chos1].kagitlar.etkiHesapla(0, nufuz3, keskinlik2, sicaklik2, kalinlik2, hiz2);
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }

                    if (player3.deste1[chos1].kagitlar.dayaniklik <= 0)
                    {
                        elementToRemove1 = chos1;
                        elements1 = elements1.Where(val => val != elementToRemove1).ToArray();
                        buttonlist1[chos1].Image = global::again.Properties.Resources.skull;

                    }
                }
                else if (player3.deste1[chos1].makaslar != null)
                {
                    if (player3.deste1[chos1].makaslar.seviyePuani > 30)
                    {
                        buttonlist2[chos1].Image = global::again.Properties.Resources.ustamakas;
                        player3.deste1[chos1].ustamakaslar = new ustaMakasSinifi(player3.deste1[chos1].makaslar.dayaniklik, 0);
                        hiz2 = player3.deste1[chos1].ustamakaslar.hiz;
                    } // seviye atlasýn


                    if (player2.deste1[chos].taslar != null)
                    {
                        damage3 = player3.deste1[chos1].makaslar.etkiHesapla(katilik2, 0, keskinlik3, sicaklik2, kalinlik2, hiz2);
                        damage3 = damage3 / 4;
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }
                    else if (player2.deste1[chos].kagitlar != null)
                    {
                        damage3 = player3.deste1[chos1].makaslar.etkiHesapla(0, nufuz2, keskinlik3, sicaklik2, kalinlik2, hiz2);
                        damage3 = damage3 * 4;

                        //player2.deste1[chos].kagitlar.dayaniklik -= damage3;
                        //player3.deste1[chos1].makaslar.seviyePuani += 20;
                        righttopscore = righttopscore + 1;

                        player2.deste1[chos].kagitlar.durumGuncelle(damage3, 0);
                        player3.deste1[chos1].makaslar.durumGuncelle(0,20);
                        player3.skor += 1;

                        Console.WriteLine(" damage of player3 is " + damage3);
                        Console.WriteLine("right top's current score : " + player2.skor);

                    }
                    else if (player2.deste1[chos].makaslar != null)
                    {
                        damage3 = 0f;
                        Console.WriteLine(" damage of player3 is " + damage3);
                    }

                    if (player3.deste1[chos1].makaslar.dayaniklik <= 0)
                    {
                        elementToRemove1 = chos1;
                        elements1 = elements1.Where(val => val != elementToRemove1).ToArray();
                        buttonlist1[chos1].Image = global::again.Properties.Resources.skull;

                    }
                }
                

                health1 = health1 - damage3;
                health2 = health2 - damage2;
                
                string health1text = health1.ToString();
                string health2text = health2.ToString();
                string damage2text = damage2.ToString();
                string damage3text = damage3.ToString();
                string score1 = righttopscore.ToString();
                string score2 = leftbottomscore.ToString();
                damagedata2.Text = damage2text;
                damagedata1.Text = damage3text;
                healthdata1.Text = health1text;
                healthdata2.Text = health2text;

                user1score.Text = score1;
                user2score.Text = score2;

                vsmenu.Visible = true;
                turns.counter += 1;
                rounds.Text = "round  : " + turns.counter;

                player3.skor = leftbottomscore;
                player2.skor = righttopscore;
                player3.oyuncuAdi = "computer2";
                player2.oyuncuAdi = "computer1";

                if (righttopscore >= 10 || leftbottomscore >= 10 || turns.counter == TOTALROUND)
                {
                    if (righttopscore >= 10 || righttopscore > leftbottomscore)
                    {
                        Console.WriteLine("user2 (top) won");
                        vsmenu.Visible = false;
                        comp_user_deck.Visible = false;
                        computerdeck.Visible = false;
                        user1scoreboard.Visible = false;
                        user2scoreboard.Visible = false;
                        winner.Text = "winner is " + player2.oyuncuAdi;
                        scores.Text = player3.oyuncuAdi + " : " + player3.skor + " - " + player2.oyuncuAdi + " : " + player2.skor;
                        next_game_menu.BackgroundImage = global::again.Properties.Resources.backgroundmenu2;
                        next_game_menu.Visible = true;
                    }
                    if (leftbottomscore >= 10 || leftbottomscore > righttopscore)
                    {
                        Console.WriteLine("user1 (bottom) won");
                        vsmenu.Visible = false;
                        comp_user_deck.Visible = false;
                        computerdeck.Visible = false;
                        user1scoreboard.Visible = false;
                        user2scoreboard.Visible = false;
                        winner.Text = "winner is " + player3.oyuncuAdi;
                        scores.Text = player3.oyuncuAdi + " : " + player3.skor + " - " + player2.oyuncuAdi + " : " + player2.skor;
                        next_game_menu.BackgroundImage = global::again.Properties.Resources.userbackground;
                        next_game_menu.Visible = true;
                    }
                    timer1.Stop();
                }
            }
        }

        //___________________________USER VS COMPUTER SCENE ______________________________________
        int[] elements = { 0, 1, 2, 3, 4 };

        private void tickbutton_Click(object sender, EventArgs e)
        {
            computerdeck.Visible = true;
            float katilik2 = 0f; // comp
            float katilik3 = 0;         //user
            float nufuz2 = 0f; // comp
            float nufuz3 = 0f;          //user
            float keskinlik2 = 0f; // comp
            float keskinlik3 = 0f;        //user

            float health1 = 0f; // user
            float health2 = 0f; // comp

            Random random = new Random();
            int chos = elements[random.Next(elements.Length)];
            int elementToRemove;

            if (player2.deste1[chos].taslar != null) // right picturebox
            {
                Console.WriteLine(player2.deste1[chos].taslar);
                pvcbuttonlist1[chos].Visible = true;
                compusr2picturebox.Image = global::again.Properties.Resources.tas;
                health1 = player2.deste1[chos].taslar.dayaniklik;
                katilik2 = player2.deste1[chos].taslar.katilik;
                string health3 = health1.ToString();
                healthdata1.Text = health3;
                if (player2.deste1[chos].taslar.seviyePuani > 30)
                {
                    compusr2picturebox.Image = global::again.Properties.Resources.agirtas;
                }
            }
            else if (player2.deste1[chos].kagitlar != null)
            {
                Console.WriteLine(player2.deste1[chos].kagitlar);
                pvcbuttonlist1[chos].Visible = true;
                compusr2picturebox.Image = global::again.Properties.Resources.kagit;
                health1 = player2.deste1[chos].kagitlar.dayaniklik;
                nufuz2 = player2.deste1[chos].kagitlar.nufuz;
                string health3 = health1.ToString();
                healthdata1.Text = health3;
                if (player2.deste1[chos].kagitlar.seviyePuani > 30)
                {
                    compusr2picturebox.Image = global::again.Properties.Resources.ozelkagit;
                }

            }
            else if (player2.deste1[chos].makaslar != null)
            {
                Console.WriteLine(player2.deste1[chos].makaslar);
                pvcbuttonlist1[chos].Visible = true;
                compusr2picturebox.Image = global::again.Properties.Resources.makas;
                health1 = player2.deste1[chos].makaslar.dayaniklik;
                keskinlik2 = player2.deste1[chos].makaslar.keskinlik;
                string health3 = health1.ToString();
                healthdata1.Text = health3;
                if (player2.deste1[chos].makaslar.seviyePuani > 30)
                {
                    compusr2picturebox.Image = global::again.Properties.Resources.ustamakas;
                }
            }
            else
            {
                Console.WriteLine("yok");
            }
            //_____________________________________________________________
            //COMBAT TIME

            float damage1 = 0f; // computer's damage 
            float damage2 = 0f; // user's damage 
            //player 2 is left one

            //user power ups
            float sicaklik1 = 1f;
            float kalinlik1 = 1f;
            float hiz1 = 1f;

            // when user's choice rock 
            if (player1.deste1[choiceindex].taslar != null)
            {

                katilik3 = player1.deste1[choiceindex].taslar.katilik;

                if (player2.deste1[chos].taslar != null)
                {
                    damage2 = 0f;
                    health2 = player2.deste1[chos].taslar.dayaniklik;

                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].taslar.dayaniklik);
                }
                else if (player2.deste1[chos].kagitlar != null)
                {
                    damage2 = player1.deste1[choiceindex].taslar.etkiHesapla(katilik3, nufuz2, 0, sicaklik1, kalinlik1, hiz1);
                    health2 = player2.deste1[chos].kagitlar.dayaniklik;
                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].kagitlar.dayaniklik);
                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    damage2 = player1.deste1[choiceindex].taslar.etkiHesapla(katilik3, 0, keskinlik2, sicaklik1, kalinlik1, hiz1);
                    //damage2 = damage2 * 4;
                    player2.deste1[chos].makaslar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].makaslar.dayaniklik;
                    player1.deste1[choiceindex].taslar.seviyePuani += 20;
                    leftbottomscore = leftbottomscore + 1;
                    Console.WriteLine("__ damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].makaslar.dayaniklik);
                }

                if (player1.deste1[choiceindex].taslar.seviyePuani > 30)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.agirtas;
                    player1.deste1[choiceindex].agirtaslar = new agirTasSinifi(player1.deste1[choiceindex].taslar.dayaniklik, 0);
                    sicaklik1 = player1.deste1[choiceindex].agirtaslar.sicaklik;
                } // seviye atlasýn

                if (player1.deste1[choiceindex].taslar.dayaniklik <= 0)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist2[choiceindex].Enabled = false;
                    comp1picturebox.Image = global::again.Properties.Resources.skull;

                }
            }
            //when user's choice paper
            else if (player1.deste1[choiceindex].kagitlar != null)
            {
                nufuz3 = player1.deste1[choiceindex].kagitlar.nufuz;

                if (player2.deste1[chos].taslar != null)
                {
                    damage2 = player1.deste1[choiceindex].kagitlar.etkiHesapla(katilik2, nufuz3, 0, sicaklik1, kalinlik1, hiz1);
                    damage2 = damage2 * 4;
                    player2.deste1[chos].taslar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].taslar.dayaniklik; 
                    player1.deste1[choiceindex].kagitlar.seviyePuani += 20;
                    leftbottomscore = leftbottomscore + 1;
                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].taslar.dayaniklik);
                }
                else if (player2.deste1[chos].kagitlar != null)
                {
                    damage2 = 0;
                    health2 = player2.deste1[chos].kagitlar.dayaniklik;
                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].kagitlar.dayaniklik);
                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    damage2 = player1.deste1[choiceindex].kagitlar.etkiHesapla(0, nufuz3, keskinlik2, sicaklik1, kalinlik1, hiz1);
                    health2 = player2.deste1[chos].makaslar.dayaniklik;
                    Console.WriteLine("__ damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].makaslar.dayaniklik);
                }

                if (player1.deste1[choiceindex].kagitlar.seviyePuani > 30)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.ozelkagit;
                    player1.deste1[choiceindex].ozelkagitlar = new ozelKagitSinifi(player1.deste1[choiceindex].kagitlar.dayaniklik, 0);
                    kalinlik1 = player1.deste1[choiceindex].ozelkagitlar.kalinlik;
                } // seviye atlasýn


                if (player1.deste1[choiceindex].kagitlar.dayaniklik <= 0)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist2[choiceindex].Enabled = false;
                    comp1picturebox.Image = global::again.Properties.Resources.skull;
                }
            }
            //when user's choice scissor
            else if (player1.deste1[choiceindex].makaslar != null)
            {
                keskinlik3 = player1.deste1[choiceindex].makaslar.keskinlik;

                if (player2.deste1[chos].taslar != null)
                {
                    damage2 = player1.deste1[choiceindex].makaslar.etkiHesapla(katilik2, 0, keskinlik3, sicaklik1, kalinlik1, hiz1);
                    health2 = player2.deste1[chos].taslar.dayaniklik;
                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].taslar.dayaniklik);
                }
                else if (player2.deste1[chos].kagitlar != null)
                {
                    damage2 = player1.deste1[choiceindex].makaslar.etkiHesapla(0, nufuz2, keskinlik3, sicaklik1, kalinlik1, hiz1);
                    damage2 = damage2 * 4;
                    player2.deste1[chos].kagitlar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].kagitlar.dayaniklik;
                    player1.deste1[choiceindex].makaslar.seviyePuani += 20;
                    leftbottomscore = leftbottomscore + 1;
                    Console.WriteLine(" damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].kagitlar.dayaniklik);
                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    damage2 = 0;
                    health2 = player2.deste1[chos].makaslar.dayaniklik;
                    Console.WriteLine("__ damage of left is " + damage2 + " health of comp is " + player2.deste1[chos].makaslar.dayaniklik);
                }

                if (player1.deste1[choiceindex].makaslar.seviyePuani > 30)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.ustamakas;
                    player1.deste1[choiceindex].ustamakaslar = new ustaMakasSinifi(player1.deste1[choiceindex].makaslar.dayaniklik, 0);
                    hiz1 = player1.deste1[choiceindex].ustamakaslar.hiz;
                } // seviye atlasýn

                if (player1.deste1[choiceindex].makaslar.dayaniklik <= 0)
                {
                    pvcbuttonlist2[choiceindex].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist2[choiceindex].Enabled = false;
                    comp1picturebox.Image = global::again.Properties.Resources.skull;
                }

            }

            float sicaklik2 = 1f;
            float kalinlik2 = 1f;
            float hiz2 = 1f;
            //when computer's choice rock
            if (player2.deste1[chos].taslar != null)
            {
 
                if (player1.deste1[choiceindex].taslar != null)
                {
                    damage1 = 0f;
                    health1 = player1.deste1[choiceindex].taslar.dayaniklik;
                    Console.WriteLine(" damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].taslar.dayaniklik);
                }
                else if (player1.deste1[choiceindex].kagitlar != null)
                {
                    damage1 = player2.deste1[chos].taslar.etkiHesapla(katilik2, nufuz3, 0, sicaklik2, kalinlik2, hiz2);
                    health1 = player1.deste1[choiceindex].kagitlar.dayaniklik;
                    Console.WriteLine(" damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].kagitlar.dayaniklik);
                }
                else if (player1.deste1[choiceindex].makaslar != null)
                {
                    damage1 = player2.deste1[chos].taslar.etkiHesapla(katilik2, 0, keskinlik3, sicaklik2, kalinlik2, hiz2);
                    //damage1 = damage1 * 4;
                    player1.deste1[choiceindex].makaslar.dayaniklik -= damage1;
                    player2.deste1[chos].taslar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].taslar.dayaniklik;
                    health1 = player1.deste1[choiceindex].makaslar.dayaniklik;
                    player2.deste1[chos].taslar.seviyePuani += 20;
                    righttopscore = righttopscore + 1;
                    Console.WriteLine("__ damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].makaslar.dayaniklik);
                }

                if (player2.deste1[chos].taslar.seviyePuani > 30)
                {
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.agirtas;
                    player2.deste1[chos].agirtaslar = new agirTasSinifi(player2.deste1[chos].taslar.dayaniklik, 0);
                    sicaklik2 = player2.deste1[chos].agirtaslar.sicaklik;
                } // seviye atlasýn

                if (player2.deste1[chos].taslar.dayaniklik <= 0)
                {
                    elementToRemove = chos;
                    elements = elements.Where(val => val != elementToRemove).ToArray();
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist1[chos].Enabled = false;

                }
            }
            //when computer's choice is paper
            else if (player2.deste1[chos].kagitlar != null)
            {

                if (player1.deste1[choiceindex].taslar != null)
                {
                    damage1 = player2.deste1[chos].kagitlar.etkiHesapla(katilik3, nufuz2, 0, sicaklik2, kalinlik2, hiz2);
                    damage1 = damage1 * 4;
                    player1.deste1[choiceindex].taslar.dayaniklik -= damage1;
                    player2.deste1[chos].kagitlar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].kagitlar.dayaniklik;
                    health1 = player1.deste1[choiceindex].taslar.dayaniklik;
                    player2.deste1[chos].kagitlar.seviyePuani += 20;
                    righttopscore = righttopscore + 1;
                    Console.WriteLine(" damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].taslar.dayaniklik);
                }
                else if (player1.deste1[choiceindex].kagitlar != null)
                {
                    damage1 = 0f;
                    health1 = player1.deste1[choiceindex].kagitlar.dayaniklik;
                    Console.WriteLine(" damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].kagitlar.dayaniklik);
                }
                else if (player1.deste1[choiceindex].makaslar != null)
                {
                    damage1 = player2.deste1[chos].kagitlar.etkiHesapla(0, nufuz2, keskinlik3, sicaklik2, kalinlik2, hiz2);
                    player1.deste1[choiceindex].makaslar.dayaniklik -= damage1;
                    health1 = player1.deste1[choiceindex].makaslar.dayaniklik;
                    Console.WriteLine("__ damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].makaslar.dayaniklik);
                }

                if (player2.deste1[chos].kagitlar.seviyePuani > 30)
                {
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.ozelkagit;
                    player2.deste1[chos].ozelkagitlar = new ozelKagitSinifi(player2.deste1[chos].kagitlar.dayaniklik, 0);
                    kalinlik2 = player2.deste1[chos].ozelkagitlar.kalinlik;
                } // seviye atlasýn

                if (player2.deste1[chos].kagitlar.dayaniklik <= 0)
                {
                    elementToRemove = chos;
                    elements = elements.Where(val => val != elementToRemove).ToArray();
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist1[chos].Enabled = false;
                    compusr2picturebox.Image = global::again.Properties.Resources.skull;
                }
            }
            // when computer's choice is scissor
            else if (player2.deste1[chos].makaslar != null)
            {

                if (player1.deste1[choiceindex].taslar != null)
                {
                    damage1 = player2.deste1[chos].makaslar.etkiHesapla(katilik3, 0, keskinlik2, sicaklik2, kalinlik2, hiz2);
                    damage1 = damage1 / 4;
                    player1.deste1[choiceindex].taslar.dayaniklik -= damage1;
                    health1 = player1.deste1[choiceindex].taslar.dayaniklik;
                    Console.WriteLine(" damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].taslar.dayaniklik);
                }
                else if (player1.deste1[choiceindex].kagitlar != null)
                {
                    damage1 = player2.deste1[chos].makaslar.etkiHesapla(0, nufuz3, keskinlik2, sicaklik2, kalinlik2, hiz2);
                    damage1 = damage1 * 4;
                    player1.deste1[choiceindex].kagitlar.dayaniklik -= damage1;
                    player2.deste1[chos].makaslar.dayaniklik -= damage2;
                    health2 = player2.deste1[chos].makaslar.dayaniklik;
                    health1 = player1.deste1[choiceindex].kagitlar.dayaniklik;
                    player2.deste1[chos].makaslar.seviyePuani += 20;
                    righttopscore = righttopscore + 1;
                    Console.WriteLine(" damage of right is " + damage1 +" health of user is "+ player1.deste1[choiceindex].kagitlar.dayaniklik);
                }
                else if (player2.deste1[chos].makaslar != null)
                {
                    damage1 = 0f;
                    health1 = player1.deste1[choiceindex].makaslar.dayaniklik;
                    Console.WriteLine("__ damage of right is " + damage1 + " health of user is " + player1.deste1[choiceindex].makaslar.dayaniklik);
                }

                if (player2.deste1[chos].makaslar.seviyePuani > 30)
                {
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.ustamakas;
                    player2.deste1[chos].ustamakaslar = new ustaMakasSinifi(player2.deste1[chos].makaslar.dayaniklik, 0);
                    hiz2 = player2.deste1[chos].ustamakaslar.hiz;
                } // seviye atlasýn

                if (player2.deste1[chos].makaslar.dayaniklik <= 0)
                {
                    elementToRemove = chos;
                    elements = elements.Where(val => val != elementToRemove).ToArray();
                    pvcbuttonlist1[chos].Image = global::again.Properties.Resources.skull;
                    pvcbuttonlist1[chos].Enabled = false;
                    compusr2picturebox.Image = global::again.Properties.Resources.skull;
                }
            }


            //health1 = health1 - damage2; //comp
            //health2 = health2 - damage1; // user

            string health1text = health1.ToString();
            string health2text = health2.ToString();
            string damage2text = damage2.ToString();
            string damage3text = damage1.ToString();
            string score1 = righttopscore.ToString();
            string score2 = leftbottomscore.ToString();
            damagedata2.Text = damage2text;
            damagedata1.Text = damage3text;
            healthdata1.Text = health1text;
            healthdata2.Text = health2text;

            user1score.Text = score1;
            user2score.Text = score2;

            turns2.counter += 1;
            string round = "round : " + turns2.counter;
            rounds.Text = round;

            player1.skor = leftbottomscore;
            player2.skor = righttopscore;
            player2.oyuncuAdi = "computer";

            if (righttopscore >= 10 || leftbottomscore >= 10 || turns.counter == TOTALROUND)
            {
                if (righttopscore >= 10 || righttopscore > leftbottomscore)
                {
                    Console.WriteLine("user2 (top) won");
                    vsmenu.Visible = false;
                    comp_user_deck.Visible = false;
                    computerdeck.Visible = false;
                    user1scoreboard.Visible = false;
                    user2scoreboard.Visible = false;

                    winner.Text = "winner is " + player2.oyuncuAdi;
                    scores.Text = player1.oyuncuAdi + " : " +player1.skor + " - " + player2.oyuncuAdi + " : " + player2.skor;
                    next_game_menu.BackgroundImage = global::again.Properties.Resources.backgroundmenu2;
                    next_game_menu.Visible = true;
                }
                if (leftbottomscore >= 10 || leftbottomscore > righttopscore)
                {
                    Console.WriteLine("user1 (bottom) won");
                    vsmenu.Visible = false;
                    comp_user_deck.Visible = false;
                    computerdeck.Visible = false;
                    user1scoreboard.Visible = false;
                    user2scoreboard.Visible = false;
                    winner.Text = "winner is " + player1.oyuncuAdi;
                    scores.Text = player1.oyuncuAdi + " : " + player1.skor + " - " + player2.oyuncuAdi + " : " + player2.skor;
                    next_game_menu.BackgroundImage = global::again.Properties.Resources.userbackground;
                    next_game_menu.Visible = true;
                }
            }


        }

        private void playagain_Click(object sender, EventArgs e)
        {
            // olmadý burasý xd
            //next_game_menu.Visible = false;
            //groupBox1.Visible = true;
            //Application.Run(new Form1());
            //Form1 form2 = new Form1();
            //Application.Run(new Form1());
            Environment.Exit(0);

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    
}