using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_GSB.ViewModels
{

    public class AcceuilViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public AcceuilViewModel(INavigationService navigationService)
            : base(navigationService)
        {       
            _navigationService = navigationService;
            Title = "Acceuil";
        }
        public String Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        private String _login;

        public String Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private String _id;

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            Id = (string)parameters["id"];
            Login = (string)parameters["nom"];

            base.OnNavigatedTo(parameters);

        }
        public DelegateCommand CompteRendue
        {
            get { return _compterendue ?? (_compterendue = new DelegateCommand(RunCompteRendue, CanCompteRendue)); }
        }
        private DelegateCommand _compterendue;

        public async void RunCompteRendue()
        {
            NavigationParameters navigationParameters = new NavigationParameters();

            navigationParameters.Add("login", Login);

            await _navigationService.NavigateAsync("CompteRenduePage", navigationParameters);
            
        }

        public virtual bool CanCompteRendue()
        {
            return true;
        }

        public DelegateCommand Visiteur
        {
            get { return _visiteur ?? (_visiteur = new DelegateCommand(RunVisiteur, CanVisiteur)); }
        }
        private DelegateCommand _visiteur;

        public async void RunVisiteur()
        {
            NavigationParameters navigationParameters = new NavigationParameters();

            navigationParameters.Add("login", Login);
            await _navigationService.NavigateAsync("VisiteurPage", navigationParameters);
        }

        public virtual bool CanVisiteur()
        {
            return true;
        }

        public DelegateCommand Praticien
        {
            get { return _praticien ?? (_praticien = new DelegateCommand(RunPraticien, CanPraticien)); }
        }
        private DelegateCommand _praticien;

        public async void RunPraticien()
        {
            NavigationParameters navigationParameters = new NavigationParameters();

            navigationParameters.Add("login", Login);
            await _navigationService.NavigateAsync("PraticienPage", navigationParameters);
        }

        public virtual bool CanPraticien()
        {
            return true;
        }

        public DelegateCommand Medicaments
        {
            get { return _medicaments ?? (_medicaments = new DelegateCommand(RunMedicaments, CanMedicaments)); }
        }
        private DelegateCommand _medicaments;
      

        public async void RunMedicaments()
        {
            NavigationParameters navigationParameters = new NavigationParameters();

            navigationParameters.Add("login", Login);
            await _navigationService.NavigateAsync("MedicamentPage", navigationParameters);
        }

        public virtual bool CanMedicaments()
        {
            return true;
        }


    }
}
