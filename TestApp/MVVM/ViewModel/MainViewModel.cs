﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core;
using TestApp.MVVM.Model;

namespace TestApp.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }


        public RelayCommand SendCommand { get; set; }


        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel()
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel()
            {
                Username = "TestUserName",
                UsernameColor = "#60F5A5",
                ImageSource = "C:\\DotNetDev\\StariProjektiUReact\\TestApp\\TestApp\\Assets\\Avatar_200x200.png",
                Message = "Test message text",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel()
                {
                    Username = "Bunny",
                    UsernameColor = "#60F50A5",
                    ImageSource = "C:\\DotNetDev\\StariProjektiUReact\\TestApp\\TestApp\\Assets\\Avatar_200x200.png",
                    Message = "Test message text",
                    Time = DateTime.Now,
                    FirstMessage = true
                });
            }
            Messages.Add(new MessageModel()
            {
                Username = "TestUserress",
                UsernameColor = "#60F5A5",
                ImageSource = "C:\\DotNetDev\\StariProjektiUReact\\TestApp\\TestApp\\Assets\\Avatar_200x200.png",
                Message = "Last Test message text",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0;i < 5;i++)
            {
                Contacts.Add(new ContactModel()
                {
                    Username = $"TestUser{i}",
                    ImageSource = "C:\\DotNetDev\\StariProjektiUReact\\TestApp\\TestApp\\Assets\\Avatar_200x200.png",
                    Messages = new ObservableCollection<MessageModel>(Messages)
                });
            }
        }
    }
}
