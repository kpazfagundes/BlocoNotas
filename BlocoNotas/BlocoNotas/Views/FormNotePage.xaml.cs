using BlocoNotas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormNotePage : ContentPage
	{
		public FormNotePage (Note note = null)
		{
			InitializeComponent ();
            SaveButton.Clicked += SalveToFile_Clicked;
        }

        private void SalveToFile_Clicked(object sender, EventArgs e)
        {
            string fileNameWithExtension = NoteTitle.Text + ".txt";
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileNameWithExtension);
            File.WriteAllText(fileName, NoteDescription.Text);

            DisplayAlert("Nota criada com sucesso", "Sua nota \"" + NoteTitle.Text + "\" foi criada com suceso", "OK");
            Navigation.PopAsync();
        }
    }
}