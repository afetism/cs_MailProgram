using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace cs_MailProgram.ViewModels;

public class MainViewModel:INotifyPropertyChanged
{
    private ObservableCollection<Message> messages;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // vqax kpns nxaj xeor

    public ObservableCollection<Message> Messages
    { 
        get => messages;
        set
        {
            messages = value;
            OnPropertyChanged();

        }
    }
    public MainViewModel()
    {
        Messages=new ObservableCollection<Message>();
        Task.Run(() => ExecuteInbox());
      
    }

    void ExecuteInbox()
    {
        using var imap = new ImapClient();

        imap.Connect("imap.gmail.com", 993);
        imap.Authenticate("aismayilova1215@gmail.com", "vqax kpns nxaj xeor");

        var inbox = imap.GetFolder("Inbox");

        inbox.Open(FolderAccess.ReadOnly);
        var ids = inbox.Search(SearchQuery.All);


        foreach (var id in ids)
        {
            var message = inbox.GetMessage(id);

            
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new Message
                {
                    Subject = message.Subject,
                    Body = message.TextBody
                });
            });

        }

    }


}
