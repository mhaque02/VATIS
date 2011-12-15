/* VATIS by Mohammed Haque
 * Copyright (c) 2011 Mohammed Haque
 * 
 * VATIS is a simple VATSIM voice ATIS maker.
 * It takes an ICAO code provided by the user,
 * finds the METAR data from NOAA for that airport, and
 * converts it to normal readable text which is then
 * sent to Microsoft's TTS servers for voice output.
 * The ICAO code provided must be valid and existing in the NOAA database.
 * This Program uses the Microsoft Translate TTS (Microsoft Corp.)
 * API for text to speech and UniATIS (http://www.uniatis.net/) for METAR decoding.
 * All rights reserved by the respective parties.
 * Please don't sue me for not citing properly. I'm sorry :)
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * 
 * ALL RIGHTS RESERVED BY RESPECTIVE PARTIES
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Threading;
using System.Timers;
using System.Media;
using System.Text.RegularExpressions;
//using System.Security.Cryptography;


namespace VATIS
{
    public partial class VATIS : Form
    {
        public VATIS()
        {
            InitializeComponent();
            ICAO_Textbox.KeyPress += new KeyPressEventHandler(ICAO_Textbox_KeyPress);//FOR CAPS LOCKING THE ICAO TEXTBOX
            dep_runways.KeyPress += new KeyPressEventHandler(dep_runways_KeyPress);//CAPS LOCK DEP RUNWAY TEXT
            arr_runways.KeyPress += new KeyPressEventHandler(arr_runways_KeyPress);//CAPS LOCK ARR RUNWAY TEXT
            atisCodeBox.DropDownStyle = ComboBoxStyle.DropDownList; //Disables ATIS box from being edited by user
        }

        void arr_runways_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Keeps CAPS LOCK ON for the arrival runways textbox
            //e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        void dep_runways_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Keeps CAPS LOCK ON for the departure runways textbox
            //e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        void ICAO_Textbox_KeyPress (object sender, KeyPressEventArgs e)
        {
            //Keeps CAPS LOCK on for the ICAO input
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {}
        private void textToSpeech_TextChanged(object sender, EventArgs e)
        {}

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Saves the spoken text to the directory of the program in a wav file.
            WebClient wc = new WebClient();

            try
            {
                if (textToSpeech.Text == "" || dep_runways.Text == "" || arr_runways.Text == "" || ICAO_Search.Text == "")
                {
                    MessageBox.Show("Could not save ATIS! A required field is missing. Please check all fields are filled in.");
                }
                else
                {
                    VoiceService.LanguageServiceClient client = new VoiceService.LanguageServiceClient();
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727)");
                    byte[] mp3Bytes = wc.DownloadData(client.Speak("8F80F32F200F7A556D3DD92CE6DAFC6DCA3B9BC8", textToSpeech.Text, "en", "audio/wav"));//API, TEXT, LANGUAGE, TYPE
                    string fileOut = "atis.mp3";
                    FileStream fs = new FileStream(fileOut, FileMode.Create);
                    fs.Write(mp3Bytes, 0, mp3Bytes.Length);
                    fs.Close();
                    MessageBox.Show("ATIS file saved.", "ATIS Saved");
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                if (error.Contains("ArgumentOutOfRangeException"))
                {
                    MessageBox.Show("Something is not right.\n1) Check the ICAO code.\n2) Check runway entries.\n3) Is there anything written on the textbox above? ERROR 1", "ERROR 1");
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "ERROR 100");
                }
            }
        }

        private void ICAO_Textbox_TextChanged(object sender, EventArgs e)
        {}
        private void arr_runways_TextChanged(object sender, EventArgs e)
        {}
        private void ICAO_Label_Click(object sender, EventArgs e)
        {}
        private void metarData_TextChanged(object sender, EventArgs e)
        {}
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {}
        private void connectToVATSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //For the Connect to VATSIM option. Opens the login box
            ConnectingToNetwork newConnection = new ConnectingToNetwork();
            newConnection.ShowDialog();//Show dialog disables the background window to prevent multiple instances of logins
        }

        private void ICAO_Search_Click(object sender, EventArgs e)
        {
            /* Searches the METAR data for the ICAO code given by the user.
             * If successful, runs it through UniATIS to get the decoded METAR.
             * Decoded METAR is outputted to the textToSpeech window on the right side of the program window.
             * Afterwards, the output text is modified for better ATC decoding.
             * Commas (,) are entered for pauses during the voice output.
             */

            if (ICAO_Textbox.Text == "")
            {
                MessageBox.Show("Please input the ICAO code of the airport. ERROR 1", "ERROR 1");
            }

            else if (arr_runways.Text == "" || dep_runways.Text == "")
            {
                MessageBox.Show("Please add the departure AND arrival runways. Type it as: 8 Left 16 Right (SEPERATE BY SPACES PLEASE) ERROR 1", "ERROR 1");
            }

            else
            {
                string url = "http://weather.noaa.gov/pub/data/observations/metar/stations/" + ICAO_Textbox.Text + ".TXT";

                try
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                    myRequest.Method = "GET";
                    WebResponse getMetar = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(getMetar.GetResponseStream(), System.Text.Encoding.UTF8);
                    string result = sr.ReadLine();
                    int found = 0;

                    while (result != ICAO_Textbox.Text)
                    {
                        if (result.Contains(ICAO_Textbox.Text))
                        {
                            found = 1;
                            break;
                        }
                        result = sr.ReadLine();
                    }

                    if (found == 1)
                    {
                        metarData.Text = result;
                        char atisCode = atisCodeBox.Text[0];
                        string uniAtis;
                        if (ilsApproachBox.Checked)
                        {
                            uniAtis = "http://www.uniatis.net/atis.php?arr=" + arr_runways.Text + "&dep=" + dep_runways.Text + "&apptype=ILS&info=" + atisCode + "&metar=" + result;
                        }
                        else
                        {
                            uniAtis = "http://www.uniatis.net/atis.php?arr=" + arr_runways.Text + "&dep=" + dep_runways.Text + "&info=" + atisCode + "&metar=" + result;
                        }
                        HttpWebRequest getData = (HttpWebRequest)WebRequest.Create(uniAtis);
                        getData.Method = "GET";
                        WebResponse responseUniAtis = getData.GetResponse();
                        StreamReader readMetar = new StreamReader(responseUniAtis.GetResponseStream(), System.Text.Encoding.UTF8);
                        string text = readMetar.ReadToEnd();
                        //------------------ALL AUTOMATED ERRORS AND THEIR FIXES ARE BELOW THIS LINE-----------------------//
                        text = text.Replace("[", " ");
                        string modify = text.Replace("]", " ");
                        modify = modify.Replace("{", "");
                        modify = modify.Replace("}", "");
                        modify = modify.Replace("     ", "");
                        modify = modify.Replace("  ", " ");
                        //modify = modify.Replace("Real World Notam ,PAPAR departures are suspended until further notice .Pilots are required to use DARAX departures instead .Contact the local ATC for an alternative routing", "");
                        //-----------------ALL AIRPORT NAME CORRECTIONS BEGIN HERE, ALPHABETICAL ORDER--------------//
                        modify = modify.Replace("SCHOENEFELD", "Schoenefeld");
                        modify = modify.Replace("DAAG", " Hoari Bomediene Airport ");
                        modify = modify.Replace("EIDW", " Dublin International Airport ");
                        modify = modify.Replace("GMMN", " International Muhammad the Fifth ");
                        modify = modify.Replace("GMMX", " Menara International Airport ");
                        modify = modify.Replace("HECA", " Cairo International Airport ");
                        modify = modify.Replace("HESH", " Sharm el Sheikh Airport ");
                        modify = modify.Replace("KLGA", " LaGuardia Airport ");
                        modify = modify.Replace("KJFK", " Kennedy Airport ");
                        modify = modify.Replace("KEWR", " Newark Liberty International Airport ");
                        modify = modify.Replace("LFPG", " Charles de Gaulle ");
                        modify = modify.Replace("LLBG", " Ben Gurion International Airport ");
                        modify = modify.Replace("LTAI", " Antaalya Airport ");
                        modify = modify.Replace("LTBA", " Istanbul Ataa Turk International Airport ");
                        modify = modify.Replace("OBBI", " Bahrain International Airport ");
                        modify = modify.Replace("OEJN", " Jeddda airport ");
                        modify = modify.Replace("OJAI", " Queen Aalia Airport");
                        modify = modify.Replace("OJAM", " Marka International Airport");
                        modify = modify.Replace("OJAQ", " Aqaba International Airport");
                        modify = modify.Replace("OKBK", " Ku-wait International Airport ");
                        modify = modify.Replace("OLBA", " Beirut - Rafic Harriri International Airport ");
                        //----------------------AIRPORT NAME CORRECTIONS END HERE---------------------------------------//
                        modify = modify.Replace("km", " kilometer ");
                        modify = modify.Replace("CAVOK", ", ceiling and visibility OK, ");
                        modify = modify.Replace("NOSIG", ", No significant weather reported, ");
                        modify = modify.Replace("ILS", "I L S");
                        modify = modify.Replace("runway " + arr_runways.Text + " in use", ", landing and departing runway " + arr_runways.Text);
                        modify = modify.Replace("TREND TEMPORARY", "TREND, TEMPORARY");
                        modify = modify.Replace("BKN", " Broken ");
                        modify = modify.Replace("Arr_rwy", " , Arrival runway ");
                        modify = modify.Replace(" transition level 55 ", "");
                        modify = modify.Replace(" transition level 150", "");
                        modify = modify.Replace("QNH", ", QNH");
                        modify = modify.Replace("expect I L S approach", ", expect I L S approach,");
                        modify = modify.Replace("arrival", ", arrival");
                        modify = modify.Replace("departure", ", departure");
                        modify = modify.Replace("degrees ", "degrees at ");
                        modify = modify.Replace("departing , runway", "departing runway");
                        modify = modify.Replace("transition level 50", "");
                        modify = modify.Replace("Z Wind", " Zulu, Wend");
                        modify = modify.Replace("Sky ", ", Sky ");
                        modify = modify.Replace(" 000", "000");
                        modify = modify.Replace("Altimeter", ", Altimeter");
                        modify = modify.Replace("Acknowledge ", ", Acknowledge ");
                        modify = modify.Replace(" QFE ", ", QFE ");
                        modify = modify.Replace(" TL ", ", Transition Level ");
                        modify = Regex.Replace(modify, "(?:sct|SCT)", "scattered");
                        modify = Regex.Replace(modify, "(?: clouds| Clouds| CLOUDS)", " clouds");
                        modify = Regex.Replace(modify, "(?:mps|MPS)", "meters per second");
                        modify = Regex.Replace(modify, "(?:Visibility|visibility)", ", Visibility");
                        modify = Regex.Replace(modify, "(?:meters|METERS)", "meters,");
                        modify = Regex.Replace(modify, "(?:fog|FOG)", "fog, ");
                        modify = Regex.Replace(modify, "(?:wind|WIND)", ", wend");
                        modify = Regex.Replace(modify, "(?:kilometers|KILOMETERS)", "kilometers, ");
                        modify = Regex.Replace(modify, "(?:no significant clouds|NO SIGNIFICANT CLOUDS)", "no significant clouds, ");
                        modify = Regex.Replace(modify, "(?:temperature|Temperature|TEMPERATURE)", ", temperature");
                        modify = Regex.Replace(modify, "(?:runways|RUNWAYS)", ", runways");
                        modify = Regex.Replace(modify, "(?:runway|RUNWAY)", ", runway");
                        modify = Regex.Replace(modify, "(?:left|Left)", "Left, ");
                        modify = Regex.Replace(modify, "(?:right|Right)", "Right, ");
                        modify = Regex.Replace(modify, "(?:knots|KNOTS)", "knots, ");
                        modify = Regex.Replace(modify, "(?:calm|CALM)", "calm, ");
                        modify = Regex.Replace(modify, "(?:scattered|Scattered|SCATTERED)", ", scattered");
                        modify = Regex.Replace(modify, "(?:broken|Broken|BROKEN)", ", broken");
                        modify = Regex.Replace(modify, "(?:dew point|Dew Point|DEW POINT)", ", dew point");
                        modify = Regex.Replace(modify, "(?:variable|Variable|VARIABLE)", ", variable");
                        modify = Regex.Replace(modify, "(?:information A|Information A|INFORMATION A)", "information Alpha, ");
                        modify = Regex.Replace(modify, "(?:information B|Information B|INFORMATION B)", "information Bravo, ");
                        modify = Regex.Replace(modify, "(?:information C|Information C|INFORMATION C)", "information Charlie, ");
                        modify = Regex.Replace(modify, "(?:information D|Information D|INFORMATION D)", "information Delta, ");
                        modify = Regex.Replace(modify, "(?:information E|Information E|INFORMATION E)", "information Echo, ");
                        modify = Regex.Replace(modify, "(?:information F|Information F|INFORMATION F)", "information Foxtrot, ");
                        modify = Regex.Replace(modify, "(?:information G|Information G|INFORMATION G)", "information Golf, ");
                        modify = Regex.Replace(modify, "(?:information H|Information H|INFORMATION H)", "information Hotel, ");
                        modify = Regex.Replace(modify, "(?:information I|Information I|INFORMATION I)", "information India, ");
                        modify = Regex.Replace(modify, "(?:information J|Information J|INFORMATION J)", "information Juliet, ");
                        modify = Regex.Replace(modify, "(?:information K|Information K|INFORMATION K)", "information Kilo, ");
                        modify = Regex.Replace(modify, "(?:information L|Information L|INFORMATION L)", "information Lima, ");
                        modify = Regex.Replace(modify, "(?:information M|Information M|INFORMATION M)", "information Mike, ");
                        modify = Regex.Replace(modify, "(?:information N|Information N|INFORMATION N)", "information November, ");
                        modify = Regex.Replace(modify, "(?:information O|Information O|INFORMATION O)", "information Oscar, ");
                        modify = Regex.Replace(modify, "(?:information P|Information P|INFORMATION P)", "information Papa, ");
                        modify = Regex.Replace(modify, "(?:information Q|Information Q|INFORMATION Q)", "information Quebec, ");
                        modify = Regex.Replace(modify, "(?:information R|Information R|INFORMATION R)", "information Romeo, ");
                        modify = Regex.Replace(modify, "(?:information S|Information S|INFORMATION S)", "information Sierra, ");
                        modify = Regex.Replace(modify, "(?:information T|Information T|INFORMATION T)", "information Tango, ");
                        modify = Regex.Replace(modify, "(?:information U|Information U|INFORMATION U)", "information Uniform, ");
                        modify = Regex.Replace(modify, "(?:information V|Information V|INFORMATION V)", "information Victor, ");
                        modify = Regex.Replace(modify, "(?:information W|Information W|INFORMATION W)", "information Whiskey, ");
                        modify = Regex.Replace(modify, "(?:information X|Information X|INFORMATION X)", "information X-Ray, ");
                        modify = Regex.Replace(modify, "(?:information Y|Information Y|INFORMATION Y)", "information Yankee, ");
                        modify = Regex.Replace(modify, "(?:information Z|Information Z|INFORMATION Z)", "information Zulu, ");
                        modify = Regex.Replace(modify, "(?:,  ,| ,)", ", ");
                        modify = modify.Replace("  ", " ");
                        modify = modify.Replace("    ", " ");
                        modify = modify.Replace("Surface, wend ", ", Surface Wend ");
                        modify = modify.Replace("Read back all hold short instructions,, Read back all hold short instructions,", "Read back all hold short instructions,");
                        modify = modify.Replace(" the, runway ", " the runway ");
                        modify = modify.Replace(" current, QNH ", " current QNH ");
                        modify = modify.Replace(" No significant cloud Temperature ", ", No significant cloud, Temperature ");
                        modify = modify.Replace(" Z , Arrival", " Zulu, Arrival");
                        modify = modify.Replace(" meters, per second", " meters per second");
                        modify = modify.Replace(", on first contact", " on first contact");
                        modify = modify.Replace(", OUT", " OUT");
                        modify = modify.Replace("degrees at,", "degrees,");
                        modify = modify.Replace("condition, scattered", "condition scattered");
                        modify = modify.Replace(" and, Visibility ", " and visibility ");
                        modify = modify.Replace(" , ", ", ");
                        modify = modify.Replace(", ,", ", ");
                        modify = modify.Replace("  ", " ");
                        modify = modify.Replace(",,", ", ");
                        modify = modify.Replace(" BETWEEN,  runways ", " between runways ");
                        modify = modify.Replace(" PARALLEL, runway", " parallel runway ");
                        modify = modify.Replace(" transition level", ", transition level");
                        modify = modify.Replace(", ,", ", ");
                        modify = modify.Replace("  ", " ");
                        modify = modify.Replace(" No, clouds below", ", No clouds below");
                        modify = Regex.Replace(modify, "(?: Departing, runway|departing , runway)", ", Departing runway");
                        modify = Regex.Replace(modify, "(?: Arriving, runway|arriving , runway)", ", Arriving runway");
                        modify = modify.Replace("degrees at,", "degrees,");
                        modify = modify.Replace(" Advise ", ", Advise ");
                        modify = modify.Replace(",,", ",");
                        //----------------------------ALL AUTOMATED ERROR CORRECTION END AT THIS LINE----------------------//
                        //----------------------------CODE TEST AREA---------------------------------//
                        int characters = 0;
                        foreach (char c in modify)
                        {
                            characters++;
                        }
                        characterCount.Text = characters.ToString();
                        if (characters > 500)
                            MessageBox.Show("There are more than 500 characters. The text will not be converted to speech if it is greater than 500 characters! ERROR 3", "ERROR 3");
                        //----------------------------CODE TEST ENDS---------------------------------//
                        textToSpeech.Text = modify;
                        readMetar.Close();
                        responseUniAtis.Close();
                        autoUpdateBox.Enabled = true;
                    }
                    sr.Close();
                    getMetar.Close();
                }
                catch (Exception ex)
                {
                    string indexError = ex.ToString();
                    if (ex.Message == "The remote server returned an error: (404) Not Found.")
                    {
                        string error = "Sorry, I could not find " + ICAO_Textbox.Text + " in the database. Please check the ICAO code again. ERROR 2";
                        MessageBox.Show(error, "ERROR 2");
                    }
                    else if (indexError.Contains("Value of '26' is not valid"))
                    {
                        atisCodeBox.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString(), "ERROR 100");
                    }
                }
            }
        }
        private void listen_Click(object sender, EventArgs e)
        {
            /* Plays the text that is put in the textToSpeech box of the program
             * The box can be modified and it will speak the modified text.
             */

            SoundPlayer player = new SoundPlayer();

            try
            {
                if (ICAO_Textbox.Text.Count() == 0)
                {
                    MessageBox.Show("No ICAO code provided. If the ICAO code is provided, it is invalid or you have not clicked the Search button. ERROR 4", "ERROR 4");
                }
                else if (dep_runways.Text == "" || arr_runways.Text == "")
                {
                    MessageBox.Show("Enter the arrival AND departure runways. ERROR 1", "ERROR 1");
                }
                else if (textToSpeech.Text == "")
                {
                    MessageBox.Show("I have nothing to say! ERROR 5", "ERROR 5");
                }
                else if (listen.Text == "Stop")
                {
                    player.Stop();
                    listen.Text = "Listen";
                }
                else
                {
                    listen.Text = "Stop";
                    VoiceService.LanguageServiceClient client = new VoiceService.LanguageServiceClient();
                    //SoundPlayer player = new SoundPlayer(client.Speak("8F80F32F200F7A556D3DD92CE6DAFC6DCA3B9BC8", textToSpeech.Text, "en", "audio/wav"));
                    player.SoundLocation = client.Speak("8F80F32F200F7A556D3DD92CE6DAFC6DCA3B9BC8", textToSpeech.Text, "en", "audio/wav");
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                if (exception.Contains("ArgumentOutOfRangeException"))
                {
                    MessageBox.Show("Invalid Entry. Please try again. ERROR 6", "ERROR 6");
                    listen.Text = "Listen";
                }
                else
                {
                    MessageBox.Show(ex.Message, "ERROR 100");
                    listen.Text = "Listen";
                }
            }
            //player.Dispose();
        }

        //PROGRAM CLOSING
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes the application when EXIT is pressed in the FILE menu
        }

        //ABOUT MENU UNDER THE "ABOUT" TAB
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {}

        private void aboutVATISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string about = "VATIS 1.0\n(c)Mohammed \"Syam\" Haque (VATSIM ID: 1161585)\n\nMETAR data provided by NOAA\nVoice by Microsoft TTS\nLogo by Abdelrahman Elfeky\n\nSpecial thanks to Sami Ylismäki\nand his UniATIS decoding system\n\nFor questions, comments, or concerns email: \nvatsim_vatis@yahoo.com";
            MessageBox.Show(about, "About VATIS");
        }

        private void autoUpdateBox_CheckedChanged(object sender, EventArgs e)
        {
            /* Updates the ATIS information and the program in every
             * 5 minute intervals.
             */

            if (autoUpdateBox.Checked)
            {
                System.Timers.Timer updateTimer = new System.Timers.Timer(1000);
                updateTimer.Elapsed += new ElapsedEventHandler(updateTimer_Elapsed);
                updateTimer.Interval = 1000;
                updateTimer.Enabled = true;
            }
        }

        //THE FUNCTION THAT IS EXECUTED ONCE THE TIMER ELAPSES
        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ICAO_Search.PerformClick();
            /*if (oldatis != textToSpeech.Text)
            {
                MessageBox.Show("NEW ATIS AVAILABLE.");
            }*/
            //throw new NotImplementedException();
        }

        private void atisCodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {}
        private void label1_Click(object sender, EventArgs e)
        {}
        private void label1_Click_1(object sender, EventArgs e)
        {}
        private void dep_runways_TextChanged(object sender, EventArgs e)
        {}
        /*private void arr_runways_TextChanged(object sender, EventArgs e)
        {}*/
        private void ilsApproachBox_CheckedChanged(object sender, EventArgs e)
        {}

        //AutoUpdate under the About Menu
        private void autoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string about = "AutoUpdate feature is a work in progress. For now, the control is disabled and VOICE ATIS must be updated MANUALLY";
            MessageBox.Show(about, "AutoUpdate");
        }

        //Disconnect option under FILE
        private void diconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to disconnect?", "Disconnect ATIS", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("DISCONNECTED!");
            }
        }
    }
}