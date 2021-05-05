using Newtonsoft.Json;
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

    public class PraticienViewModel : ViewModelBase
    {
        private readonly HttpClient _client;
        private readonly INavigationService _navigationService;
        public PraticienViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _client = new HttpClient();
            _navigationService = navigationService;
            Title = "Praticien";
        }

        public String PRA_NOM
        {
            get { return _PRA_NOM; }
            set { SetProperty(ref _PRA_NOM, value); }
        }
        private String _PRA_NOM;

        public String PRA_PRENOM
        {
            get { return _PRA_PRENOM; }
            set { SetProperty(ref _PRA_PRENOM, value); }
        }
        private String _PRA_PRENOM;

        public String PRA_ADRESSE
        {
            get { return _PRA_ADRESSE; }
            set { SetProperty(ref _PRA_ADRESSE, value); }
        }
        private String _PRA_ADRESSE;

        public String PRA_CP
        {
            get { return _PRA_CP; }
            set { SetProperty(ref _PRA_CP, value); }
        }
        private String _PRA_CP;

        public String PRA_VILLE
        {
            get { return _PRA_VILLE; }
            set { SetProperty(ref _PRA_VILLE, value); }
        }
        private String _PRA_VILLE;

        public String PRA_COEFNOTORIETE
        {
            get { return _PRA_COEFNOTORIETE; }
            set { SetProperty(ref _PRA_COEFNOTORIETE, value); }
        }
        private String _PRA_COEFNOTORIETE;

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

            Numero = 1;
            getCompteRendu();

            base.OnNavigatedTo(parameters);

        }

        public DelegateCommand PLus
        {
            get { return _pLus ?? (_pLus = new DelegateCommand(RunPLus, CanRunPLus)); }
        }
        private DelegateCommand _pLus;
        public async void RunPLus()
        {
            Numero++;
            getCompteRendu();
        }

        public virtual bool CanRunPLus()
        {
            return true;
        }

        public DelegateCommand Moins
        {
            get { return _moins ?? (_moins = new DelegateCommand(RunMoins, CanRunMoins)); }
        }
        private DelegateCommand _moins;
        public async void RunMoins()
        {
            if (Numero >= 1)
            {
                Numero--;
                getCompteRendu();
            }
        }

        public virtual bool CanRunMoins()
        {
            return true;
        }


        public async void getCompteRendu()
        {

            try
            {
                Uri uri = new Uri("https://api.gsb-france.fr/PraticienbyID.php?id=" + Numero);
                Console.WriteLine("{0} URI", uri);

                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    dynamic dynJson = JsonConvert.DeserializeObject(answer);
                    PRA_NOM = dynJson.PRA_NOM;
                    PRA_PRENOM = dynJson.PRA_PRENOM;
                    PRA_ADRESSE = dynJson.PRA_ADRESSE;
                    PRA_CP = dynJson.PRA_CP;
                    PRA_VILLE = dynJson.PRA_VILLE;
                    PRA_COEFNOTORIETE = dynJson.PRA_COEFNOTORIETE;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR", e);
            }
        }
    }
}
