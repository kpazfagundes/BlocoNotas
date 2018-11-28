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
	public partial class ViewNotePage : ContentPage
	{
        public Note ItemNote;
		public ViewNotePage (Note note)
		{
            ItemNote = note;
			InitializeComponent ();
            BindingContext = note;
        }

        public void OnSave(object sender, EventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(ItemNote.Path);

            if (fileName != ItemNote.Title)
            {
                File.Delete(ItemNote.Path);

                ItemNote.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ItemNote.Title + ".txt");
            }
            
            File.WriteAllText(ItemNote.Path, NoteDescription.Text);
            DisplayAlert("Dados atualizados com sucesso", "Sua nota \"" + ItemNote.Title + "\" foi atualizada com suceso\r\n" + ItemNote.Path, "OK");
            Navigation.PopAsync();
        }

        public void OnDelete(object sender, EventArgs e)
        {
            File.Delete(ItemNote.Path);
            DisplayAlert("Nota apagada com sucesso", "Sua nota \"" + ItemNote.Title + "\" foi apagada com suceso", "OK");
            Navigation.PopAsync();
        }
    }
}