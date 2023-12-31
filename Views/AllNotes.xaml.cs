namespace CaicedoRamos_TareaMVVM.Views;

public partial class AllNotes : ContentPage
{
    public AllNotes()
    {
        InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}