using BlocoNotas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlocoNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListNotesPage : ContentPage
    {
        public static ObservableCollection<Note> Items { get; set; }

        public ListNotesPage()
        {
            InitializeComponent();

            Items = loadFiles();

            ListViewNotes.ItemsSource = Items;

        }

        async void OnTap(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            await Navigation.PushAsync(new ViewNotePage((Note)e.Item));
        }

        public ObservableCollection<Note> loadFiles()
        {
            ObservableCollection<Note> notes = new ObservableCollection<Note>();
            var files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string readedFile = File.ReadAllText(file);
                notes.Add(new Note(fileName, file, readedFile));
            }
            return notes;
        }

        protected override void OnAppearing()
        {
            Items = loadFiles();
            ListViewNotes.ItemsSource = Items;
            base.OnAppearing();
        }

        public void OnCreate(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormNotePage());
        }
        
    }
}
