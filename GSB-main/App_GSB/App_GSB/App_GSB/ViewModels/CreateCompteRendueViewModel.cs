using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace App_GSB.ViewModels
{

    public class CreateCompteRendueViewModel : ViewModelBase
    {
        private readonly HttpClient _client;
        private readonly INavigationService _navigationService;
        public CreateCompteRendueViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _client = new HttpClient();
            _navigationService = navigationService;
            Title = "Comptes Rendues";
        }

        public String Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        private String _login;

        public String Matricule
        {
            get { return _matricule; }
            set { SetProperty(ref _matricule, value); }
        }
        private String _matricule;
        public String RapNum
        {
            get { return _rapnum; }
            set { SetProperty(ref _rapnum, value); }
        }
        private String _rapnum;
        public String PraNum
        {
            get { return _pranum; }
            set { SetProperty(ref _pranum, value); }
        }
        private String _pranum;
        public String RapDate
        {
            get { return _rapdate; }
            set { SetProperty(ref _rapdate, value); }
        }
        private String _rapdate;
        public String RapBilan
        {
            get { return _rapbilan; }
            set { SetProperty(ref _rapbilan, value); }
        }
        private String _rapbilan;
        public String RapMotif
        {
            get { return _rapmotif; }
            set { SetProperty(ref _rapmotif, value); }
        }
        private String _rapmotif;

        

        public String Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }
        private String _answer;
        public int Numero
        {
            get { return _numero; }
            set { SetProperty(ref _numero, value); }
        }
        private int _numero;

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            Login = (string)parameters["login"];

            Numero = 0;

            base.OnNavigatedTo(parameters);

        }


        public DelegateCommand AddCompteRendu
        {
            get { return _addCompteRendu ?? (_addCompteRendu = new DelegateCommand(RunAddCompteRendu, CanAddCompteRendu)); }
        }
        private DelegateCommand _addCompteRendu;

        public async void RunAddCompteRendu()
        {
            try
            {
                Uri uri = new Uri("https://api.gsb-france.fr/createRapport.php?visMat=" + Login + "&praNum=" + PraNum + "&date=" + RapDate + "&bilan=" + RapBilan + "&motif=" + RapMotif);
                Console.WriteLine("{0} URI", uri);

                await _client.GetAsync(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR", e);
            }

            NavigationParameters navigationParameters = new NavigationParameters();

            navigationParameters.Add("login", Login);
            await _navigationService.NavigateAsync("CompteRenduePage", navigationParameters);
        }

        public virtual bool CanAddCompteRendu()
        {
            return true;
        }
    }
}
