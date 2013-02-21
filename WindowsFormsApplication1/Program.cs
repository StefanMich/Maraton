using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Marathon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}


//TitleControl
//TODO Variabel tekststørrelse
//TODO Skal printe season/seasons ved en eller flere
//TODO Vis total duration + gennemsnit duration pr. afsnit i tekst

// SeriesOverview
//TODO drag and drop
//TODO variabelt antal serier der vises
//TODO pænere buffer ved skift af serie
//TODO en måde at søge på i overview, jump? Search? 
//TODO alfabetisk sortering i overview
//TODO eventuelt forskellige sorteringer - alfabetisk, frekvens (frekvens kunne eventuelt være et træ der har rod i midten)
//TODO genvej til senest sete serie
//TODO Fix at der ikke altid er fokus til at bruge keyboard shortcuts

//General
//TODO sygt ikon - lille mand der løber

//Editseries
//TODO Sortering af sæsoner i EditSeries
//TODO Enter for play og delete for remove
//TODO undo ved delete
//TODO tilføj fil til sæson
//TODO Bedre layout

